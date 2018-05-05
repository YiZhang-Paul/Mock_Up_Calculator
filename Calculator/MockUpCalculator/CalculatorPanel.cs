using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlClassLibrary;
using CalculatorClassLibrary;
using FormatterClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class CalculatorPanel : UserControl {

        protected const string _divideByZeroMessage = "Cannot divide by zero";
        protected const string _invalidInputMessage = "Invalid input";

        protected bool MemoryPanelActivated { get; set; }
        protected bool MemoryPanelDeactivated { get; set; }
        protected IKeyChecker Checker { get; set; }
        protected IFormatter NumberFormatter { get; set; }
        protected IFormatter ExpressionFormatter { get; set; }
        protected IStandardCalculator Calculator { get; set; }
        protected IKeypad Keypad { get; set; }
        protected ICalculatorDisplay Display { get; set; }
        protected IMemoryItemDisplay MemoryPanel { get; set; }
        protected virtual IFormatter ActiveFormatter { get { return NumberFormatter; } }

        public CalculatorPanel() {

            InitializeComponent();
        }

        public CalculatorPanel(

            IKeyChecker checker,
            IFormatter numberFormatter,
            IFormatter expressionFormatter,
            IStandardCalculator calculator

        ) {

            InitializeComponent();
            Checker = checker;
            NumberFormatter = numberFormatter;
            ExpressionFormatter = expressionFormatter;
            Calculator = calculator;
        }

        protected virtual void DisplayValue(string value) {

            Display.DisplayResult(value, ActiveFormatter);
        }

        protected virtual void RefreshDisplay(object sender, EventArgs e) {

            Display.RefreshDisplay(ActiveFormatter);
        }

        protected virtual void EnableKeypad() {

            Keypad.HasMemory = Calculator.MemoryValues.Length != 0;
            Keypad.EnableValidKeys();
        }

        protected virtual void KeypadButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.ButtonMouseEnter(sender, e);
        }

        protected virtual void KeypadButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave(sender, e);
        }

        protected virtual void HandleEvaluation() {

            try {

                DisplayValue(Calculator.Evaluate().ToString());
                Calculator.Clear();
            }
            catch(DivideByZeroException) {

                Display.DisplayError(_divideByZeroMessage);
                Keypad.LeaveBasicKeysOn();
            }
            catch(Exception) {

                Display.DisplayError(_invalidInputMessage);
                Keypad.LeaveBasicKeysOn();
            }
        }

        protected virtual void HandleActionKey(string key) {

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
            Display.DisplayExpression(Calculator.Expression, ExpressionFormatter);
        }

        protected virtual void HandleOperator(string key) {

            try {

                Calculator.Add(key);

                if(Calculator.IsSpecialKey(key)) {

                    DisplayValue(Calculator.Input);

                    return;
                }

                DisplayValue(Calculator.LastResult.ToString());
            }
            catch(DivideByZeroException) {

                Display.DisplayError(_divideByZeroMessage);
                Keypad.LeaveBasicKeysOn();
            }
            catch(Exception) {

                Display.DisplayError(_invalidInputMessage);
                Keypad.LeaveBasicKeysOn();
            }
        }

        protected virtual void HandleValue(decimal value) {

            Calculator.Add(value);
            DisplayValue(Calculator.Input);
        }

        protected virtual void HandleCalculation(string key) {

            decimal value = 0;

            if(decimal.TryParse(key, out value)) {

                HandleValue(value);
            }
            else {

                HandleOperator(key);
            }

            Display.DisplayExpression(Calculator.Expression, ExpressionFormatter);
        }

        protected virtual void KeypadButtonMouseClick(object sender, EventArgs e) {

            Display.Clear();
            string key = ((Button)sender).Tag.ToString();

            if(Checker.IsActionKey(key)) {

                HandleActionKey(key);

                return;
            }

            HandleCalculation(key);
        }

        protected virtual void EnableKeypadFromError(object sender, EventArgs e) {

            Display.Clear();
            Calculator.Clear();
            string key = ((Button)sender).Tag.ToString();

            if(Checker.IsInputKey(key)) {

                HandleCalculation(key);
            }
            else {

                DisplayValue(Calculator.Input);
            }
        }

        protected virtual void OpenMemoryPanel() {

            MemoryPanel.Extend(Keypad.MainAreaHeight);
            Keypad.LeaveMemoryKeyOn();
        }

        protected virtual void CloseMemoryPanel() {

            MemoryPanel.Shrink();
            EnableKeypad();
        }

        protected virtual void ToggleMemoryPanel(object sender, EventArgs e) {

            if(MemoryPanelDeactivated) {

                MemoryPanelDeactivated = false;

                return;
            }

            if(!MemoryPanelActivated) {

                OpenMemoryPanel();

                return;
            }

            CloseMemoryPanel();
        }

        protected virtual void CalculatorMemoryStore(object sender, EventArgs e) {

            decimal value = 0;

            if(!decimal.TryParse(Display.Content, out value)) {

                return;
            }

            Calculator.MemoryStore(value);
            Calculator.ClearInput();
        }

        protected virtual void CalculatorMemoryClear(object sender, EventArgs e) {

            Calculator.MemoryClear();
        }

        protected virtual void CalculatorMemoryRecall(object sender, EventArgs e) {

            Calculator.MemoryRecall();
            DisplayValue(Calculator.Input);
        }

        protected virtual void CalculatorMemoryPlus(object sender, EventArgs e) {

            int total = Calculator.MemoryValues.Length;

            if(total == 0) {

                Calculator.MemoryStore(Display.RecentValue);
            }
            else {

                Calculator.MemoryPlus(total - 1, Display.RecentValue);
            }

            Calculator.ClearInput();
        }

        protected virtual void CalculatorMemoryMinus(object sender, EventArgs e) {

            int total = Calculator.MemoryValues.Length;

            if(total == 0) {

                Calculator.MemoryStore(-Display.RecentValue);
            }
            else {

                Calculator.MemoryMinus(total - 1, Display.RecentValue);
            }

            Calculator.ClearInput();
        }

        protected virtual void RefreshMemoryPanel() {

            MemoryPanel.RefreshItems(Calculator.MemoryValues, NumberFormatter);
        }

        protected virtual void MemoryPanelRemove(object sender, EventArgs e) {

            int key = MemoryPanel.TryGetKey(sender);
            Calculator.MemoryRemove(key);
            RefreshMemoryPanel();
        }

        protected virtual void MemoryPanelClear(object sender, EventArgs e) {

            CalculatorMemoryClear(sender, e);
            CloseMemoryPanel();
        }

        protected virtual void MemoryPanelSelect(object sender, EventArgs e) {

            int key = MemoryPanel.TryGetKey(sender);
            Calculator.MemoryRetrieve(key);
            DisplayValue(Calculator.Input);
            CloseMemoryPanel();
        }

        protected virtual void MemoryPanelPlus(object sender, EventArgs e) {

            int key = MemoryPanel.TryGetKey(sender);
            Calculator.MemoryPlus(key, Display.RecentValue);
            RefreshMemoryPanel();
        }

        protected virtual void MemoryPanelMinus(object sender, EventArgs e) {

            int key = MemoryPanel.TryGetKey(sender);
            Calculator.MemoryMinus(key, Display.RecentValue);
            RefreshMemoryPanel();
        }

        protected virtual void MemoryPanelExtended(object sender, EventArgs e) {

            MemoryPanelActivated = true;
            MemoryPanel.ShowItems(Calculator.MemoryValues, NumberFormatter);
        }

        protected virtual void MemoryPanelShrunken(object sender, EventArgs e) {

            MemoryPanelActivated = false;
            ((Control)Keypad).BringToFront();
        }

        public void DeactivateMemoryPanel() {

            bool deselected = MemoryPanelActivated && !UIHelper.ContainsPointer((Control)MemoryPanel);

            if(deselected) {

                CloseMemoryPanel();
            }

            MemoryPanelDeactivated = deselected;
            Keypad.ExtraKeysSuspended = deselected;
        }
    }
}