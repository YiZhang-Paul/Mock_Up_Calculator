using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class UnitConverterTest {

        UnitConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 9) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            converter = new UnitConverter();
        }

        [TestMethod]
        public void RadianToDegree() {

            Assert.IsTrue(IsAccurate(45, converter.RadianToDegree((decimal)(Math.PI * 0.25))));
            Assert.IsTrue(IsAccurate(90, converter.RadianToDegree((decimal)(Math.PI * 0.5))));
            Assert.IsTrue(IsAccurate(135, converter.RadianToDegree((decimal)(Math.PI * 0.75))));
        }

        [TestMethod]
        public void DegreeToRadian() {

            Assert.IsTrue(IsAccurate((decimal)(Math.PI * 0.25), converter.DegreeToRadian(45)));
            Assert.IsTrue(IsAccurate((decimal)(Math.PI * 0.5), converter.DegreeToRadian(90)));
            Assert.IsTrue(IsAccurate((decimal)(Math.PI * 0.75), converter.DegreeToRadian(135)));
        }

        [TestMethod]
        public void RadianToGradian() {

            Assert.IsTrue(IsAccurate(1, converter.RadianToGradian(0.0157075m)));
            Assert.IsTrue(IsAccurate(5, converter.RadianToGradian(0.0785375m)));
            Assert.IsTrue(IsAccurate(100, converter.RadianToGradian(1.57075m)));
        }

        [TestMethod]
        public void GradianToRadian() {

            Assert.IsTrue(IsAccurate(0.0157075m, converter.GradianToRadian(1)));
            Assert.IsTrue(IsAccurate(0.0785375m, converter.GradianToRadian(5)));
            Assert.IsTrue(IsAccurate(1.57075m, converter.GradianToRadian(100)));
        }

        [TestMethod]
        public void DmsToDegree() {

            Assert.IsTrue(IsAccurate(9, converter.DmsToDegree(9)));
            Assert.IsTrue(IsAccurate(3.665m, converter.DmsToDegree(3.3954m)));
            Assert.IsTrue(IsAccurate(-6.22354m, converter.DmsToDegree(-6.1324744m), 2));
            Assert.IsTrue(IsAccurate(1.016944m, converter.DmsToDegree(1.01009984m), 2));
        }

        [TestMethod]
        public void DegreeToDms() {

            Assert.IsTrue(IsAccurate(9, converter.DegreeToDms(9)));
            Assert.IsTrue(IsAccurate(3.3954m, converter.DegreeToDms(3.665m)));
            Assert.IsTrue(IsAccurate(-6.1324744m, converter.DegreeToDms(-6.22354m)));
            Assert.IsTrue(IsAccurate(1.01009984m, converter.DegreeToDms(1.016944m)));
        }
    }
}