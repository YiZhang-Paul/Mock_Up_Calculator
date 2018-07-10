using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public interface IConverterDisplay {

        event EventHandler OnUnitChange;

        string InputUnit { get; }
        string InputValue { get; }
        string MainOutputUnit { get; }
        string MainOutputValue { get; }

        void Clear();
        void PopulateOptions(string[] units);
        void DisplayInput(string input, IFormatter formatter);
        void DisplayMainOutput(string output, IFormatter formatter);
        void DisplayExtraOutputs(Tuple<string, string>[] outputs, IFormatter formatter);
    }
}