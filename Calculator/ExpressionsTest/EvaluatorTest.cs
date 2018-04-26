using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;
using ExpressionsClassLibrary;
using Moq;

namespace ExpressionsTest {
    [TestClass]
    public class EvaluatorTest {

        Mock<IUnitConverter> unitConverter;
        OperatorConverter operatorConverter;
        ExpressionParser parser;
        Evaluator evaluator;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 2) {

            return Math.Abs(actual - expected) <= (decimal)Math.Pow(0.1, precision);
        }

        [TestInitialize]
        public void Setup() {

            unitConverter = new Mock<IUnitConverter>();
            operatorConverter = new OperatorConverter(OperatorLookup.Operators);
            parser = new ExpressionParser(operatorConverter);
            evaluator = new Evaluator(unitConverter.Object, operatorConverter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "Invalid Operator.")]
        public void InvalidOperator() {

            var mockConverter = new Mock<IOperatorConverter>();
            mockConverter.Setup(x => x.ToOperator(It.IsAny<int>())).Returns("#");
            evaluator = new Evaluator(unitConverter.Object, mockConverter.Object);

            var node = parser.Parse("( 5.13 " + OperatorLookup.Plus + " 5 )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void Add() {

            var node = parser.Parse("( 5.13 " + OperatorLookup.Plus + " 5 )");

            Assert.AreEqual(10.13m, evaluator.Evaluate(node));

            node = parser.Parse("( 5.13 " + OperatorLookup.Plus + " -5 )");

            Assert.AreEqual(0.13m, evaluator.Evaluate(node));
        }

        [TestMethod]
        public void Subtract() {

            var node = parser.Parse("( 5 " + OperatorLookup.Minus + " 7.5 )");

            Assert.AreEqual(-2.5m, evaluator.Evaluate(node));

            node = parser.Parse("( 5 " + OperatorLookup.Minus + " -7.5 )");

            Assert.AreEqual(12.5m, evaluator.Evaluate(node));
        }

        [TestMethod]
        public void Multiply() {

            var node = parser.Parse("( 5 " + OperatorLookup.Multiply + " 7.55 )");

            Assert.AreEqual(37.75m, evaluator.Evaluate(node));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void DivideByZero() {

            var node = parser.Parse("( 5 " + OperatorLookup.Divide + " 0 )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void Divide() {

            var node = parser.Parse("( 5 " + OperatorLookup.Divide + " 4 )");

            Assert.AreEqual(1.25m, evaluator.Evaluate(node));
        }

        [TestMethod]
        public void Modulus() {

            var node = parser.Parse("( 5 " + OperatorLookup.Modulus + " -2 )");

            Assert.AreEqual(1, evaluator.Evaluate(node));

            node = parser.Parse("( 5 " + OperatorLookup.Modulus + " 7 )");

            Assert.AreEqual(5, evaluator.Evaluate(node));

            node = parser.Parse("( 5 " + OperatorLookup.Modulus + " 3 )");

            Assert.AreEqual(2, evaluator.Evaluate(node));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Square Root.")]
        public void InvalidSquareRoot() {

            var node = parser.Parse("( -1 " + OperatorLookup.SquareRoot + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void SquareRoot() {

            var node = parser.Parse("( 5 " + OperatorLookup.SquareRoot + " )");

            Assert.IsTrue(IsAccurate(2.2360679774997896964091736687313m, evaluator.Evaluate(node)));

            node = parser.Parse("( 2.7 " + OperatorLookup.SquareRoot + " )");

            Assert.IsTrue(IsAccurate(1.6431676725154983403709093484024m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.SquareRoot + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Square() {

            var node = parser.Parse("( 5 " + OperatorLookup.Square + " )");

            Assert.IsTrue(IsAccurate(25, evaluator.Evaluate(node)));

            node = parser.Parse("( -2.7 " + OperatorLookup.Square + " )");

            Assert.IsTrue(IsAccurate(7.29m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.Square + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Cube() {

            var node = parser.Parse("( 5 " + OperatorLookup.Cube + " )");

            Assert.IsTrue(IsAccurate(125, evaluator.Evaluate(node)));

            node = parser.Parse("( -2.7 " + OperatorLookup.Cube + " )");

            Assert.IsTrue(IsAccurate(-19.683m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.Cube + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void ToPowerOfTen() {

            var node = parser.Parse("( 5 " + OperatorLookup.Exp + " 2 )");

            Assert.IsTrue(IsAccurate(500, evaluator.Evaluate(node)));

            node = parser.Parse("( 1.0003 " + OperatorLookup.Exp + " 3 )");

            Assert.IsTrue(IsAccurate(1000.3m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.Exp + " 10 )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidFactorial() {

            var node = parser.Parse("( 99 " + OperatorLookup.Factorial + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void Factorial() {

            var node = parser.Parse("( 5 " + OperatorLookup.Factorial + " )");

            Assert.IsTrue(IsAccurate(120, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.Factorial + " )");

            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(node)));

            node = parser.Parse("( 15 " + OperatorLookup.Factorial + " )");

            Assert.IsTrue(IsAccurate(1307674368000, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidLog() {

            var node = parser.Parse("( -0.1 " + OperatorLookup.Log + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void Log() {

            var node = parser.Parse("( 5 " + OperatorLookup.Log + " )");

            Assert.IsTrue(IsAccurate(0.69897000433601880478626110527551m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0.1 " + OperatorLookup.Log + " )");

            Assert.IsTrue(IsAccurate(-1, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.77 " + OperatorLookup.Log + " )");

            Assert.IsTrue(IsAccurate(0.57634135020579285653935192091158m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidNaturalLogarithm() {

            var node = parser.Parse("( -1 " + OperatorLookup.Ln + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void NaturalLogarithm() {

            var node = parser.Parse("( 5 " + OperatorLookup.Ln + " )");

            Assert.IsTrue(IsAccurate(1.6094379124341003746007593332262m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.Ln + " )");

            Assert.IsTrue(IsAccurate(1.1378330018213909876644461334936m, evaluator.Evaluate(node)));

            node = parser.Parse("( 15 " + OperatorLookup.Ln + " )");

            Assert.IsTrue(IsAccurate(2.7080502011022100659960045701487m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Sine() {

            var node = parser.Parse("( 5 " + OperatorLookup.Sine + " )");

            Assert.IsTrue(IsAccurate(-0.95892427466313846889315440615599m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.Sine + " )");

            Assert.IsTrue(IsAccurate(0.02159097572609606609099810420189m, evaluator.Evaluate(node)));

            node = parser.Parse("( -1500 " + OperatorLookup.Sine + " )");

            Assert.IsTrue(IsAccurate(0.99390195690665346412392361954959m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Cosine() {

            var node = parser.Parse("( 5 " + OperatorLookup.Cosine + " )");

            Assert.IsTrue(IsAccurate(0.28366218546322626446663917151356m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.Cosine + " )");

            Assert.IsTrue(IsAccurate(-0.99976688771292837334358497397559m, evaluator.Evaluate(node)));

            node = parser.Parse("( -1500 " + OperatorLookup.Cosine + " )");

            Assert.IsTrue(IsAccurate(-0.1102674025137291440863676047183m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Tangent() {

            var node = parser.Parse("( 5 " + OperatorLookup.Tangent + " )");

            Assert.IsTrue(IsAccurate(-3.3805150062465856369827058794473m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.Tangent + " )");

            Assert.IsTrue(IsAccurate(-0.02159601002138377263113057217128m, evaluator.Evaluate(node)));

            node = parser.Parse("( -1500 " + OperatorLookup.Tangent + " )");

            Assert.IsTrue(IsAccurate(-9.0135609822032852063237238916881m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Sinh() {

            var node = parser.Parse("( 5 " + OperatorLookup.Sinh + " )");

            Assert.IsTrue(IsAccurate(74.203210577788758977009471996065m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.Sinh + " )");

            Assert.IsTrue(IsAccurate(11.301111237377851417436310948009m, evaluator.Evaluate(node)));

            node = parser.Parse("( -5 " + OperatorLookup.Sinh + " )");

            Assert.IsTrue(IsAccurate(-74.203210577788758977009471996065m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Cosh() {

            var node = parser.Parse("( 5 " + OperatorLookup.Cosh + " )");

            Assert.IsTrue(IsAccurate(74.209948524787844444106108044488m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.Cosh + " )");

            Assert.IsTrue(IsAccurate(11.345268405797544284388326799609m, evaluator.Evaluate(node)));

            node = parser.Parse("( -5 " + OperatorLookup.Cosh + " )");

            Assert.IsTrue(IsAccurate(74.209948524787844444106108044488m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Tanh() {

            var node = parser.Parse("( 5 " + OperatorLookup.Tanh + " )");

            Assert.IsTrue(IsAccurate(0.99990920426259513121099044753447m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.Tanh + " )");

            Assert.IsTrue(IsAccurate(0.99610787802982888289626466149844m, evaluator.Evaluate(node)));

            node = parser.Parse("( -5000 " + OperatorLookup.Tanh + " )");

            Assert.IsTrue(IsAccurate(-1, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcSine() {

            var node = parser.Parse("( 1.01 " + OperatorLookup.ArcSin + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void ArcSine() {

            var node = parser.Parse("( 1 " + OperatorLookup.ArcSin + " )");

            Assert.IsTrue(IsAccurate(1.5707963267948966192313216916398m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.ArcSin + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));

            node = parser.Parse("( -0.5 " + OperatorLookup.ArcSin + " )");

            Assert.IsTrue(IsAccurate(-0.52359877559829887307710723054658m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Invalid Input.")]
        public void InvalidArcCosine() {

            var node = parser.Parse("( 1.01 " + OperatorLookup.ArcCos + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void ArcCosine() {

            var node = parser.Parse("( 1 " + OperatorLookup.ArcCos + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.ArcCos + " )");

            Assert.IsTrue(IsAccurate(1.5707963267948966192313216916398m, evaluator.Evaluate(node)));

            node = parser.Parse("( -0.5 " + OperatorLookup.ArcCos + " )");

            Assert.IsTrue(IsAccurate(2.0943951023931954923084289221863m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void ArcTangent() {

            var node = parser.Parse("( 5 " + OperatorLookup.ArcTan + " )");

            Assert.IsTrue(IsAccurate(1.373400766945015860861271926445m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.ArcTan + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));

            node = parser.Parse("( -0.5 " + OperatorLookup.ArcTan + " )");

            Assert.IsTrue(IsAccurate(-0.46364760900080611621425623146121m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void ArcSinh() {

            var node = parser.Parse("( 5 " + OperatorLookup.ArcSinh + " )");

            Assert.IsTrue(IsAccurate(2.3124383412727526202535623413644m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.ArcSinh + " )");

            Assert.IsTrue(IsAccurate(1.8557258612240877670777891388734m, evaluator.Evaluate(node)));

            node = parser.Parse("( -5 " + OperatorLookup.ArcSinh + " )");

            Assert.IsTrue(IsAccurate(-2.3124383412727526202535623413644m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "Invalid Input.")]
        public void InvalidArcCosh() {

            var node = parser.Parse("( 0.99 " + OperatorLookup.ArcCosh + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void ArcCosh() {

            var node = parser.Parse("( 5 " + OperatorLookup.ArcCosh + " )");

            Assert.IsTrue(IsAccurate(2.292431669561177687800787311348m, evaluator.Evaluate(node)));

            node = parser.Parse("( 3.12 " + OperatorLookup.ArcCosh + " )");

            Assert.IsTrue(IsAccurate(1.8042481325420644064626018879644m, evaluator.Evaluate(node)));

            node = parser.Parse("( 1 " + OperatorLookup.ArcCosh + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "Invalid Input.")]
        public void InvalidArcTanh() {

            var node = parser.Parse("( 1.01 " + OperatorLookup.ArcTanh + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void ArcTanh() {

            var node = parser.Parse("( 0.99 " + OperatorLookup.ArcTanh + " )");

            Assert.IsTrue(IsAccurate(2.6466524123622461977050606459343m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0.5 " + OperatorLookup.ArcTanh + " )");

            Assert.IsTrue(IsAccurate(0.54930614433405484569762261846126m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.ArcTanh + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void ToPower() {

            var node = parser.Parse("( 5 " + OperatorLookup.Power + " 7 )");

            Assert.IsTrue(IsAccurate(78125, evaluator.Evaluate(node)));

            node = parser.Parse("( 0.5 " + OperatorLookup.Power + " 12 )");

            Assert.IsTrue(IsAccurate(0.000244140625m, evaluator.Evaluate(node)));

            node = parser.Parse("( 5 " + OperatorLookup.Power + " -2 )");

            Assert.IsTrue(IsAccurate(0.04m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
         "Cannot Divide by Zero.")]
        public void InvalidReciprocal() {

            var node = parser.Parse("( 0 " + OperatorLookup.Reciprocal + " )");
            evaluator.Evaluate(node);
        }

        [TestMethod]
        public void Reciprocal() {

            var node = parser.Parse("( 5 " + OperatorLookup.Reciprocal + " )");

            Assert.IsTrue(IsAccurate(0.2m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0.5 " + OperatorLookup.Reciprocal + " )");

            Assert.IsTrue(IsAccurate(2, evaluator.Evaluate(node)));

            node = parser.Parse("( -3 " + OperatorLookup.Reciprocal + " )");

            Assert.IsTrue(IsAccurate(-0.33333333333333333333333333333333m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Negate() {

            var node = parser.Parse("( 5 " + OperatorLookup.Negate + " )");

            Assert.IsTrue(IsAccurate(-5, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.Negate + " )");

            Assert.IsTrue(IsAccurate(0, evaluator.Evaluate(node)));

            node = parser.Parse("( -3.77 " + OperatorLookup.Negate + " )");

            Assert.IsTrue(IsAccurate(3.77m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void Exponential() {

            var node = parser.Parse("( 5 " + OperatorLookup.Exponential + " )");

            Assert.IsTrue(IsAccurate(148.41315910257660342111558004055m, evaluator.Evaluate(node)));

            node = parser.Parse("( 0 " + OperatorLookup.Exponential + " )");

            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(node)));

            node = parser.Parse("( -3.77 " + OperatorLookup.Exponential + " )");

            Assert.IsTrue(IsAccurate(0.02305206328722557020660113475915m, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void PowerOfTen() {

            var node = parser.Parse("( 5 " + OperatorLookup.PowerOfTen + " )");

            Assert.IsTrue(IsAccurate(100000, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void DmsToDegrees() {

            unitConverter.Setup(x => x.DmsToDegree(It.IsAny<decimal>())).Returns(1);

            var node = parser.Parse("( 5 " + OperatorLookup.Degrees + " )");

            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(node)));
        }

        [TestMethod]
        public void DegreesToDms() {

            unitConverter.Setup(x => x.DegreeToDms(It.IsAny<decimal>())).Returns(1);

            var node = parser.Parse("( 5 " + OperatorLookup.Dms + " )");

            Assert.IsTrue(IsAccurate(1, evaluator.Evaluate(node)));
        }
    }
}