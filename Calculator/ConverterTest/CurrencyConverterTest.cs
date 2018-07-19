using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;
using WebContentClassLibrary;
using Moq;

namespace ConverterTest {
    [TestClass]
    public class CurrencyConverterTest {

        Mock<IExchangeRateLoader> loader;
        CurrencyConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 9) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            var rates = new List<Tuple<string, decimal>>() {

                new Tuple<string, decimal>("EUR", 1),
                new Tuple<string, decimal>("USD", 1.5m),
                new Tuple<string, decimal>("AUD", 2),
                new Tuple<string, decimal>("CAD", 3)
            };

            loader = new Mock<IExchangeRateLoader>();
            loader.Setup(x => x.Base).Returns("EUR");
            loader.Setup(x => x.Rates).Returns(rates);

            converter = new CurrencyConverter(loader.Object);
        }

        [TestMethod]
        public void EURToEUR() {

            Assert.AreEqual(5, converter.Convert("EUR", 5, "EUR"));
            Assert.AreEqual(15, converter.Convert("EUR", 15, "EUR"));
            Assert.AreEqual(0.5m, converter.Convert("EUR", 0.5m, "EUR"));
        }

        [TestMethod]
        public void EURToUSD() {

            Assert.AreEqual(7.5m, converter.Convert("EUR", 5, "USD"));
            Assert.AreEqual(22.5m, converter.Convert("EUR", 15, "USD"));
            Assert.AreEqual(0.75m, converter.Convert("EUR", 0.5m, "USD"));
        }

        [TestMethod]
        public void USDToEUR() {

            Assert.IsTrue(IsAccurate(5, converter.Convert("USD", 7.5m, "EUR"), -1));
            Assert.IsTrue(IsAccurate(15, converter.Convert("USD", 22.5m, "EUR"), -1));
            Assert.IsTrue(IsAccurate(0.5m, converter.Convert("USD", 0.75m, "EUR"), -1));
        }

        [TestMethod]
        public void EURToAUD() {

            Assert.AreEqual(10, converter.Convert("EUR", 5, "AUD"));
            Assert.AreEqual(30, converter.Convert("EUR", 15, "AUD"));
            Assert.AreEqual(1, converter.Convert("EUR", 0.5m, "AUD"));
        }

        [TestMethod]
        public void EURToCAD() {

            Assert.AreEqual(15, converter.Convert("EUR", 5, "CAD"));
            Assert.AreEqual(45, converter.Convert("EUR", 15, "CAD"));
            Assert.AreEqual(1.5m, converter.Convert("EUR", 0.5m, "CAD"));
        }

        [TestMethod]
        public void USDToCAD() {

            Assert.AreEqual(10, converter.Convert("USD", 5, "CAD"));
            Assert.AreEqual(30, converter.Convert("USD", 15, "CAD"));
            Assert.AreEqual(1, converter.Convert("USD", 0.5m, "CAD"));
        }

        [TestMethod]
        public void CADToUSD() {

            Assert.AreEqual(5, converter.Convert("CAD", 10, "USD"));
            Assert.AreEqual(15, converter.Convert("CAD", 30, "USD"));
            Assert.AreEqual(0.5m, converter.Convert("CAD", 1, "USD"));
        }
    }
}