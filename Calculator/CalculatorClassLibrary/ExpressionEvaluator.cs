using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CalculatorClassLibrary {
    public class ExpressionEvaluator : IEvaluator {

        private Dictionary<string, Func<decimal, decimal, decimal>> Expression { get; set; }

        public ExpressionEvaluator() {

            initialize();
        }

        private void initialize() {

            Expression = new Dictionary<string, Func<decimal, decimal, decimal>>();

            Expression["+"] = (op1, op2) => op1 + op2;
            Expression["-"] = (op1, op2) => op1 - op2;
            Expression["*"] = (op1, op2) => op1 * op2;
            Expression["/"] = (op1, op2) => op1 / op2;
            Expression["%"] = (op1, op2) => op1 % op2;
            Expression["^"] = RaiseToPower;
            Expression["root"] = NthRoot;
            Expression["exp"] = RaiseToPowerOfTen;
            Expression["e^x"] = (op1, op2) => Exponential(op2);
            Expression["log"] = (op1, op2) => Log10(op2);
            Expression["ln"] = (op1, op2) => NaturalLogarithm(op2);
        }

        private decimal RaiseToPower(decimal number, decimal power) {

            return (decimal)Math.Pow((double)number, (double)power);
        }

        private decimal NthRoot(decimal number, decimal order) {

            if(order == 2) {

                return (decimal)Math.Sqrt((double)number);
            }

            return (decimal)Math.Pow((double)number, 1 / (double)order);
        }

        private decimal RaiseToPowerOfTen(decimal number, decimal power) {

            return number * (decimal)Math.Pow(10, (double)power);
        }

        private decimal Exponential(decimal power) {

            return (decimal)Math.Exp((double)power);
        }

        private decimal Log10(decimal number) {

            return (decimal)Math.Log10((double)number);
        }

        private decimal NaturalLogarithm(decimal number) {

            return (decimal)(Math.Log((double)number) / Math.Log(Math.E));
        }

        public decimal Evaluate(string token, decimal operand1, decimal operand2) {

            if(!Expression.ContainsKey(token)) {

                throw new ArgumentException("Invalid Operator.");
            }

            return Expression[token](operand1, operand2);
        }
    }
}