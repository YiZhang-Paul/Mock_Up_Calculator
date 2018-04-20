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

            tree.Parse("( 6 + 7 ) a");
        }

        [TestMethod]
        public void Evaluate() {

            converter.Setup(x => x.IsOperator(It.Is<string>(i => i == "+"))).Returns(true);
            converter.Setup(x => x.toValue(It.IsAny<string>())).Returns(0);
            converter.Setup(x => x.toOperator(It.IsAny<int>())).Returns("+");

            tree.Parse("( ( 6 + 7 ) + ( 3 + 9 ) )");

            Assert.AreEqual(25, tree.Evaluate());
        }
    }
}