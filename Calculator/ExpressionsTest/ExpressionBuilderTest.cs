using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;

namespace ExpressionsTest {
    [TestClass]
    public class ExpressionBuilderTest {

        enum KeyType { Value, Unary, Binary, Left, Right, Empty };

        ExpressionBuilder builder;

        [TestInitialize]
        public void Setup() {

            builder = new ExpressionBuilder();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Operands Must be Separated by Operators.")]
        public void ConsecutiveValueInput() {

            builder = new ExpressionBuilder((int)KeyType.Value);
            builder.AddValue(5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Operands Must be Separated by Operators.")]
        public void ValueInputAfterRightParenthesis() {

            builder = new ExpressionBuilder((int)KeyType.Right);
            builder.AddValue(5);
        }

        [TestMethod]
        public void ValueInputAfterLeftParenthesis() {

            builder = new ExpressionBuilder((int)KeyType.Left);
            builder.AddValue(5);

            Assert.AreEqual("( 5 )", builder.Expression);
        }

        [TestMethod]
        public void ValueInputAfterUnaryOperator() {

            builder = new ExpressionBuilder((int)KeyType.Unary);
            builder.AddValue(5);

            Assert.AreEqual("( 5 )", builder.Expression);
        }

        [TestMethod]
        public void ValueInputAfterBinaryOperator() {

            builder = new ExpressionBuilder((int)KeyType.Binary);
            builder.AddValue(5);

            Assert.AreEqual("( 5 )", builder.Expression);
        }

        [TestMethod]
        public void ValueInputInEmptyExpression() {

            builder = new ExpressionBuilder((int)KeyType.Empty);
            builder.AddValue(5);

            Assert.AreEqual("( 5 )", builder.Expression);
        }
    }
}