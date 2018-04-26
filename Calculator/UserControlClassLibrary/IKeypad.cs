using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlClassLibrary {
    public interface IKeypad {

        event EventHandler OnKeypadEnable;

        bool IsDisabled { get; }

        void EnableKeys();
        void DisableKeys();
    }
}