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
    public partial class topPanel : UserControl {

        public event MouseEventHandler OnMouseHold;
        public event MouseEventHandler OnMouseDrag;
        public event EventHandler OnMinimize;
        public event EventHandler OnSizeToggle;
        public event EventHandler OnExit;

        public topPanel() {

            InitializeComponent();
        }

        private void GetPointerLocation(object sender, MouseEventArgs e) {

            OnMouseHold(sender, e);
        }

        private void Drag(object sender, MouseEventArgs e) {

            OnMouseDrag(sender, e);
        }

        private void btnMinimize_Click(object sender, EventArgs e) {

            OnMinimize(sender, e);
        }

        private void btnSizeToggle_Click(object sender, EventArgs e) {

            OnSizeToggle(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e) {

            OnExit(sender, e);
        }
    }
}