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

        private bool ExtensionTwoOn { get; set; }

        public event EventHandler OnButtonMouseClick;
        public event EventHandler OnButtonMouseEnter;
        public event EventHandler OnButtonMouseLeave;

        public scientificKeypad() {

            InitializeComponent();
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

        private void ButtonMouseEnter(object sender, EventArgs e) {

            OnButtonMouseEnter(sender, e);
        }

        private void ButtonMouseLeave(object sender, EventArgs e) {

            OnButtonMouseLeave(sender, e);
        }

        private void ButtonMouseClick(object sender, EventArgs e) {

            OnButtonMouseClick(sender, e);
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