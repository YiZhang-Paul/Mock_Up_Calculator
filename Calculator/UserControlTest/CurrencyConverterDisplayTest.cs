using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using ConverterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class CurrencyConverterDisplayTest {

        Mock<IFormatter> formatter;
        Mock<ICurrencyCodeConverter> converter;
        CurrencyConverterDisplay display;

        private string GetSymbol(string countryCode) {

            var region = new RegionInfo(countryCode);

            return region.CurrencySymbol;
        }

        [TestInitialize]
        public void Setup() {

            formatter = new Mock<IFormatter>();
            formatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5,512");

            var countryCodes = new Dictionary<string, string[]>() {

                { "USD", new string[] { "US" } },
                { "CNY", new string[] { "CN" } },
                { "BOB", new string[] { "BO" } }
            };

            var currencyCodes = new Dictionary<string, string>() {

                { "US", "USD" },
                { "CN", "CNY" },
                { "BO", "BOB" }
            };

            converter = new Mock<ICurrencyCodeConverter>();
            converter.Setup(x => x.ToCountryCode(It.IsAny<string>()))
                     .Returns<string>(code => countryCodes[code]);
            converter.Setup(x => x.ToCurrencyCode(It.IsAny<string>()))
                     .Returns<string>(code => currencyCodes[code]);

            display = new CurrencyConverterDisplay(converter.Object);
        }

        [TestMethod]
        public void PopulateOptions() {

            display.PopulateOptions(new string[] { "USD", "CNY" });

            Assert.AreEqual("CNY", display.InputUnit);
            Assert.AreEqual("USD", display.MainOutputUnit);

            display.PopulateOptions(new string[] { "USD", "BOB", "CNY" });

            Assert.AreEqual("BOB", display.InputUnit);
            Assert.AreEqual("CNY", display.MainOutputUnit);
        }

        [TestMethod]
        public void DisplayInput() {

            display.PopulateOptions(new string[] { "USD", "CNY" });
            display.DisplayInput("5512", formatter.Object);

            Assert.AreEqual(GetSymbol("CN") + " 5,512", display.InputValue);
        }

        [TestMethod]
        public void DisplayMainOutput() {

            display.PopulateOptions(new string[] { "USD", "CNY" });
            display.DisplayMainOutput("5512", formatter.Object);

            Assert.AreEqual(GetSymbol("US") + " 5,512", display.MainOutputValue);
        }

        [TestMethod]
        public void DisplayMaximumNumberOfExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "USD"),
                new Tuple<string, string>("5512", "CNY")
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual("USD 5,512", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual("CNY 5,512", display.ExtraOutputLabels[1].Text);
        }

        [TestMethod]
        public void DisplayFewerExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "USD"),
                null
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual("USD 5,512", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual(string.Empty, display.ExtraOutputLabels[1].Text);
        }

        [TestMethod]
        public void DisplayMoreExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "USD"),
                new Tuple<string, string>("5512", "BOB"),
                new Tuple<string, string>("5512", "CNY")
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual("USD 5,512", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual("BOB 5,512", display.ExtraOutputLabels[1].Text);
        }
    }
}