using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlClassLibrary {
    public interface IKeypad {

        event EventHandler OnKeypadEnable;

        int MainAreaHeight { get; }
        bool IsDisabled { get; }

        void EnableAllKeys();
        void EnableValidKeys();
        void LeaveBasicKeysOn();
        void LeaveMemoryKeyOn();
    }
}