using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;

namespace ExpressionsTest {
    [TestClass]
    public class ParenthesizerTest {

        Parenthesizer parenthesizer;
        string plus = "+";
        string minus = "-";
        string multiply = "*";
        string divide = "/";
        string factorial = "fact";
        string power = "^";
        string log = "log";
        string exp = "exp";

        [TestInitialize]
        public void Setup() {

            var precedence = new List<string[]>() {

                new string[] { factorial, log },
                new string[] { power, exp },
                new string[] { multiply, divide },
                new string[] { plus, minus }
            };

            parenthesizer = new Parenthesizer(precedence);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid Expression.")]
        public void InvalidExpression() {

            parenthesizer.Parenthesize("( ( 5 " + plus + " 6 ) " + multiply + " 6 ) " + plus + " (");
        }

        [TestMethod]
        public void Parenthesize() {

            string result = parenthesizer.Parenthesize("( ( 5 " + plus + " 6 ) " + power + " 6 ) " + minus + " ( 8 " + plus + " 9 ) " + power + " 7");

            Assert.AreEqual("( ( ( 5 " + plus + " 6 ) " + power + " 6 ) " + minus + " ( ( 8 " + plus + " 9 ) " + power + " 7 ) )", result);

            result = parenthesizer.Parenthesize("8 " + power + " 5 " + factorial + " " + plus + " ( ( 5 " + plus + " 6 " + factorial + " ) " + multiply + " 7 ) " + log + " " + divide + " 11 " + exp + " 2 " + plus + " 9 " + multiply + " 2");

            Assert.AreEqual("( ( ( 8 " + power + " ( 5 " + factorial + " ) ) " + plus + " ( ( ( ( 5 " + plus + " ( 6 " + factorial + " ) ) " + multiply + " 7 ) " + log + " ) " + divide + " ( 11 " + exp + " 2 ) ) ) " + plus + " ( 9 " + multiply + " 2 ) )", result);
        }
    }
}