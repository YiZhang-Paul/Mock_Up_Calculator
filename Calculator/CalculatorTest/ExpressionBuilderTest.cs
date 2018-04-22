using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;

namespace CalculatorTest {
    [TestClass]
    public class ExpressionBuilderTest {

        ExpressionBuilder builder;

        [TestInitialize]
        public void Setup() {

            builder = new ExpressionBuilder();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Operands Must be Separated by Operators.")]
        public void ConsecutiveValueInput() {

            builder = new ExpressionBuilder("( 5 ", 0);
            builder.AddValue(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Operands Must be Separated by Operators.")]
        public void ValueInputAfterRightParentheses() {

            builder = new ExpressionBuilder("( 5 + 5 ) ", 4);
            builder.AddValue(5);
        }

        [TestMethod]
        public void ValueInputAfterLeftParentheses() {

            builder = new ExpressionBuilder("( ", 3);
            builder.AddValue(5);

            Assert.AreEqual("( 5", builder.Expression);
        }

        [TestMethod]
        public void ValueInputAfterBinaryOperator() {

            builder = new ExpressionBuilder("( 5 + ", 1);
            builder.AddValue(5);

            Assert.AreEqual("( 5 + 5 )", builder.Expression);
        }

        [TestMethod]
        public void ValueInputAfterUnaryOperator() {

            builder = new ExpressionBuilder("( log ", 2);
            builder.AddValue(5);

            Assert.AreEqual("( log 5 )", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Nested Expression.")]
        public void DifferentParenthesesInput() {

            builder = new ExpressionBuilder("( 5 + 5 ) ", 4);
            builder.AddParentheses("(");
        }

        [TestMethod]
        public void SameParenthesesInput() {

            builder.AddParentheses("(");

            Assert.AreEqual("( (", builder.Expression);

            builder = new ExpressionBuilder("( 5 + ( 5 + 5 ) ", 4);

            builder.AddParentheses(")");

            Assert.AreEqual("( 5 + ( 5 + 5 ) )", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Missing Operand Before Operator.")]
        public void BinaryOperatorAfterUnaryOperator() {

            builder = new ExpressionBuilder("( 5 ! ", 2);
            builder.AddBinaryOperator("+");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Missing Operand Before Operator.")]
        public void BinaryOperatorAfterBinaryOperator() {

            builder = new ExpressionBuilder("( 5 + ", 1);
            builder.AddBinaryOperator("+");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Missing Operand Before Operator.")]
        public void BinaryOperatorAfterLeftParentheses() {

            builder = new ExpressionBuilder("( ", 3);
            builder.AddBinaryOperator("+");
        }

        [TestMethod]
        public void BinaryOperatorAfterValue() {

            builder = new ExpressionBuilder("( 5 ", 0);
            builder.AddBinaryOperator("+");

            Assert.AreEqual("( 5 +", builder.Expression);
        }

        [TestMethod]
        public void BinaryOperatorAfterRightParentheses() {

            builder = new ExpressionBuilder("( 5 * 5 ) ", 4);
            builder.AddBinaryOperator("+");

            Assert.AreEqual("( 5 * 5 ) +", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Missing Operand.")]
        public void UnaryOperatorAfterValue() {

            builder = new ExpressionBuilder("( 5", 0);
            builder.AddUnaryOperator("log");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Missing Operand.")]
        public void UnaryOperatorAfterUnaryOperator() {

            builder = new ExpressionBuilder("( !", 2);
            builder.AddUnaryOperator("log");
        }

        [TestMethod]
        public void UnaryOperatorAfterBinaryOperator() {

            builder = new ExpressionBuilder("( 5 + ", 1);
            builder.AddUnaryOperator("log");

            Assert.AreEqual("( 5 + ( log", builder.Expression);
        }

        [TestMethod]
        public void UnaryOperatorAfterLeftParenthesis() {

            builder = new ExpressionBuilder("( ", 3);
            builder.AddUnaryOperator("log");

            Assert.AreEqual("( log", builder.Expression);
        }

        [TestMethod]
        public void UnaryOperatorAfterRightParenthesis() {

            builder = new ExpressionBuilder("( 5 + ( 5 + 3 ) ", 4);
            builder.AddUnaryOperator("log");

            Assert.AreEqual("( 5 + ( log ( 5 + 3 ) )", builder.Expression);

            builder.AddUnaryOperator("!");

            Assert.AreEqual("( 5 + ( ! ( log ( 5 + 3 ) ) )", builder.Expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid Expression.")]
        public void InvalidExpression() {

            builder = new ExpressionBuilder("5 + 3 ) ", 4);
            builder.AddUnaryOperator("log");
        }
    }
}