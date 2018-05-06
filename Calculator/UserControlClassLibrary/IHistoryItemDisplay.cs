using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IHistoryItemDisplay : IExpandable, IDisplayPanel, IItemDisplay<Tuple<string, decimal>> {

        event EventHandler OnHistorySelect;
    }
}