using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class PressureConverterTest {

        PressureConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 2) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            converter = new PressureConverter();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidCurrentUnit() {

            converter.Convert("bar", 5, "pascals");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidTargetUnit() {

            converter.Convert("bars", 5, "pascal");
        }

        [TestMethod]
        public void BarsToAtmospheres() {

            Assert.IsTrue(IsAccurate(4.934616m, converter.Convert("bars", 5, "atmospheres")));
            Assert.IsTrue(IsAccurate(14.80385m, converter.Convert("bars", 15, "atmospheres")));
            Assert.IsTrue(IsAccurate(0.493462m, converter.Convert("bars", 0.5m, "atmospheres")));
        }

        [TestMethod]
        public void BarsToBars() {

            Assert.AreEqual(5, converter.Convert("bars", 5, "bars"));
            Assert.AreEqual(15, converter.Convert("bars", 15, "bars"));
            Assert.AreEqual(0.5m, converter.Convert("bars", 0.5m, "bars"));
        }

        [TestMethod]
        public void BarsToKilopascals() {

            Assert.IsTrue(IsAccurate(500, converter.Convert("bars", 5, "kilopascals")));
            Assert.IsTrue(IsAccurate(1500, converter.Convert("bars", 15, "kilopascals")));
            Assert.IsTrue(IsAccurate(50, converter.Convert("bars", 0.5m, "kilopascals")));
        }

        [TestMethod]
        public void BarsToMillimetresOfMercury() {

            Assert.IsTrue(IsAccurate(3750.938m, converter.Convert("bars", 5, "millimetres of mercury"), -1));
            Assert.IsTrue(IsAccurate(11252.81m, converter.Convert("bars", 15, "millimetres of mercury"), -1));
            Assert.IsTrue(IsAccurate(375.0938m, converter.Convert("bars", 0.5m, "millimetres of mercury"), -1));
        }

        [TestMethod]
        public void BarsToPascals() {

            Assert.IsTrue(IsAccurate(500000, converter.Convert("bars", 5, "pascals")));
            Assert.IsTrue(IsAccurate(1500000, converter.Convert("bars", 15, "pascals")));
            Assert.IsTrue(IsAccurate(50000, converter.Convert("bars", 0.5m, "pascals")));
        }

        [TestMethod]
        public void BarsToPoundsPerSquareInch() {

            Assert.IsTrue(IsAccurate(72.51887m, converter.Convert("bars", 5, "pounds per square inch")));
            Assert.IsTrue(IsAccurate(217.5566m, converter.Convert("bars", 15, "pounds per square inch")));
            Assert.IsTrue(IsAccurate(7.251887m, converter.Convert("bars", 0.5m, "pounds per square inch")));
        }
    }
}