using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlClassLibrary {
    public interface IKeypad {

        event EventHandler OnKeypadEnable;

        bool HasMemory { get; set; }
        int MainAreaHeight { get; }
        bool IsDisabled { get; }
        bool ExtraKeysSuspended { get; set; }

        void EnableAllKeys();
        void EnableValidKeys();
        void LeaveBasicKeysOn();
        void LeaveMemoryKeyOn();
    }
}