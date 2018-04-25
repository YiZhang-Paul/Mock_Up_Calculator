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
        private IUnitConverter Converter { get; set; }

        public string Input { get { return Buffer.Formatted; } }

        public Calculator() {

            var parenthesizer = new Parenthesizer(OperatorLookup.Operators);
            var converter = new OperatorConverter(OperatorLookup.Operators);
            Buffer = new InputBuffer(new Formatter());
            Builder = new ExpressionBuilder(parenthesizer);
            Parser = new ExpressionParser(converter);
        }

        public void Clear() {

            Buffer.Clear();
            Builder.Clear();
        }

        public void Undo() {
        }

        public void Add(decimal input) {

            Buffer.Add(input.ToString());
        }

        public void Add(string input) {

            if(input == ".") {

                Buffer.Add(input);

                return;
            }
        }

        public decimal Evaluate() {

            return -1;
        }
    }
}