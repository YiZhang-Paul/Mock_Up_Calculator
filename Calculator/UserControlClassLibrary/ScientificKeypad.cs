using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlClassLibrary {
    public partial class scientificKeypad : UserControl {

        private IButtonTracker Tracker { get; set; }
        private Button[] MemoryKeys { get; set; }
        private bool ExtensionTwoOn { get; set; }

        public event EventHandler OnButtonMouseClick;
        public event EventHandler OnButtonMouseEnter;
        public event EventHandler OnButtonMouseLeave;

        public scientificKeypad() {

            InitializeComponent();
            Initialize();
        }

        private void Initialize() {

            Tracker = new ButtonTracker();

            MemoryKeys = new Button[] {

                btnMemory,
                btnMemoryClear,
                btnMemoryRecall
            };

            DisableMemoryKeys();
        }

        private void DisableMemoryKeys() {

            Tracker.Disable(MemoryKeys);

            foreach(var button in MemoryKeys) {

                var backColor = Color.FromArgb(32, 32, 32);
                button.FlatAppearance.MouseDownBackColor = backColor;
                button.FlatAppearance.MouseOverBackColor = backColor;
                button.ForeColor = Color.FromArgb(75, 75, 75);
            }
        }

        private void DrawUnderline(object sender, PaintEventArgs e) {

            var button = (Button)sender;
            int height = (int)(button.Height * 0.1);

            e.Graphics.FillRectangle(

                new SolidBrush(Color.FromArgb(65, 65, 65)),
                0,
                button.Height - height,
                button.Width,
                height
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
            ExtensionTwoOn = !ExtensionTwoOn;

            if(ExtensionTwoOn) {

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