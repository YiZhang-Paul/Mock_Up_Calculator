using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;
using Moq;

namespace ExpressionsTest {
    [TestClass]
    public class ExpressionBuilderTest {

        enum KeyType { Value, Unary, Binary, Left, Right, Empty };

        Mock<IParenthesize> parenthesizer;
        ExpressionBuilder builder;

        [TestInitialize]
        public void Setup() {

            parenthesizer = new Mock<IParenthesize>();
            builder = new ExpressionBuilder(parenthesizer.Object);
        }

        [TestMethod]
        public void Clear() {

            builder = new ExpressionBuilder(parenthesizer.Object, "5", (int)KeyType.Value);

            Assert.AreEqual("5", builder.Expression);

            builder.Clear();

            Assert.AreEqual(string.Empty, builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "Invalid Key Type.")]
        public void InvalidKeyType() {

            builder = new ExpressionBuilder(parenthesizer.Object, "5", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Operands Must be Separated by Operators.")]
        public void ConsecutiveValueInput() {

            builder = new ExpressionBuilder(parenthesizer.Object, "5", (int)KeyType.Value);
            builder.AddValue(5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Operands Must be Separated by Operators.")]
        public void ValueInputAfterRightParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, ")", (int)KeyType.Right);
            builder.AddValue(5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Operands Must be Separated by Operators.")]
        public void ValueInputAfterUnaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "!", (int)KeyType.Unary);
            builder.AddValue(5);
        }

        [TestMethod]
        public void ValueInputAfterLeftParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "(", (int)KeyType.Left);
            builder.AddValue(5);

            Assert.AreEqual("( 5", builder.Expression);
        }

        [TestMethod]
        public void ValueInputAfterBinaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "+", (int)KeyType.Binary);
            builder.AddValue(5);

            Assert.AreEqual("+ 5", builder.Expression);
        }

        [TestMethod]
        public void ValueInputInEmptyExpression() {

            builder = new ExpressionBuilder(parenthesizer.Object, null, (int)KeyType.Empty);
            builder.AddValue(5);

            Assert.AreEqual("5", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Mismatched Parentheses.")]
        public void MismatchedParentheses() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 + 6 ) * 3", (int)KeyType.Value);
            builder.AddParentheses(")");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Mismatched Parentheses.")]
        public void LeftParenthesisAfterRightParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 + 6 )", (int)KeyType.Right);
            builder.AddParentheses("(");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operators.")]
        public void LeftParenthesisAfterUnaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 !", (int)KeyType.Unary);
            builder.AddParentheses("(");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operators.")]
        public void LeftParenthesisAfterValue() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5", (int)KeyType.Value);
            builder.AddParentheses("(");
        }

        [TestMethod]
        public void LeftParenthesisAfterBinaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 +", (int)KeyType.Binary);
            builder.AddParentheses("(");

            Assert.AreEqual("( 5 + (", builder.Expression);
        }

        [TestMethod]
        public void LeftParenthesisAfterLeftParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "(", (int)KeyType.Left);
            builder.AddParentheses("(");

            Assert.AreEqual("( (", builder.Expression);
        }

        [TestMethod]
        public void LeftParenthesisInEmptyExpression() {

            builder = new ExpressionBuilder(parenthesizer.Object, null, (int)KeyType.Empty);
            builder.AddParentheses("(");

            Assert.AreEqual("(", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Mismatched Parentheses.")]
        public void RightParenthesisInEmptyExpression() {

            builder = new ExpressionBuilder(parenthesizer.Object, null, (int)KeyType.Empty);
            builder.AddParentheses(")");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operand.")]
        public void RightParenthesisAfterBinaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 6 * ( 5 +", (int)KeyType.Binary);
            builder.AddParentheses(")");
        }

        [TestMethod]
        public void RightParenthesisAfterLeftParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "(", (int)KeyType.Left);
            builder.AddParentheses(")");

            Assert.AreEqual("( 0 )", builder.Expression);
        }

        [TestMethod]
        public void RightParenthesisAfterRightParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 6 * ( 5 + 5 )", (int)KeyType.Right);
            builder.AddParentheses(")");

            Assert.AreEqual("( 6 * ( 5 + 5 ) )", builder.Expression);
        }

        [TestMethod]
        public void RightParenthesisAfterUnaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 6 * ( 5 + 5 !", (int)KeyType.Unary);
            builder.AddParentheses(")");

            Assert.AreEqual("( 6 * ( 5 + 5 ! )", builder.Expression);
        }

        [TestMethod]
        public void RightParenthesisAfterValue() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 6 * ( 5", (int)KeyType.Value);
            builder.AddParentheses(")");

            Assert.AreEqual("( 6 * ( 5 )", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operand.")]
        public void UnaryOperatorAfterBinaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 +", (int)KeyType.Binary);
            builder.AddUnary("!");
        }

        [TestMethod]
        public void UnaryOperatorAfterUnaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 !", (int)KeyType.Unary);
            builder.AddUnary("!");

            Assert.AreEqual("( 5 ! !", builder.Expression);
        }

        [TestMethod]
        public void UnaryOperatorAfterLeftParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "(", (int)KeyType.Left);
            builder.AddUnary("!");

            Assert.AreEqual("( 0 !", builder.Expression);
        }

        [TestMethod]
        public void UnaryOperatorAfterRightParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 + 5 )", (int)KeyType.Right);
            builder.AddUnary("!");

            Assert.AreEqual("( 5 + 5 ) !", builder.Expression);
        }

        [TestMethod]
        public void UnaryOperatorAfterValue() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5", (int)KeyType.Value);
            builder.AddUnary("!");

            Assert.AreEqual("( 5 !", builder.Expression);
        }

        [TestMethod]
        public void UnaryOperatorInEmptyExpression() {

            builder = new ExpressionBuilder(parenthesizer.Object, null, (int)KeyType.Empty);
            builder.AddUnary("!");

            Assert.AreEqual("0 !", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Missing Operand.")]
        public void BinaryOperatorAfterBinaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 +", (int)KeyType.Binary);
            builder.AddBinary("+");
        }

        [TestMethod]
        public void BinaryOperatorAfterUnaryOperator() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 !", (int)KeyType.Unary);
            builder.AddBinary("+");

            Assert.AreEqual("( 5 ! +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorAfterLeftParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "(", (int)KeyType.Left);
            builder.AddBinary("+");

            Assert.AreEqual("( 0 +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorAfterRightParenthesis() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5 + 5 )", (int)KeyType.Right);
            builder.AddBinary("+");

            Assert.AreEqual("( 5 + 5 ) +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorAfterValue() {

            builder = new ExpressionBuilder(parenthesizer.Object, "( 5", (int)KeyType.Value);
            builder.AddBinary("+");

            Assert.AreEqual("( 5 +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorInEmptyExpression() {

            builder = new ExpressionBuilder(parenthesizer.Object, null, (int)KeyType.Empty);
            builder.AddBinary("+");

            Assert.AreEqual("0 +", builder.Expression);
        }

        [TestMethod]
        public void GetExpression() {

            builder.AddParentheses("(");
            builder.AddValue(5);
            builder.AddBinary("^");
            builder.AddValue(7);
            builder.AddUnary("!");
            builder.AddParentheses(")");
            builder.AddBinary("*");
            builder.AddValue(79.7m);
            builder.AddUnary("log");
            builder.AddBinary("-");
            builder.AddValue(6);

            Assert.AreEqual("( 5 ^ 7 ! ) * 79.7 log - 6", builder.Expression);
        }

        [TestMethod]
        public void BuildExpression() {

            parenthesizer.Setup(x => x.Parenthesize(It.IsAny<string>())).Returns("( 5 + 5 )");

            Assert.AreEqual("( 5 + 5 )", builder.Build());
        }
    }
}