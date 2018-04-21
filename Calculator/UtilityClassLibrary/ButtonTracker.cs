using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityClassLibrary {
    public class ButtonTracker : IButtonTracker {

        private Dictionary<Button, bool> Buttons { get; set; }

        public ButtonTracker() {

            Buttons = new Dictionary<Button, bool>();
        }

        public bool IsDisabled(Button button) {

            if(!Buttons.ContainsKey(button)) {

                return false;
            }

            return !Buttons[button];
        }

        public void Disable(Button button) {

            Buttons[button] = false;
        }

        public void Enable(Button button) {

            Buttons[button] = true;
        }
    }
}