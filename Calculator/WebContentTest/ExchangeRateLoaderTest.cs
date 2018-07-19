using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebContentClassLibrary;

namespace WebContentTest {
    [TestClass]
    public class ExchangeRateLoaderTest {

        private static ExchangeRateLoader loader;

        [ClassInitialize]
        public static void Setup(TestContext context) {

            loader = new ExchangeRateLoader();
            string key = "9cc79a54b9fd6990022df1b32309c2cf";
            string[] symbols = { "USD", "AUD", "CAD", "PLN", "MXN" };
            loader.Load(key, symbols);
        }

        [TestMethod]
        public void GetBaseBeforeLoad() {

            Assert.IsNull(new ExchangeRateLoader().Base);
        }

        [TestMethod]
        public void GetBaseAfterLoad() {

            Assert.AreEqual("EUR", loader.Base);
        }

        [TestMethod]
        public void GetRatesBeforeLoad() {

            Assert.IsNull(new ExchangeRateLoader().Rates);
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