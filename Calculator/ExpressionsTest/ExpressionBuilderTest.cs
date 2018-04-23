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

            builder = new ExpressionBuilder("5", (int)KeyType.Value);
            builder.AddValue(5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Operands Must be Separated by Operators.")]
        public void ValueInputAfterRightParenthesis() {

            builder = new ExpressionBuilder(")", (int)KeyType.Right);
            builder.AddValue(5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Operands Must be Separated by Operators.")]
        public void ValueInputAfterUnaryOperator() {

            builder = new ExpressionBuilder("!", (int)KeyType.Unary);
            builder.AddValue(5);
        }

        [TestMethod]
        public void ValueInputAfterLeftParenthesis() {

            builder = new ExpressionBuilder("(", (int)KeyType.Left);
            builder.AddValue(5);

            Assert.AreEqual("( 5", builder.Expression);
        }

        [TestMethod]
        public void ValueInputAfterBinaryOperator() {

            builder = new ExpressionBuilder("+", (int)KeyType.Binary);
            builder.AddValue(5);

            Assert.AreEqual("+ 5", builder.Expression);
        }

        [TestMethod]
        public void ValueInputInEmptyExpression() {

            builder = new ExpressionBuilder(null, (int)KeyType.Empty);
            builder.AddValue(5);

            Assert.AreEqual("5", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Mismatched Parentheses.")]
        public void MismatchedParentheses() {

            builder = new ExpressionBuilder("( 5 + 6 ) * 3", (int)KeyType.Value);
            builder.AddParentheses(")");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Mismatched Parentheses.")]
        public void LeftParenthesisAfterRightParenthesis() {

            builder = new ExpressionBuilder("( 5 + 6 )", (int)KeyType.Right);
            builder.AddParentheses("(");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operators.")]
        public void LeftParenthesisAfterUnaryOperator() {

            builder = new ExpressionBuilder("( 5 !", (int)KeyType.Unary);
            builder.AddParentheses("(");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operators.")]
        public void LeftParenthesisAfterValue() {

            builder = new ExpressionBuilder("( 5", (int)KeyType.Value);
            builder.AddParentheses("(");
        }

        [TestMethod]
        public void LeftParenthesisAfterBinaryOperator() {

            builder = new ExpressionBuilder("( 5 +", (int)KeyType.Binary);
            builder.AddParentheses("(");

            Assert.AreEqual("( 5 + (", builder.Expression);
        }

        [TestMethod]
        public void LeftParenthesisAfterLeftParenthesis() {

            builder = new ExpressionBuilder("(", (int)KeyType.Left);
            builder.AddParentheses("(");

            Assert.AreEqual("( (", builder.Expression);
        }

        [TestMethod]
        public void LeftParenthesisInEmptyExpression() {

            builder = new ExpressionBuilder(null, (int)KeyType.Empty);
            builder.AddParentheses("(");

            Assert.AreEqual("(", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Mismatched Parentheses.")]
        public void RightParenthesisInEmptyExpression() {

            builder = new ExpressionBuilder(null, (int)KeyType.Empty);
            builder.AddParentheses(")");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operand.")]
        public void RightParenthesisAfterBinaryOperator() {

            builder = new ExpressionBuilder("( 6 * ( 5 +", (int)KeyType.Binary);
            builder.AddParentheses(")");
        }

        [TestMethod]
        public void RightParenthesisAfterLeftParenthesis() {

            builder = new ExpressionBuilder("(", (int)KeyType.Left);
            builder.AddParentheses(")");

            Assert.AreEqual("( 0 )", builder.Expression);
        }

        [TestMethod]
        public void RightParenthesisAfterRightParenthesis() {

            builder = new ExpressionBuilder("( 6 * ( 5 + 5 )", (int)KeyType.Right);
            builder.AddParentheses(")");

            Assert.AreEqual("( 6 * ( 5 + 5 ) )", builder.Expression);
        }

        [TestMethod]
        public void RightParenthesisAfterUnaryOperator() {

            builder = new ExpressionBuilder("( 6 * ( 5 + 5 !", (int)KeyType.Unary);
            builder.AddParentheses(")");

            Assert.AreEqual("( 6 * ( 5 + 5 ! )", builder.Expression);
        }

        [TestMethod]
        public void RightParenthesisAfterValue() {

            builder = new ExpressionBuilder("( 6 * ( 5", (int)KeyType.Value);
            builder.AddParentheses(")");

            Assert.AreEqual("( 6 * ( 5 )", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operand.")]
        public void BinaryOperatorAfterBinaryOperator() {

            builder = new ExpressionBuilder("( 5 +", (int)KeyType.Binary);
            builder.AddBinary("+");
        }

        [TestMethod]
        public void BinaryOperatorAfterUnaryOperator() {

            builder = new ExpressionBuilder("( 5 !", (int)KeyType.Unary);
            builder.AddBinary("+");

            Assert.AreEqual("( 5 ! +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorAfterLeftParenthesis() {

            builder = new ExpressionBuilder("(", (int)KeyType.Left);
            builder.AddBinary("+");

            Assert.AreEqual("( 0 +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorAfterRightParenthesis() {

            builder = new ExpressionBuilder("( 5 + 5 )", (int)KeyType.Right);
            builder.AddBinary("+");

            Assert.AreEqual("( 5 + 5 ) +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorAfterValue() {

            builder = new ExpressionBuilder("( 5", (int)KeyType.Value);
            builder.AddBinary("+");

            Assert.AreEqual("( 5 +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorInEmptyExpression() {

            builder = new ExpressionBuilder(null, (int)KeyType.Empty);
            builder.AddBinary("+");

            Assert.AreEqual("0 +", builder.Expression);
        }
    }
}