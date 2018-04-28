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
    public partial class MainCalculator : Form {

        private const string divideByZeroMessage = "Cannot divide by zero";
        private const string invalidInput = "Invalid input";

        private int DefaultWidth { get; set; }
        private int DefaultHeight { get; set; }
        private bool MemoryPanelOn { get; set; }
        private bool MemoryPanelDeselected { get; set; }
        private Point ClientCenter { get; set; }
        private Point Pointer { get; set; }
        private Resizer Resizer { get; set; }
        private Rectangle Viewport { get { return Screen.FromControl(this).WorkingArea; } }
        private IKeyChecker Checker { get; set; }
        private IFormatter NumberFormatter { get; set; }
        private IFormatter EngineeringFormatter { get; set; }
        private IScientificCalculator Calculator { get; set; }

        public MainCalculator() {

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
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

            scientificKeypad.OnKeypadEnable += KeypadEnable;
            scientificKeypad.OnEngineeringModeToggle += RefreshDisplay;
            scientificKeypad.OnAngularUnitToggle += ChangeAngularUnit;
            scientificKeypad.OnMemoryToggle += ToggleMemoryPanel;
            scientificKeypad.OnMemoryStore += MemoryStore;
            scientificKeypad.OnMemoryClear += MemoryClear;
            scientificKeypad.OnMemoryRecall += MemoryRecall;
            scientificKeypad.OnMemoryAdd += MemoryPlus;
            scientificKeypad.OnMemorySubtract += MemoryMinus;
            scientificKeypad.OnButtonMouseClick += KeypadButtonMouseClick;
            scientificKeypad.OnButtonMouseEnter += KeypadButtonMouseEnter;
            scientificKeypad.OnButtonMouseLeave += KeypadButtonMouseLeave;
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
            Checker = new KeyChecker();
            Calculator = new ScientificCalculator();
            NumberFormatter = new NumberFormatter();
            EngineeringFormatter = new EngineeringFormatter();
            DisplayValue(Calculator.Input);
            SaveDimension();
            SetupTopPanel();
            SetupKeypad();
        }

        private IFormatter GetFormatter() {

            if(scientificKeypad.EngineeringMode) {

                return EngineeringFormatter;
            }

            return NumberFormatter;
        }

        private void DisplayValue(string value) {

            standardDisplay.DisplayResult(value, GetFormatter());
        }

        private void HandleEvaluation() {

            try {

                DisplayValue(Calculator.Evaluate().ToString());
                Calculator.Clear();
            }
            catch(DivideByZeroException) {

                standardDisplay.DisplayError(divideByZeroMessage);
                scientificKeypad.LeaveBasicKeysOn();
            }
            catch(Exception) {

                standardDisplay.DisplayError(invalidInput);
                scientificKeypad.LeaveBasicKeysOn();
            }
        }

        private void HandleActionKey(string key) {

            if(key == "=") {

                HandleEvaluation();

                return;
            }

            if(key == "C") {

                Calculator.Clear();
            }
            else if(key == "CE") {

                Calculator.ClearInput();
            }
            else {

                Calculator.Undo();
            }

            DisplayValue(Calculator.Input);
            standardDisplay.DisplayExpression(Calculator.Expression);
        }

        private void HandleValue(decimal value) {

            Calculator.Add(value);
            DisplayValue(Calculator.Input);
        }

        private void HandleOperator(string key) {

            try {

                Calculator.Add(Calculator.CheckTrigonometricKey(key));

                if(Calculator.IsSpecialKey(key)) {

                    DisplayValue(Calculator.Input);

                    return;
                }

                DisplayValue(Calculator.LastResult.ToString());
            }
            catch(DivideByZeroException) {

                standardDisplay.DisplayError(divideByZeroMessage);
                scientificKeypad.LeaveBasicKeysOn();
            }
            catch(Exception) {

                standardDisplay.DisplayError(invalidInput);
                scientificKeypad.LeaveBasicKeysOn();
            }
        }

        private void HandleCalculation(string key) {

            decimal value = 0;

            if(decimal.TryParse(key, out value)) {

                HandleValue(value);
            }
            else {

                HandleOperator(key);
            }

            standardDisplay.DisplayExpression(Calculator.Expression);
        }

        private void KeypadButtonMouseClick(object sender, EventArgs e) {

            ButtonLoseFocus(sender, e);
            standardDisplay.Clear();
            string key = ((Button)sender).Tag.ToString();

            if(Checker.IsActionKey(key)) {

                HandleActionKey(key);

                return;
            }

            HandleCalculation(key);
        }

        private void KeypadEnable(object sender, EventArgs e) {

            standardDisplay.Clear();
            Calculator.Clear();
            string key = ((Button)sender).Tag.ToString();

            if(Checker.IsInputKey(key)) {

                HandleCalculation(key);
            }
            else {

                DisplayValue(Calculator.Input);
            }
        }

        private void RefreshDisplay(object sender, EventArgs e) {

            standardDisplay.RefreshDisplay(GetFormatter());
        }

        private void ChangeAngularUnit(object sender, EventArgs e) {

            Calculator.ChangeAngularUnit();
        }

        private void ButtonLoseFocus(object sender, EventArgs e) {

            currentCalculatorLabel.Focus();
        }

        private void OpenMemoryPanel(object sender, EventArgs e) {

            int speed = Math.Min(65, scientificKeypad.MainAreaHeight - memoryPanel.Height);
            memoryPanel.Top -= speed;
            memoryPanel.Height += speed;

            if(memoryPanel.Height >= scientificKeypad.MainAreaHeight) {

                MemoryPanelOn = true;
                memoryTimer.Tick -= OpenMemoryPanel;
                memoryTimer.Stop();
                ShowMemoryItems();
            }
        }

        private void CloseMemoryPanel(object sender, EventArgs e) {

            int alpha = Math.Max(0, memoryPanel.BackColor.A - 75);
            int red = memoryPanel.BackColor.R;
            int green = memoryPanel.BackColor.G;
            int blue = memoryPanel.BackColor.B;
            memoryPanel.BackColor = Color.FromArgb(alpha, red, green, blue);

            if(alpha <= 0) {

                MemoryPanelOn = false;
                memoryPanel.Height = 50;
                memoryPanel.Top += scientificKeypad.MainAreaHeight - memoryPanel.Height;
                memoryPanel.BackColor = Color.FromArgb(255, red, green, blue);
                memoryTimer.Tick -= CloseMemoryPanel;
                memoryTimer.Stop();
                scientificKeypad.BringToFront();
            }
        }

        private void StartMemoryPanelOpen() {

            memoryTimer.Tick -= CloseMemoryPanel;
            memoryTimer.Tick += OpenMemoryPanel;
            memoryTimer.Start();
            memoryPanel.BringToFront();
            scientificKeypad.LeaveMemoryKeyOn();
        }

        private void StartMemoryPanelClose() {

            RemoveMemoryItems();
            memoryTimer.Tick -= OpenMemoryPanel;
            memoryTimer.Tick += CloseMemoryPanel;
            memoryTimer.Start();
            scientificKeypad.EnableAllKeys();
        }

        private void ToggleMemoryPanel(object sender, EventArgs e) {

            if(MemoryPanelDeselected) {

                MemoryPanelDeselected = false;

                return;
            }

            if(!MemoryPanelOn) {

                StartMemoryPanelOpen();

                return;
            }

            StartMemoryPanelClose();
        }

        private void RemoveMemoryItems() {

            var controls = memoryPanel.Controls.OfType<MemoryItem>().ToArray();

            for(int i = 0; i < controls.Length; i++) {

                controls[i].Dispose();
            }
        }

        private MemoryItem GetMemoryItem(int key, decimal value) {

            var item = new MemoryItem(key, value, NumberFormatter);
            item.Parent = memoryPanel;
            item.Visible = false;
            item.OnDelete += MemoryRemove;
            item.OnMemoryPlus += MemoryPlusByKey;
            item.OnMemoryMinus += MemoryMinusByKey;

            return item;
        }

        private void ShowMemoryItems() {

            const int visibleItems = 3;
            const int itemMargin = 15;
            int panelHeight = scientificKeypad.MainAreaHeight;
            int totalHeight = (int)((double)panelHeight / visibleItems);
            decimal[] items = Calculator.MemoryValues;

            for(int i = items.Length - 1, j = 0; i >= 0; i--, j++) {

                var item = GetMemoryItem(i, items[i]);
                item.Height = totalHeight - itemMargin;

                if(j < visibleItems) {

                    item.Top = totalHeight * j + itemMargin;
                    item.Visible = true;
                }
            }
        }

        private void RefreshMemoryItems() {

            RemoveMemoryItems();
            ShowMemoryItems();
        }

        private int TryGetItemKey(object sender) {

            var button = (Button)sender;
            var item = (IMemoryItem)button.Tag;

            return item.Key;
        }

        private void MemoryStore(object sender, EventArgs e) {

            decimal value = 0;

            if(!decimal.TryParse(standardDisplay.Content, out value)) {

                return;
            }

            Calculator.MemoryStore(value);
            Calculator.ClearInput();
        }

        private void MemoryClear(object sender, EventArgs e) {

            Calculator.MemoryClear();
        }

        private void MemoryRecall(object sender, EventArgs e) {

            Calculator.MemoryRecall();
            DisplayValue(Calculator.Input);
        }

        private void MemoryRemove(object sender, EventArgs e) {

            Calculator.MemoryRemove(TryGetItemKey(sender));
            RefreshMemoryItems();
        }

        private void MemoryPlus(object sender, EventArgs e) {

            int total = Calculator.MemoryValues.Length;

            if(total == 0) {

                Calculator.MemoryStore(standardDisplay.RecentValue);
            }
            else {

                Calculator.MemoryPlus(total - 1, standardDisplay.RecentValue);
            }

            Calculator.ClearInput();
        }

        private void MemoryPlusByKey(object sender, EventArgs e) {

            Calculator.MemoryPlus(TryGetItemKey(sender), standardDisplay.RecentValue);
            RefreshMemoryItems();
        }

        private void MemoryMinus(object sender, EventArgs e) {

            int total = Calculator.MemoryValues.Length;

            if(total == 0) {

                Calculator.MemoryStore(-standardDisplay.RecentValue);
            }
            else {

                Calculator.MemoryMinus(total - 1, standardDisplay.RecentValue);
            }

            Calculator.ClearInput();
        }

        private void MemoryMinusByKey(object sender, EventArgs e) {

            Calculator.MemoryMinus(TryGetItemKey(sender), standardDisplay.RecentValue);
            RefreshMemoryItems();
        }

        private void KeypadButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.KeypadButtonMouseEnter(sender, e);
        }

        private void KeypadButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.KeypadButtonMouseLeave(sender, e);
        }

        private void GetPointerLocation(object sender, MouseEventArgs e) {

            Pointer = UIHelper.GetPointerLocation(e);
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

        private void MainCalculator_ResizeBegin(object sender, EventArgs e) {

            mainLayout.Visible = false;
        }

        private void MainCalculator_ResizeEnd(object sender, EventArgs e) {

            SaveDimension();
            mainLayout.Visible = true;
        }

        private void MainCalculator_Deactivate(object sender, EventArgs e) {

            DeselectMemoryPanel();
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

        private void DeselectMemoryPanel() {

            bool hoverOnTopPanel = UIHelper.ContainsPointer(topPanel);
            bool hoverOnMemoryPanel = UIHelper.ContainsPointer(memoryPanel);
            bool deselected = MemoryPanelOn && !hoverOnTopPanel && !hoverOnMemoryPanel;

            if(deselected) {

                StartMemoryPanelClose();
            }

            MemoryPanelDeselected = deselected;
            scientificKeypad.ExtraKeysSuspended = deselected;
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

                DeselectMemoryPanel();
            }
        }
    }
}