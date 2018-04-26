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
        public void InvalidUnaryOperator() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(OperatorLookup.Factorial);

            Assert.AreEqual("5 + 5 " + OperatorLookup.Factorial, calculator.Expression);
        }

        [TestMethod]
        public void InvalidBinaryOperator() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(OperatorLookup.Modulus);

            Assert.AreEqual("5 " + OperatorLookup.Modulus, calculator.Expression);
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

            calculator.Clear();
            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5 +", calculator.Expression);

            Assert.AreEqual(10, calculator.Evaluate());
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

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void TryEvaluateDivideByZero() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(OperatorLookup.Divide);

            Assert.AreEqual("5 " + OperatorLookup.Divide, calculator.Expression);

            calculator.Add(0);

            Assert.AreEqual("5 " + OperatorLookup.Divide, calculator.Expression);

            calculator.Add(OperatorLookup.Plus);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Large.")]
        public void TryEvaluateOverflow() {

            calculator.Add(35000000000000000000000000000m);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(OperatorLookup.Plus);

            Assert.AreEqual("35000000000000000000000000000 " + OperatorLookup.Plus, calculator.Expression);

            calculator.Add(35000000000000000000000000000m);

            Assert.AreEqual("35000000000000000000000000000 " + OperatorLookup.Plus, calculator.Expression);

            calculator.Add(OperatorLookup.Plus);

            Assert.AreEqual("35000000000000000000000000000 " + OperatorLookup.Plus + " 35000000000000000000000000000 " + OperatorLookup.Plus, calculator.Expression);

            calculator.Add(35000000000000000000000000000m);

            Assert.AreEqual("35000000000000000000000000000 " + OperatorLookup.Plus + " 35000000000000000000000000000 " + OperatorLookup.Plus, calculator.Expression);

            calculator.Add(OperatorLookup.Plus);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Input")]
        public void TryEvaluateInvalidInput() {

            calculator.Add(8);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(OperatorLookup.ArcTanh);

            Assert.AreEqual("8 " + OperatorLookup.ArcTanh, calculator.Expression);
            calculator.Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void EvaluateDivideByZero() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(OperatorLookup.Divide);

            Assert.AreEqual("5 " + OperatorLookup.Divide, calculator.Expression);

            calculator.Add(0);

            Assert.AreEqual("5 " + OperatorLookup.Divide, calculator.Expression);
            calculator.Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Large.")]
        public void EvaluateOverflow() {

            calculator.Add(50000000000000000000000000000m);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(OperatorLookup.Plus);

            Assert.AreEqual("50000000000000000000000000000 " + OperatorLookup.Plus, calculator.Expression);

            calculator.Add(50000000000000000000000000000m);

            Assert.AreEqual("50000000000000000000000000000 " + OperatorLookup.Plus, calculator.Expression);

            calculator.Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Input")]
        public void EvaluateInvalidInput() {

            calculator.Add(8);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(OperatorLookup.ArcTanh);

            try {

                Assert.AreEqual("8 " + OperatorLookup.ArcTanh, calculator.Expression);
            }
            catch(Exception) { }

            calculator.Evaluate();
        }
    }
}