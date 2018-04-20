using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseTreeClassLibrary;
using ConverterClassLibrary;
using Moq;

namespace ParseTreeTest {
    [TestClass]
    public class ParseTreeTest {

        Mock<IOperatorConverter> converter;
        ParseTree tree;

        [TestInitialize]
        public void Setup() {

            converter = new Mock<IOperatorConverter>();
            tree = new ParseTree(converter.Object);
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