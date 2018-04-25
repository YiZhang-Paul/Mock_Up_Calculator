using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using UtilityClassLibrary;

namespace CalculatorClassLibrary {
    public abstract class Calculator : ICalculator {

        private IInputBuffer Buffer { get; set; }

        public string Input { get { return Buffer.Formatted; } }

        public Calculator() {

            Buffer = new InputBuffer(new Formatter());
        }

        public void Clear() {

            Buffer.Clear();
        }

        public void Undo() {

            Buffer.Undo();
        }

        public void Add(decimal input) {

            Buffer.Add(input.ToString());
        }

        public void Add(string input) {

            if(input == ".") {

                Buffer.Add(input);
            }
        }

        public abstract decimal Evaluate();
    }
}