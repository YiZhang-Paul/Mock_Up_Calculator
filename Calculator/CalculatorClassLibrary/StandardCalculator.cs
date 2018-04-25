using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionsClassLibrary;
using ConverterClassLibrary;

namespace CalculatorClassLibrary {
    public class StandardCalculator : Calculator, IStandardCalculator {

        protected IUnitConverter UnitConverter { get; set; }
        protected IOperatorConverter OperatorConverter { get; set; }
        protected IExpressionBuilder Builder { get; set; }
        protected IExpressionParser Parser { get; set; }
        protected IEvaluate Evaluator { get; set; }

        public string Expression { get { return Builder.Expression; } }

        public StandardCalculator() {

            var parenthesizer = new Parenthesizer(OperatorLookup.Operators);
            UnitConverter = new UnitConverter();
            OperatorConverter = new OperatorConverter(OperatorLookup.Operators);
            Builder = new ExpressionBuilder(parenthesizer);
            Parser = new ExpressionParser(OperatorConverter);
            Evaluator = new Evaluator(UnitConverter, OperatorConverter);
        }

        public override void Clear() {

            base.Clear();
            Builder.Clear();
        }

        public void ClearInput() {

            Buffer.Clear();
        }

        public override void Add(decimal input) {

            base.Add(input);
            Builder.AddValue(input);
        }

        private void AddDecimal() {

            try {

                Builder.AddDecimal();
            }
            catch(Exception) {

                //TODO: handle decimal point
            }
        }

        private void AddParentheses(string input) {

            try {

                Builder.AddParentheses(input);
            }
            catch(Exception) {

                //TODO: track matched parentheses
            }
        }

        private void AddUnary(string input) {

            try {

                Builder.AddUnary(input);
            }
            catch(Exception) {

                //TODO: add current evaluated value
            }
        }

        private void AddBinary(string input) {

            try {

                Builder.AddBinary(input);
            }
            catch(Exception) {

                //TODO: change last binary operator
            }
        }

        public override void Add(string input) {

            base.Add(input);

            if(input == ".") {

                AddDecimal();
            }
            else if(input == "(" || input == ")") {

                AddParentheses(input);
            }
            else if(OperatorConverter.IsUnary(input)) {

                AddUnary(input);
            }
            else {

                AddBinary(input);
            }
        }

        public override decimal Evaluate() {

            decimal result = 0;

            try {

                result = Evaluator.Evaluate(Parser.Parse(Builder.Build()));
            }
            catch(DivideByZeroException) {

                //TODO: handle dividebyzero exception
            }
            catch(OverflowException) {

                //TODO: handle overflow exception
            }
            catch(InvalidOperationException exception) {

                throw exception;
            }

            return result;
        }
    }
}