using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;

namespace CalculatorTest {
    [TestClass]
    public class CalculatorTest {

        Calculator calculator;

        [TestInitialize]
        public void Setup() {

            calculator = new Calculator();
        }

        [TestMethod]
        public void AddDigit() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("58", calculator.Input);
        }

        [TestMethod]
        public void AddDecimalPoint() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("5.8", calculator.Input);
        }

        [TestMethod]
        public void AddDecimalPointFirst() {

            calculator.Add(".");

            Assert.AreEqual("0.", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("0.8", calculator.Input);
        }

        [TestMethod]
        public void AddConsecutiveDecimalPoint() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);
        }
    }
}