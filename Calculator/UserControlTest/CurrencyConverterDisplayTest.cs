using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class CurrencyConverterDisplayTest {

        CurrencyConverterDisplay display;
        Mock<IFormatter> formatter;

        private string GetSymbol(string country) {

            var region = new RegionInfo(country);

            return region.CurrencySymbol;
        }

        [TestInitialize]
        public void Setup() {

            display = new CurrencyConverterDisplay();
            formatter = new Mock<IFormatter>();
            formatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5,512");
        }

        [TestMethod]
        public void PopulateOptions() {

            display.PopulateOptions(new string[] { "USD", "CNY" });

            Assert.AreEqual("USD", display.InputUnit);
            Assert.AreEqual("CNY", display.MainOutputUnit);

            display.PopulateOptions(new string[] { "USD", "BOB", "CNY" });

            Assert.AreEqual("USD", display.InputUnit);
            Assert.AreEqual("BOB", display.MainOutputUnit);
        }

        [TestMethod]
        public void DisplayInput() {

            display.PopulateOptions(new string[] { "USD", "CNY" });

            Assert.AreEqual(GetSymbol("US") + " 0", display.InputValue);

            display.DisplayInput("5512", formatter.Object);

            Assert.AreEqual(GetSymbol("US") + " 5,512", display.InputValue);
        }

        [TestMethod]
        public void DisplayMainOutput() {

            display.PopulateOptions(new string[] { "USD", "CNY" });

            Assert.AreEqual(GetSymbol("CN") + " 0", display.MainOutputValue);

            display.DisplayMainOutput("5512", formatter.Object);

            Assert.AreEqual(GetSymbol("CN") + " 5,512", display.MainOutputValue);
        }

        [TestMethod]
        public void DisplayMaximumNumberOfExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "USD"),
                new Tuple<string, string>("5512", "CNY")
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual(GetSymbol("US") + " 5,512", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual(GetSymbol("CN") + " 5,512", display.ExtraOutputLabels[1].Text);
        }

        [TestMethod]
        public void DisplayFewerExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "USD"),
                null
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual(GetSymbol("US") + " 5,512", display.ExtraOutputLabels[0].Text);
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

            Assert.AreEqual(GetSymbol("US") + " 5,512", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual(GetSymbol("BO") + " 5,512", display.ExtraOutputLabels[1].Text);
        }
    }
}