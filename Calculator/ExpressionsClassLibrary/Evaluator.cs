using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterClassLibrary;

namespace ExpressionsClassLibrary {
    public class Evaluator : IEvaluate {

        private IUnitConverter UnitConverter { get; set; }
        private IOperatorConverter OperatorConverter { get; set; }
        private IOperatorLookup Lookup { get; set; }
        private Dictionary<string, Func<decimal, decimal, decimal>> Calculation { get; set; }

        public Evaluator(

            IUnitConverter unitConverter,
            IOperatorConverter operatorConverter,
            IOperatorLookup operatorLookup

        ) {

            UnitConverter = unitConverter;
            OperatorConverter = operatorConverter;
            Lookup = operatorLookup;
            Initialize();
        }

        private void Initialize() {

            #region List of Supported Arithmetic Operations
            Calculation = new Dictionary<string, Func<decimal, decimal, decimal>>() {

                { Lookup.SquareRoot, (op1, op2) => NthRoot(op1, 2) },
                { Lookup.Square, (op1, op2) => AsDecimal(op1, 2, Math.Pow) },
                { Lookup.Cube, (op1, op2) => AsDecimal(op1, 3, Math.Pow) },
                { Lookup.Exponential, (op1, op2) => AsDecimal(op1, Math.Exp) },
                { Lookup.Factorial, (op1, op2) => Factorial(op1) },
                { Lookup.Log, (op1, op2) => AsDecimal(op1, Math.Log10) },
                { Lookup.Ln, (op1, op2) => NaturalLogarithm(op1) },
                { Lookup.Dms, (op1, op2) => UnitConverter.Convert("degrees", op1, "dms") },
                { Lookup.Degrees, (op1, op2) => UnitConverter.Convert("dms", op1, "degrees") },
                { Lookup.Negate, (op1, op2) => decimal.Negate(op1) },
                { Lookup.Reciprocal, (op1, op2) => decimal.Divide(1, op1) },
                { Lookup.PowerOfTen, (op1, op2) => AsDecimal(10, op1, Math.Pow) },
                { Lookup.SineDEG, (op1, op2) => AsDecimal(ToRadian(op1), Math.Sin) },
                { Lookup.SineRAD, (op1, op2) => AsDecimal(op1, Math.Sin) },
                { Lookup.SineGRAD, (op1, op2) => AsDecimal(ToRadian(op1, false), Math.Sin) },
                { Lookup.CosineDEG, (op1, op2) => AsDecimal(ToRadian(op1), Math.Cos) },
                { Lookup.CosineRAD, (op1, op2) => AsDecimal(op1, Math.Cos) },
                { Lookup.CosineGRAD, (op1, op2) => AsDecimal(ToRadian(op1, false), Math.Cos) },
                { Lookup.TangentDEG, (op1, op2) => AsDecimal(ToRadian(op1), Math.Tan) },
                { Lookup.TangentRAD, (op1, op2) => AsDecimal(op1, Math.Tan) },
                { Lookup.TangentGRAD, (op1, op2) => AsDecimal(ToRadian(op1, false), Math.Tan) },
                { Lookup.ArcSinDEG, (op1, op2) => ToDegree(AsDecimal(op1, Math.Asin)) },
                { Lookup.ArcSinRAD, (op1, op2) => AsDecimal(op1, Math.Asin) },
                { Lookup.ArcSinGRAD, (op1, op2) => ToGradian(AsDecimal(op1, Math.Asin)) },
                { Lookup.ArcCosDEG, (op1, op2) => ToDegree(AsDecimal(op1, Math.Acos)) },
                { Lookup.ArcCosRAD, (op1, op2) => AsDecimal(op1, Math.Acos) },
                { Lookup.ArcCosGRAD, (op1, op2) => ToGradian(AsDecimal(op1, Math.Acos)) },
                { Lookup.ArcTanDEG, (op1, op2) => ToDegree(AsDecimal(op1, Math.Atan)) },
                { Lookup.ArcTanRAD, (op1, op2) => AsDecimal(op1, Math.Atan) },
                { Lookup.ArcTanGRAD, (op1, op2) => ToGradian(AsDecimal(op1, Math.Atan)) },
                { Lookup.Sinh, (op1, op2) => AsDecimal(op1, Math.Sinh) },
                { Lookup.Cosh, (op1, op2) => AsDecimal(op1, Math.Cosh) },
                { Lookup.Tanh, (op1, op2) => AsDecimal(op1, Math.Tanh) },
                { Lookup.ArcSinh, (op1, op2) => ArcSinh(op1) },
                { Lookup.ArcCosh, (op1, op2) => ArcCosh(op1) },
                { Lookup.ArcTanh, (op1, op2) => ArcTanh(op1) },
                { Lookup.Power, (op1, op2) => AsDecimal(op1, op2, Math.Pow) },
                { Lookup.Exp, ToPowerOfTen },
                { Lookup.NthRoot, NthRoot },
                { Lookup.Multiply, decimal.Multiply },
                { Lookup.Divide, decimal.Divide },
                { Lookup.Modulus, decimal.Remainder },
                { Lookup.Plus, decimal.Add },
                { Lookup.Minus, decimal.Subtract }
            };
            #endregion
        }

        private decimal AsDecimal(decimal operand, Func<double, double> unaryOperation) {

            return (decimal)unaryOperation((double)operand);
        }

        private decimal AsDecimal(decimal operand1, decimal operand2, Func<double, double, double> binaryOperation) {

            return (decimal)binaryOperation((double)operand1, (double)operand2);
        }

        private decimal ToRadian(decimal angle, bool isDegree = true) {

            if(isDegree) {

                return UnitConverter.Convert("degrees", angle, "radians");
            }

            return UnitConverter.Convert("gradians", angle, "radians");
        }

        private decimal ToDegree(decimal radian) {

            return UnitConverter.Convert("radians", radian, "degrees");
        }

        private decimal ToGradian(decimal radian) {

            return UnitConverter.Convert("radians", radian, "gradians");
        }

        private decimal ToPowerOfTen(decimal number, decimal power) {

            return number * AsDecimal(10, power, Math.Pow);
        }

        private decimal NthRoot(decimal number, decimal order) {

            return AsDecimal(number, decimal.Divide(1, order), Math.Pow);
        }

        private decimal NaturalLogarithm(decimal number) {

            return (decimal)(Math.Log((double)number) / Math.Log(Math.E));
        }

        private decimal ArcSinh(decimal number) {

            return NaturalLogarithm(number + NthRoot(AsDecimal(number, 2, Math.Pow) + 1, 2));
        }

        private decimal ArcCosh(decimal number) {

            if(number < 1) {

                throw new ArgumentOutOfRangeException("Invalid Input.");
            }

            return NaturalLogarithm(number + NthRoot(AsDecimal(number, 2, Math.Pow) - 1, 2));
        }

        private decimal ArcTanh(decimal number) {

            if(Math.Abs(number) >= 1) {

                throw new ArgumentOutOfRangeException("Invalid Input.");
            }

            return decimal.Divide(NaturalLogarithm(decimal.Divide(1 + number, 1 - number)), 2);
        }

        private decimal Factorial(decimal number) {

            return number <= 1 ? 1 : number * Factorial(number - 1);
        }

        private decimal Calculate(string token, decimal operand1, decimal operand2) {

            if(!Calculation.ContainsKey(token)) {

                throw new ArgumentException("Invalid Operator.");
            }

            return Calculation[token](operand1, operand2);
        }

        public decimal Evaluate(INode node) {

            if(node == null) {

                return 0;
            }

            if(node.IsOperand) {

                return node.Value;
            }

            return Calculate(

                OperatorConverter.ToOperator((int)node.Value),
                Evaluate(node.Left),
                Evaluate(node.Right)
            );
        }
    }
}