using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using StorageClassLibrary;
using UtilityClassLibrary;

namespace CalculatorClassLibrary {
    public class StandardCalculator : Calculator, IStandardCalculator {

        protected IOperatorLookup Lookup { get; set; }
        protected ITempUnitConverter UnitConverter { get; set; }
        protected IOperatorConverter OperatorConverter { get; set; }
        protected IExpressionBuilder Builder { get; set; }
        protected IExpressionParser Parser { get; set; }
        protected IEvaluate Evaluator { get; set; }
        protected IMemoryStorage Memory { get; set; }

        public decimal LastResult { get; private set; }
        public string Expression { get { return Builder.Expression; } }
        public decimal[] MemoryValues { get { return Memory.Values; } }

        public StandardCalculator(

            IInputBuffer buffer,
            IOperatorLookup lookup,
            ITempUnitConverter unitConverter,
            IOperatorConverter operatorConverter,
            IExpressionBuilder builder,
            IExpressionParser parser,
            IEvaluate evaluator,
            IMemoryStorage memory

        ) : base(buffer) {

            Lookup = lookup;
            UnitConverter = unitConverter;
            OperatorConverter = operatorConverter;
            Builder = builder;
            Parser = parser;
            Evaluator = evaluator;
            Memory = memory;
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
            //clear entire calculator on invalid value input
            if(!Builder.CanAddValue()) {

                Clear();
            }

            base.Add(input);
        }

        private void AddValue(decimal value) {

            Builder.AddValue(value);
        }

        private void AddParentheses(string input) {
            //invalid parentheses input has no impact
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
                //use last evaluation result when operand is absent
                Builder.AddValue(LastResult);
                Builder.AddUnary(input);
            }
        }

        private void AddBinary(string input) {

            try {

                Builder.AddBinary(input);
            }
            catch(InvalidOperationException) {
                //on consecutive binary operator input, only the last one counts as valid input
                Builder.Undo();
                Builder.AddBinary(input);
            }
        }

        public virtual bool IsSpecialKey(string input) {

            if(input == "." || input == Lookup.PI) {

                return true;
            }
            //negating when buffer is not empty will not push buffer content to builder
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

            string expression = Builder.Build();
            var parseTree = Parser.Parse(expression);

            return Evaluator.Evaluate(parseTree);
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
                /*
                 * push last evaluation result into builder and try evaluating again
                 * e.g. when evaluating "5 + ", try evaluating "5 + 5" instead
                 */
                AddValue(LastResult);

                return TryEvaluate();
            }
        }
    }
}