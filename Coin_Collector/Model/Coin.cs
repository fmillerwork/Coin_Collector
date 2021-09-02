using System;
using System.Collections.Generic;
using System.Text;

namespace Coin_Collector.Model
{
    public class Coin
    {
        public CoinValue Value { get; set; }
        public CoinYear Year { get; set; }
        public CoinCulture Culture { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public CoinState  State { get; set; }

    }
}
