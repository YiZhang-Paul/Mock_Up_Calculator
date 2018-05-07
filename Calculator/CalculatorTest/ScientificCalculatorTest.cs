using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;
using CalculatorClassLibrary;

namespace CalculatorTest {
    [TestClass]
    public class ScientificCalculatorTest {

        ScientificCalculator calculator;

        [TestInitialize]
        public void Setup() {

            calculator = new ScientificCalculator();
        }

        [TestMethod]
        public void ChangeAngularUnit() {

            Assert.AreEqual(0, calculator.AngularUnit);

            calculator.ChangeAngularUnit();

            Assert.AreEqual(1, calculator.AngularUnit);

            calculator.ChangeAngularUnit();

            Assert.AreEqual(2, calculator.AngularUnit);

            calculator.ChangeAngularUnit();

            Assert.AreEqual(0, calculator.AngularUnit);
        }

        [TestMethod]
        public void CheckNonTrigonometricKey() {

            Assert.AreEqual("sinh", calculator.CheckTrigonometricKey("sinh"));
            Assert.AreEqual("+", calculator.CheckTrigonometricKey("+"));
            Assert.AreEqual("log", calculator.CheckTrigonometricKey("log"));
        }

        [TestMethod]
        public void CheckTrigonometricKey() {

            var lookup = new OperatorLookup();

            Assert.AreEqual(lookup.SineDEG, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(lookup.SineRAD, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(lookup.SineGRAD, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(lookup.SineDEG, calculator.CheckTrigonometricKey("sin"));
        }
    }
}