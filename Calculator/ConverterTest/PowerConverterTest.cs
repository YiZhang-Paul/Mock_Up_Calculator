using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class PowerConverterTest {

        PowerConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 3) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            converter = new PowerConverter();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidCurrentUnit() {

            converter.Convert("watt", 5, "kilowatts");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidTargetUnit() {

            converter.Convert("watts", 5, "kilowatt");
        }

        [TestMethod]
        public void WattsToWatts() {

            Assert.AreEqual(5, converter.Convert("watts", 5, "watts"));
            Assert.AreEqual(15, converter.Convert("watts", 15, "watts"));
            Assert.AreEqual(0.5m, converter.Convert("watts", 0.5m, "watts"));
        }

        [TestMethod]
        public void WattsToKilowatts() {

            Assert.IsTrue(IsAccurate(0.005m, converter.Convert("watts", 5, "kilowatts")));
            Assert.IsTrue(IsAccurate(0.015m, converter.Convert("watts", 15, "kilowatts")));
            Assert.IsTrue(IsAccurate(0.0005m, converter.Convert("watts", 0.5m, "kilowatts")));
        }

        [TestMethod]
        public void WattsToHorsepowerUS() {

            Assert.IsTrue(IsAccurate(0.006705m, converter.Convert("watts", 5, "horsepower (us)")));
            Assert.IsTrue(IsAccurate(0.020115m, converter.Convert("watts", 15, "horsepower (us)")));
            Assert.IsTrue(IsAccurate(0.000671m, converter.Convert("watts", 0.5m, "horsepower (us)")));
        }

        [TestMethod]
        public void WattsToFootPoundsPerMinute() {

            Assert.IsTrue(IsAccurate(221.2686m, converter.Convert("watts", 5, "foot-pounds/minute")));
            Assert.IsTrue(IsAccurate(663.8059m, converter.Convert("watts", 15, "foot-pounds/minute")));
            Assert.IsTrue(IsAccurate(22.12686m, converter.Convert("watts", 0.5m, "foot-pounds/minute")));
        }

        [TestMethod]
        public void FootPoundsPerMinuteToWatts() {

            Assert.IsTrue(IsAccurate(5, converter.Convert("foot-pounds/minute", 221.2686m, "watts"), -1));
            Assert.IsTrue(IsAccurate(15, converter.Convert("foot-pounds/minute", 663.8059m, "watts"), -1));
            Assert.IsTrue(IsAccurate(0.5m, converter.Convert("foot-pounds/minute", 22.12686m, "watts"), -1));
        }

        [TestMethod]
        public void WattsToBTUsPerMinute() {

            Assert.IsTrue(IsAccurate(0.284345m, converter.Convert("watts", 5, "btus/minute")));
            Assert.IsTrue(IsAccurate(0.853035m, converter.Convert("watts", 15, "btus/minute")));
            Assert.IsTrue(IsAccurate(0.028435m, converter.Convert("watts", 0.5m, "btus/minute")));
        }

        [TestMethod]
        public void BTUsPerMinuteToWatts() {

            Assert.IsTrue(IsAccurate(5, converter.Convert("btus/minute", 0.284345m, "watts"), -1));
            Assert.IsTrue(IsAccurate(15, converter.Convert("btus/minute", 0.853035m, "watts"), -1));
            Assert.IsTrue(IsAccurate(0.5m, converter.Convert("btus/minute", 0.028435m, "watts"), -1));
        }

        [TestMethod]
        public void BTUsPerMinuteToFootPoundsPerMinute() {

            Assert.IsTrue(IsAccurate(3890.847m, converter.Convert("btus/minute", 5, "foot-pounds/minute"), -1));
            Assert.IsTrue(IsAccurate(11672.54m, converter.Convert("btus/minute", 15, "foot-pounds/minute"), -1));
            Assert.IsTrue(IsAccurate(389.0847m, converter.Convert("btus/minute", 0.5m, "foot-pounds/minute"), -1));
        }

        [TestMethod]
        public void FootPoundsPerMinuteToBTUsPerMinute() {

            Assert.IsTrue(IsAccurate(5, converter.Convert("foot-pounds/minute", 3890.847m, "btus/minute"), -1));
            Assert.IsTrue(IsAccurate(15, converter.Convert("foot-pounds/minute", 11672.54m, "btus/minute"), -1));
            Assert.IsTrue(IsAccurate(0.5m, converter.Convert("foot-pounds/minute", 389.0847m, "btus/minute"), -1));
        }
    }
}