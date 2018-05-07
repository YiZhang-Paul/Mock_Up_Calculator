using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;

namespace ExpressionsTest {
    [TestClass]
    public class OperatorLookupTest {

        OperatorLookup lookup;

        [TestInitialize]
        public void Setup() {

            lookup = new OperatorLookup();
        }

        [TestMethod]
        public void LookupOperators() {

            Assert.AreEqual("√", lookup.SquareRoot);
            Assert.AreEqual("sqr", lookup.Square);
            Assert.AreEqual("cube", lookup.Cube);
            Assert.AreEqual("eˣ", lookup.Exponential);
            Assert.AreEqual("fact", lookup.Factorial);
            Assert.AreEqual("log", lookup.Log);
            Assert.AreEqual("ln", lookup.Ln);
            Assert.AreEqual("dms", lookup.Dms);
            Assert.AreEqual("degrees", lookup.Degrees);
            Assert.AreEqual("negate", lookup.Negate);
            Assert.AreEqual("¹⁄x", lookup.Reciprocal);
            Assert.AreEqual("10ˣ", lookup.PowerOfTen);
            Assert.AreEqual("sin₀", lookup.SineDEG);
            Assert.AreEqual("sinᵣ", lookup.SineRAD);
            Assert.AreEqual("sin₉", lookup.SineGRAD);
            Assert.AreEqual("cos₀", lookup.CosineDEG);
            Assert.AreEqual("cosᵣ", lookup.CosineRAD);
            Assert.AreEqual("cos₉", lookup.CosineGRAD);
            Assert.AreEqual("tan₀", lookup.TangentDEG);
            Assert.AreEqual("tanᵣ", lookup.TangentRAD);
            Assert.AreEqual("tan₉", lookup.TangentGRAD);
            Assert.AreEqual("sin₀⁻¹", lookup.ArcSinDEG);
            Assert.AreEqual("sinᵣ⁻¹", lookup.ArcSinRAD);
            Assert.AreEqual("sin₉⁻¹", lookup.ArcSinGRAD);
            Assert.AreEqual("cos₀⁻¹", lookup.ArcCosDEG);
            Assert.AreEqual("cosᵣ⁻¹", lookup.ArcCosRAD);
            Assert.AreEqual("cos₉⁻¹", lookup.ArcCosGRAD);
            Assert.AreEqual("tan₀⁻¹", lookup.ArcTanDEG);
            Assert.AreEqual("tanᵣ⁻¹", lookup.ArcTanRAD);
            Assert.AreEqual("tan₉⁻¹", lookup.ArcTanGRAD);
            Assert.AreEqual("sinh", lookup.Sinh);
            Assert.AreEqual("cosh", lookup.Cosh);
            Assert.AreEqual("tanh", lookup.Tanh);
            Assert.AreEqual("sinh⁻¹", lookup.ArcSinh);
            Assert.AreEqual("cosh⁻¹", lookup.ArcCosh);
            Assert.AreEqual("tanh⁻¹", lookup.ArcTanh);
            Assert.AreEqual("^", lookup.Power);
            Assert.AreEqual("Exp", lookup.Exp);
            Assert.AreEqual("yroot", lookup.NthRoot);
            Assert.AreEqual("×", lookup.Multiply);
            Assert.AreEqual("÷", lookup.Divide);
            Assert.AreEqual("Mod", lookup.Modulus);
            Assert.AreEqual("+", lookup.Plus);
            Assert.AreEqual("−", lookup.Minus);
            Assert.AreEqual("π", lookup.PI);
        }

        [TestMethod]
        public void CheckPrecedence() {

            var precedence = lookup.Precedence.Select(group => {

                return new HashSet<string>(group);

            }).ToArray();

            Assert.IsTrue(precedence[0].Contains(lookup.SquareRoot));
            Assert.IsTrue(precedence[0].Contains(lookup.Square));
            Assert.IsTrue(precedence[0].Contains(lookup.Cube));
            Assert.IsTrue(precedence[0].Contains(lookup.Exponential));
            Assert.IsTrue(precedence[0].Contains(lookup.Factorial));
            Assert.IsTrue(precedence[0].Contains(lookup.Log));
            Assert.IsTrue(precedence[0].Contains(lookup.Ln));
            Assert.IsTrue(precedence[0].Contains(lookup.Dms));
            Assert.IsTrue(precedence[0].Contains(lookup.Degrees));
            Assert.IsTrue(precedence[0].Contains(lookup.Negate));
            Assert.IsTrue(precedence[0].Contains(lookup.Reciprocal));
            Assert.IsTrue(precedence[0].Contains(lookup.PowerOfTen));
            Assert.IsTrue(precedence[0].Contains(lookup.SineDEG));
            Assert.IsTrue(precedence[0].Contains(lookup.SineRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.SineGRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.CosineDEG));
            Assert.IsTrue(precedence[0].Contains(lookup.CosineRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.CosineGRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.TangentDEG));
            Assert.IsTrue(precedence[0].Contains(lookup.TangentRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.TangentGRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcSinDEG));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcSinRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcSinGRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcCosDEG));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcCosRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcCosGRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcTanDEG));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcTanRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcTanGRAD));
            Assert.IsTrue(precedence[0].Contains(lookup.Sinh));
            Assert.IsTrue(precedence[0].Contains(lookup.Cosh));
            Assert.IsTrue(precedence[0].Contains(lookup.Tanh));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcSinh));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcCosh));
            Assert.IsTrue(precedence[0].Contains(lookup.ArcTanh));

            Assert.IsTrue(precedence[1].Contains(lookup.Power));
            Assert.IsTrue(precedence[1].Contains(lookup.Exp));
            Assert.IsTrue(precedence[1].Contains(lookup.NthRoot));

            Assert.IsTrue(precedence[2].Contains(lookup.Multiply));
            Assert.IsTrue(precedence[2].Contains(lookup.Divide));
            Assert.IsTrue(precedence[2].Contains(lookup.Modulus));

            Assert.IsTrue(precedence[3].Contains(lookup.Plus));
            Assert.IsTrue(precedence[3].Contains(lookup.Minus));
        }

        [TestMethod]
        public void IsOperator() {

            var operators = new HashSet<string>(lookup.Operators);

            Assert.IsTrue(operators.Contains(lookup.SquareRoot));
            Assert.IsTrue(operators.Contains(lookup.Square));
            Assert.IsTrue(operators.Contains(lookup.Cube));
            Assert.IsTrue(operators.Contains(lookup.Exponential));
            Assert.IsTrue(operators.Contains(lookup.Factorial));
            Assert.IsTrue(operators.Contains(lookup.Log));
            Assert.IsTrue(operators.Contains(lookup.Ln));
            Assert.IsTrue(operators.Contains(lookup.Dms));
            Assert.IsTrue(operators.Contains(lookup.Degrees));
            Assert.IsTrue(operators.Contains(lookup.Negate));
            Assert.IsTrue(operators.Contains(lookup.Reciprocal));
            Assert.IsTrue(operators.Contains(lookup.PowerOfTen));
            Assert.IsTrue(operators.Contains(lookup.SineDEG));
            Assert.IsTrue(operators.Contains(lookup.SineRAD));
            Assert.IsTrue(operators.Contains(lookup.SineGRAD));
            Assert.IsTrue(operators.Contains(lookup.CosineDEG));
            Assert.IsTrue(operators.Contains(lookup.CosineRAD));
            Assert.IsTrue(operators.Contains(lookup.CosineGRAD));
            Assert.IsTrue(operators.Contains(lookup.TangentDEG));
            Assert.IsTrue(operators.Contains(lookup.TangentRAD));
            Assert.IsTrue(operators.Contains(lookup.TangentGRAD));
            Assert.IsTrue(operators.Contains(lookup.ArcSinDEG));
            Assert.IsTrue(operators.Contains(lookup.ArcSinRAD));
            Assert.IsTrue(operators.Contains(lookup.ArcSinGRAD));
            Assert.IsTrue(operators.Contains(lookup.ArcCosDEG));
            Assert.IsTrue(operators.Contains(lookup.ArcCosRAD));
            Assert.IsTrue(operators.Contains(lookup.ArcCosGRAD));
            Assert.IsTrue(operators.Contains(lookup.ArcTanDEG));
            Assert.IsTrue(operators.Contains(lookup.ArcTanRAD));
            Assert.IsTrue(operators.Contains(lookup.ArcTanGRAD));
            Assert.IsTrue(operators.Contains(lookup.Sinh));
            Assert.IsTrue(operators.Contains(lookup.Cosh));
            Assert.IsTrue(operators.Contains(lookup.Tanh));
            Assert.IsTrue(operators.Contains(lookup.ArcSinh));
            Assert.IsTrue(operators.Contains(lookup.ArcCosh));
            Assert.IsTrue(operators.Contains(lookup.ArcTanh));
            Assert.IsTrue(operators.Contains(lookup.Power));
            Assert.IsTrue(operators.Contains(lookup.Exp));
            Assert.IsTrue(operators.Contains(lookup.NthRoot));
            Assert.IsTrue(operators.Contains(lookup.Multiply));
            Assert.IsTrue(operators.Contains(lookup.Divide));
            Assert.IsTrue(operators.Contains(lookup.Modulus));
            Assert.IsTrue(operators.Contains(lookup.Plus));
            Assert.IsTrue(operators.Contains(lookup.Minus));
        }

        [TestMethod]
        public void IsNotOperator() {

            var operators = new HashSet<string>(lookup.Operators);

            Assert.IsFalse(operators.Contains(lookup.PI));
            Assert.IsFalse(operators.Contains("#"));
            Assert.IsFalse(operators.Contains("$"));
            Assert.IsFalse(operators.Contains("5"));
            Assert.IsFalse(operators.Contains("C"));
        }

        [TestMethod]
        public void IsUnary() {

            Assert.IsTrue(lookup.Unary.Contains(lookup.SquareRoot));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Square));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Cube));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Exponential));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Factorial));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Log));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Ln));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Dms));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Degrees));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Negate));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Reciprocal));
            Assert.IsTrue(lookup.Unary.Contains(lookup.PowerOfTen));
            Assert.IsTrue(lookup.Unary.Contains(lookup.SineDEG));
            Assert.IsTrue(lookup.Unary.Contains(lookup.SineRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.SineGRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.CosineDEG));
            Assert.IsTrue(lookup.Unary.Contains(lookup.CosineRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.CosineGRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.TangentDEG));
            Assert.IsTrue(lookup.Unary.Contains(lookup.TangentRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.TangentGRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcSinDEG));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcSinRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcSinGRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcCosDEG));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcCosRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcCosGRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcTanDEG));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcTanRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcTanGRAD));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Sinh));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Cosh));
            Assert.IsTrue(lookup.Unary.Contains(lookup.Tanh));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcSinh));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcCosh));
            Assert.IsTrue(lookup.Unary.Contains(lookup.ArcTanh));
        }

        [TestMethod]
        public void IsNotUnary() {

            Assert.IsFalse(lookup.Unary.Contains(lookup.Power));
            Assert.IsFalse(lookup.Unary.Contains(lookup.Exp));
            Assert.IsFalse(lookup.Unary.Contains(lookup.NthRoot));
            Assert.IsFalse(lookup.Unary.Contains(lookup.Multiply));
            Assert.IsFalse(lookup.Unary.Contains(lookup.Divide));
            Assert.IsFalse(lookup.Unary.Contains(lookup.Modulus));
            Assert.IsFalse(lookup.Unary.Contains(lookup.Plus));
            Assert.IsFalse(lookup.Unary.Contains(lookup.Minus));
        }
    }
}