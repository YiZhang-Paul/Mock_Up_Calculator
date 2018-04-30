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
    public partial class StandardKeypad : Keypad {

        public StandardKeypad() {

            InitializeComponent();
            Initialize();
        }

        private void RemoveFocus() {

            mainLayout.Focus();
        }

        protected override void ButtonMouseEnter(object sender, EventArgs e) {

            base.ButtonMouseEnter(sender, e);
        }

        protected override void ButtonMouseLeave(object sender, EventArgs e) {

            base.ButtonMouseLeave(sender, e);
        }

        protected override void ButtonMouseClick(object sender, EventArgs e) {

            RemoveFocus();
            base.ButtonMouseClick(sender, e);
        }
    }
}