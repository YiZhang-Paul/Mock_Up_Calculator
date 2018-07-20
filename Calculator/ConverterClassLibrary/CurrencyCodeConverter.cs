using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public class CurrencyCodeConverter : ICurrencyCodeConverter {

        private Dictionary<string, string> ToCurrency { get; set; }
        private Dictionary<string, List<string>> ToCountry { get; set; }

        public CurrencyCodeConverter(string fileName) {

            Initialize(fileName);
        }

        private void AddCurrencyCode(string countryCode, string currencyCode) {

            ToCurrency[countryCode] = currencyCode;
        }

        private void AddCountryCode(string currencyCode, string countryCode) {

            if(!ToCountry.ContainsKey(currencyCode)) {

                ToCountry[currencyCode] = new List<string>();
            }

            ToCountry[currencyCode].Add(countryCode);
        }

        private void RegisterCodes(string record) {

            string[] information = record.Split(',').ToArray();
            string countryCode = information[1];
            string currencyCode = information[3];
            AddCountryCode(currencyCode, countryCode);
            AddCurrencyCode(countryCode, currencyCode);
        }

        private void Initialize(string fileName) {

            ToCurrency = new Dictionary<string, string>();
            ToCountry = new Dictionary<string, List<string>>();

            try {

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                foreach(string line in File.ReadAllLines(path)) {

                    RegisterCodes(line);
                }
            }
            catch(FileNotFoundException exception) {

                throw exception;
            }
        }

        public string ToCurrencyCode(string countryCode) {

            if(!ToCurrency.ContainsKey(countryCode)) {

                throw new InvalidOperationException("Invalid Code.");
            }

            return ToCurrency[countryCode];
        }

        public IEnumerable<string> ToCountryCode(string currencyCode) {

            if(!ToCountry.ContainsKey(currencyCode)) {

                throw new InvalidOperationException("Invalid Code.");
            }

            return ToCountry[currencyCode];
        }
    }
}