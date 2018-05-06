using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IHistoryItem {

        string Expression { get; }
        decimal Result { get; }

        event EventHandler OnSelect;

        void DisplayExpression();
    }
}