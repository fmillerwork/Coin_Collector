using System;
using System.Collections.Generic;
using System.Text;

namespace Coin_Collector.Model
{
    public class Coin
    {
        public string Value { get; set; }
        public string Localisation { get; set; }
        public string Year { get; set; }
        public string Culture { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public CoinState State { get; set; }

        public enum CoinState
        {
            FDC,
            SPL,
            SUP,
            TTB,
            TB,
            B,
            AB,
        }

    }
}
