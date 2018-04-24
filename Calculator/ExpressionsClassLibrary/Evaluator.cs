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
        private Dictionary<string, Func<decimal, decimal, decimal>> Calculation { get; set; }

        public Evaluator(IUnitConverter unitConverter, IOperatorConverter operatorConverter) {

            UnitConverter = unitConverter;
            OperatorConverter = operatorConverter;
            Initialize();
        }

        private void Initialize() {

            Calculation = new Dictionary<string, Func<decimal, decimal, decimal>>() {

                { OperatorLookup.SquareRoot, (op1, op2) => NthRoot(op1, 2) },
                { OperatorLookup.Square, (op1, op2) => AsDecimal(op1, 2, Math.Pow) },
                { OperatorLookup.Cube, (op1, op2) => AsDecimal(op1, 3, Math.Pow) },
                { OperatorLookup.Exponential, (op1, op2) => AsDecimal(op1, Math.Exp) },
                { OperatorLookup.Factorial, (op1, op2) => Factorial(op1) },
                { OperatorLookup.Log, (op1, op2) => AsDecimal(op1, Math.Log10) },
                { OperatorLookup.Ln, (op1, op2) => NaturalLogarithm(op1) },
                { OperatorLookup.Dms, (op1, op2) => UnitConverter.DegreeToDms(op1) },
                { OperatorLookup.Degrees, (op1, op2) => UnitConverter.DmsToDegree(op1) },
                { OperatorLookup.Negate, (op1, op2) => decimal.Negate(op1) },
                { OperatorLookup.Reciprocal, (op1, op2) => decimal.Divide(1, op1) },
                { OperatorLookup.Sine, (op1, op2) => AsDecimal(op1, Math.Sin) },
                { OperatorLookup.Cosine, (op1, op2) => AsDecimal(op1, Math.Cos) },
                { OperatorLookup.Tangent, (op1, op2) => AsDecimal(op1, Math.Tan) },
                { OperatorLookup.Sinh, (op1, op2) => AsDecimal(op1, Math.Sinh) },
                { OperatorLookup.Cosh, (op1, op2) => AsDecimal(op1, Math.Cosh) },
                { OperatorLookup.Tanh, (op1, op2) => AsDecimal(op1, Math.Tanh) },
                { OperatorLookup.ArcSin, (op1, op2) => AsDecimal(op1, Math.Asin) },
                { OperatorLookup.ArcCos, (op1, op2) => AsDecimal(op1, Math.Acos) },
                { OperatorLookup.ArcTan, (op1, op2) => AsDecimal(op1, Math.Atan) },
                { OperatorLookup.ArcSinh, (op1, op2) => ArcSinh(op1) },
                { OperatorLookup.ArcCosh, (op1, op2) => ArcCosh(op1) },
                { OperatorLookup.ArcTanh, (op1, op2) => ArcTanh(op1) },
                { OperatorLookup.Power, (op1, op2) => AsDecimal(op1, op2, Math.Pow) },
                { OperatorLookup.Exp, ToPowerOfTen },
                { OperatorLookup.NthRoot, NthRoot },
                { OperatorLookup.Multiply, decimal.Multiply },
                { OperatorLookup.Divide, decimal.Divide },
                { OperatorLookup.Modulus, decimal.Remainder },
                { OperatorLookup.Plus, decimal.Add },
                { OperatorLookup.Minus, decimal.Subtract }
            };
        }

        private decimal AsDecimal(decimal operand, Func<double, double> callback) {

            return (decimal)callback((double)operand);
        }

        private decimal AsDecimal(decimal operand1, decimal operand2, Func<double, double, double> callback) {

            return (decimal)callback((double)operand1, (double)operand2);
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

                throw new ArgumentException("Invalid Input.");
            }

            return NaturalLogarithm(number + NthRoot(AsDecimal(number, 2, Math.Pow) - 1, 2));
        }

        private decimal ArcTanh(decimal number) {

            if(Math.Abs(number) >= 1) {

                throw new ArgumentException("Invalid Input.");
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