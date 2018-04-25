using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using UtilityClassLibrary;

namespace CalculatorClassLibrary {
    public class Calculator : ICalculator {

        private IInputBuffer Buffer { get; set; }
        private IExpressionBuilder Builder { get; set; }
        private IExpressionParser Parser { get; set; }

        public string Input { get { return Buffer.Value.ToString(); } }

        public Calculator() {

            Buffer = new InputBuffer(new Formatter());
            Builder = new ExpressionBuilder(new Parenthesizer(OperatorLookup.Operators));
            Parser = new ExpressionParser(new OperatorConverter(OperatorLookup.Operators));
        }

        public void Clear() {

        }

        public void Undo() {
        }

        public void Add(decimal input) {
        }

        public void Add(string input) {
        }

        public decimal Evaluate() {

            return -1;
        }
    }
}