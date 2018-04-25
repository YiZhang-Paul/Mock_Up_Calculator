using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityClassLibrary;

namespace CalculatorClassLibrary {
    public abstract class Calculator : ICalculator {

        protected IInputBuffer Buffer { get; set; }

        public string Input { get { return Buffer.Content; } }

        public Calculator() {

            Buffer = new InputBuffer();
        }

        public virtual void Clear() {

            Buffer.Clear();
        }

        public virtual void Undo() {

            Buffer.Undo();
        }

        public virtual void Add(decimal input) {

            Buffer.Add(input.ToString());
        }

        public virtual void Add(string input) {

            if(input == ".") {

                Buffer.Add(input);
            }
        }

        public abstract decimal Evaluate();
    }
}