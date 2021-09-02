using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Coin_Collector.Model
{
    public class Location
    {
        private static int locationCount;

        public Location()
        {
            locationCount++;
            LocationNumber = locationCount;
        }

        public int LocationNumber { get; set; }

        [JsonIgnore]
        public string LocationString 
        { 
            get => IntLocationToStringLocation(LocationNumber); 
            set => LocationNumber = StringLocationToIntLocation(value); 
        }   

        public static string GetNextLocation()
        {
            return IntLocationToStringLocation(locationCount + 1);
        }

        private static string IntLocationToStringLocation(int location)
        {
            var sb = new StringBuilder();

            sb.Append(location / 20 + 1);
            // Ligne
            switch (location % 20 / 5 + 1)
            {
                case 1:
                    sb.Append("A");
                    break;
                case 2:
                    sb.Append("B");
                    break;
                case 3:
                    sb.Append("C");
                    break;
                case 4:
                    sb.Append("D");
                    break;
                case 0:
                    sb.Append("E");
                    break;
            }
            // Colonne
            switch (location % 20 % 4)
            {
                case 1:
                    sb.Append("A");
                    break;
                case 2:
                    sb.Append("B");
                    break;
                case 3:
                    sb.Append("C");
                    break;
                case 0:
                    sb.Append("D");
                    break;
            }
            return sb.ToString();
        }

        public static bool VerifyValue(string stringLocation)
        {
            if (stringLocation.Length < 3)
                return false;
            if (!char.IsLetter(stringLocation[^1]) || !char.IsLetter(stringLocation[^2]))
                return false;
            if (stringLocation[0] == '0')
                return false;
            foreach (var pageChar in stringLocation[..^2])
            {
                if (!char.IsNumber(pageChar))
                    return false;
            }

            return true;
        }

        private int StringLocationToIntLocation(string location)
        {
            // Page
            int intLocation = (location[0] - 1) * 20;

            // Ligne
            switch (location[1])
            {
                case 'A':
                    intLocation += 0;
                    break;
                case 'B':
                    intLocation += 4;
                    break;
                case 'C':
                    intLocation += 8;
                    break;
                case 'D':
                    intLocation += 12;
                    break;
                case 'E':
                    intLocation += 16;
                    break;
            }
            // Colonne
            switch (location[2])
            {
                case 'A':
                    intLocation += 1;
                    break;
                case 'B':
                    intLocation += 2;
                    break;
                case 'C':
                    intLocation += 3;
                    break;
                case 'D':
                    intLocation += 4;
                    break;
            }
            return intLocation;
        }
    }
}
