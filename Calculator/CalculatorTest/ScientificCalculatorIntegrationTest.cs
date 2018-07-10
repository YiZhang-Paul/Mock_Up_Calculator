using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;
using CalculatorClassLibrary;
using ConverterClassLibrary;
using StorageClassLibrary;
using UtilityClassLibrary;

namespace CalculatorTest {
    [TestClass]
    public class ScientificCalculatorIntegrationTest {

        IInputBuffer buffer;
        IOperatorLookup lookup;
        ITempUnitConverter unitConverter;
        IOperatorConverter operatorConverter;
        IParenthesize parenthesizer;
        IExpressionBuilder builder;
        IExpressionParser parser;
        IEvaluate evaluator;
        IMemoryStorage memory;
        ScientificCalculator calculator;

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

            calculator = new ScientificCalculator(

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
        public void ChangeAngularUnit() {

            Assert.AreEqual(0, calculator.AngularUnit);

            calculator.ChangeAngularUnit();

            Assert.AreEqual(1, calculator.AngularUnit);

            calculator.ChangeAngularUnit();

            Assert.AreEqual(2, calculator.AngularUnit);

            calculator.ChangeAngularUnit();

            Assert.AreEqual(0, calculator.AngularUnit);
        }

        [TestMethod]
        public void CheckNonTrigonometricKey() {

            Assert.AreEqual("sinh", calculator.CheckTrigonometricKey("sinh"));
            Assert.AreEqual("+", calculator.CheckTrigonometricKey("+"));
            Assert.AreEqual("log", calculator.CheckTrigonometricKey("log"));
        }

        [TestMethod]
        public void CheckTrigonometricKey() {

            var lookup = new OperatorLookup();

            Assert.AreEqual(lookup.SineDEG, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(lookup.SineRAD, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(lookup.SineGRAD, calculator.CheckTrigonometricKey("sin"));

            calculator.ChangeAngularUnit();

            Assert.AreEqual(lookup.SineDEG, calculator.CheckTrigonometricKey("sin"));
        }
    }
}