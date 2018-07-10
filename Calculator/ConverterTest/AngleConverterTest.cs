using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class AngleConverterTest {

        AngleConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 9) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            converter = new AngleConverter();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidCurrentUnit() {

            converter.Convert("radian", 5, "degrees");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidTargetUnit() {

            converter.Convert("radians", 5, "degree");
        }

        [TestMethod]
        public void RadianToDegree() {

            Assert.IsTrue(IsAccurate(45, converter.Convert("radians", (decimal)(Math.PI * 0.25), "degrees")));
            Assert.IsTrue(IsAccurate(90, converter.Convert("radians", (decimal)(Math.PI * 0.5), "degrees")));
            Assert.IsTrue(IsAccurate(135, converter.Convert("radians", (decimal)(Math.PI * 0.75), "degrees")));
        }

        [TestMethod]
        public void DegreeToRadian() {

            Assert.IsTrue(IsAccurate((decimal)(Math.PI * 0.25), converter.Convert("degrees", 45, "radians")));
            Assert.IsTrue(IsAccurate((decimal)(Math.PI * 0.5), converter.Convert("degrees", 90, "radians")));
            Assert.IsTrue(IsAccurate((decimal)(Math.PI * 0.75), converter.Convert("degrees", 135, "radians")));
        }

        [TestMethod]
        public void RadianToGradian() {

            Assert.IsTrue(IsAccurate(1, converter.Convert("radians", 0.0157075m, "gradians")));
            Assert.IsTrue(IsAccurate(5, converter.Convert("radians", 0.0785375m, "gradians")));
            Assert.IsTrue(IsAccurate(100, converter.Convert("radians", 1.57075m, "gradians")));
        }

        [TestMethod]
        public void GradianToRadian() {

            Assert.IsTrue(IsAccurate(0.0157075m, converter.Convert("gradians", 1, "radians")));
            Assert.IsTrue(IsAccurate(0.0785375m, converter.Convert("gradians", 5, "radians")));
            Assert.IsTrue(IsAccurate(1.57075m, converter.Convert("gradians", 100, "radians")));
        }

        [TestMethod]
        public void DmsToDegree() {

            Assert.IsTrue(IsAccurate(9, converter.Convert("dms", 9, "degrees")));
            Assert.IsTrue(IsAccurate(3.665m, converter.Convert("dms", 3.3954m, "degrees")));
            Assert.IsTrue(IsAccurate(-6.22354m, converter.Convert("dms", -6.1324744m, "degrees"), 2));
            Assert.IsTrue(IsAccurate(1.016944m, converter.Convert("dms", 1.01009984m, "degrees"), 2));
        }

        [TestMethod]
        public void DegreeToDms() {

            Assert.IsTrue(IsAccurate(9, converter.Convert("degrees", 9, "dms")));
            Assert.IsTrue(IsAccurate(3.3954m, converter.Convert("degrees", 3.665m, "dms")));
            Assert.IsTrue(IsAccurate(-6.1324744m, converter.Convert("degrees", -6.22354m, "dms")));
            Assert.IsTrue(IsAccurate(1.01009984m, converter.Convert("degrees", 1.016944m, "dms")));
        }
    }
}