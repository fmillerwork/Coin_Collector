using System;
using System.Collections.Generic;
using System.Text;

namespace Coin_Collector.Model
{
    public class Coin
    {
        public string Value { get; set; }
        public string Year { get; set; }
        public string Culture { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }

        public string State { get; set; }

    }
}
