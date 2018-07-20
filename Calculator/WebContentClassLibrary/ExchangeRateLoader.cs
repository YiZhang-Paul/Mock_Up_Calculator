using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WebContentClassLibrary {
    public class ExchangeRateLoader : IExchangeRateLoader {

        private const string _saveFile = "ExchangeRate.json";

        private string URL { get; set; }
        private JObject ExchangeRate { get; set; }

        public string Base {

            get {

                if(ExchangeRate == null) {

                    return null;
                }
                //base currency
                return ExchangeRate["base"].ToString();
            }
        }

        public IEnumerable<Tuple<string, decimal>> Rates {

            get {

                if(ExchangeRate == null) {

                    return null;
                }

                var rates = new List<Tuple<string, decimal>>();
                //stores rates as { currencyCode : exchangeRate } key/value pair
                foreach(var pair in JObject.Parse(ExchangeRate["rates"].ToString())) {

                    string type = pair.Key.ToString();
                    decimal rate = decimal.Parse(pair.Value.ToString());
                    rates.Add(new Tuple<string, decimal>(type, rate));
                }

                return rates;
            }
        }

        public ExchangeRateLoader(string url) {

            URL = url;
        }

        public void Load(string key, string[] symbols) {

            var client = new WebClient();
            string apiKey = "?access_key=" + key;
            string symbol = "&symbols=" + string.Join(",", symbols);
            string response;

            try {
                //pulling exchange rate through API call
                response = client.DownloadString(URL + apiKey + symbol);
                ExchangeRate = JObject.Parse(response);
                File.WriteAllText(_saveFile, response);
            }
            catch(WebException) {

                try {
                    //attempting to restore from local save as fallback
                    response = File.ReadAllText(_saveFile);
                    ExchangeRate = JObject.Parse(response);
                }
                catch(Exception) {

                    throw new InvalidDataException("Invalid Data.");
                }
            }
        }
    }
}