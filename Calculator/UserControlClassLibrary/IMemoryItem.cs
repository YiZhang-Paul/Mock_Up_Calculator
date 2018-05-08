using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public interface IMemoryItem {

        int Key { get; }
        decimal RawValue { get; }
        string FormattedValue { get; }

        event EventHandler OnDelete;
        event EventHandler OnSelect;
        event EventHandler OnPlus;
        event EventHandler OnMinus;

        void DisplayValue();
    }
}