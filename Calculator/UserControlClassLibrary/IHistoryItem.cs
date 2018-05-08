using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IHistoryItem {

        string RawExpression { get; }
        string FormattedExpression { get; }
        decimal RawResult { get; }
        string FormattedResult { get; }

        event EventHandler OnSelect;

        void DisplayExpression();
    }
}