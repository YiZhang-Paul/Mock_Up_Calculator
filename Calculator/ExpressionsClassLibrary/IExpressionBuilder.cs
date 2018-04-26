using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public interface IExpressionBuilder {

        string Expression { get; }

        void Clear();
        void Undo();
        void AddValue(decimal input);
        void AddUnary(string input);
        void AddBinary(string input);
        void AddParentheses(string input);
        string Build();
    }
}