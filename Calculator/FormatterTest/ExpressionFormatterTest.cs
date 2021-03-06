﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatterClassLibrary;

namespace FormatterTest {
    [TestClass]
    public class ExpressionFormatterTest {

        ExpressionFormatter formatter;
        const string factorial = "fact";
        const string sine = "sin";
        const string log = "log";

        [TestInitialize]
        public void Setup() {

            var unarys = new HashSet<string>() { factorial, sine, log };
            formatter = new ExpressionFormatter(unarys);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
         "Invalid Expression.")]
        public void NullInput() {

            formatter.Format(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "Invalid Expression.")]
        public void InvalidExpression() {

            formatter.Format(") " + factorial);
        }

        [TestMethod]
        public void ExpressionWithoutOperator() {

            string expression = "5";

            Assert.AreEqual(expression, formatter.Format(expression));
        }

        [TestMethod]
        public void ExpressionWithoutUnaryOperator() {

            string expression = "5 + 6 % 6";

            Assert.AreEqual(expression, formatter.Format(expression));
        }

        [TestMethod]
        public void RemoveSpacingBetweenParentheses() {

            string expression = "( 5 + 6 ) % 6";

            Assert.AreEqual("(5 + 6) % 6", formatter.Format(expression));
        }

        [TestMethod]
        public void ExpressionWithoutNestedUnaryOperator() {

            string expression = "5 + 6 " + factorial;

            Assert.AreEqual("5 + " + factorial + "(6)", formatter.Format(expression));
        }

        [TestMethod]
        public void ExpressionWithNestedUnaryOperator() {

            string expression = "5 + 6 " + factorial + " " + factorial;

            Assert.AreEqual("5 + " + factorial + "(" + factorial + "(6)" + ")", formatter.Format(expression));

            expression = "5 + 6 " + factorial + " " + sine;

            Assert.AreEqual("5 + " + sine + "(" + factorial + "(6)" + ")", formatter.Format(expression));

            expression = "5 + 6 " + factorial + " " + sine + " " + log;

            Assert.AreEqual("5 + " + log + "(" + sine + "(" + factorial + "(6)" + "))", formatter.Format(expression));
        }
    }
}