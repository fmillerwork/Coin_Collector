using Coin_Collector.Model;
using Coin_Collector.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Coin_Collector.ViewModel
{
    public class MainViewModel : Observable
    {
        public ObservableCollection<CoinViewModel> Coins { get; set; }

        public MainViewModel()
        {
            Coins = new ObservableCollection<CoinViewModel>();
            foreach (Coin coin in Saver.Load())
            {
                Coins.Add(new CoinViewModel(coin));
            }
        }

        private CoinViewModel selectedCoin;
        public CoinViewModel SelectedCoin
        {
            get => selectedCoin;
            set => SetProperty(ref selectedCoin, value);
        }

        public void AddCoin(string value, string year, string culture, string description, string state)
        {
            var model = new Coin()
            {
                Value = value,
                Year = year,
                Culture = culture,
                Description = description,
                State = state
            };
            Coins.Add(new CoinViewModel(model));
        }
    }
}
