using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatterClassLibrary;

namespace FormatterTest {
    [TestClass]
    public class EngineeringFormatterTest {

        EngineeringFormatter formatter;

        [TestInitialize]
        public void Setup() {

            formatter = new EngineeringFormatter();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException),
         "Invalid Number.")]
        public void FormatInvalidNumber() {

            formatter.Format("100a012");
        }

        [TestMethod]
        public void FormatNumber() {

            Assert.AreEqual("1.00012e+5", formatter.Format("100012"));
            Assert.AreEqual("1.012e+3", formatter.Format("1012"));
            Assert.AreEqual("-1.012e+3", formatter.Format("-1012"));
            Assert.AreEqual("8.e+0", formatter.Format("8"));
            Assert.AreEqual("-8.e+0", formatter.Format("-8"));
            Assert.AreEqual("8.e+0", formatter.Format("8."));
            Assert.AreEqual("0.e+0", formatter.Format("0"));
            Assert.AreEqual("0.e+0", formatter.Format("0."));
        }
    }
}