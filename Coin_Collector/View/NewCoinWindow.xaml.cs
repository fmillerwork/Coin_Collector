using Coin_Collector.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coin_Collector.View
{
    /// <summary>
    /// Logique d'interaction pour NewCoinWindow.xaml
    /// </summary>
    public partial class NewCoinWindow : Window
    {
        public static bool IsDisplayed { get; set; }

        public NewCoinWindow()
        {
            InitializeComponent();
            IsDisplayed = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsDisplayed = false;
        }

        private void AddCoin_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).AddCoin(ValueCB.Text, YearCB.Text, CultureCB.Text, DescriptionTxtBox.Text, StateCB.Text);
        }
    }
}
