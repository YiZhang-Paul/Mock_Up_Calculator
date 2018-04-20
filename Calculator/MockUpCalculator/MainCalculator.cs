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

        private void Initialize() {

            SetupTopPanel();
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

        private void Minimize(object sender, EventArgs e) {

            WindowState = FormWindowState.Minimized;
        }

        private void ToggleWindowSize(object sender, EventArgs e) {

            if(WindowState == FormWindowState.Normal) {

                WindowState = FormWindowState.Maximized;

                return;
            }

            WindowState = FormWindowState.Normal;
        }

        private void Exit(object sender, EventArgs e) {

            Application.Exit();
        }
    }
}