using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityClassLibrary {
    public interface IButtonTracker {

        bool IsDisabled(Button button);
        void Disable(Button button);
        void Enable(Button button);
    }
}