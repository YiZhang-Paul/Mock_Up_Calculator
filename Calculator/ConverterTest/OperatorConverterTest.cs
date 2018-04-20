using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class OperatorConverterTest {

        OperatorConverter converter;

        [TestInitialize]
        public void Setup() {

            converter = new OperatorConverter();
        }

        [TestMethod]
        public void IsInvalidOperator() {

            Assert.IsFalse(converter.IsOperator("#"));
        }

        [TestMethod]
        public void IsValidOperator() {

            Assert.IsTrue(converter.IsOperator("%"));
        }

        [TestMethod]
        public void ConvertValidOperatorToValue() {

            Assert.AreEqual(1, converter.toValue("-"));
        }

        [TestMethod]
        public void ConvertInvalidOperatorToValue() {

            Assert.AreEqual(-1, converter.toValue("#"));
        }

        [TestMethod]
        public void ConvertToOperator() {

            Assert.AreEqual("%", converter.toOperator(4));
        }
    }
}