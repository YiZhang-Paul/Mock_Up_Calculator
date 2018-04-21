using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityClassLibrary;

namespace UtilityTest {
    [TestClass]
    public class KeyCheckerTest {

        KeyChecker checker;

        [TestInitialize]
        public void Setup() {

            checker = new KeyChecker();
        }

        [TestMethod]
        public void IsInputKey() {

            for(int i = 0; i <= 9; i++) {

                Assert.IsTrue(checker.IsInputKey(i.ToString()));
            }

            Assert.IsTrue(checker.IsInputKey("."));
            Assert.IsTrue(checker.IsInputKey("π"));
        }

        [TestMethod]
        public void IsNotInputKey() {

            Assert.IsFalse(checker.IsInputKey("10"));
            Assert.IsFalse(checker.IsInputKey("+"));
            Assert.IsFalse(checker.IsInputKey("%"));
            Assert.IsFalse(checker.IsInputKey("CE"));
        }

        [TestMethod]
        public void IsActionKey() {

            Assert.IsTrue(checker.IsActionKey("CE"));
            Assert.IsTrue(checker.IsActionKey("C"));
            Assert.IsTrue(checker.IsActionKey("⌫"));
            Assert.IsTrue(checker.IsActionKey("="));
        }

        [TestMethod]
        public void IsNotActionKey() {

            Assert.IsFalse(checker.IsActionKey("+"));
            Assert.IsFalse(checker.IsActionKey("%"));
            Assert.IsFalse(checker.IsActionKey("8"));
            Assert.IsFalse(checker.IsActionKey("MC"));
        }

        [TestMethod]
        public void IsFunctionKey() {

            Assert.IsTrue(checker.IsFunctionKey("log"));
            Assert.IsTrue(checker.IsFunctionKey("+"));
            Assert.IsTrue(checker.IsFunctionKey("÷"));
            Assert.IsTrue(checker.IsFunctionKey("("));
            Assert.IsTrue(checker.IsFunctionKey("n!"));
        }

        [TestMethod]
        public void IsNotFunctionKey() {

            Assert.IsFalse(checker.IsFunctionKey("8"));
            Assert.IsFalse(checker.IsFunctionKey("CE"));
            Assert.IsFalse(checker.IsFunctionKey("="));
            Assert.IsFalse(checker.IsFunctionKey("MS"));
        }

        [TestMethod]
        public void IsMemoryKey() {

            Assert.IsTrue(checker.IsMemoryKey("MC"));
            Assert.IsTrue(checker.IsMemoryKey("MR"));
            Assert.IsTrue(checker.IsMemoryKey("M+"));
            Assert.IsTrue(checker.IsMemoryKey("M-"));
            Assert.IsTrue(checker.IsMemoryKey("MS"));
            Assert.IsTrue(checker.IsMemoryKey("M▾"));
        }

        [TestMethod]
        public void IsNotMemoryKey() {

            Assert.IsFalse(checker.IsMemoryKey("DEG"));
            Assert.IsFalse(checker.IsMemoryKey("+"));
            Assert.IsFalse(checker.IsMemoryKey("%"));
            Assert.IsFalse(checker.IsMemoryKey("8"));
            Assert.IsFalse(checker.IsMemoryKey(")"));
            Assert.IsFalse(checker.IsMemoryKey("="));
        }
    }
}