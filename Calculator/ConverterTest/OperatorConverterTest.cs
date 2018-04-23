using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;
using ExpressionsClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class OperatorConverterTest {

        const string invalidOperator = "#";
        OperatorConverter converter;

        [TestInitialize]
        public void Setup() {

            converter = new OperatorConverter(OperatorLookup.Operators);
        }

        [TestMethod]
        public void IsInvalidOperator() {

            Assert.IsFalse(converter.IsOperator(invalidOperator));
        }

        [TestMethod]
        public void IsValidOperator() {

            Assert.IsTrue(converter.IsOperator(OperatorLookup.Modulus));
        }

        [TestMethod]
        public void IsInvalidUnaryOperator() {

            Assert.IsFalse(converter.IsUnary(OperatorLookup.Modulus));
        }

        [TestMethod]
        public void IsValidUnaryOperator() {

            Assert.IsTrue(converter.IsUnary(OperatorLookup.Factorial));
        }

        [TestMethod]
        public void IsInvalidBinaryOperator() {

            Assert.IsFalse(converter.IsBinary(OperatorLookup.Factorial));
            Assert.IsFalse(converter.IsBinary(invalidOperator));
        }

        [TestMethod]
        public void IsValidBinaryOperator() {

            Assert.IsTrue(converter.IsBinary(OperatorLookup.Modulus));
        }

        [TestMethod]
        public void ConvertValidOperatorToValue() {

            Assert.AreEqual(30, converter.ToValue(OperatorLookup.Minus));
        }

        [TestMethod]
        public void ConvertInvalidOperatorToValue() {

            Assert.AreEqual(-1, converter.ToValue(invalidOperator));
        }

        [TestMethod]
        public void ConvertToOperator() {

            Assert.AreEqual(OperatorLookup.Modulus, converter.ToOperator(28));
        }
    }
}