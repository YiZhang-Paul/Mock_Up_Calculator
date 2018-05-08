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
using ConverterClassLibrary;
using StorageClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class MainForm : Form {

        private int DefaultWidth { get; set; }
        private int DefaultHeight { get; set; }
        private Point ClientCenter { get; set; }
        private Point Pointer { get; set; }
        private Rectangle Viewport { get { return Helper.GetViewport(this); } }
        private List<string[]> MenuItems { get; set; }
        private ServiceLookup ServiceLookup { get; set; }
        private CalculatorPanel CalculatorPanel { get; set; }
        private IHelper Helper { get; set; }
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

        private void SetupSidePanel() {

            sidePanel.OnExtended += ShowSidePanel;
            sidePanel.OnShrunken += HideSidePanel;
            sidePanel.OnSelect += SelectCalculator;
        }

        private void SaveDimension() {

            DefaultWidth = Width;
            DefaultHeight = Height;
        }

        private void SaveClientCenter() {

            ClientCenter = PointToScreen(new Point(Width / 2, Height / 2));
        }

        private void ToStandardCalculator() {

            if(CalculatorPanel != null) {

                CalculatorPanel.Dispose();
            }

            CalculatorPanel = ServiceLookup.GetStandardCalculatorPanel();
            CalculatorPanel.Parent = uiLayout;
            CalculatorPanel.Dock = DockStyle.Fill;
            CalculatorPanel.Show();
            calculatorLabel.Text = "Standard";
        }

        private void ToScientificCalculatorPanel() {

            if(CalculatorPanel != null) {

                CalculatorPanel.Dispose();
            }

            CalculatorPanel = ServiceLookup.GetScientificCalculatorPanel();
            CalculatorPanel.Parent = uiLayout;
            CalculatorPanel.Dock = DockStyle.Fill;
            CalculatorPanel.Show();
            calculatorLabel.Text = "Scientific";
        }

        private void Initialize() {

            Resizer = new Resizer(this);
            ServiceLookup = new ServiceLookup();
            Helper = new UIHelper();
            SaveDimension();
            SaveClientCenter();
            SetupTopPanel();
            SetupSidePanel();

            MenuItems = new List<string[]>() {

                new string[] { "Calculator", "Standard", "Scientific" },
                new string[] { "Converter", "Currency" }
            };
        }

        private void ToggleHistoryPanel(object sender, EventArgs e) {

            calculatorLabel.Focus();
            CalculatorPanel.ToggleHistoryPanel(sender, e);
        }

        private void SavePointerLocation(object sender, MouseEventArgs e) {

            Pointer = Helper.GetPointerLocation(e);
        }

        private void KeypadButtonMouseEnter(object sender, EventArgs e) {

            Helper.ButtonMouseEnter(sender, e);
        }

        private void KeypadButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave(sender, e);
        }

        private void btnChangeCalculator_Click(object sender, EventArgs e) {

            calculatorLabel.Focus();
            calculatorLabel.Visible = false;
            sidePanel.Extend(Math.Min(280, Width / 4 * 3));
        }

        private void ShowSidePanel(object sender, EventArgs e) {

            sidePanel.ShowMenu(MenuItems, calculatorLabel.Text);
        }

        private void HideSidePanel(object sender, EventArgs e) {

            calculatorLabel.Visible = true;
            sidePanel.SendToBack();
        }

        private void SelectCalculator(object sender, EventArgs e) {

            string selection = ((Control)sender).Tag.ToString();

            if(selection == calculatorLabel.Text) {

                return;
            }

            if(selection == "Scientific") {

                ToScientificCalculatorPanel();

                return;
            }

            ToStandardCalculator();
        }

        private void FormResizeBegin(object sender, EventArgs e) {

            mainLayout.Visible = false;
        }

        private void FormResizeEnd(object sender, EventArgs e) {

            SaveDimension();
            mainLayout.Visible = true;
        }

        private void MainCalculator_Deactivate(object sender, EventArgs e) {

            CalculatorPanel.DeactivateBackPanel();
        }

        private void DragWindow(object sender, MouseEventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                return;
            }

            Helper.DragWindow(e, this, Pointer);
        }

        private void Minimize(object sender, EventArgs e) {

            WindowState = FormWindowState.Minimized;
        }

        private void ZoomToMax(object sender, EventArgs e) {

            Helper.ScaleTo(this, Width + 20, Height + 20);

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
            Helper.ScaleTo(this, DefaultWidth, DefaultHeight, false);
            Helper.CenterToPoint(this, ClientCenter);
            Visible = true;
        }

        private void NormalToMaximize() {

            SaveClientCenter();
            int width = (int)(Viewport.Width * 0.95);
            int height = (int)(Viewport.Height * 0.95);
            Helper.ScaleTo(this, width, height);
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

        private void FinishLoadUI(object sender, EventArgs e) {

            Opacity += 0.02;

            if(Opacity >= 1) {

                Opacity = 1;
                openTimer.Tick -= FinishLoadUI;
                openTimer.Stop();
            }
        }

        private void ZoomUI(object sender, EventArgs e) {

            float scale = 1.025f;
            Helper.ScaleTo(this, (int)(Width * scale), (int)(Height * scale));

            if(Width * scale >= DefaultWidth || Height * scale >= DefaultHeight) {

                Opacity = 0.9;
                Helper.ScaleTo(this, DefaultWidth, DefaultHeight);
                openTimer.Tick -= ZoomUI;
                openTimer.Tick += FinishLoadUI;
                ToScientificCalculatorPanel();
            }
        }

        private void LoadUI(object sender, EventArgs e) {

            SaveClientCenter();
            SaveDimension();
            int width = (int)(DefaultWidth * 0.97);
            int height = (int)(DefaultHeight * 0.97);
            Helper.ScaleTo(this, width, height);
            openTimer.Tick += ZoomUI;
            openTimer.Start();
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

                if(!Helper.ContainsPointer(topPanel, Cursor.Position)) {

                    CalculatorPanel.DeactivateBackPanel();
                }
            }
        }
    }
}