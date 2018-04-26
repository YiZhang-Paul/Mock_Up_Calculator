using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IDisplay {

        void Clear();
        void DisplayResult(string result);
        void DisplayExpression(string expression);
        void DisplayError(string error);
    }
}