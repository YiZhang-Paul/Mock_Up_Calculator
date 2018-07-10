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

        protected int DefaultWidth { get; set; }
        protected int DefaultHeight { get; set; }
        protected Point ClientCenter { get; set; }
        protected Point Pointer { get; set; }
        protected Rectangle Viewport { get { return Helper.GetViewport(this); } }
        protected List<string[]> MenuItems { get; set; }
        protected TableLayoutPanel MainLayout { get { return mainLayout; } }
        protected ServiceLookup ServiceLookup { get; set; }
        protected ISidePanel SidePanel { get; set; }
        protected ICalculatorPanel CalculatorPanel { get; set; }
        protected ConverterPanel ConverterPanel { get; set; }
        protected IHelper Helper { get; set; }
        protected IResize Resizer { get; set; }

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

            SidePanel = sidePanel;
            sidePanel.OnExtended += ShowSidePanel;
            sidePanel.OnShrunken += HideSidePanel;
            sidePanel.OnSelect += SelectCalculator;
        }

        protected void SaveDimension() {

            DefaultWidth = Width;
            DefaultHeight = Height;
        }

        protected void SaveClientCenter() {

            ClientCenter = PointToScreen(new Point(Width / 2, Height / 2));
        }

        protected virtual void Initialize() {

            Resizer = new Resizer(this);
            ServiceLookup = new ServiceLookup();
            Helper = new UIHelper();
            SaveDimension();
            SaveClientCenter();
            SetupTopPanel();
            SetupSidePanel();

            MenuItems = new List<string[]>() {

                new string[] { "Calculator", "Standard", "Scientific" },
                new string[] { "Converter", "Currency", "Angle" }
            };
        }

        protected void ClearMainPanel() {

            if(ConverterPanel != null) {

                ConverterPanel.Dispose();
            }

            if(CalculatorPanel != null) {

                ((Control)CalculatorPanel).Dispose();
            }
        }

        protected void LoadMainPanel(Control panel) {

            panel.Parent = uiLayout;
            panel.Dock = DockStyle.Fill;
            panel.Show();
        }

        protected void ResizeMainPanel() {

            if(CalculatorPanel != null) {

                CalculatorPanel.AdjustSize();
            }
        }

        protected void ToCalculator(string label, Func<ICalculatorPanel> factoryMethod) {

            btnHistory.Visible = true;
            currentLabel.Text = label;
            ClearMainPanel();
            CalculatorPanel = factoryMethod();
            LoadMainPanel((Control)CalculatorPanel);
        }

        protected void ToConverter(string label, Func<ConverterPanel> factoryMethod) {

            btnHistory.Visible = false;
            currentLabel.Text = label;
            ClearMainPanel();
            ConverterPanel = factoryMethod();
            LoadMainPanel(ConverterPanel);
        }

        protected void ToStandardCalculator() {

            ToCalculator("Standard", ServiceLookup.GetStandardCalculatorPanel);
        }

        protected void ToScientificCalculatorPanel() {

            ToCalculator("Scientific", ServiceLookup.GetScientificCalculatorPanel);
        }

        protected void ToAngleConverterPanel() {

            ToConverter("Angle", ServiceLookup.GetAngleConverterPanel);
        }

        protected void ToggleHistoryPanel(object sender, EventArgs e) {

            currentLabel.Focus();

            if(CalculatorPanel != null) {

                CalculatorPanel.ToggleHistoryPanel(sender, e);
            }
        }

        protected void SavePointerLocation(object sender, MouseEventArgs e) {

            Pointer = Helper.GetPointerLocation(e);
        }

        protected void KeypadButtonMouseEnter(object sender, EventArgs e) {

            Helper.ButtonMouseEnter(sender, e);
        }

        protected void KeypadButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave(sender, e);
        }

        protected void ChangeMenuClick(object sender, EventArgs e) {

            currentLabel.Focus();
            currentLabel.Visible = false;
            SidePanel.Extend(Math.Min(280, Width / 4 * 3));
        }

        protected void ShowSidePanel(object sender, EventArgs e) {

            SidePanel.ShowMenu(MenuItems, currentLabel.Text);
        }

        protected void HideSidePanel(object sender, EventArgs e) {

            currentLabel.Visible = true;
            sidePanel.SendToBack();
        }

        protected virtual void SelectCalculator(object sender, EventArgs e) {

            string selection = ((Control)sender).Tag.ToString();

            if(selection == currentLabel.Text) {

                return;
            }

            switch(selection) {

                case "Standard" :

                    ToStandardCalculator();

                    break;

                case "Scientific" :

                    ToScientificCalculatorPanel();

                    break;

                case "Angle" :

                    ToAngleConverterPanel();

                    break;
            }
        }

        protected virtual void FormResizeBegin(object sender, EventArgs e) {

            MainLayout.Visible = false;
        }

        protected virtual void FormResizeEnd(object sender, EventArgs e) {

            SaveDimension();
            MainLayout.Visible = true;
            ResizeMainPanel();
            SidePanel.AdjustSize();
        }

        protected virtual void DeactivateBackPanel(object sender, EventArgs e) {

            if(CalculatorPanel != null) {

                CalculatorPanel.DeactivateBackPanel();
            }
        }

        protected void DragWindow(object sender, MouseEventArgs e) {

            if(WindowState == FormWindowState.Maximized) {

                return;
            }

            Helper.DragWindow(e, this, Pointer);
        }

        protected void Minimize(object sender, EventArgs e) {

            WindowState = FormWindowState.Minimized;
        }

        protected void ZoomToMax(object sender, EventArgs e) {

            Helper.ScaleTo(this, Width + 20, Height + 20);
            ResizeMainPanel();
            SidePanel.AdjustSize();

            if(Width >= Viewport.Width && Height >= Viewport.Height) {

                bottomPanel.Visible = true;
                WindowState = FormWindowState.Maximized;
                ResizeMainPanel();
                SidePanel.AdjustSize();
                zoomTimer.Tick -= ZoomToMax;
                zoomTimer.Stop();
            }
        }

        protected void MaximizeToNormal() {

            WindowState = FormWindowState.Normal;
            Opacity = 0;
            Helper.ScaleTo(this, DefaultWidth, DefaultHeight, false);
            Helper.CenterToPoint(this, ClientCenter);
            ResizeMainPanel();
            SidePanel.AdjustSize();
            Opacity = 1;
        }

        protected void NormalToMaximize() {

            SaveClientCenter();
            int width = (int)(Viewport.Width * 0.95);
            int height = (int)(Viewport.Height * 0.95);
            Helper.ScaleTo(this, width, height);
            bottomPanel.Visible = false;
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

        protected void FinishLoadUI(object sender, EventArgs e) {

            Opacity += 0.02;

            if(Opacity >= 1) {

                Opacity = 1;
                openTimer.Tick -= FinishLoadUI;
                openTimer.Stop();
            }
        }

        protected void ZoomUI(object sender, EventArgs e) {

            float scale = 1.025f;
            Helper.ScaleTo(this, (int)(Width * scale), (int)(Height * scale));

            if(Width * scale >= DefaultWidth || Height * scale >= DefaultHeight) {

                Opacity = 0.9;
                Helper.ScaleTo(this, DefaultWidth, DefaultHeight);
                openTimer.Tick -= ZoomUI;
                openTimer.Tick += FinishLoadUI;
                ToAngleConverterPanel();
            }
        }

        protected void LoadUI(object sender, EventArgs e) {

            SaveClientCenter();
            SaveDimension();
            int width = (int)(DefaultWidth * 0.97);
            int height = (int)(DefaultHeight * 0.97);
            Helper.ScaleTo(this, width, height);
            openTimer.Tick += ZoomUI;
            openTimer.Start();
        }

        protected void CloseUI(object sender, EventArgs e) {

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

        protected void ResizeWindow(ref Message message, Point cursor) {

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

                ResizeWindow(ref message, PointToClient(Cursor.Position));
            }
            else if(message.Msg == click || (message.Msg == notify && (int)message.WParam == click)) {

                if(!Helper.ContainsPointer(topPanel, Cursor.Position)) {

                    DeactivateBackPanel(null, null);
                }
            }
        }
    }
}