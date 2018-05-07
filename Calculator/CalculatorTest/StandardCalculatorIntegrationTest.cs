using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using StorageClassLibrary;
using UtilityClassLibrary;

namespace CalculatorTest {
    [TestClass]
    public class StandardCalculatorIntegrationTest {

        IInputBuffer buffer;
        IOperatorLookup lookup;
        IUnitConverter unitConverter;
        IOperatorConverter operatorConverter;
        IParenthesize parenthesizer;
        IExpressionBuilder builder;
        IExpressionParser parser;
        IEvaluate evaluator;
        IMemoryStorage memory;
        StandardCalculator calculator;

        [TestInitialize]
        public void Setup() {

            buffer = new InputBuffer();
            lookup = new OperatorLookup();
            unitConverter = new UnitConverter();
            operatorConverter = new OperatorConverter(lookup.Operators, lookup.Unary);
            parenthesizer = new Parenthesizer(lookup.Precedence);
            builder = new ExpressionBuilder(parenthesizer);
            parser = new ExpressionParser(operatorConverter);
            evaluator = new Evaluator(unitConverter, operatorConverter, lookup);
            memory = new MemoryStorage();

            calculator = new StandardCalculator(

                buffer,
                lookup,
                unitConverter,
                operatorConverter,
                builder,
                parser,
                evaluator,
                memory
            );
        }

        [TestMethod]
        public void Clear() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Clear();

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }

        [TestMethod]
        public void ClearInput() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5 +", calculator.Expression);

            calculator.ClearInput();

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5 +", calculator.Expression);
        }

        [TestMethod]
        public void MemoryClear() {

            calculator.MemoryStore(3);
            calculator.MemoryStore(4);
            calculator.MemoryStore(5);

            Assert.AreEqual(3, calculator.MemoryValues.Length);

            calculator.MemoryClear();

            Assert.AreEqual(0, calculator.MemoryValues.Length);
        }

        [TestMethod]
        public void MemoryStore() {

            Assert.AreEqual(0, calculator.MemoryValues.Length);

            calculator.MemoryStore(3);

            Assert.AreEqual(1, calculator.MemoryValues.Length);

            calculator.MemoryStore(4);

            Assert.AreEqual(2, calculator.MemoryValues.Length);

            calculator.MemoryStore(5);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
        }

        [TestMethod]
        public void MemoryRecall() {

            Assert.AreEqual(0, calculator.MemoryValues.Length);
            Assert.AreEqual("0", calculator.Input);

            calculator.MemoryStore(55);

            Assert.AreEqual(1, calculator.MemoryValues.Length);
            Assert.AreEqual("0", calculator.Input);

            calculator.MemoryRecall();

            Assert.AreEqual(1, calculator.MemoryValues.Length);
            Assert.AreEqual("55", calculator.Input);

            calculator.MemoryStore(-666);

            Assert.AreEqual(2, calculator.MemoryValues.Length);
            Assert.AreEqual("55", calculator.Input);

            calculator.MemoryRecall();

            Assert.AreEqual(2, calculator.MemoryValues.Length);
            Assert.AreEqual("-666", calculator.Input);

            calculator.MemoryStore(150);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            Assert.AreEqual("-666", calculator.Input);

            calculator.MemoryRecall();

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            Assert.AreEqual("150", calculator.Input);

            calculator.MemoryRemove(1);

            Assert.AreEqual(2, calculator.MemoryValues.Length);
            Assert.AreEqual("150", calculator.Input);

            calculator.MemoryRecall();

            Assert.AreEqual(2, calculator.MemoryValues.Length);
            Assert.AreEqual("150", calculator.Input);

            calculator.MemoryRemove(1);

            Assert.AreEqual(1, calculator.MemoryValues.Length);
            Assert.AreEqual("150", calculator.Input);

            calculator.MemoryRecall();

            Assert.AreEqual(1, calculator.MemoryValues.Length);
            Assert.AreEqual("55", calculator.Input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void MemoryRetrieveWithInvalidKey() {

            calculator.MemoryRetrieve(calculator.MemoryValues.Length);
        }

        [TestMethod]
        public void MemoryRetrieve() {

            calculator.MemoryStore(6);
            calculator.MemoryStore(7);
            calculator.MemoryStore(12);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, calculator.MemoryValues);

            calculator.MemoryRetrieve(0);

            Assert.AreEqual("6", calculator.Input);
            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, calculator.MemoryValues);

            calculator.MemoryRetrieve(1);

            Assert.AreEqual("7", calculator.Input);
            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, calculator.MemoryValues);

            calculator.MemoryRetrieve(2);

            Assert.AreEqual("12", calculator.Input);
            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, calculator.MemoryValues);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void MemoryRemoveWithInvalidKey() {

            calculator.MemoryRemove(calculator.MemoryValues.Length);
        }

        [TestMethod]
        public void MemoryRemove() {

            calculator.MemoryStore(6);
            calculator.MemoryStore(7);
            calculator.MemoryStore(12);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, calculator.MemoryValues);

            calculator.MemoryRemove(1);

            Assert.AreEqual(2, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 12 }, calculator.MemoryValues);

            calculator.MemoryRemove(1);

            Assert.AreEqual(1, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6 }, calculator.MemoryValues);

            calculator.MemoryRemove(0);

            Assert.AreEqual(0, calculator.MemoryValues.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void MemoryPlusWithInvalidKey() {

            calculator.MemoryPlus(calculator.MemoryValues.Length, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Large.")]
        public void OverflowWhenMemoryPlus() {

            calculator.MemoryStore(decimal.MaxValue);

            Assert.AreEqual(1, calculator.MemoryValues.Length);

            calculator.MemoryPlus(0, 1);
        }

        [TestMethod]
        public void MemoryPlus() {

            calculator.MemoryStore(6);
            calculator.MemoryStore(7);
            calculator.MemoryStore(12);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, calculator.MemoryValues);

            calculator.MemoryPlus(1, 8);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 15, 12 }, calculator.MemoryValues);

            calculator.MemoryPlus(1, -50);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, -35, 12 }, calculator.MemoryValues);

            calculator.MemoryPlus(0, 100);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 106, -35, 12 }, calculator.MemoryValues);

            calculator.MemoryPlus(2, -100);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 106, -35, -88 }, calculator.MemoryValues);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void MemoryMinusWithInvalidKey() {

            calculator.MemoryMinus(calculator.MemoryValues.Length, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Small.")]
        public void OverflowWhenMemoryMinus() {

            calculator.MemoryStore(-decimal.MaxValue);

            Assert.AreEqual(1, calculator.MemoryValues.Length);

            calculator.MemoryMinus(0, 1);
        }

        [TestMethod]
        public void MemoryMinus() {

            calculator.MemoryStore(6);
            calculator.MemoryStore(7);
            calculator.MemoryStore(12);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, calculator.MemoryValues);

            calculator.MemoryMinus(1, 8);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, -1, 12 }, calculator.MemoryValues);

            calculator.MemoryMinus(1, -50);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { 6, 49, 12 }, calculator.MemoryValues);

            calculator.MemoryMinus(0, 100);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { -94, 49, 12 }, calculator.MemoryValues);

            calculator.MemoryMinus(2, -100);

            Assert.AreEqual(3, calculator.MemoryValues.Length);
            CollectionAssert.AreEqual(new decimal[] { -94, 49, 112 }, calculator.MemoryValues);
        }

        [TestMethod]
        public void AddExpression() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5.5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("5.5 +", calculator.Expression);

            calculator.Add("(");

            Assert.AreEqual("5.5 + (", calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5.5 + (", calculator.Expression);

            calculator.Add(lookup.Factorial);

            Assert.AreEqual("5.5 + ( 5 " + lookup.Factorial, calculator.Expression);
        }

        [TestMethod]
        public void AddPI() {

            calculator.Add(lookup.PI);

            Assert.AreEqual(Math.PI.ToString(), calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }

        [TestMethod]
        public void NegateInput() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.Negate);

            Assert.AreEqual("-5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.Negate);

            Assert.AreEqual("5", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }

        [TestMethod]
        public void ValueInputAfterRightParenthesis() {

            calculator.Add("(");

            Assert.AreEqual("(", calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("(", calculator.Expression);

            calculator.Add(lookup.Plus);

            Assert.AreEqual("( 5 " + lookup.Plus, calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("( 5 " + lookup.Plus, calculator.Expression);

            calculator.Add(")");

            Assert.AreEqual("( 5 " + lookup.Plus + " 5 )", calculator.Expression);

            calculator.Add(8);

            Assert.AreEqual("8", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }

        [TestMethod]
        public void ValueInputAfterUnaryOperator() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.Factorial);

            Assert.AreEqual("5 " + lookup.Factorial, calculator.Expression);

            calculator.Add(9);

            Assert.AreEqual("9", calculator.Input);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }

        [TestMethod]
        public void InvalidUnaryOperator() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(lookup.Factorial);

            Assert.AreEqual("5 + 5 " + lookup.Factorial, calculator.Expression);
        }

        [TestMethod]
        public void InvalidParenthesis() {

            calculator.Add("(");

            Assert.AreEqual("(", calculator.Expression);

            calculator.Add(")");

            Assert.AreEqual("( 0 )", calculator.Expression);

            calculator.Add(")");

            Assert.AreEqual("( 0 )", calculator.Expression);

            calculator.Add("(");

            Assert.AreEqual("( 0 )", calculator.Expression);
        }

        [TestMethod]
        public void InvalidBinaryOperator() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(lookup.Modulus);

            Assert.AreEqual("5 " + lookup.Modulus, calculator.Expression);
        }

        [TestMethod]
        public void EvaluateValidExpression() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(lookup.Factorial);

            Assert.AreEqual("5 + 5 " + lookup.Factorial, calculator.Expression);

            Assert.AreEqual(125, calculator.Evaluate());

            calculator.Clear();
            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add(5);

            Assert.AreEqual("5 +", calculator.Expression);

            Assert.AreEqual(10, calculator.Evaluate());
        }

        [TestMethod]
        public void EvaluateInvalidExpression() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add("+");

            Assert.AreEqual("5 +", calculator.Expression);

            calculator.Add("(");

            Assert.AreEqual("5 + (", calculator.Expression);
            Assert.AreEqual(5, calculator.Evaluate());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void TryEvaluateDivideByZero() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.Divide);

            Assert.AreEqual("5 " + lookup.Divide, calculator.Expression);

            calculator.Add(0);

            Assert.AreEqual("5 " + lookup.Divide, calculator.Expression);

            calculator.Add(lookup.Plus);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Large.")]
        public void TryEvaluateOverflow() {

            calculator.Add(35000000000000000000000000000m);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.Plus);

            Assert.AreEqual("35000000000000000000000000000 " + lookup.Plus, calculator.Expression);

            calculator.Add(35000000000000000000000000000m);

            Assert.AreEqual("35000000000000000000000000000 " + lookup.Plus, calculator.Expression);

            calculator.Add(lookup.Plus);

            Assert.AreEqual("35000000000000000000000000000 " + lookup.Plus + " 35000000000000000000000000000 " + lookup.Plus, calculator.Expression);

            calculator.Add(35000000000000000000000000000m);

            Assert.AreEqual("35000000000000000000000000000 " + lookup.Plus + " 35000000000000000000000000000 " + lookup.Plus, calculator.Expression);

            calculator.Add(lookup.Plus);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Input")]
        public void TryEvaluateInvalidInput() {

            calculator.Add(8);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.ArcTanh);

            Assert.AreEqual("8 " + lookup.ArcTanh, calculator.Expression);
            calculator.Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void EvaluateDivideByZero() {

            calculator.Add(5);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.Divide);

            Assert.AreEqual("5 " + lookup.Divide, calculator.Expression);

            calculator.Add(0);

            Assert.AreEqual("5 " + lookup.Divide, calculator.Expression);
            calculator.Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Large.")]
        public void EvaluateOverflow() {

            calculator.Add(50000000000000000000000000000m);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.Plus);

            Assert.AreEqual("50000000000000000000000000000 " + lookup.Plus, calculator.Expression);

            calculator.Add(50000000000000000000000000000m);

            Assert.AreEqual("50000000000000000000000000000 " + lookup.Plus, calculator.Expression);

            calculator.Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Input")]
        public void EvaluateInvalidInput() {

            calculator.Add(8);

            Assert.AreEqual(string.Empty, calculator.Expression);

            calculator.Add(lookup.ArcTanh);

            try {

                Assert.AreEqual("8 " + lookup.ArcTanh, calculator.Expression);
            }
            catch(Exception) { }

            calculator.Evaluate();
        }
    }
}