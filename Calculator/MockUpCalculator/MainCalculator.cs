using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            scientificKeypad.OnButtonMouseEnter += ButtonMouseEnter;
            scientificKeypad.OnButtonMouseLeave += ButtonMouseLeave;
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

        private void ScaleTo(int width, int height, bool center = true) {

            var screen = Screen.FromControl(this).WorkingArea;
            Width = Math.Min(width, screen.Width);
            Height = Math.Min(height, screen.Height);

            if(center) {

                CenterToScreen();
            }
        }

        private void CenterToPoint(Point point) {

            Top = ClientCenter.Y - Height / 2;
            Left = ClientCenter.X - Width / 2;
        }

        private void GetPointerLocation(object sender, MouseEventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                return;
            }

            Pointer = e.Location;
        }

        private void DragWindow(object sender, MouseEventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                return;
            }

            if(e.Button == MouseButtons.Left) {

                Left += e.X - Pointer.X;
                Top += e.Y - Pointer.Y;
            }
        }

        private void ButtonMouseEnter(object sender, EventArgs e) {

            var button = (Button)sender;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
        }

        private void ButtonMouseLeave(object sender, EventArgs e) {

            var button = (Button)sender;
            button.FlatAppearance.BorderSize = 0;
        }

        private void Minimize(object sender, EventArgs e) {

            WindowState = FormWindowState.Minimized;
        }

        private void ZoomToMax(object sender, EventArgs e) {

            var screen = Screen.FromControl(this).WorkingArea;
            ScaleTo(Width + 20, Height + 20);

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
                ScaleTo(DefaultWidth, DefaultHeight, false);
                CenterToPoint(ClientCenter);

                return;
            }

            GetClientCenter();
            var screen = Screen.FromControl(this).WorkingArea;
            ScaleTo((int)(screen.Width * 0.95), (int)(screen.Height * 0.95));
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