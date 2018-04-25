using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClassLibrary {
    public interface IStandardCalculator : ICalculator {

        string Expression { get; }

        void ClearInput();
    }
}