using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClassLibrary {
    public interface ICalculator {

        decimal Evaluate(string token, decimal operand1, decimal operand2);
    }
}