using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;
using ExpressionsClassLibrary;

namespace CalculatorTest {
    [TestClass]
    public class StandardCalculatorTest {

        StandardCalculator calculator;

        [TestInitialize]
        public void Setup() {

            calculator = new StandardCalculator();
        }

        [TestMethod]
        public void Clear() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Clear();

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }

        [TestMethod]
        public void ClearInput() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5 +", calculator.Expression);

            calculator.ClearInput();

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5 +", calculator.Expression);
        }

        [TestMethod]
        public void AddExpression() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5.5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5.5 +", calculator.Expression);

            calculator.Add("(");

            Assert.AreEqual("5.5 + (", calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5.5 + (", calculator.Expression);

            calculator.Add(OperatorLookup.Factorial);

            Assert.AreEqual("5.5 + ( 5 " + OperatorLookup.Factorial, calculator.Expression);
        }

        [TestMethod]
        public void EvaluateValidExpression() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(OperatorLookup.Factorial);

            Assert.AreEqual("5 + 5 " + OperatorLookup.Factorial, calculator.Expression);

            Assert.AreEqual(125, calculator.Evaluate());
        }

        [TestMethod]
        public void EvaluateInvalidExpression() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add("(");

            Assert.AreEqual("5 + (", calculator.Expression);
            Assert.AreEqual(5, calculator.Evaluate());
        }
    }
}