using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;
using ExpressionsClassLibrary;
using Moq;

namespace ExpressionsTest {
    [TestClass]
    public class EvaluatorTest {

        Mock<IUnitConverter> unitConverter;
        Mock<IOperatorConverter> operatorConverter;
        Mock<IOperatorLookup> lookup;
        Evaluator evaluator;

        private INode MockNode(decimal value, bool isOperand, INode left, INode right) {

            var node = new Mock<INode>();

            node.Setup(x => x.Value).Returns(value);
            node.Setup(x => x.IsOperand).Returns(isOperand);
            node.Setup(x => x.Left).Returns(left);
            node.Setup(x => x.Right).Returns(right);

            return node.Object;
        }

        private INode MockParseTree(decimal operand1, decimal operand2 = 0) {

            var left = MockNode(operand1, true, null, null);
            var right = MockNode(operand2, true, null, null);

            return MockNode(0, false, left, right);
        }

        private void SetupOperatorConverter(string output) {

            operatorConverter.Setup(x => x.ToOperator(It.IsAny<int>())).Returns(output);
        }

        private void SetupLookup() {

            lookup.Setup(x => x.SquareRoot).Returns("√");
            lookup.Setup(x => x.Square).Returns("sqr");
            lookup.Setup(x => x.Cube).Returns("cube");
            lookup.Setup(x => x.Exponential).Returns("eˣ");
            lookup.Setup(x => x.Factorial).Returns("fact");
            lookup.Setup(x => x.Log).Returns("log");
            lookup.Setup(x => x.Ln).Returns("ln");
            lookup.Setup(x => x.Dms).Returns("dms");
            lookup.Setup(x => x.Degrees).Returns("degrees");
            lookup.Setup(x => x.Negate).Returns("negate");
            lookup.Setup(x => x.Reciprocal).Returns("¹⁄x");
            lookup.Setup(x => x.PowerOfTen).Returns("10ˣ");
            lookup.Setup(x => x.SineDEG).Returns("sin₀");
            lookup.Setup(x => x.SineRAD).Returns("sinᵣ");
            lookup.Setup(x => x.SineGRAD).Returns("sin₉");
            lookup.Setup(x => x.CosineDEG).Returns("cos₀");
            lookup.Setup(x => x.CosineRAD).Returns("cosᵣ");
            lookup.Setup(x => x.CosineGRAD).Returns("cos₉");
            lookup.Setup(x => x.TangentDEG).Returns("tan₀");
            lookup.Setup(x => x.TangentRAD).Returns("tanᵣ");
            lookup.Setup(x => x.TangentGRAD).Returns("tan₉");
            lookup.Setup(x => x.ArcSinDEG).Returns("sin₀⁻¹");
            lookup.Setup(x => x.ArcSinRAD).Returns("sinᵣ⁻¹");
            lookup.Setup(x => x.ArcSinGRAD).Returns("sin₉⁻¹");
            lookup.Setup(x => x.ArcCosDEG).Returns("cos₀⁻¹");
            lookup.Setup(x => x.ArcCosRAD).Returns("cosᵣ⁻¹");
            lookup.Setup(x => x.ArcCosGRAD).Returns("cos₉⁻¹");
            lookup.Setup(x => x.ArcTanDEG).Returns("tan₀⁻¹");
            lookup.Setup(x => x.ArcTanRAD).Returns("tanᵣ⁻¹");
            lookup.Setup(x => x.ArcTanGRAD).Returns("tan₉⁻¹");
            lookup.Setup(x => x.Sinh).Returns("sinh");
            lookup.Setup(x => x.Cosh).Returns("cosh");
            lookup.Setup(x => x.Tanh).Returns("tanh");
            lookup.Setup(x => x.ArcSinh).Returns("sinh⁻¹");
            lookup.Setup(x => x.ArcCosh).Returns("cosh⁻¹");
            lookup.Setup(x => x.ArcTanh).Returns("tanh⁻¹");
            lookup.Setup(x => x.Power).Returns("^");
            lookup.Setup(x => x.Exp).Returns("Exp");
            lookup.Setup(x => x.NthRoot).Returns("yroot");
            lookup.Setup(x => x.Multiply).Returns("×");
            lookup.Setup(x => x.Divide).Returns("÷");
            lookup.Setup(x => x.Modulus).Returns("Mod");
            lookup.Setup(x => x.Plus).Returns("+");
            lookup.Setup(x => x.Minus).Returns("−");
            lookup.Setup(x => x.PI).Returns("π");
        }

        private bool IsAccurate(decimal expected, decimal actual, int precision = 2) {

            return Math.Abs(actual - expected) <= (decimal)Math.Pow(0.1, precision);
        }

        [TestInitialize]
        public void Setup() {

            unitConverter = new Mock<IUnitConverter>();
            operatorConverter = new Mock<IOperatorConverter>();
            lookup = new Mock<IOperatorLookup>();
            SetupLookup();
            evaluator = new Evaluator(unitConverter.Object, operatorConverter.Object, lookup.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "Invalid Operator.")]
        public void InvalidOperator() {

            SetupOperatorConverter("$");

            evaluator.Evaluate(MockParseTree(5.13m, 5));
        }

        [TestMethod]
        public void Add() {

            SetupOperatorConverter(lookup.Object.Plus);

            Assert.AreEqual(10.13m, evaluator.Evaluate(MockParseTree(5.13m, 5)));
            Assert.AreEqual(0.13m, evaluator.Evaluate(MockParseTree(5.13m, -5)));
        }

        [TestMethod]
        public void Subtract() {

            SetupOperatorConverter(lookup.Object.Minus);

            Assert.AreEqual(-2.5m, evaluator.Evaluate(MockParseTree(5, 7.5m)));
            Assert.AreEqual(12.5m, evaluator.Evaluate(MockParseTree(5, -7.5m)));
        }

        [TestMethod]
        public void Multiply() {

            SetupOperatorConverter(lookup.Object.Multiply);

            Assert.AreEqual(37.75m, evaluator.Evaluate(MockParseTree(5, 7.55m)));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void DivideByZero() {

            SetupOperatorConverter(lookup.Object.Divide);

            evaluator.Evaluate(MockParseTree(5, 0));
        }

        [TestMethod]
        public void Divide() {

            SetupOperatorConverter(lookup.Object.Divide);

            Assert.AreEqual(1.25m, evaluator.Evaluate(MockParseTree(5, 4)));
        }

        [TestMethod]
        public void Modulus() {

            SetupOperatorConverter(lookup.Object.Modulus);

            Assert.AreEqual(1, evaluator.Evaluate(MockParseTree(5, -2)));
            Assert.AreEqual(5, evaluator.Evaluate(MockParseTree(5, 7)));
            Assert.AreEqual(2, evaluator.Evaluate(MockParseTree(5, 3)));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Square Root.")]
        public void InvalidSquareRoot() {

            SetupOperatorConverter(lookup.Object.SquareRoot);

            evaluator.Evaluate(MockParseTree(-1));
        }

        [TestMethod]
        public void SquareRoot() {

            SetupOperatorConverter(lookup.Object.SquareRoot);

            Assert.IsTrue(IsAccurate(2.23606797m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(1.64316767m, evaluator.Evaluate(MockParseTree(2.7m))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0))));
        }

        [TestMethod]
        public void Square() {

            SetupOperatorConverter(lookup.Object.Square);

            Assert.IsTrue(IsAccurate(25, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(7.29m, evaluator.Evaluate(MockParseTree(-2.7m))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0))));
        }

        [TestMethod]
        public void Cube() {

            SetupOperatorConverter(lookup.Object.Cube);

            Assert.IsTrue(IsAccurate(125, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(-19.683m, evaluator.Evaluate(MockParseTree(-2.7m))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0))));
        }

        [TestMethod]
        public void ToPowerOfTen() {

            SetupOperatorConverter(lookup.Object.Exp);

            Assert.IsTrue(IsAccurate(500, evaluator.Evaluate(MockParseTree(5, 2))));
            Assert.IsTrue(IsAccurate(1000.3m, evaluator.Evaluate(MockParseTree(1.0003m, 3))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0, 10))));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidFactorial() {

            SetupOperatorConverter(lookup.Object.Factorial);

            evaluator.Evaluate(MockParseTree(99));
        }

        [TestMethod]
        public void Factorial() {

            SetupOperatorConverter(lookup.Object.Factorial);

            Assert.IsTrue(IsAccurate(120, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(MockParseTree(0))));
            Assert.IsTrue(IsAccurate(1307674368000, evaluator.Evaluate(MockParseTree(15))));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidLog() {

            SetupOperatorConverter(lookup.Object.Log);

            evaluator.Evaluate(MockParseTree(-0.1m));
        }

        [TestMethod]
        public void Log() {

            SetupOperatorConverter(lookup.Object.Log);

            Assert.IsTrue(IsAccurate(0.69897000433m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(-1, evaluator.Evaluate(MockParseTree(0.1m))));
            Assert.IsTrue(IsAccurate(0.57634135020m, evaluator.Evaluate(MockParseTree(3.77m))));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidNaturalLogarithm() {

            SetupOperatorConverter(lookup.Object.Ln);

            evaluator.Evaluate(MockParseTree(-1));
        }

        [TestMethod]
        public void NaturalLogarithm() {

            SetupOperatorConverter(lookup.Object.Ln);

            Assert.IsTrue(IsAccurate(1.609437912434m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(1.137833001821m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(2.708050201102m, evaluator.Evaluate(MockParseTree(15))));
        }

        [TestMethod]
        public void SineDegree() {

            SetupOperatorConverter(lookup.Object.SineDEG);

            unitConverter.Setup(x => x.DegreeToRadian(It.IsAny<decimal>()))
                         .Returns(0.08726646259971647884618453842443m);

            Assert.IsTrue(IsAccurate(0.087155742747m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void SineRadian() {

            SetupOperatorConverter(lookup.Object.SineRAD);

            Assert.IsTrue(IsAccurate(-0.95892427466m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(0.021590975726m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(0.993901956906m, evaluator.Evaluate(MockParseTree(-1500))));
        }

        [TestMethod]
        public void SineGradian() {

            SetupOperatorConverter(lookup.Object.SineGRAD);
            unitConverter.Setup(x => x.GradianToRadian(It.IsAny<decimal>())).Returns(0.0785375m);

            Assert.IsTrue(IsAccurate(0.078459095727m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void CosineDegree() {

            SetupOperatorConverter(lookup.Object.CosineDEG);

            unitConverter.Setup(x => x.DegreeToRadian(It.IsAny<decimal>()))
                         .Returns(0.08726646259971647884618453842443m);

            Assert.IsTrue(IsAccurate(0.996194698091m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void CosineRadian() {

            SetupOperatorConverter(lookup.Object.CosineRAD);

            Assert.IsTrue(IsAccurate(0.283662185463m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(-0.99976688771m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(-0.11026740251m, evaluator.Evaluate(MockParseTree(-1500))));
        }

        [TestMethod]
        public void CosineGradian() {

            SetupOperatorConverter(lookup.Object.CosineGRAD);
            unitConverter.Setup(x => x.GradianToRadian(It.IsAny<decimal>())).Returns(0.0785375m);

            Assert.IsTrue(IsAccurate(0.996917333733m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void TangentDegree() {

            SetupOperatorConverter(lookup.Object.TangentDEG);

            unitConverter.Setup(x => x.DegreeToRadian(It.IsAny<decimal>()))
                         .Returns(0.08726646259971647884618453842443m);

            Assert.IsTrue(IsAccurate(0.087488663525m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void TangentRadian() {

            SetupOperatorConverter(lookup.Object.TangentRAD);

            Assert.IsTrue(IsAccurate(-3.38051500624m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(-0.02159601002m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(-9.01356098220m, evaluator.Evaluate(MockParseTree(-1500))));
        }

        [TestMethod]
        public void TangentGradian() {

            SetupOperatorConverter(lookup.Object.TangentGRAD);
            unitConverter.Setup(x => x.GradianToRadian(It.IsAny<decimal>())).Returns(0.0785375m);

            Assert.IsTrue(IsAccurate(0.0787017068246m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcSineDegree() {

            SetupOperatorConverter(lookup.Object.ArcSinDEG);

            evaluator.Evaluate(MockParseTree(1.01m));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcSineRadian() {

            SetupOperatorConverter(lookup.Object.ArcSinRAD);

            evaluator.Evaluate(MockParseTree(1.01m));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcSineGradian() {

            SetupOperatorConverter(lookup.Object.ArcSinGRAD);

            evaluator.Evaluate(MockParseTree(1.01m));
        }

        [TestMethod]
        public void ArcSineDegree() {

            SetupOperatorConverter(lookup.Object.ArcSinDEG);
            unitConverter.Setup(x => x.RadianToDegree(It.IsAny<decimal>())).Returns(90);

            Assert.IsTrue(IsAccurate(90, evaluator.Evaluate(MockParseTree(1))));
        }

        [TestMethod]
        public void ArcSineRadian() {

            SetupOperatorConverter(lookup.Object.ArcSinRAD);

            Assert.IsTrue(IsAccurate(1.5707963267m, evaluator.Evaluate(MockParseTree(1))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0))));
            Assert.IsTrue(IsAccurate(-0.523598775m, evaluator.Evaluate(MockParseTree(-0.5m))));
        }

        [TestMethod]
        public void ArcSineGradian() {

            SetupOperatorConverter(lookup.Object.ArcSinGRAD);
            unitConverter.Setup(x => x.RadianToGradian(It.IsAny<decimal>())).Returns(100);

            Assert.IsTrue(IsAccurate(100, evaluator.Evaluate(MockParseTree(1))));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcCosineDegree() {

            SetupOperatorConverter(lookup.Object.ArcCosDEG);

            evaluator.Evaluate(MockParseTree(1.01m));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcCosineRadian() {

            SetupOperatorConverter(lookup.Object.ArcCosRAD);

            evaluator.Evaluate(MockParseTree(1.01m));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcCosineGradian() {

            SetupOperatorConverter(lookup.Object.ArcCosGRAD);

            evaluator.Evaluate(MockParseTree(1.01m));
        }

        [TestMethod]
        public void ArcCosineDegree() {

            SetupOperatorConverter(lookup.Object.ArcCosDEG);
            unitConverter.Setup(x => x.RadianToDegree(It.IsAny<decimal>())).Returns(60);

            Assert.IsTrue(IsAccurate(60, evaluator.Evaluate(MockParseTree(0.5m))));
        }

        [TestMethod]
        public void ArcCosineRadian() {

            SetupOperatorConverter(lookup.Object.ArcCosRAD);

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(1))));
            Assert.IsTrue(IsAccurate(1.57079632679m, evaluator.Evaluate(MockParseTree(0))));
            Assert.IsTrue(IsAccurate(2.09439510239m, evaluator.Evaluate(MockParseTree(-0.5m))));
        }

        [TestMethod]
        public void ArcCosineGradian() {

            SetupOperatorConverter(lookup.Object.ArcCosGRAD);

            unitConverter.Setup(x => x.RadianToGradian(It.IsAny<decimal>()))
                         .Returns(66.666666666666666666666666666667m);

            Assert.IsTrue(IsAccurate(66.6666666666m, evaluator.Evaluate(MockParseTree(0.5m))));
        }

        [TestMethod]
        public void ArcTangentDegree() {

            SetupOperatorConverter(lookup.Object.ArcTanDEG);

            unitConverter.Setup(x => x.RadianToDegree(It.IsAny<decimal>()))
                         .Returns(78.69006752597978691352549456166m);

            Assert.IsTrue(IsAccurate(78.6900675259m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void ArcTangentRadian() {

            SetupOperatorConverter(lookup.Object.ArcTanRAD);

            Assert.IsTrue(IsAccurate(1.37340076694m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0))));
            Assert.IsTrue(IsAccurate(-0.4636476090m, evaluator.Evaluate(MockParseTree(-0.5m))));
        }

        [TestMethod]
        public void ArcTangentGradian() {

            SetupOperatorConverter(lookup.Object.ArcTanGRAD);

            unitConverter.Setup(x => x.RadianToGradian(It.IsAny<decimal>()))
                         .Returns(87.433408362199763237250549512956m);

            Assert.IsTrue(IsAccurate(87.4334083621m, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void Sinh() {

            SetupOperatorConverter(lookup.Object.Sinh);

            Assert.IsTrue(IsAccurate(74.2032105777m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(11.3011112373m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(-74.203210577m, evaluator.Evaluate(MockParseTree(-5))));
        }

        [TestMethod]
        public void Cosh() {

            SetupOperatorConverter(lookup.Object.Cosh);

            Assert.IsTrue(IsAccurate(74.2099485247m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(11.3452684057m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(74.2099485247m, evaluator.Evaluate(MockParseTree(-5))));
        }

        [TestMethod]
        public void Tanh() {

            SetupOperatorConverter(lookup.Object.Tanh);

            Assert.IsTrue(IsAccurate(0.99990920426m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(0.99610787802m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(-1, evaluator.Evaluate(MockParseTree(-5000))));
        }

        [TestMethod]
        public void ArcSinh() {

            SetupOperatorConverter(lookup.Object.ArcSinh);

            Assert.IsTrue(IsAccurate(2.31243834127m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(1.85572586122m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(-2.3124383412m, evaluator.Evaluate(MockParseTree(-5))));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Input.")]
        public void InvalidArcCosh() {

            SetupOperatorConverter(lookup.Object.ArcCosh);

            evaluator.Evaluate(MockParseTree(0.99m));
        }

        [TestMethod]
        public void ArcCosh() {

            SetupOperatorConverter(lookup.Object.ArcCosh);

            Assert.IsTrue(IsAccurate(2.2924316695m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(1.8042481325m, evaluator.Evaluate(MockParseTree(3.12m))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(1))));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Input.")]
        public void InvalidArcTanh() {

            SetupOperatorConverter(lookup.Object.ArcTanh);

            evaluator.Evaluate(MockParseTree(1.01m));
        }

        [TestMethod]
        public void ArcTanh() {

            SetupOperatorConverter(lookup.Object.ArcTanh);

            Assert.IsTrue(IsAccurate(2.6466524123m, evaluator.Evaluate(MockParseTree(0.99m))));
            Assert.IsTrue(IsAccurate(0.5493061443m, evaluator.Evaluate(MockParseTree(0.5m))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0))));
        }

        [TestMethod]
        public void ToPower() {

            SetupOperatorConverter(lookup.Object.Power);

            Assert.IsTrue(IsAccurate(78125, evaluator.Evaluate(MockParseTree(5, 7))));
            Assert.IsTrue(IsAccurate(0.0002441m, evaluator.Evaluate(MockParseTree(0.5m, 12))));
            Assert.IsTrue(IsAccurate(0.04m, evaluator.Evaluate(MockParseTree(5, -2))));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void InvalidReciprocal() {

            SetupOperatorConverter(lookup.Object.Reciprocal);

            evaluator.Evaluate(MockParseTree(0));
        }

        [TestMethod]
        public void Reciprocal() {

            SetupOperatorConverter(lookup.Object.Reciprocal);

            Assert.IsTrue(IsAccurate(0.2m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(2, evaluator.Evaluate(MockParseTree(0.5m))));
            Assert.IsTrue(IsAccurate(-0.333333333m, evaluator.Evaluate(MockParseTree(-3))));
        }

        [TestMethod]
        public void Negate() {

            SetupOperatorConverter(lookup.Object.Negate);

            Assert.IsTrue(IsAccurate(-5, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(MockParseTree(0))));
            Assert.IsTrue(IsAccurate(3.77m, evaluator.Evaluate(MockParseTree(-3.77m))));
        }

        [TestMethod]
        public void Exponential() {

            SetupOperatorConverter(lookup.Object.Exponential);

            Assert.IsTrue(IsAccurate(148.41315910257m, evaluator.Evaluate(MockParseTree(5))));
            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(MockParseTree(0))));
            Assert.IsTrue(IsAccurate(0.0230520632872m, evaluator.Evaluate(MockParseTree(-3.77m))));
        }

        [TestMethod]
        public void PowerOfTen() {

            SetupOperatorConverter(lookup.Object.PowerOfTen);

            Assert.IsTrue(IsAccurate(100000, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void DmsToDegrees() {

            SetupOperatorConverter(lookup.Object.Degrees);
            unitConverter.Setup(x => x.DmsToDegree(It.IsAny<decimal>())).Returns(1);

            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(MockParseTree(5))));
        }

        [TestMethod]
        public void DegreesToDms() {

            SetupOperatorConverter(lookup.Object.Dms);
            unitConverter.Setup(x => x.DegreeToDms(It.IsAny<decimal>())).Returns(1);

            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(MockParseTree(5))));
        }
    }
}