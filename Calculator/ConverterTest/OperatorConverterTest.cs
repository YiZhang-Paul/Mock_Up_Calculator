using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class OperatorConverterTest {

        OperatorConverter converter;
        const string invalidOperator = "#";
        const string modulus = "%";
        const string minus = "-";
        const string power = "^";
        const string log = "log";
        const string factorial = "fact";

        [TestInitialize]
        public void Setup() {

            var operators = new string[] { modulus, minus, power, log, factorial };
            var unarys = new HashSet<string>() { log, factorial };
            converter = new OperatorConverter(operators, unarys);
        }

        [TestMethod]
        public void IsNotOperator() {

            Assert.IsFalse(converter.IsOperator(invalidOperator));
        }

        [TestMethod]
        public void IsOperator() {

            Assert.IsTrue(converter.IsOperator(modulus));
            Assert.IsTrue(converter.IsOperator(log));
        }

        [TestMethod]
        public void IsNotUnaryOperator() {

            Assert.IsFalse(converter.IsUnary(modulus));
            Assert.IsFalse(converter.IsUnary(power));
        }

        [TestMethod]
        public void IsUnaryOperator() {

            Assert.IsTrue(converter.IsUnary(log));
            Assert.IsTrue(converter.IsUnary(factorial));
        }

        [TestMethod]
        public void IsNotBinaryOperator() {

            Assert.IsFalse(converter.IsBinary(factorial));
            Assert.IsFalse(converter.IsBinary(log));
            Assert.IsFalse(converter.IsBinary(invalidOperator));
        }

        [TestMethod]
        public void IsBinaryOperator() {

            Assert.IsTrue(converter.IsBinary(modulus));
            Assert.IsTrue(converter.IsBinary(minus));
            Assert.IsTrue(converter.IsBinary(power));
        }

        [TestMethod]
        public void ConvertValidOperatorToValue() {

            Assert.AreEqual(0, converter.ToValue(modulus));
            Assert.AreEqual(1, converter.ToValue(minus));
            Assert.AreEqual(2, converter.ToValue(power));
            Assert.AreEqual(3, converter.ToValue(log));
            Assert.AreEqual(4, converter.ToValue(factorial));
        }

        [TestMethod]
        public void ConvertInvalidOperatorToValue() {

            Assert.AreEqual(-1, converter.ToValue(invalidOperator));
        }

        [TestMethod]
        public void ConvertToOperator() {

            Assert.AreEqual(modulus, converter.ToOperator(0));
            Assert.AreEqual(minus, converter.ToOperator(1));
            Assert.AreEqual(power, converter.ToOperator(2));
            Assert.AreEqual(log, converter.ToOperator(3));
            Assert.AreEqual(factorial, converter.ToOperator(4));
        }
    }
}