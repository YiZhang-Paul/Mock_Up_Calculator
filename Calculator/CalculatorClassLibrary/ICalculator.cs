using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClassLibrary {
    public interface ICalculator {

        string Input { get; }

        void Clear();
        void Undo();
        void Add(decimal input);
        void Add(string input);
        decimal Evaluate();
    }
}