using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlClassLibrary;
using FormatterClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class BaseForm : Form {

        protected int DefaultWidth { get; set; }
        protected int DefaultHeight { get; set; }
        protected Point ClientCenter { get; set; }
        protected Point Pointer { get; set; }
        protected Rectangle Viewport { get { return Screen.FromControl(this).WorkingArea; } }
        protected TableLayoutPanel MainLayout { get; set; }
        protected Panel BottomPanel { get; set; }
        protected IResize Resizer { get; set; }
        protected IKeyChecker Checker { get; set; }
        protected IFormatter NumberFormatter { get; set; }

        public BaseForm() {

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Resizer = new Resizer(this);
        }

        protected void SaveDimension() {

            DefaultWidth = Width;
            DefaultHeight = Height;
        }

        protected void SaveClientCenter() {

            ClientCenter = PointToScreen(new Point(Width / 2, Height / 2));
        }

        protected void SavePointerLocation(object sender, MouseEventArgs e) {

            Pointer = UIHelper.GetPointerLocation(e);
        }

        protected virtual void Initialize() {

            NumberFormatter = new NumberFormatter();
            SaveDimension();
            SaveClientCenter();
        }

        protected virtual void ButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.ButtonMouseEnter(sender, e);
        }

        protected virtual void ButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave(sender, e);
        }

        protected virtual void DragWindow(object sender, MouseEventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                return;
            }

            UIHelper.DragWindow(e, this, Pointer);
        }

        protected virtual void Minimize(object sender, EventArgs e) {

            WindowState = FormWindowState.Minimized;
        }

        private void ZoomToMax(object sender, EventArgs e) {

            UIHelper.ScaleTo(this, Width + 20, Height + 20);

            if(Width >= Viewport.Width && Height >= Viewport.Height) {

                BottomPanel.Visible = true;
                WindowState = FormWindowState.Maximized;
                zoomTimer.Tick -= ZoomToMax;
                zoomTimer.Stop();
            }
        }

        private void MaximizeToNormal() {

            WindowState = FormWindowState.Normal;
            Visible = false;
            UIHelper.ScaleTo(this, DefaultWidth, DefaultHeight, false);
            UIHelper.CenterToPoint(this, ClientCenter);
            Visible = true;
        }

        private void NormalToMaximize() {

            SaveClientCenter();
            UIHelper.ScaleTo(this, (int)(Viewport.Width * 0.95), (int)(Viewport.Height * 0.95));
            BottomPanel.Visible = false;
            zoomTimer.Tick += ZoomToMax;
            zoomTimer.Start();
        }

        protected virtual void ToggleWindowSize(object sender, EventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                MaximizeToNormal();

                return;
            }

            NormalToMaximize();
        }

        private void CloseUI(object sender, EventArgs e) {

            Opacity -= 0.05;

            if(Opacity <= 0.7) {

                Width -= (int)(DefaultWidth * 0.005);
                Height -= (int)(DefaultHeight * 0.005);
                Application.Exit();
            }
        }

        protected virtual void Exit(object sender, EventArgs e) {

            closeTimer.Tick += CloseUI;
            closeTimer.Start();
        }

        protected virtual void FormResizeBegin(object sender, EventArgs e) {

            MainLayout.Visible = false;
        }

        protected virtual void FormResizeEnd(object sender, EventArgs e) {

            SaveDimension();
            MainLayout.Visible = true;
        }

        private void ResizeWindow(ref Message message) {

            var cursor = PointToClient(Cursor.Position);

            foreach(int key in Resizer.Keys) {

                if(Resizer.Boxes[key]().Contains(cursor)) {

                    message.Result = (IntPtr)key;

                    break;
                }
            }
        }

        protected override void WndProc(ref Message message) {

            base.WndProc(ref message);
            //WM_NCHITTEST
            if(message.Msg == 0x84) {

                ResizeWindow(ref message);
            }
        }
    }
}