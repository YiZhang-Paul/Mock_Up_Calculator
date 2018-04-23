using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;

namespace ExpressionsTest {
    [TestClass]
    public class ParenthesizerTest {

        Parenthesizer parenthesizer;

        [TestInitialize]
        public void Setup() {

            parenthesizer = new Parenthesizer();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid Expression.")]
        public void InvalidExpression() {

            parenthesizer.Parenthesize("( ( 5 + 6 ) × 6 ) + (");
        }

        [TestMethod]
        public void Parenthesize() {

            string result = parenthesizer.Parenthesize("( ( 5 + 6 ) × 6 ) + ( 8 + 9 ) ^ 7");

            Assert.AreEqual("( ( ( 5 + 6 ) × 6 ) + ( ( 8 + 9 ) ^ 7 ) )", result);

            result = parenthesizer.Parenthesize("8 ^ 5 fact + ( ( 5 + 6 fact ) × 7 ) log ÷ 11 Exp 2 + 9 × 2");

            Assert.AreEqual("( ( ( 8 ^ ( 5 fact ) ) + ( ( ( ( 5 + ( 6 fact ) ) × 7 ) log ) ÷ ( 11 Exp 2 ) ) ) + ( 9 × 2 ) )", result);
        }
    }
}