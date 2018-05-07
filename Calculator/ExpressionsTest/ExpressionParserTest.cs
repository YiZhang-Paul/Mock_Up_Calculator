using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using Moq;

namespace ExpressionsTest {
    [TestClass]
    public class ExpressionParserTest {

        Mock<IOperatorConverter> converter;
        ExpressionParser parser;
        const string plus = "+";
        const string modulus = "%";
        const string factorial = "fact";

        [TestInitialize]
        public void Setup() {

            converter = new Mock<IOperatorConverter>();

            converter.Setup(x => x.IsOperator(It.IsAny<string>()))
                     .Returns((string token) => token == plus || token == modulus || token == factorial);
            converter.Setup(x => x.IsUnary(It.IsAny<string>()))
                     .Returns((string token) => token == factorial);
            converter.Setup(x => x.ToValue(It.IsAny<string>()))
                     .Returns((string token) => token == plus ? 1 : (token == modulus ? 2 : 3));

            parser = new ExpressionParser(converter.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Expression.")]
        public void ParseInvalidExpression() {

            var node = parser.Parse("( ( 5 " + plus + " 7 ) " + modulus + " ( 4 " + plus + " 3 ) ) " + plus + " (");
        }

        [TestMethod]
        public void ParseValidExpression() {

            var node = parser.Parse("( ( 5 " + plus + " ( 7 " + factorial + " ) ) " + modulus + " ( 4 " + plus + " 3 ) )");
        }
    }
}