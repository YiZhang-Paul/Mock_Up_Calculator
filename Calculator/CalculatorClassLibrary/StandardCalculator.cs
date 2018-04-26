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

        public override void Add(decimal input) {

            if(!Builder.CanAddValue()) {

                Clear();
            }

            base.Add(input);
        }

        private void AddValue(decimal value) {

            Builder.AddValue(value);
        }

        private void AddParentheses(string input) {

            try {

                Builder.AddParentheses(input);
            }
            catch(Exception) { }
        }

        private void AddUnary(string input) {

            try {

                Builder.AddUnary(input);
            }
            catch(InvalidOperationException) {

                Builder.AddValue(LastResult);
                Builder.AddUnary(input);
            }
        }

        private void AddBinary(string input) {

            try {

                Builder.AddBinary(input);
            }
            catch(InvalidOperationException) {

                Builder.Undo();
                Builder.AddBinary(input);
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

        protected decimal GetResult() {

            return Evaluator.Evaluate(Parser.Parse(Builder.Build()));
        }

        protected decimal TryEvaluate() {

            try {

                LastResult = GetResult();

                return LastResult;
            }
            catch(DivideByZeroException exception) {

                throw exception;
            }
            catch(OverflowException exception) {

                throw exception;
            }
            catch(ArgumentOutOfRangeException exception) {

                throw exception;
            }
            catch(Exception) {

                return LastResult;
            }
        }

        public override decimal Evaluate() {

            if(!Buffer.IsEmpty) {

                PushBuffer();
            }

            try {

                return GetResult();
            }
            catch(DivideByZeroException exception) {

                throw exception;
            }
            catch(OverflowException exception) {

                throw exception;
            }
            catch(Exception) {

                AddValue(LastResult);

                return TryEvaluate();
            }
        }
    }
}