using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public interface IOperatorConverter {

        bool IsOperator(string token);
        bool IsUnary(string token);
        bool IsBinary(string token);
        int ToValue(string token);
        string ToOperator(int value);
    }
}