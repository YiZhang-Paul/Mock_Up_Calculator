using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseTreeClassLibrary;
using ConverterClassLibrary;
using CalculatorClassLibrary;
using Moq;

namespace ParseTreeTest {
    [TestClass]
    public class ParseTreeTest {

        Mock<ICalculator> calculator;
        Mock<IOperatorConverter> converter;
        ParseTree tree;

        [TestInitialize]
        public void Setup() {

            calculator = new Mock<ICalculator>();
            converter = new Mock<IOperatorConverter>();
            tree = new ParseTree(calculator.Object, converter.Object);
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

            converter.Setup(x => x.IsOperator(It.Is<string>(i => i == "+" || i == "log")))
                     .Returns(true);

            converter.Setup(x => x.toValue(It.IsAny<string>()))
                     .Returns((string i) => i == "+" ? 0 : 1);

            converter.Setup(x => x.toOperator(It.IsAny<int>()))
                     .Returns((int i) => i == 0 ? "+" : "log");

            calculator.Setup(x => x.Evaluate(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                      .Returns((string i, decimal a, decimal b) => {

                          return i == "+" ? a + b : (decimal)Math.Log10((double)b);
                      });

            tree.Parse("( ( 6 + 7 ) + ( 3 + 9 ) )");

            Assert.AreEqual(25, tree.Evaluate());

            tree.Parse("( ( 6 + 7 ) + ( log 100 ) )");

            Assert.AreEqual(15, tree.Evaluate());
        }
    }
}