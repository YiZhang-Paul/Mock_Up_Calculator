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
    public partial class scientificKeypad : UserControl, IScientificKeypad {

        private IButtonTracker Tracker { get; set; }
        private Button[] AllKeys { get; set; }
        private Button[] MemoryKeys { get; set; }
        private Button[] HypotenuseKeys { get; set; }
        private Button[] BasicKeys { get; set; }
        private bool ExtensionToggled { get; set; }
        private bool HypotenuseToggled { get; set; }
        private float ExtraKeyFontSize { get; set; }
        private float BasicKeyFontSize { get; set; }

        public int AngularUnit { get; private set; }
        public bool EngineeringMode { get; private set; }

        public event EventHandler OnButtonMouseClick;
        public event EventHandler OnButtonMouseEnter;
        public event EventHandler OnButtonMouseLeave;

        public scientificKeypad() {

            InitializeComponent();
            Initialize();
        }

        private Button[] GetAllKeys() {

            var keys = new List<Button>();
            UIHelper.ControlsOfType<Button>(this, keys);

            return keys.ToArray();
        }

        private bool IsMemoryKey(Button button) {

            return Regex.IsMatch(button.Text, "^(MC|MR|M▾)$");
        }

        private bool IsHypotenuseKey(Button button) {

            return Regex.IsMatch(button.Text, "sin|cos|tan");
        }

        private bool IsBasicKey(Button button) {

            return Regex.IsMatch(button.Text, "^([0-9=]|CE|C|⌫)$");
        }

        private void RecordKeys() {

            AllKeys = GetAllKeys();
            MemoryKeys = AllKeys.Where(IsMemoryKey).ToArray();
            HypotenuseKeys = AllKeys.Where(IsHypotenuseKey).ToArray();
            BasicKeys = AllKeys.Where(IsBasicKey).ToArray();
            ExtraKeyFontSize = btnDegRadGrad.Font.SizeInPoints;
            BasicKeyFontSize = btnArcSine.Font.SizeInPoints;
        }

        private void Initialize() {

            RecordKeys();
            Tracker = new ButtonTracker();
            UIHelper.DisableKeys(MemoryKeys, Tracker);
        }

        private void ButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.RaiseButtonEvent(sender, e, OnButtonMouseEnter, Tracker);
        }

        private void ButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.RaiseButtonEvent(sender, e, OnButtonMouseLeave, Tracker);
        }

        private void ButtonMouseClick(object sender, EventArgs e) {

            UIHelper.RaiseButtonEvent(sender, e, OnButtonMouseClick, Tracker);
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

        private void UpdateHypotenuseKeys() {

            foreach(var key in HypotenuseKeys) {

                string pattern = HypotenuseToggled ? "sin|cos|tan" : "h";
                string replace = HypotenuseToggled ? "h" : string.Empty;
                UIHelper.UpdateKeyText(key, pattern, replace, HypotenuseToggled);
            }
        }

        private void btnHypotenuse_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            HypotenuseToggled = !HypotenuseToggled;
            UpdateHypotenuseKeys();

            if(HypotenuseToggled) {

                button.Paint += UIHelper.DrawUnderline;
            }
            else {

                button.Paint -= UIHelper.DrawUnderline;
            }
        }

        private void btnScientificFormat_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            EngineeringMode = !EngineeringMode;

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

            if(AngularUnit == 0) {

                button.Text = "DEG";

                return;
            }

            button.Text = AngularUnit == 1 ? "RAD" : "GRAD";
        }

        private void ResizeText(object sender, EventArgs e) {

            var button = (Button)sender;
            float size = ExtraKeyFontSize;

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
    }
}