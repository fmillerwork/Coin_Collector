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
            // TODO
        }

        private void RemoveCoin_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void NewCoin_Click(object sender, RoutedEventArgs e)
        {
            if (!NewCoinWindow.IsDisplayed)
            {
                newCoinWindow = new NewCoinWindow();
                newCoinWindow.Show();
            }
        }





    }
}
