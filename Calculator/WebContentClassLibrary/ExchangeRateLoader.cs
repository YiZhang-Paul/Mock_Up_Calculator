using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WebContentClassLibrary {
    public class ExchangeRateLoader : IExchangeRateLoader {

        private string URL { get; set; }
        private JObject ExchangeRate { get; set; }

        public string Base {

            get {

                if(ExchangeRate == null) {

                    return null;
                }

                return ExchangeRate["base"].ToString();
            }
        }

        public IEnumerable<Tuple<string, decimal>> Rates {

            get {

                if(ExchangeRate == null) {

                    return null;
                }

                var rates = new List<Tuple<string, decimal>>();

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
            var responseBody = client.DownloadString(URL + apiKey + symbol);
            ExchangeRate = JObject.Parse(responseBody);
        }
    }
}