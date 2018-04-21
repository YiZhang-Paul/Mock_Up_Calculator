using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UtilityClassLibrary;

namespace UserControlClassLibrary {
    public partial class scientificKeypad : UserControl {

        private IButtonTracker Tracker { get; set; }
        private Button[] AllKeys { get; set; }
        private Button[] MemoryKeys { get; set; }
        private Button[] BasicKeys { get; set; }
        private bool ExtensionToggled { get; set; }

        public event EventHandler OnButtonMouseClick;
        public event EventHandler OnButtonMouseEnter;
        public event EventHandler OnButtonMouseLeave;

        public scientificKeypad() {

            InitializeComponent();
            Initialize();
        }

        private Button[] GetAllKeys() {

            var keys = new List<Button>();
            uiHelper.ControlsOfType<Button>(this, keys);

            return keys.ToArray();
        }

        private bool IsMemoryKey(Button button) {

            return Regex.IsMatch(button.Text, "^(MC|MR|M▾)$");
        }

        private bool IsBasicKey(Button button) {

            return Regex.IsMatch(button.Text, "^([0-9=]|CE|C|⌫)$");
        }

        private void RecordKeys() {

            AllKeys = GetAllKeys();
            MemoryKeys = AllKeys.Where(IsMemoryKey).ToArray();
            BasicKeys = AllKeys.Where(IsBasicKey).ToArray();
        }

        private void Initialize() {

            RecordKeys();
            Tracker = new ButtonTracker();
            uiHelper.DisableKeys(MemoryKeys, Tracker);
        }

        private void ButtonMouseEnter(object sender, EventArgs e) {

            uiHelper.RaiseButtonEvent(sender, e, OnButtonMouseEnter, Tracker);
        }

        private void ButtonMouseLeave(object sender, EventArgs e) {

            uiHelper.RaiseButtonEvent(sender, e, OnButtonMouseLeave, Tracker);
        }

        private void ButtonMouseClick(object sender, EventArgs e) {

            uiHelper.RaiseButtonEvent(sender, e, OnButtonMouseClick, Tracker);
        }

        private void btnExtend_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            ExtensionToggled = !ExtensionToggled;

            if(ExtensionToggled) {

                button.Paint += uiHelper.DrawUnderline;
                extensionTwoPanel.BringToFront();
            }
            else {

                button.Paint -= uiHelper.DrawUnderline;
                extensionOnePanel.BringToFront();
            }
        }
    }
}