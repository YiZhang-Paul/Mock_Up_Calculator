using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class OperatorConverterTest {

        List<string[]> operators = new List<string[]>() {

            new string[] {

                "√", "¹⁄ x", "eˣ", "sqr", "cube",
                "fact", "log", "ln", "dms", "degrees", "negate",
                "sin", "cos", "tan", "sinh", "cosh", "tanh",
                "sin⁻¹", "cos⁻¹", "tan⁻¹", "sinh⁻¹", "cosh⁻¹", "tanh⁻¹"
            },

            new string[] { "^", "Exp", "yroot" },
            new string[] { "×", "÷", "Mod" },
            new string[] { "+", "−" }
        };

        OperatorConverter converter;

        [TestInitialize]
        public void Setup() {

            converter = new OperatorConverter(operators);
        }

        [TestMethod]
        public void IsInvalidOperator() {

            Assert.IsFalse(converter.IsOperator("#"));
        }

        [TestMethod]
        public void IsValidOperator() {

            Assert.IsTrue(converter.IsOperator("Mod"));
        }

        [TestMethod]
        public void IsInvalidUnaryOperator() {

            Assert.IsFalse(converter.IsUnary("Mod"));
        }

        [TestMethod]
        public void IsValidUnaryOperator() {

            Assert.IsTrue(converter.IsUnary("fact"));
        }

        [TestMethod]
        public void IsInvalidBinaryOperator() {

            Assert.IsFalse(converter.IsBinary("fact"));
            Assert.IsFalse(converter.IsBinary("#"));
        }

        [TestMethod]
        public void IsValidBinaryOperator() {

            Assert.IsTrue(converter.IsBinary("Mod"));
        }

        [TestMethod]
        public void ConvertValidOperatorToValue() {

            Assert.AreEqual(30, converter.ToValue("−"));
        }

        [TestMethod]
        public void ConvertInvalidOperatorToValue() {

            Assert.AreEqual(-1, converter.ToValue("#"));
        }

        [TestMethod]
        public void ConvertToOperator() {

            Assert.AreEqual("Mod", converter.ToOperator(28));
        }
    }
}