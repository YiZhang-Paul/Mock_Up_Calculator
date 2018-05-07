using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClassLibrary;
using UtilityClassLibrary;

namespace CalculatorTest {

    public class TestCalculator : Calculator {

        public TestCalculator(IInputBuffer buffer) : base(buffer) {}

        public override decimal Evaluate() {

            return -1;
        }
    }

    [TestClass]
    public class CalculatorIntegrationTest {

        TestCalculator calculator;

        [TestInitialize]
        public void Setup() {

            calculator = new TestCalculator(new InputBuffer());
        }

        [TestMethod]
        public void AddDigit() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("58", calculator.Input);
        }

        [TestMethod]
        public void Clear() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Clear();

            Assert.AreEqual("0", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("8", calculator.Input);

            calculator.Clear();

            Assert.AreEqual("0", calculator.Input);
        }

        [TestMethod]
        public void UndoWhenInputIsEmpty() {

            calculator.Undo();

            Assert.AreEqual("0", calculator.Input);
        }

        [TestMethod]
        public void Undo() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Undo();

            Assert.AreEqual("0", calculator.Input);

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("58", calculator.Input);

            calculator.Undo();

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Undo();

            Assert.AreEqual("5", calculator.Input);
        }

        [TestMethod]
        public void AddDecimalPoint() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("5.8", calculator.Input);
        }

        [TestMethod]
        public void AddDecimalPointFirst() {

            calculator.Add(".");

            Assert.AreEqual("0.", calculator.Input);

            calculator.Add(8);

            Assert.AreEqual("0.8", calculator.Input);
        }

        [TestMethod]
        public void AddConsecutiveDecimalPoint() {

            calculator.Add(5);

            Assert.AreEqual("5", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);

            calculator.Add(".");

            Assert.AreEqual("5.", calculator.Input);
        }

        [TestMethod]
        public void AddRandomCharacter() {

            calculator.Add("t");

            Assert.AreEqual("0", calculator.Input);
        }

        [TestMethod]
        public void Evaluate() {

            Assert.AreEqual(-1, calculator.Evaluate());
        }
    }
}