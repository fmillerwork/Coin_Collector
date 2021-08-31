using Coin_Collector.Model;
using Coin_Collector.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using static Coin_Collector.Model.Coin;

namespace Coin_Collector.ViewModel
{
    public class CoinViewModel : Observable
    {
        private Coin _model;

        public CoinViewModel(Coin model)
        {
            _model = model;
        }

        public string Value
        {
            get => _model.Value;
            set { _model.Value = value; OnPropertyChanged();}
        }

        public string Year
        {
            get => _model.Year;
            set { _model.Year = value; OnPropertyChanged(); }
        }

        public string Culture
        {
            get => _model.Culture;
            set { _model.Culture = value; OnPropertyChanged(); }
        }

        public string Localisation
        {
            get => _model.Localisation;
            set { _model.Localisation = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get => _model.Description;
            set { _model.Description = value; OnPropertyChanged(); }
        }
        //public string State
        //{
        //    get => _model.State;
        //    set { _model.State = value; OnPropertyChanged(); }
        //}


    }
}
