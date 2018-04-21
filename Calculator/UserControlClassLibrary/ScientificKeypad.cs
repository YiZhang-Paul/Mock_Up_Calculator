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

        private void GetKeys(Control control, List<Button> keys) {

            foreach(Control subControl in control.Controls) {

                if(subControl.GetType() == typeof(Button)) {

                    keys.Add((Button)subControl);

                    continue;
                }

                GetKeys(subControl, keys);
            }
        }

        private Button[] GetAllKeys() {

            var keys = new List<Button>();
            GetKeys(this, keys);

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

            Tracker = new ButtonTracker();
            RecordKeys();
            DisableKeys(MemoryKeys);
        }

        private void DisableKeys(IEnumerable<Button> keys) {

            foreach(var key in keys) {

                Tracker.Disable(key);
                key.FlatAppearance.MouseDownBackColor = key.BackColor;
                key.FlatAppearance.MouseOverBackColor = key.BackColor;
                key.ForeColor = Color.FromArgb(75, 75, 75);
            }
        }

        private void EnableKeys(IEnumerable<Button> keys) {

            foreach(var key in keys) {

                Tracker.Enable(key);
                key.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 77, 77);
                key.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 69, 69);
                key.ForeColor = SystemColors.ControlLightLight;
            }
        }

        private void DrawUnderline(object sender, PaintEventArgs e) {

            var button = (Button)sender;
            int lineHeight = (int)(button.Height * 0.1);

            e.Graphics.FillRectangle(

                new SolidBrush(Color.FromArgb(65, 65, 65)),
                0,
                button.Height - lineHeight,
                button.Width,
                lineHeight
            );
        }

        private void RaiseCustomEvent(object sender, EventArgs e, EventHandler handler) {

            if(Tracker.IsDisabled((Button)sender)) {

                return;
            }

            handler(sender, e);
        }

        private void ButtonMouseEnter(object sender, EventArgs e) {

            RaiseCustomEvent(sender, e, OnButtonMouseEnter);
        }

        private void ButtonMouseLeave(object sender, EventArgs e) {

            RaiseCustomEvent(sender, e, OnButtonMouseLeave);
        }

        private void ButtonMouseClick(object sender, EventArgs e) {

            RaiseCustomEvent(sender, e, OnButtonMouseClick);
        }

        private void btnExtend_Click(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            ExtensionToggled = !ExtensionToggled;

            if(ExtensionToggled) {

                button.Paint += DrawUnderline;
                extensionTwoPanel.BringToFront();
            }
            else {

                button.Paint -= DrawUnderline;
                extensionOnePanel.BringToFront();
            }
        }
    }
}