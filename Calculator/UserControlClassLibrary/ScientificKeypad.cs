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
    public partial class ScientificKeypad : StandardKeypad, IScientificKeypad {

        private HashSet<Button> TrigonometricKeys { get; set; }
        private bool ExtensionToggled { get; set; }
        private bool TrigonometricToggled { get; set; }
        private float UnitKeyFontSize { get; set; }

        public override int MainAreaHeight { get { return Height - extraKeysLayout.Height; } }
        public int AngularUnit { get; private set; }
        public bool EngineeringMode { get; private set; }

        public event EventHandler OnAngularUnitToggle;
        public event EventHandler OnEngineeringModeToggle;

        public ScientificKeypad() {

            InitializeComponent();
            Initialize();
            UnitKeyFontSize = btnDegRadGrad.Font.SizeInPoints;
        }

        private bool IsTrigonometricKey(Button button) {

            return Regex.IsMatch(button.Text, "sin|cos|tan");
        }

        protected override void RecordKeys() {

            base.RecordKeys();
            TrigonometricKeys = new HashSet<Button>(AllKeys.Where(IsTrigonometricKey));
        }

        public override void LeaveMemoryKeyOn() {

            base.LeaveMemoryKeyOn();
            UIHelper.EnableKeys(new Button[] { btnMemory }, Tracker);
        }

        protected override void ButtonMouseEnter(object sender, EventArgs e) {

            base.ButtonMouseEnter(sender, e);
        }

        protected override void ButtonMouseLeave(object sender, EventArgs e) {

            base.ButtonMouseLeave(sender, e);
        }

        protected override void ButtonMouseClick(object sender, EventArgs e) {

            base.ButtonMouseClick(sender, e);
        }

        private void btnExtend_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            ExtensionToggled = !ExtensionToggled;

            if(ExtensionToggled) {

                button.Paint += UIHelper.DrawUnderline;
                extensionTwoPanel.BringToFront();
            }
            else {

                button.Paint -= UIHelper.DrawUnderline;
                extensionOnePanel.BringToFront();
            }
        }

        private void UpdateTrigonometricKeys() {

            foreach(var key in TrigonometricKeys) {

                string pattern = TrigonometricToggled ? "sin|cos|tan" : "h";
                string replace = TrigonometricToggled ? "h" : string.Empty;
                UIHelper.UpdateKeyText(key, pattern, replace, TrigonometricToggled);
            }
        }

        private void btnHypotenuse_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            TrigonometricToggled = !TrigonometricToggled;
            UpdateTrigonometricKeys();

            if(TrigonometricToggled) {

                button.Paint += UIHelper.DrawUnderline;
            }
            else {

                button.Paint -= UIHelper.DrawUnderline;
            }
        }

        private void btnEngineeringFormat_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            EngineeringMode = !EngineeringMode;
            OnEngineeringModeToggle(sender, e);

            if(EngineeringMode) {

                button.Paint += UIHelper.DrawUnderline;
            }
            else {

                button.Paint -= UIHelper.DrawUnderline;
            }
        }

        private void btnDegRadGrad_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            AngularUnit = (AngularUnit + 1) % 3;
            OnAngularUnitToggle(sender, e);

            if(AngularUnit == 0) {

                button.Text = "DEG";

                return;
            }

            button.Text = AngularUnit == 1 ? "RAD" : "GRAD";
        }

        private void ResizeUnitKeyText(object sender, EventArgs e) {

            var button = (Button)sender;
            float size = UnitKeyFontSize;

            if(AngularUnit != 2) {

                button.Font = new Font(button.Font.FontFamily, size);

                return;
            }

            float maxWidth = (button.Width - 2 * button.FlatAppearance.BorderSize) / 5 * 3.5f;

            if(size * button.Text.Length > maxWidth) {

                size *= maxWidth / (size * button.Text.Length);
            }

            button.Font = new Font(button.Font.FontFamily, size);
        }

        protected override void MemoryStoreClick(object sender, EventArgs e) {

            base.MemoryStoreClick(sender, e);
        }

        protected override void MemoryAddClick(object sender, EventArgs e) {

            base.MemoryAddClick(sender, e);
        }

        protected override void MemorySubtractClick(object sender, EventArgs e) {

            base.MemorySubtractClick(sender, e);
        }

        protected override void MemoryClearClick(object sender, EventArgs e) {

            base.MemoryClearClick(sender, e);
        }

        protected override void MemoryRecallClick(object sender, EventArgs e) {

            base.MemoryRecallClick(sender, e);
        }

        protected override void MemoryToggleClick(object sender, EventArgs e) {

            base.MemoryToggleClick(sender, e);
        }
    }
}