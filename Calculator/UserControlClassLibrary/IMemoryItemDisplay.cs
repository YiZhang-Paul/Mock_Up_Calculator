using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public interface IMemoryItemDisplay {

        event EventHandler OnDelete;
        event EventHandler OnMemoryPlus;
        event EventHandler OnMemoryMinus;
        event EventHandler OnExtended;
        event EventHandler OnShrunken;

        int TryGetKey(object sender);
        void ClearItems();
        void ShowItems(decimal[] values, IFormatter formatter);
        void RefreshItems(decimal[] values, IFormatter formatter);
        void Extend(int height);
        void Shrink();
    }
}