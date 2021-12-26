using Coin_Collector.Model;
using Coin_Collector.Utils;
using Coin_Collector.View;
using Coin_Collector.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coin_Collector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewCoinWindow newCoinWindow;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {

            if (((MainViewModel)DataContext).SelectedCoin == null || Location.VerifyValue(LocationTxtBox.Text))
            {
                Saver.Save(((MainViewModel)DataContext).GetCoinModels());
                MessageBox.Show("Sauvegarde effectuée");
            }
            else
                MessageBox.Show("Veuilliez vérifier les informations dans le champs Localisation !", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void RemoveCoin_Click(object sender, RoutedEventArgs e)
        {
            var context = (MainViewModel)DataContext;
            if (MessageBox.Show("Supprimer la monnaie ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            { 
                context.RemoveCoin();
            }
        }
        
        private void RemoveCoin_ListClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn)
            {
                if (MessageBox.Show("Supprimer la monnaie ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    ((MainViewModel)DataContext).RemoveCoin((CoinViewModel)btn.DataContext);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var value = (CoinValue)SearchValueCB.SelectedItem;
            var year = (CoinYear)SearchYearCB.SelectedItem;
            var culture = (CoinCulture)SearchCultureCB.SelectedItem;
            var location = SearchLocationTxtBox.Text;
            var description = SearchDescriptionTxtBox.Text;
            ((MainViewModel)DataContext).ApplySearchFilter(value, year, culture, location, description);
        }

        private void NewCoin_Click(object sender, RoutedEventArgs e)
        {
            if (!NewCoinWindow.IsDisplayed)
            {
                newCoinWindow = new NewCoinWindow()
                {
                    DataContext = DataContext
                };
                newCoinWindow.Show();
            }
        }

        private void ResetSearch_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            ((MainViewModel)DataContext).ResetCoinsVisibility();

            SearchValueCB.SelectedItem = null;
            SearchYearCB.SelectedItem = null;
            SearchCultureCB.SelectedItem = null;
            SearchStateCB.SelectedItem = null;
            SearchDescriptionTxtBox.Text = Globals.DESCRIPTION_DEFAULT_TEXT;
            SearchLocationTxtBox.Text = Globals.LOCATION_DEFAULT_TEXT;
        }


        #region Focus Event
        private void SearchLocation_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchLocationTxtBox.Text == Globals.LOCATION_DEFAULT_TEXT)
            {
                SearchLocationTxtBox.Text = "";
                SearchLocationTxtBox.Foreground = Brushes.Black;
            }
        }

        private void SearchLocation_LostFocus(object sender, RoutedEventArgs e)
        {
            if(SearchLocationTxtBox.Text == "")
            {
                SearchLocationTxtBox.Text = Globals.LOCATION_DEFAULT_TEXT;
                SearchLocationTxtBox.Foreground = Brushes.Gray;
            }
        }
        
        private void SearchDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchDescriptionTxtBox.Text == Globals.DESCRIPTION_DEFAULT_TEXT)
            {
                SearchDescriptionTxtBox.Text = "";
                SearchDescriptionTxtBox.Foreground = Brushes.Black;
            }
        }

        private void SearchDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if(SearchDescriptionTxtBox.Text == "")
            {
                SearchDescriptionTxtBox.Text = Globals.DESCRIPTION_DEFAULT_TEXT;
                SearchDescriptionTxtBox.Foreground = Brushes.Gray;
            }
        }
        #endregion
    }
}
