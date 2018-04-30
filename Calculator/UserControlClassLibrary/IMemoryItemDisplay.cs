using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public interface IMemoryItemDisplay : IExpandable, IDisplayPanel, IItemDisplay<decimal> {

        event EventHandler OnMemoryDelete;
        event EventHandler OnMemorySelect;
        event EventHandler OnMemoryPlus;
        event EventHandler OnMemoryMinus;
    }
}