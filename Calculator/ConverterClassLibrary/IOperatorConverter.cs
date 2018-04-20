using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public interface IOperatorConverter {

        bool IsOperator(string token);
        int toValue(string token);
        string toOperator(int value);
    }
}