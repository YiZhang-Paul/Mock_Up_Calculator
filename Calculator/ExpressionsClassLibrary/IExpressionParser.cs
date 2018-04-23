using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public interface IExpressionParser {

        INode Parse(string expression);
    }
}