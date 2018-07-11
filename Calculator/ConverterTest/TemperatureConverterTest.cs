using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class TemperatureConverterTest {

        TemperatureConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 9) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            converter = new TemperatureConverter();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidCurrentUnit() {

            converter.Convert("f", 5, "celsius");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidTargetUnit() {

            converter.Convert("fahrenheit", 5, "c");
        }

        [TestMethod]
        public void FahrenheitToFahrenheit() {

            Assert.IsTrue(IsAccurate(5, converter.Convert("fahrenheit", 5, "fahrenheit")));
            Assert.IsTrue(IsAccurate(0, converter.Convert("fahrenheit", 0, "fahrenheit")));
            Assert.IsTrue(IsAccurate(130, converter.Convert("fahrenheit", 130, "fahrenheit")));
        }

        [TestMethod]
        public void FahrenheitToCelsius() {

            Assert.IsTrue(IsAccurate(-15, converter.Convert("fahrenheit", 5, "celsius"), 2));
            Assert.IsTrue(IsAccurate(-17.778m, converter.Convert("fahrenheit", 0, "celsius"), 2));
            Assert.IsTrue(IsAccurate(54.444m, converter.Convert("fahrenheit", 130, "celsius"), 2));
        }

        [TestMethod]
        public void FahrenheitToKelvin() {

            Assert.IsTrue(IsAccurate(258.15m, converter.Convert("fahrenheit", 5, "kelvin"), 2));
            Assert.IsTrue(IsAccurate(255.372m, converter.Convert("fahrenheit", 0, "kelvin"), 2));
            Assert.IsTrue(IsAccurate(327.594m, converter.Convert("fahrenheit", 130, "kelvin"), 2));
        }

        [TestMethod]
        public void CelsiusToCelsius() {

            Assert.IsTrue(IsAccurate(5, converter.Convert("celsius", 5, "celsius")));
            Assert.IsTrue(IsAccurate(0, converter.Convert("celsius", 0, "celsius")));
            Assert.IsTrue(IsAccurate(130, converter.Convert("celsius", 130, "celsius")));
        }

        [TestMethod]
        public void CelsiusToFahrenheit() {

            Assert.IsTrue(IsAccurate(41, converter.Convert("celsius", 5, "fahrenheit")));
            Assert.IsTrue(IsAccurate(32, converter.Convert("celsius", 0, "fahrenheit")));
            Assert.IsTrue(IsAccurate(266, converter.Convert("celsius", 130, "fahrenheit")));
        }

        [TestMethod]
        public void CelsiusToKelvin() {

            Assert.IsTrue(IsAccurate(278.15m, converter.Convert("celsius", 5, "kelvin")));
            Assert.IsTrue(IsAccurate(273.15m, converter.Convert("celsius", 0, "kelvin")));
            Assert.IsTrue(IsAccurate(403.15m, converter.Convert("celsius", 130, "kelvin")));
        }

        [TestMethod]
        public void KelvinToKelvin() {

            Assert.IsTrue(IsAccurate(5, converter.Convert("kelvin", 5, "kelvin")));
            Assert.IsTrue(IsAccurate(0, converter.Convert("kelvin", 0, "kelvin")));
            Assert.IsTrue(IsAccurate(130, converter.Convert("kelvin", 130, "kelvin")));
        }

        [TestMethod]
        public void KelvinToFahrenheit() {

            Assert.IsTrue(IsAccurate(-450.67m, converter.Convert("kelvin", 5, "fahrenheit")));
            Assert.IsTrue(IsAccurate(-459.67m, converter.Convert("kelvin", 0, "fahrenheit")));
            Assert.IsTrue(IsAccurate(-225.67m, converter.Convert("kelvin", 130, "fahrenheit")));
        }

        [TestMethod]
        public void KelvinToCelsius() {

            Assert.IsTrue(IsAccurate(-268.15m, converter.Convert("kelvin", 5, "celsius")));
            Assert.IsTrue(IsAccurate(-273.15m, converter.Convert("kelvin", 0, "celsius")));
            Assert.IsTrue(IsAccurate(-143.15m, converter.Convert("kelvin", 130, "celsius")));
        }
    }
}