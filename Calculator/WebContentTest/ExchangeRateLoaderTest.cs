using System;
using System.Linq;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebContentClassLibrary;

namespace WebContentTest {
    [TestClass]
    public class ExchangeRateLoaderTest {

        private static string _url = ConfigurationManager.AppSettings["exchangeRateAPIURL"];
        private static string _key = ConfigurationManager.AppSettings["exchangeRateAPIKey"];
        private static ExchangeRateLoader loader;

        [ClassInitialize]
        public static void Setup(TestContext context) {

            loader = new ExchangeRateLoader(_url);
            string[] symbols = { "USD", "AUD", "CAD", "PLN", "MXN" };
            loader.Load(_key, symbols);
        }

        [TestMethod]
        public void GetBaseBeforeLoad() {

            Assert.IsNull(new ExchangeRateLoader(_url).Base);
        }

        [TestMethod]
        public void GetBaseAfterLoad() {

            Assert.AreEqual("EUR", loader.Base);
        }

        [TestMethod]
        public void GetRatesBeforeLoad() {

            Assert.IsNull(new ExchangeRateLoader(_url).Rates);
        }

        [TestMethod]
        public void GetRatesAfterLoad() {

            var rates = loader.Rates.ToArray();
            Assert.AreEqual(5, rates.Length);
            Assert.AreEqual("USD", rates[0].Item1);
            Assert.AreEqual("AUD", rates[1].Item1);
            Assert.AreEqual("CAD", rates[2].Item1);
            Assert.AreEqual("PLN", rates[3].Item1);
            Assert.AreEqual("MXN", rates[4].Item1);
        }
    }
}