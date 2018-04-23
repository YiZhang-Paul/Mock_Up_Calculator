using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;

namespace ExpressionsTest {
    [TestClass]
    public class ParenthesizerTest {

        List<string[]> operators = new List<string[]>() {

            new string[] {

                "√", "¹⁄ x", "eˣ", "sqr", "cube",
                "fact", "log", "ln", "dms", "degrees", "negate",
                "sin", "cos", "tan", "sinh", "cosh", "tanh",
                "sin⁻¹", "cos⁻¹", "tan⁻¹", "sinh⁻¹", "cosh⁻¹", "tanh⁻¹"
            },

            new string[] { "^", "Exp", "yroot" },
            new string[] { "×", "÷", "Mod" },
            new string[] { "+", "−" }
        };

        Parenthesizer parenthesizer;

        [TestInitialize]
        public void Setup() {

            parenthesizer = new Parenthesizer(operators);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid Expression.")]
        public void InvalidExpression() {

            parenthesizer.Parenthesize("( ( 5 + 6 ) × 6 ) + (");
        }

        [TestMethod]
        public void Parenthesize() {

            string result = parenthesizer.Parenthesize("( ( 5 + 6 ) × 6 ) − ( 8 + 9 ) ^ 7");

            Assert.AreEqual("( ( ( 5 + 6 ) × 6 ) − ( ( 8 + 9 ) ^ 7 ) )", result);

            result = parenthesizer.Parenthesize("8 ^ 5 fact + ( ( 5 + 6 fact ) × 7 ) log ÷ 11 Exp 2 + 9 × 2");

            Assert.AreEqual("( ( ( 8 ^ ( 5 fact ) ) + ( ( ( ( 5 + ( 6 fact ) ) × 7 ) log ) ÷ ( 11 Exp 2 ) ) ) + ( 9 × 2 ) )", result);
        }
    }
}