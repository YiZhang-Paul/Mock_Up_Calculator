using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseTreeClassLibrary;

namespace ParseTreeTest {
    [TestClass]
    public class ParseTreeTest {

        ParseTree tree;

        [TestInitialize]
        public void Setup() {

            tree = new ParseTree();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Expression.")]
        public void ParseExpressionWithMissingParentheses() {

            tree.Parse("6 + 7 )");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Expression.")]
        public void ParseExpressionWithMissingSpaces() {

            tree.Parse("( 6 + 7)");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Expression.")]
        public void ParseExpressionWithInvalidCharacter() {

            tree.Parse("( 6 + 7a )");
        }
    }
}