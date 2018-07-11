using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class TimeConverterTest {

        TimeConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 9) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            converter = new TimeConverter();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidCurrentUnit() {

            converter.Convert("h", 5, "years");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidTargetUnit() {

            converter.Convert("y", 5, "hours");
        }

        [TestMethod]
        public void HoursToHours() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "hours")));
            Assert.IsTrue(IsAccurate(5, converter.Convert("hours", 5, "hours")));
            Assert.IsTrue(IsAccurate(130, converter.Convert("hours", 130, "hours")));
        }

        [TestMethod]
        public void HoursToMicroseconds() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "microseconds")));
            Assert.IsTrue(IsAccurate(18000000000, converter.Convert("hours", 5, "microseconds")));
            Assert.IsTrue(IsAccurate(468000000000, converter.Convert("hours", 130, "microseconds")));
        }

        [TestMethod]
        public void HoursToMilliseconds() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "milliseconds")));
            Assert.IsTrue(IsAccurate(18000000, converter.Convert("hours", 5, "milliseconds")));
            Assert.IsTrue(IsAccurate(468000000, converter.Convert("hours", 130, "milliseconds")));
        }

        [TestMethod]
        public void HoursToSeconds() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "seconds")));
            Assert.IsTrue(IsAccurate(18000, converter.Convert("hours", 5, "seconds")));
            Assert.IsTrue(IsAccurate(468000, converter.Convert("hours", 130, "seconds")));
        }

        [TestMethod]
        public void HoursToMinutes() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "minutes")));
            Assert.IsTrue(IsAccurate(300, converter.Convert("hours", 5, "minutes")));
            Assert.IsTrue(IsAccurate(7800, converter.Convert("hours", 130, "minutes")));
        }

        [TestMethod]
        public void HoursToDays() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "days")));
            Assert.IsTrue(IsAccurate(0.208m, converter.Convert("hours", 5, "days"), 2));
            Assert.IsTrue(IsAccurate(5.417m, converter.Convert("hours", 130, "days"), 2));
        }

        [TestMethod]
        public void HoursToWeeks() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "weeks")));
            Assert.IsTrue(IsAccurate(0.03m, converter.Convert("hours", 5, "weeks"), 2));
            Assert.IsTrue(IsAccurate(0.774m, converter.Convert("hours", 130, "weeks"), 2));
        }

        [TestMethod]
        public void HoursToYears() {

            Assert.IsTrue(IsAccurate(0, converter.Convert("hours", 0, "years")));
            Assert.IsTrue(IsAccurate(0.001m, converter.Convert("hours", 5, "years"), 2));
            Assert.IsTrue(IsAccurate(0.015m, converter.Convert("hours", 130, "years"), 2));
        }
    }
}