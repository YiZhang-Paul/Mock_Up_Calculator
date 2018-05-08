using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public interface ICalculatorDisplay {

        decimal RecentValue { get; }
        string Expression { get; }
        string Input { get; }

        void Clear();
        void RefreshDisplay(IFormatter formatter);
        void DisplayResult(string result, IFormatter formatter);
        void DisplayExpression(string expression, IFormatter formatter);
        void DisplayError(string error);
    }
}