﻿using System;
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
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class MainCalculator : Form {

        private const string divideByZeroMessage = "Cannot divide by zero";
        private const string invalidInput = "Invalid input";

        private int DefaultWidth { get; set; }
        private int DefaultHeight { get; set; }
        private Point ClientCenter { get; set; }
        private Point Pointer { get; set; }
        private Resizer Resizer { get; set; }
        private Rectangle Viewport { get { return Screen.FromControl(this).WorkingArea; } }
        private IKeyChecker Checker { get; set; }
        private IFormatter NumberFormatter { get; set; }
        private IFormatter EngineeringFormatter { get; set; }
        private IStandardCalculator Calculator { get; set; }

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
            Calculator = new StandardCalculator();
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
                scientificKeypad.DisableKeys();
            }
            catch(Exception) {

                standardDisplay.DisplayError(invalidInput);
                scientificKeypad.DisableKeys();
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

                Calculator.Add(key);

                if(Calculator.IsSpecialKey(key)) {

                    DisplayValue(Calculator.Input);

                    return;
                }

                DisplayValue(Calculator.LastResult.ToString());
            }
            catch(DivideByZeroException) {

                standardDisplay.DisplayError(divideByZeroMessage);
                scientificKeypad.DisableKeys();
            }
            catch(Exception) {

                standardDisplay.DisplayError(invalidInput);
                scientificKeypad.DisableKeys();
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

        private void ButtonLoseFocus(object sender, EventArgs e) {

            currentCalculatorLabel.Focus();
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

        protected override void WndProc(ref Message message) {

            base.WndProc(ref message);

            if(message.Msg != 0x84) {

                return;
            }
            //WM_NCHITTEST
            var cursor = PointToClient(Cursor.Position);

            foreach(int key in Resizer.Keys) {

                if(Resizer.Boxes[key]().Contains(cursor)) {

                    message.Result = (IntPtr)key;

                    break;
                }
            }
        }
    }
}