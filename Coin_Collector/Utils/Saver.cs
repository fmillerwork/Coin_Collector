using Coin_Collector.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Coin_Collector.Utils
{
    public static class Saver
    {
        private const string FILEPATH = "save.json";
        public static void Save(List<Coin> coinList)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize(coinList, options);

            File.WriteAllText(FILEPATH, json);
        }

        public static List<Coin> Load()
        {
            if (File.Exists(FILEPATH))
                return JsonSerializer.Deserialize<List<Coin>>(File.ReadAllText(FILEPATH));
            else
                return new List<Coin>();
        }
    }
}
 