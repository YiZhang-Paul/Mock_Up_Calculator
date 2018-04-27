﻿using System;
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

            Assert.AreEqual(OperatorLookup.SineDEG, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(OperatorLookup.SineRAD, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(OperatorLookup.SineGRAD, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(OperatorLookup.SineDEG, calculator.CheckTrigonometricKey("sin"));
        }
    }
}