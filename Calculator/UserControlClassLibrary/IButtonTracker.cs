using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlClassLibrary {
    public interface IButtonTracker {

        bool IsDisabled(Button button);
        void Disable(Button button);
        void Disable(IEnumerable<Button> buttons);
        void Enable(Button button);
        void Enable(IEnumerable<Button> buttons);
    }
}