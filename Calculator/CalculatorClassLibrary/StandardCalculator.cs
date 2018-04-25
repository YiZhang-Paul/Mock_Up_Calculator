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

        public decimal LastResult { get; private set; }
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
            LastResult = 0;
        }

        public void ClearInput() {

            Buffer.Clear();
        }

        protected void PushBuffer() {

            AddValue(Buffer.Value);
            ClearInput();
        }

        private void AddValue(decimal value) {

            try {

                Builder.AddValue(value);
            }
            catch(Exception) {

                //TODO: add value
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

            if(input == ".") {

                Buffer.Add(input);

                return;
            }

            if(!Buffer.IsEmpty) {

                PushBuffer();
                TryEvaluate();
            }

            if(input == "(" || input == ")") {

                AddParentheses(input);
            }
            else if(OperatorConverter.IsUnary(input)) {

                AddUnary(input);
            }
            else {

                AddBinary(input);
            }

            TryEvaluate();
        }

        protected void TryEvaluate() {

            try {

                LastResult = Evaluator.Evaluate(Parser.Parse(Builder.Build()));
            }
            catch(Exception) { }
        }

        public override decimal Evaluate() {

            if(!Buffer.IsEmpty) {

                PushBuffer();
            }

            try {

                return Evaluator.Evaluate(Parser.Parse(Builder.Build()));
            }
            catch(DivideByZeroException) {

                //TODO: handle dividebyzero exception
            }
            catch(OverflowException) {

                //TODO: handle overflow exception
            }
            catch(Exception) {

                AddValue(LastResult);

                try {

                    return Evaluator.Evaluate(Parser.Parse(Builder.Build()));
                }
                catch(Exception) {

                    return LastResult;
                }
            }

            return -999;
        }
    }
}