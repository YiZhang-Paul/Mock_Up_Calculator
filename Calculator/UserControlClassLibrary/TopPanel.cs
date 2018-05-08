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
    public partial class TopPanel : UserControl {

        public event MouseEventHandler OnMouseHold;
        public event MouseEventHandler OnMouseDrag;
        public event EventHandler OnMinimize;
        public event EventHandler OnSizeToggle;
        public event EventHandler OnExit;

        public TopPanel() {

            InitializeComponent();
        }

        public void GetPointerLocation(object sender, MouseEventArgs e) {

            OnMouseHold(sender, e);
        }

        public void Drag(object sender, MouseEventArgs e) {

            OnMouseDrag(sender, e);
        }

        public void Minimize(object sender, EventArgs e) {

            OnMinimize(sender, e);
        }

        public void ToggleSize(object sender, EventArgs e) {

            OnSizeToggle(sender, e);
        }

        public void ExitApplication(object sender, EventArgs e) {

            OnExit(sender, e);
        }
    }
}