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
    public partial class CalculatorPanel : UserControl, IResizable {

        protected const string _divideByZeroMessage = "Cannot divide by zero";
        protected const string _invalidInputMessage = "Invalid input";

        protected bool BackPanelActivated { get; set; }
        protected bool BackPanelDeactivated { get; set; }
        protected List<Tuple<string, decimal>> History { get; set; }
        protected IHelper Helper { get; set; }
        protected IExpandable ActiveBackPanel { get; set; }
        protected IKeyChecker Checker { get; set; }
        protected IFormatter NumberFormatter { get; set; }
        protected IFormatter ExpressionFormatter { get; set; }
        protected IStandardCalculator Calculator { get; set; }
        protected IKeypad Keypad { get; set; }
        protected ICalculatorDisplay Display { get; set; }
        protected IMemoryItemDisplay MemoryPanel { get; set; }
        protected IHistoryItemDisplay HistoryPanel { get; set; }
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
            History = new List<Tuple<string, decimal>>();
            NumberFormatter = numberFormatter;
            ExpressionFormatter = expressionFormatter;
            Calculator = calculator;
            Helper = new UIHelper();
        }

        private void PlaceBackPanel(Control panel, Control parent) {

            panel.Parent = parent;
            panel.Height = 50;
            panel.Width = Width;
            panel.Anchor = AnchorStyles.Bottom;
            panel.Top = parent.Height - panel.Height;
        }

        protected virtual void SetupMemoryPanel(Control parent) {

            MemoryPanel = new MemoryPanel(NumberFormatter);
            MemoryPanel.OnMemoryDelete += MemoryPanelRemove;
            MemoryPanel.OnClear += MemoryPanelClear;
            MemoryPanel.OnMemorySelect += MemoryPanelSelect;
            MemoryPanel.OnMemoryPlus += MemoryPanelPlus;
            MemoryPanel.OnMemoryMinus += MemoryPanelMinus;
            MemoryPanel.OnExtended += MemoryPanelExtended;
            MemoryPanel.OnShrunken += BackPanelShrunken;
            PlaceBackPanel((Control)MemoryPanel, parent);
        }

        protected virtual void SetupHistoryPanel(Control parent) {

            HistoryPanel = new HistoryPanel(ExpressionFormatter, NumberFormatter);
            HistoryPanel.OnClear += HistoryPanelClear;
            HistoryPanel.OnHistorySelect += HistoryPanelSelect;
            HistoryPanel.OnExtended += HistoryPanelExtended;
            HistoryPanel.OnShrunken += BackPanelShrunken;
            PlaceBackPanel((Control)HistoryPanel, parent);
        }

        protected virtual void FitToParent(Control control) {

            control.Width = control.Parent.Width;
            control.Left = 0;
        }

        public virtual void AdjustSize() {

            if(ActiveBackPanel != null) {

                Helper.SetHeight((Control)ActiveBackPanel, Keypad.MainAreaHeight);
                FitToParent((Control)ActiveBackPanel);
            }
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

            Helper.ButtonMouseEnter(sender, e);
        }

        protected virtual void KeypadButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave(sender, e);
        }

        protected virtual void AddHistory(string expression, decimal result) {

            History.Add(new Tuple<string, decimal>(expression, result));
        }

        protected virtual void HandleEvaluation() {

            try {

                decimal result = Calculator.Evaluate();
                DisplayValue(result.ToString());
                AddHistory(Calculator.Expression, result);
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

        protected virtual void ClosePanel(IExpandable panel) {

            panel.Shrink();
            EnableKeypad();
        }

        protected virtual void ToggleMemoryPanel(object sender, EventArgs e) {

            if(BackPanelDeactivated) {

                BackPanelDeactivated = false;

                return;
            }

            if(!BackPanelActivated) {

                OpenMemoryPanel();

                return;
            }

            ClosePanel(MemoryPanel);
        }

        protected virtual void OpenHistoryPanel() {

            HistoryPanel.Extend(Keypad.MainAreaHeight);
            Keypad.DisableAllKeys();
        }

        public void ToggleHistoryPanel(object sender, EventArgs e) {

            if(BackPanelDeactivated) {

                BackPanelDeactivated = false;

                return;
            }

            if(!BackPanelActivated) {

                OpenHistoryPanel();

                return;
            }

            ClosePanel(HistoryPanel);
        }

        protected virtual void CalculatorMemoryStore(object sender, EventArgs e) {

            decimal value = 0;

            if(!decimal.TryParse(Display.Input, out value)) {

                return;
            }

            Calculator.MemoryStore(value);
            Calculator.ClearInput();
        }

        protected virtual void CalculatorMemoryClear(object sender, EventArgs e) {

            Calculator.MemoryClear();
            MemoryPanel.ResetPointer();
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

        protected virtual int GetMemoryItemKey(object sender) {

            return ((IMemoryItem)sender).Key;
        }

        protected virtual void RefreshMemoryPanel() {

            MemoryPanel.RefreshItems(Calculator.MemoryValues);
        }

        protected virtual void MemoryPanelRemove(object sender, EventArgs e) {

            int key = GetMemoryItemKey(sender);
            Calculator.MemoryRemove(key);
            RefreshMemoryPanel();
        }

        protected virtual void MemoryPanelClear(object sender, EventArgs e) {

            CalculatorMemoryClear(sender, e);
            ClosePanel(MemoryPanel);
        }

        protected virtual void MemoryPanelSelect(object sender, EventArgs e) {

            int key = GetMemoryItemKey(sender);
            Calculator.MemoryRetrieve(key);
            DisplayValue(Calculator.Input);
            ClosePanel(MemoryPanel);
        }

        protected virtual void MemoryPanelPlus(object sender, EventArgs e) {

            int key = GetMemoryItemKey(sender);
            Calculator.MemoryPlus(key, Display.RecentValue);
            RefreshMemoryPanel();
        }

        protected virtual void MemoryPanelMinus(object sender, EventArgs e) {

            int key = GetMemoryItemKey(sender);
            Calculator.MemoryMinus(key, Display.RecentValue);
            RefreshMemoryPanel();
        }

        protected virtual void MemoryPanelExtended(object sender, EventArgs e) {

            BackPanelActivated = true;
            ActiveBackPanel = MemoryPanel;
            MemoryPanel.ShowItems(Calculator.MemoryValues);
        }

        protected virtual void BackPanelShrunken(object sender, EventArgs e) {

            BackPanelActivated = false;
            ((Control)Keypad).BringToFront();
        }

        protected virtual void RestoreHistory(string expression) {

            Calculator.Clear();
            var tokens = expression.Split(' ');

            for(int i = 0; i < tokens.Length; i++) {

                HandleCalculation(tokens[i]);
            }
        }

        protected virtual void HistoryPanelSelect(object sender, EventArgs e) {

            RestoreHistory(((IHistoryItem)sender).RawExpression);
            ClosePanel(HistoryPanel);
        }

        protected virtual void HistoryPanelClear(object sender, EventArgs e) {

            History.Clear();
            ClosePanel(HistoryPanel);
        }

        protected virtual void HistoryPanelExtended(object sender, EventArgs e) {

            BackPanelActivated = true;
            ActiveBackPanel = HistoryPanel;
            HistoryPanel.ShowItems(History.ToArray());
        }

        public void DeactivateBackPanel() {

            if(ActiveBackPanel == null) {

                return;
            }

            bool mouseOver = Helper.ContainsPointer((Control)ActiveBackPanel, Cursor.Position);
            bool deselected = BackPanelActivated && !mouseOver;

            if(deselected) {

                ClosePanel(ActiveBackPanel);
            }

            BackPanelDeactivated = deselected;
            Keypad.ExtraKeysSuspended = deselected;
        }
    }
}