using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebContentClassLibrary;

namespace ConverterClassLibrary {
    public class CurrencyConverter : IUnitConverter {

        private IExchangeRateLoader Loader { get; set; }
        private Dictionary<string, decimal> Rates { get; set; }

        public CurrencyConverter(IExchangeRateLoader loader) {

            Loader = loader;
            Initialize();
        }

        private void Initialize() {

            Rates = new Dictionary<string, decimal>();

            foreach(var rate in Loader.Rates) {

                Rates[rate.Item1.ToLower()] = rate.Item2;
            }
        }

        public decimal Convert(string current, decimal value, string target) {

            return Rates[target.ToLower()] / Rates[current.ToLower()] * value;
        }
    }
}