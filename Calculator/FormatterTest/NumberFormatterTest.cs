using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatterClassLibrary;

namespace FormatterTest {
    [TestClass]
    public class NumberFormatterTest {

        NumberFormatter formatter;

        [TestInitialize]
        public void Setup() {

            formatter = new NumberFormatter();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
         "Invalid Number.")]
        public void FormatNullInput() {

            formatter.Format(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException),
         "Invalid Number.")]
        public void FormatEmptyInput() {

            formatter.Format(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException),
         "Invalid Number.")]
        public void FormatInvalidNumber() {

            formatter.Format("1000a120");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Number.")]
        public void FormatLargeNumber() {

            formatter.Format(decimal.MaxValue.ToString() + "9");
        }

        [TestMethod]
        public void FormatInteger() {

            Assert.AreEqual("1,000,120", formatter.Format("1000120"));
            Assert.AreEqual("-1,000,120", formatter.Format("-1000120"));
            Assert.AreEqual("1,990", formatter.Format("1990"));
            Assert.AreEqual("990", formatter.Format("990"));
            Assert.AreEqual("-0", formatter.Format("-0"));
            Assert.AreEqual("0", formatter.Format("0"));
        }

        [TestMethod]
        public void FormatDecimal() {

            Assert.AreEqual("1,000,120.0012", formatter.Format("1000120.0012"));
            Assert.AreEqual("-1,000,120.0012", formatter.Format("-1000120.0012"));
            Assert.AreEqual("1,990.01", formatter.Format("1990.01"));
            Assert.AreEqual("990.88", formatter.Format("990.88"));
            Assert.AreEqual("-0.1", formatter.Format("-0.1"));
            Assert.AreEqual("0.1", formatter.Format("0.1"));
        }

        [TestMethod]
        public void KeepDecimalPoint() {

            Assert.AreEqual("1,000,120.", formatter.Format("1000120."));
            Assert.AreEqual("-1,000,120.", formatter.Format("-1000120."));
            Assert.AreEqual("1,990.", formatter.Format("1990."));
            Assert.AreEqual("990.", formatter.Format("990."));
            Assert.AreEqual("-0.", formatter.Format("-0."));
            Assert.AreEqual("0.", formatter.Format("0."));
        }
    }
}