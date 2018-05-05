using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;
using FormatterClassLibrary;

namespace FormatterTest {
    [TestClass]
    public class ExpressionFormatterTest {

        ExpressionFormatter formatter;

        [TestInitialize]
        public void Setup() {

            formatter = new ExpressionFormatter();
        }

        [TestMethod]
        public void ExpressionWithoutUnaryOperator() {

            string expression = "5 + 6 " + OperatorLookup.Multiply + " 6";

            Assert.AreEqual(expression, formatter.Format(expression));

            expression = "( 5 + 6 ) " + OperatorLookup.Multiply + " 6";

            Assert.AreEqual("(5 + 6) " + OperatorLookup.Multiply + " 6", formatter.Format(expression));
        }

        [TestMethod]
        public void ExpressionWithoutNestedUnaryOperator() {

            string expression = "5 + 6 " + OperatorLookup.Factorial;

            Assert.AreEqual("5 + " + OperatorLookup.Factorial + "(6)", formatter.Format(expression));
        }

        [TestMethod]
        public void ExpressionWithNestedUnaryOperator() {

            string expression = "5 + 6 " + OperatorLookup.Factorial + " " + OperatorLookup.Factorial;

            Assert.AreEqual("5 + " + OperatorLookup.Factorial + "(" + OperatorLookup.Factorial + "(6)" + ")", formatter.Format(expression));

            expression = "5 + 6 " + OperatorLookup.Factorial + " " + OperatorLookup.SineDEG;

            Assert.AreEqual("5 + " + OperatorLookup.SineDEG + "(" + OperatorLookup.Factorial + "(6)" + ")", formatter.Format(expression));
        }
    }
}