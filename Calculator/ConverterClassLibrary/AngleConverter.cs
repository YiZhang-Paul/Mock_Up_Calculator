using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterClassLibrary;

namespace ConverterClassLibrary {
    public class AngleConverter : IUnitConverter {

        private Dictionary<string, decimal> Rates { get; set; }

        public AngleConverter() {

            Initialize();
        }

        private void Initialize() {

            Rates = new Dictionary<string, decimal>() {

                { "radians", 1 },
                { "degrees", 1 / (decimal)Math.PI * 180 },
                { "gradians", 1 / 0.0157075m }
            };
        }

        private bool IsSpecialConversion(string current, string target) {

            var units = new HashSet<string>() { "dms", "degrees" };

            return units.Contains(current.ToLower()) && units.Contains(target.ToLower());
        }

        private string GetDecimal(decimal decimals, int padding) {

            if(decimals == 0) {

                return string.Empty.PadRight(padding, '0');
            }

            return decimals.ToString().Substring(2).PadRight(padding, '0');
        }

        private decimal DmsToDegree(decimal dms) {

            decimal integer = Math.Abs(Math.Truncate(dms));
            string decimals = GetDecimal(Math.Abs(dms) - integer, 4);
            decimal minute = decimal.Parse(decimals.Substring(0, 2));
            decimal second = decimal.Parse(decimals.Substring(2, 2));

            return (integer + (minute + second / 60) / 60) * (dms < 0 ? -1 : 1);
        }

        private decimal DegreeToDms(decimal degree) {

            decimal integer = Math.Truncate(degree);
            decimal remain = Math.Abs(degree - integer) * 60;
            decimal minute = Math.Truncate(remain);
            decimal second = Math.Truncate((remain - minute) * 60);

            return decimal.Parse(string.Join("", new string[] {

                integer.ToString() + ".",
                minute.ToString().PadLeft(2, '0'),
                second.ToString().PadLeft(2, '0'),
                GetDecimal((remain - minute) * 60 - second, 4)
            }));
        }

        public decimal Convert(string current, decimal value, string target) {

            if(IsSpecialConversion(current, target)) {

                return current.ToLower() == "dms" ? DmsToDegree(value) : DegreeToDms(value);
            }

            return value / Rates[current.ToLower()] * Rates[target.ToLower()];
        }
    }
}