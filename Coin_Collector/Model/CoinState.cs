using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Coin_Collector.Model
{
    public class CoinState
    {
        public string State { get; set; }

        [JsonIgnore]
        public string StateDescription { get; set; }
    }
}
