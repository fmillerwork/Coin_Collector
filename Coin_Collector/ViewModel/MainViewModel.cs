using Coin_Collector.Model;
using Coin_Collector.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;

namespace Coin_Collector.ViewModel
{
    public class MainViewModel : Observable
    {
        public ObservableCollection<CoinViewModel> Coins { get; set; }
        public ObservableCollection<CoinValue> CoinValues { get; }
        public ObservableCollection<CoinYear> CoinYears { get; }
        public ObservableCollection<CoinCulture> CoinCultures { get; }
        public ObservableCollection<CoinState> CoinStates { get; }
        public string CoinStatesDescription { get; }

        public MainViewModel()
        {
            Coins = new ObservableCollection<CoinViewModel>();

            #region Init Combobox
            CoinValues = new ObservableCollection<CoinValue>()
            {
                new CoinValue() { Value = "2.00€" },
                new CoinValue() { Value = "1.00€" },
                new CoinValue() { Value = "0.50€" },
                new CoinValue() { Value = "0.20€" },
                new CoinValue() { Value = "0.10€" },
                new CoinValue() { Value = "0.05€" },
                new CoinValue() { Value = "0.02€" },
                new CoinValue() { Value = "0.01€" }
            };

            CoinYears = new ObservableCollection<CoinYear>()
            {
                new CoinYear() { Year = "2021"},
                new CoinYear() { Year = "2020"},
                new CoinYear() { Year = "2019"},
                new CoinYear() { Year = "2018"},
                new CoinYear() { Year = "2017"},
                new CoinYear() { Year = "2016"},
                new CoinYear() { Year = "2015"},
                new CoinYear() { Year = "2014"},
                new CoinYear() { Year = "2013"},
                new CoinYear() { Year = "2012"},
                new CoinYear() { Year = "2011"},
                new CoinYear() { Year = "2010"},
                new CoinYear() { Year = "2009"},
                new CoinYear() { Year = "2008"},
                new CoinYear() { Year = "2007"},
                new CoinYear() { Year = "2005"},
                new CoinYear() { Year = "2004"},
                new CoinYear() { Year = "2003"},
                new CoinYear() { Year = "2002"}
            };

            CoinCultures = new ObservableCollection<CoinCulture>()
            {
                new CoinCulture() { Culture = "Allemagne"},
                new CoinCulture() { Culture = "Andorre"},
                new CoinCulture() { Culture = "Autriche"},
                new CoinCulture() { Culture = "Belgique" },
                new CoinCulture() { Culture = "Chypre" },
                new CoinCulture() { Culture = "Estonie" },
                new CoinCulture() { Culture = "Espagne" },
                new CoinCulture() { Culture = "Finlande" },
                new CoinCulture() { Culture = "France" },
                new CoinCulture() { Culture = "Grèce" },
                new CoinCulture() { Culture = "Italie" },
                new CoinCulture() { Culture = "Irlande" },
                new CoinCulture() { Culture = "Lettonie" },
                new CoinCulture() { Culture = "Lituanie" },
                new CoinCulture() { Culture = "Luxembourg" },
                new CoinCulture() { Culture = "Malte" },
                new CoinCulture() { Culture = "Monaco" },
                new CoinCulture() { Culture = "Pays-Bas" },
                new CoinCulture() { Culture = "Portugal" },
                new CoinCulture() { Culture = "Saint-Marin" },
                new CoinCulture() { Culture = "Slovaquie" },
                new CoinCulture() { Culture = "Slovénie" },
                new CoinCulture() { Culture = "Vatican" },
            };

            CoinStates = new ObservableCollection<CoinState>()
            {
                new CoinState() 
                { 
                    State = "FDC"
                },
                new CoinState() 
                { 
                    State = "SPL"
                },
                new CoinState() 
                { 
                    State = "SUP"
                },
                new CoinState() 
                { 
                    State = "TTB"
                },
                new CoinState() 
                { 
                    State = "TB"
                },
                new CoinState() 
                { 
                    State = "B"
                },
                new CoinState() 
                {
                    State = "AB"
                },
            };
            #endregion

            foreach (Coin coin in Saver.Load())
            {
                var coinVM = new CoinViewModel(coin) 
                { 
                    Value   = CoinValues.AsQueryable().Where(x => x.Value == coin.Value.Value).First(),
                    Year    = CoinYears.AsQueryable().Where(x => x.Year == coin.Year.Year).First(),
                    Culture = CoinCultures.AsQueryable().Where(x => x.Culture == coin.Culture.Culture).First(),
                    State   = CoinStates.AsQueryable().Where(x => x.State == coin.State.State).First(),
                };

                Coins.Add(coinVM);
            }

            
        }

        private CoinViewModel selectedCoin;
        public CoinViewModel SelectedCoin
        {
            get => selectedCoin;
            set { SetProperty(ref selectedCoin, value); OnPropertyChanged("CBIsEnabled"); }
        }

        public bool CBIsEnabled
        {
            get => SelectedCoin != null;
        }

        public string ComboBoxToolTip { get => Globals.STATES_TOOLTIP; }

        public void AddCoin(CoinValue value, CoinYear year, CoinCulture culture, string description, CoinState state)
        {
            var model = new Coin()
            {
                Value = value,
                Year = year ,
                Culture = culture ,
                Description = description,
                State = state ,
                Location = new Location()
            };
            Coins.Add(new CoinViewModel(model));
        }

        public string NextLocation
        {
            get => Location.GetNextLocation();
        }

        public List<Coin> GetCoinModels()
        {
            var coins = new List<Coin>();
            foreach (var coinVM in Coins)
            {
                coins.Add(coinVM.Model);
            }
            return coins;
        }

        public void RemoveCoin(CoinViewModel coinVM = null)
        {
            if (coinVM == null)
                Coins.Remove(SelectedCoin);
            else
                Coins.Remove(coinVM);
        }

        public void ResetCoinsVisibility()
        {
            foreach(var coinVM in Coins)
            {
                coinVM.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public void ApplySearchFilter(CoinValue value, CoinYear year, CoinCulture culture, string location)
        {
            foreach (var coinViewModel in Coins)
                coinViewModel.Visibility = System.Windows.Visibility.Collapsed;

            List<CoinViewModel> matchingCoins = Coins.ToList();
            if (value != null)
            {
                matchingCoins = matchingCoins.AsQueryable().Where(x => x.Value == value).ToList();
            }
            if (year != null)
            {
                matchingCoins = matchingCoins.AsQueryable().Where(x => x.Year == year).ToList();
            }
            if (culture != null)
            {
                matchingCoins = matchingCoins.AsQueryable().Where(x => x.Culture == culture).ToList();
            }
            if (!string.IsNullOrEmpty(location) && location != Globals.LOCATION_DEFAULT_TEXT)
            {
                matchingCoins = matchingCoins.AsQueryable().Where(x => x.Location.LocationString == location).ToList();
            }

            foreach (var coinViewModel in matchingCoins)
                coinViewModel.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
