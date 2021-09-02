using Coin_Collector.Model;
using Coin_Collector.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using static Coin_Collector.Model.Coin;

namespace Coin_Collector.ViewModel
{
    public class CoinViewModel : Observable
    {
        public Coin Model { get; }

        public CoinViewModel(Coin newModel)
        {
            Model = newModel;
        }

        public CoinValue Value
        {
            get => Model.Value;
            set { Model.Value = value; OnPropertyChanged();}
        }

        public CoinYear Year
        {
            get => Model.Year;
            set { Model.Year = value; OnPropertyChanged(); }
        }

        public CoinCulture Culture
        {
            get => Model.Culture;
            set { Model.Culture = value; OnPropertyChanged(); }
        }

        public Location Location
        {
            get => Model.Location;
            set { Model.Location = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get => Model.Description;
            set { Model.Description = value; OnPropertyChanged(); }
        }

        public CoinState State
        {
            get => Model.State;
            set { Model.State = value; OnPropertyChanged(); }
        }

        private Visibility visibility;
        public Visibility Visibility 
        { 
            get => visibility; 
            set => SetProperty(ref visibility, value); 
        }
    }
}
