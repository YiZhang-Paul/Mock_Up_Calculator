using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTreeClassLibrary {
    public interface IParseTree {

        void Clear();
        void Parse(string expression);
        decimal Evaluate();
    }
}