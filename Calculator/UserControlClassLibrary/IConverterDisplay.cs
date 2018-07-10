using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public interface IConverterDisplay {

        string Input { get; }
        string Output { get; }

        void Clear();
        void DisplayInput(string input, IFormatter formatter);
        void DisplayOutput(string output, IFormatter formatter);
    }
}