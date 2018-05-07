using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using StorageClassLibrary;

namespace CalculatorClassLibrary {
    public class StandardCalculator : Calculator, IStandardCalculator {

        protected IUnitConverter UnitConverter { get; set; }
        protected IOperatorConverter OperatorConverter { get; set; }
        protected IOperatorLookup Lookup { get; set; }
        protected IExpressionBuilder Builder { get; set; }
        protected IExpressionParser Parser { get; set; }
        protected IEvaluate Evaluator { get; set; }
        protected IMemoryStorage Memory { get; set; }

        public decimal LastResult { get; private set; }
        public string Expression { get { return Builder.Expression; } }
        public decimal[] MemoryValues { get { return Memory.Values; } }

        public StandardCalculator() {

            Lookup = new OperatorLookup();
            var parenthesizer = new Parenthesizer(Lookup.Precedence);
            UnitConverter = new UnitConverter();
            OperatorConverter = new OperatorConverter(Lookup.Operators, Lookup.Unary);
            Builder = new ExpressionBuilder(parenthesizer);
            Parser = new ExpressionParser(OperatorConverter);
            Evaluator = new Evaluator(UnitConverter, OperatorConverter, Lookup);
            Memory = new MemoryStorage();
        }

        public override void Clear() {

            base.Clear();
            Builder.Clear();
            LastResult = 0;
        }

        public void ClearInput() {

            Buffer.Clear();
        }

        public void MemoryClear() {

            Memory.Clear();
        }

        public void MemoryRemove(int key) {

            Memory.Remove(key);
        }

        public void MemoryRecall() {

            Buffer.Set(Memory.Last.ToString());
        }

        public void MemoryRetrieve(int key) {

            Buffer.Set(Memory.Retrieve(key).ToString());
        }

        public void MemoryStore(decimal value) {

            Memory.Store(value);
        }

        public void MemoryPlus(int key, decimal value) {

            Memory.Plus(key, value);
        }

        public void MemoryMinus(int key, decimal value) {

            Memory.Minus(key, value);
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

        public virtual bool IsSpecialKey(string input) {

            if(input == "." || input == Lookup.PI) {

                return true;
            }

            return input == Lookup.Negate && !Buffer.IsEmpty;
        }

        protected virtual void HandleSpecialKey(string input) {

            if(input == ".") {

                Buffer.Add(input);
            }
            else if(input == Lookup.PI) {

                Buffer.Set(Math.PI.ToString());
            }
            else {

                Buffer.Negate();
            }
        }

        public override void Add(string input) {

            if(IsSpecialKey(input)) {

                HandleSpecialKey(input);

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