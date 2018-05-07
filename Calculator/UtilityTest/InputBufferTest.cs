using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityClassLibrary;

namespace UtilityTest {
    [TestClass]
    public class InputBufferTest {

        InputBuffer buffer;

        [TestInitialize]
        public void Setup() {

            buffer = new InputBuffer();
        }

        [TestMethod]
        public void Clear() {

            buffer.Clear();
            Assert.AreEqual(0, buffer.Value);
        }

        [TestMethod]
        public void AddDigitFirst() {

            buffer.Add("0");
            Assert.AreEqual(0, buffer.Value);

            buffer.Add("1");
            Assert.AreEqual(1, buffer.Value);

            buffer.Add("5");
            Assert.AreEqual(15, buffer.Value);

            buffer.Add("0");
            Assert.AreEqual(150, buffer.Value);

            buffer.Add(".");
            Assert.AreEqual(150, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);

            buffer.Add("6");
            Assert.AreEqual(150.6m, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);
        }

        [TestMethod]
        public void AddDecimalFirst() {

            buffer.Add(".");
            Assert.AreEqual(0, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);

            buffer.Add("8");
            Assert.AreEqual(0.8m, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);
        }

        [TestMethod]
        public void AddDuplicateDecimalPoint() {

            buffer.Add(".");
            Assert.AreEqual(0, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);

            buffer.Add(".");
            Assert.AreEqual(0, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);

            buffer.Add("8");
            Assert.AreEqual(0.8m, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);

            buffer.Add(".");
            Assert.AreEqual(0.8m, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);

            buffer.Add("8");
            Assert.AreEqual(0.88m, buffer.Value);
            Assert.IsTrue(buffer.IsDecimal);
        }

        [TestMethod]
        public void AddMaxLengthInteger() {

            for(int i = 0; i < 28; i++) {

                buffer.Add("1");
            }

            decimal value = buffer.Value;

            for(int i = 0; i < 10; i++) {

                buffer.Add("1");
            }

            Assert.AreEqual(value, buffer.Value);
        }

        [TestMethod]
        public void AddMaxLengthDecimal() {

            buffer.Add(".");

            for(int i = 0; i < 29; i++) {

                buffer.Add("1");
            }

            decimal value = buffer.Value;

            for(int i = 0; i < 5; i++) {

                buffer.Add("1");
            }

            Assert.AreEqual(value, buffer.Value);
        }

        [TestMethod]
        public void Set() {

            buffer.Set("0.01");
            Assert.AreEqual(0.01m, buffer.Value);

            buffer.Set("0.0");
            Assert.AreEqual(0, buffer.Value);

            buffer.Set("-11.21");
            Assert.AreEqual(-11.21m, buffer.Value);

            buffer.Set("-991");
            Assert.AreEqual(-991, buffer.Value);
        }

        [TestMethod]
        public void Undo() {

            buffer.Set("6");
            Assert.AreEqual(6, buffer.Value);
            buffer.Undo();
            Assert.AreEqual(0, buffer.Value);

            buffer.Set("15");
            Assert.AreEqual(15, buffer.Value);
            buffer.Undo();
            Assert.AreEqual(1, buffer.Value);
        }

        [TestMethod]
        public void Negate() {

            buffer.Set("0.01");
            Assert.AreEqual(0.01m, buffer.Value);
            buffer.Negate();
            Assert.AreEqual(-0.01m, buffer.Value);
            Assert.IsTrue(buffer.IsNegative);

            buffer.Set("-11.21");
            Assert.AreEqual(-11.21m, buffer.Value);
            buffer.Negate();
            Assert.AreEqual(11.21m, buffer.Value);
            Assert.IsFalse(buffer.IsNegative);
        }
    }
}