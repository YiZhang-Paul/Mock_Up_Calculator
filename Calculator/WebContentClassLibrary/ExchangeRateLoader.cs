using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WebContentClassLibrary {
    public class ExchangeRateLoader : IExchangeRateLoader {

        private const string _url = "http://data.fixer.io/api/latest?access_key=";

        private JObject Response { get; set; }

        public string Base {

            get {

                if(Response == null) {

                    return null;
                }

                return Response["base"].ToString();
            }
        }

        public IEnumerable<Tuple<string, decimal>> Rates {

            get {

                if(Response == null) {

                    return null;
                }

                var rates = new List<Tuple<string, decimal>>();

                foreach(var pair in JObject.Parse(Response["rates"].ToString())) {

                    string currency = pair.Key.ToString();
                    decimal rate = decimal.Parse(pair.Value.ToString());
                    rates.Add(new Tuple<string, decimal>(currency, rate));
                }

                return rates;
            }
        }

        public void Load(string key, string[] symbols) {

            var client = new WebClient();
            string symbol = "&symbols=" + string.Join(",", symbols);
            var responseBody = client.DownloadString(_url + key + symbol);
            Response = JObject.Parse(responseBody);
        }
    }
}