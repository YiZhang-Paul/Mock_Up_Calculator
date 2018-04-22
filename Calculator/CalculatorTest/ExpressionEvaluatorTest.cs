using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;

namespace CalculatorTest {
    [TestClass]
    public class ExpressionEvaluatorTest {

        ExpressionEvaluator evaluator;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 9) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            evaluator = new ExpressionEvaluator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Operator.")]
        public void InvalidOperator() {

            evaluator.Evaluate("#", 2, 4);
        }

        [TestMethod]
        public void Add() {

            Assert.AreEqual(2 + 3, evaluator.Evaluate("+", 2, 3));
            Assert.AreEqual(2 - 7, evaluator.Evaluate("+", 2, -7));
            Assert.AreEqual(2.67m + 9.05m, evaluator.Evaluate("+", 2.67m, 9.05m));
            Assert.AreEqual(5.95m - 17.67m, evaluator.Evaluate("+", 5.95m, -17.67m));
        }

        [TestMethod]
        public void Minus() {

            Assert.AreEqual(2 - 3, evaluator.Evaluate("-", 2, 3));
            Assert.AreEqual(2 + 7, evaluator.Evaluate("-", 2, -7));
            Assert.AreEqual(2.67m - 9.05m, evaluator.Evaluate("-", 2.67m, 9.05m));
            Assert.AreEqual(5.95m + 17.67m, evaluator.Evaluate("-", 5.95m, -17.67m));
        }

        [TestMethod]
        public void Multiply() {

            Assert.AreEqual(2 * 3, evaluator.Evaluate("*", 2, 3));
            Assert.AreEqual(2 * -7, evaluator.Evaluate("*", 2, -7));
            Assert.AreEqual(2.67m * 9.05m, evaluator.Evaluate("*", 2.67m, 9.05m));
            Assert.AreEqual(5.95m * -17.67m, evaluator.Evaluate("*", 5.95m, -17.67m));
        }

        [TestMethod]
        public void Divide() {

            Assert.AreEqual(2m / 3, evaluator.Evaluate("/", 2, 3));
            Assert.AreEqual(2m / -7, evaluator.Evaluate("/", 2, -7));
            Assert.AreEqual(2.67m / 9.05m, evaluator.Evaluate("/", 2.67m, 9.05m));
            Assert.AreEqual(5.95m / -17.67m, evaluator.Evaluate("/", 5.95m, -17.67m));
        }

        [TestMethod]
        public void Modulus() {

            Assert.AreEqual(2m % 3, evaluator.Evaluate("%", 2, 3));
            Assert.AreEqual(2m % -7, evaluator.Evaluate("%", 2, -7));
            Assert.AreEqual(2.67m % 9.05m, evaluator.Evaluate("%", 2.67m, 9.05m));
            Assert.AreEqual(5.95m % -17.67m, evaluator.Evaluate("%", 5.95m, -17.67m));
        }

        [TestMethod]
        public void RaiseToPower() {

            Assert.AreEqual((decimal)Math.Pow(2, 3), evaluator.Evaluate("^", 2, 3));
            Assert.AreEqual((decimal)Math.Pow(2, -7), evaluator.Evaluate("^", 2, -7));
            Assert.AreEqual((decimal)Math.Pow(2.67, 9.05), evaluator.Evaluate("^", 2.67m, 9.05m));
            Assert.AreEqual((decimal)Math.Pow(5.95, -17.67), evaluator.Evaluate("^", 5.95m, -17.67m));
        }

        [TestMethod]
        public void NthRoot() {

            Assert.AreEqual(2, evaluator.Evaluate("root", 4, 2));
            Assert.AreEqual(2, evaluator.Evaluate("root", 8, 3));
            Assert.AreEqual(2.35m, evaluator.Evaluate("root", 71.6703146875m, 5));
        }

        [TestMethod]
        public void RaiseToPowerOfTen() {

            Assert.AreEqual(400, evaluator.Evaluate("exp", 4, 2));
            Assert.AreEqual(8000, evaluator.Evaluate("exp", 8, 3));
            Assert.AreEqual(7167031.46875m, evaluator.Evaluate("exp", 71.6703146875m, 5));
        }

        [TestMethod]
        public void Exponential() {

            Assert.AreEqual((decimal)Math.Exp(2), evaluator.Evaluate("e^x", 4, 2));
            Assert.AreEqual((decimal)Math.Exp(3), evaluator.Evaluate("e^x", 4, 3));
            Assert.AreEqual((decimal)Math.Exp(5), evaluator.Evaluate("e^x", 4, 5));
        }

        [TestMethod]
        public void Log10() {

            Assert.AreEqual((decimal)Math.Log10(100), evaluator.Evaluate("log", 4, 100));
            Assert.AreEqual((decimal)Math.Log10(1000), evaluator.Evaluate("log", 4, 1000));
            Assert.AreEqual((decimal)Math.Log10(555), evaluator.Evaluate("log", 4, 555));
        }

        [TestMethod]
        public void NaturalLogarithm() {

            Assert.IsTrue(IsAccurate(4.6051701859880913680359829093687m, evaluator.Evaluate("ln", 4, 100)));
            Assert.IsTrue(IsAccurate(6.9077552789821370520539743640531m, evaluator.Evaluate("ln", 4, 1000)));
            Assert.IsTrue(IsAccurate(6.3189681137464345103641002411802m, evaluator.Evaluate("ln", 4, 555)));
        }
    }
}