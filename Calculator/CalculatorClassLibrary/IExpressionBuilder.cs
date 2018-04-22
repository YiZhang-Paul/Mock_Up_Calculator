using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClassLibrary {
    public interface IExpressionBuilder {

        string Expression { get; }

        void Clear();
        void AddValue(decimal input);
        void AddParentheses(string input);
        void AddUnaryOperator(string input);
        void AddBinaryOperator(string input);
    }
}