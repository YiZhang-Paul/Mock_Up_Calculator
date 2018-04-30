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
using ExpressionsClassLibrary;
using CalculatorClassLibrary;
using FormatterClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class MainForm : Form {

        private CalculatorPanel CalculatorPanel { get; set; }

        private int DefaultWidth { get; set; }
        private int DefaultHeight { get; set; }
        private Point ClientCenter { get; set; }
        private Point Pointer { get; set; }
        private Rectangle Viewport { get { return UIHelper.GetViewport(this); } }
        private IResize Resizer { get; set; }

        public MainForm() {

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Initialize();
        }

        private void SetupTopPanel() {

            topPanel.OnMouseHold += SavePointerLocation;
            topPanel.OnMouseDrag += DragWindow;
            topPanel.OnMinimize += Minimize;
            topPanel.OnSizeToggle += ToggleWindowSize;
            topPanel.OnExit += Exit;
        }

        private void SaveDimension() {

            DefaultWidth = Width;
            DefaultHeight = Height;
        }

        private void SaveClientCenter() {

            ClientCenter = PointToScreen(new Point(Width / 2, Height / 2));
        }

        private void Initialize() {

            Resizer = new Resizer(this);
            SaveDimension();
            SaveClientCenter();
            SetupTopPanel();

            //CalculatorPanel = new ScientificCalculatorPanel(

            //    new ScientificCalculator(),
            //    new KeyChecker(),
            //    new NumberFormatter(),
            //    new EngineeringFormatter()
            //);

            //CalculatorPanel.Parent = uiLayout;
            //CalculatorPanel.Dock = DockStyle.Fill;
            //CalculatorPanel.Show();
            //CalculatorLabel.Text = "Scientific";

            CalculatorPanel = new StandardCalculatorPanel(

                new KeyChecker(),
                new NumberFormatter(),
                new StandardCalculator()
            );

            CalculatorPanel.Parent = uiLayout;
            CalculatorPanel.Dock = DockStyle.Fill;
            CalculatorPanel.Show();
            CalculatorLabel.Text = "Standard";
        }

        private void RemoveFocus(object sender, EventArgs e) {

            CalculatorLabel.Focus();
        }

        private void SavePointerLocation(object sender, MouseEventArgs e) {

            Pointer = UIHelper.GetPointerLocation(e);
        }

        private void KeypadButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.ButtonMouseEnter(sender, e);
        }

        private void KeypadButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave(sender, e);
        }

        private void FormResizeBegin(object sender, EventArgs e) {

            mainLayout.Visible = false;
        }

        private void FormResizeEnd(object sender, EventArgs e) {

            SaveDimension();
            mainLayout.Visible = true;
        }

        private void MainCalculator_Deactivate(object sender, EventArgs e) {

            CalculatorPanel.DeactivateMemoryPanel();
        }

        private void DragWindow(object sender, MouseEventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                return;
            }

            UIHelper.DragWindow(e, this, Pointer);
        }

        private void Minimize(object sender, EventArgs e) {

            WindowState = FormWindowState.Minimized;
        }

        private void ZoomToMax(object sender, EventArgs e) {

            UIHelper.ScaleTo(this, Width + 20, Height + 20);

            if(Width >= Viewport.Width && Height >= Viewport.Height) {

                bottomPanel.Visible = true;
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
            bottomPanel.Visible = false;
            zoomTimer.Tick += ZoomToMax;
            zoomTimer.Start();
        }

        private void ToggleWindowSize(object sender, EventArgs e) {

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

        private void Exit(object sender, EventArgs e) {

            closeTimer.Tick += CloseUI;
            closeTimer.Start();
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

            const int resize = 0x84;  //WM_NCHITTEST
            const int notify = 0x210; //WM_PARENTNOTIFY
            const int click = 0x201;  //WM_LBUTTONDOWN

            if(message.Msg == resize) {

                ResizeWindow(ref message);
            }
            else if(message.Msg == click || (message.Msg == notify && (int)message.WParam == click)) {

                if(!UIHelper.ContainsPointer(topPanel)) {

                    CalculatorPanel.DeactivateMemoryPanel();
                }
            }
        }
    }
}