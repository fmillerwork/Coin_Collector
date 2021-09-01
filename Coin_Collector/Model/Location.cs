using System;
using System.Collections.Generic;
using System.Text;

namespace Coin_Collector.Model
{
    public class Location
    {
        public Location()
        {
            locationCount++;
        }
        private static int locationCount;
        public int Page { get; set; }
        private LineLocation VLocation { get; set; }
        private ColumnLocation HLocation { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(locationCount / 20 + 1);
            switch (HLocation)
            {
                case ColumnLocation.A:
                    sb.Append("A");
                    break;
                case ColumnLocation.B:
                    sb.Append("B");
                    break;
                case ColumnLocation.C:
                    sb.Append("C");
                    break;
                case ColumnLocation.D:
                    sb.Append("D");
                    break;
            }
            switch (VLocation)
            {
                case LineLocation.A:
                    sb.Append("A");
                    break;
                case LineLocation.B:
                    sb.Append("B");
                    break;
                case LineLocation.C:
                    sb.Append("C");
                    break;
                case LineLocation.D:
                    sb.Append("D");
                    break;
                case LineLocation.E:
                    sb.Append("E");
                    break;
            }

            return sb.ToString();
        }

        private enum LineLocation
        {
            A,B,C,D,E,F
        }
        private enum ColumnLocation
        {
            A, B, C, D, E
        }
    }
}
