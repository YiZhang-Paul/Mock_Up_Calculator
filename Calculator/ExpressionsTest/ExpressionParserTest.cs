using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using Moq;

namespace ExpressionsTest {
    [TestClass]
    public class ExpressionParserTest {

        string plus = OperatorLookup.Plus;
        string multiply = OperatorLookup.Multiply;
        Mock<IOperatorConverter> converter;
        ExpressionParser parser;

        [TestInitialize]
        public void Setup() {

            converter = new Mock<IOperatorConverter>();
            parser = new ExpressionParser(converter.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Expression.")]
        public void ParseInvalidExpression() {

            converter.Setup(x => x.IsOperator(It.IsAny<string>()))
                     .Returns((string i) => i == plus || i == multiply);
            converter.Setup(x => x.IsUnary(It.IsAny<string>()))
                     .Returns((string i) => i != plus && i != multiply);
            converter.Setup(x => x.ToValue(It.IsAny<string>()))
                     .Returns((string i) => i == plus ? 29 : 26);

            var node = parser.Parse("( ( 5 " + plus + " 7 ) " + multiply + " ( 4 " + plus + " 3 ) ) " + plus + " (");
        }

        [TestMethod]
        public void ParseValidExpression() {

            converter.Setup(x => x.IsOperator(It.IsAny<string>()))
                     .Returns((string i) => i == plus || i == multiply);
            converter.Setup(x => x.IsUnary(It.IsAny<string>()))
                     .Returns((string i) => i != plus && i != multiply);
            converter.Setup(x => x.ToValue(It.IsAny<string>()))
                     .Returns((string i) => i == plus ? 29 : 26);

            var node = parser.Parse("( ( 5 " + plus + " 7 ) " + multiply + " ( 4 " + plus + " 3 ) )");
        }
    }
}