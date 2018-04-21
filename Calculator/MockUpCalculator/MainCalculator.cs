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

namespace MockUpCalculator {
    public partial class MainCalculator : Form {

        private int DefaultWidth { get; set; }
        private int DefaultHeight { get; set; }
        private Point ClientCenter { get; set; }
        private Point Pointer { get; set; }

        public MainCalculator() {

            InitializeComponent();
            Initialize();
        }

        private void SetupTopPanel() {

            topPanel.OnMouseHold += GetPointerLocation;
            topPanel.OnMouseDrag += DragWindow;
            topPanel.OnMinimize += Minimize;
            topPanel.OnSizeToggle += ToggleWindowSize;
            topPanel.OnExit += Exit;
        }

        private void SetupKeypad() {

            scientificKeypad.OnButtonMouseClick += KeypadButtonMouseClick;
            scientificKeypad.OnButtonMouseEnter += KeypadButtonMouseEnter;
            scientificKeypad.OnButtonMouseLeave += KeypadButtonMouseLeave;
        }

        private void GetDefaultDimension() {

            DefaultWidth = Width;
            DefaultHeight = Height;
        }

        private void GetClientCenter() {

            ClientCenter = PointToScreen(new Point(Width / 2, Height / 2));
        }

        private void Initialize() {

            GetDefaultDimension();
            SetupTopPanel();
            SetupKeypad();
        }

        private void KeypadButtonMouseClick(object sender, EventArgs e) {

        }

        private void KeypadButtonMouseEnter(object sender, EventArgs e) {

            uiHelper.KeypadButtonMouseEnter(sender, e);
        }

        private void KeypadButtonMouseLeave(object sender, EventArgs e) {

            uiHelper.KeypadButtonMouseLeave(sender, e);
        }

        private void GetPointerLocation(object sender, MouseEventArgs e) {

            Pointer = uiHelper.GetPointerLocation(sender, e);
        }

        private void DragWindow(object sender, MouseEventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                return;
            }

            uiHelper.DragWindow(sender, e, this, Pointer);
        }

        private void Minimize(object sender, EventArgs e) {

            WindowState = FormWindowState.Minimized;
        }

        private void ZoomToMax(object sender, EventArgs e) {

            var screen = Screen.FromControl(this).WorkingArea;
            uiHelper.ScaleTo(this, Width + 20, Height + 20);

            if(Width >= screen.Width && Height >= screen.Height) {

                bottomPanel.Visible = true;
                WindowState = FormWindowState.Maximized;
                zoomTimer.Tick -= ZoomToMax;
                zoomTimer.Stop();
            }
        }

        private void ToggleWindowSize(object sender, EventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                WindowState = FormWindowState.Normal;
                Visible = false;
                uiHelper.ScaleTo(this, DefaultWidth, DefaultHeight, false);
                uiHelper.CenterToPoint(this, ClientCenter);
                Visible = true;

                return;
            }

            GetClientCenter();
            var screen = Screen.FromControl(this).WorkingArea;
            uiHelper.ScaleTo(this, (int)(screen.Width * 0.95), (int)(screen.Height * 0.95));
            bottomPanel.Visible = false;
            zoomTimer.Tick += ZoomToMax;
            zoomTimer.Start();
        }

        private void CloseUI(object sender, EventArgs e) {

            Opacity -= 0.05;

            if(Opacity <= 0.7) {

                Width -= (int)(DefaultWidth * 0.005);
                Height -= (int)(DefaultHeight * 0.005);
                Application.Exit();
            }
        }

        private void Exit(object sender, EventArgs e) {

            closeTimer.Tick += CloseUI;
            closeTimer.Start();
        }
    }
}