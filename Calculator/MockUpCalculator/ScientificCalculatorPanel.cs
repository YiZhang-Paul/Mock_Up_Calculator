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
    public partial class ScientificCalculatorPanel : UserControl {

        protected const string _divideByZeroMessage = "Cannot divide by zero";
        protected const string _invalidInputMessage = "Invalid input";

        private bool MemoryPanelActivated { get; set; }
        private bool MemoryPanelDeactivated { get; set; }
        private IScientificCalculator Calculator { get; set; }
        private IKeyChecker Checker { get; set; }
        private IFormatter NumberFormatter { get; set; }
        private IFormatter EngineeringFormatter { get; set; }

        public ScientificCalculatorPanel(

            IScientificCalculator calculator,
            IKeyChecker checker,
            IFormatter numberFormatter,
            IFormatter engineeringFormatter

        ) {

            InitializeComponent();
            Calculator = calculator;
            Checker = checker;
            NumberFormatter = numberFormatter;
            EngineeringFormatter = engineeringFormatter;
            SetupKeypad();
            SetupMemoryPanel();
            DisplayValue(Calculator.Input);
        }

        private void SetupKeypad() {

            scientificKeypad.OnKeypadEnable += EnableKeypadFromError;
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

        private void SetupMemoryPanel() {

            memoryPanel.OnMemoryDelete += MemoryRemove;
            memoryPanel.OnClear += MemoryPanelClear;
            memoryPanel.OnMemorySelect += MemorySelect;
            memoryPanel.OnMemoryPlus += MemoryPlusByKey;
            memoryPanel.OnMemoryMinus += MemoryMinusByKey;
            memoryPanel.OnExtended += MemoryPanelExtended;
            memoryPanel.OnShrunken += MemoryPanelShrunken;
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

        private void RefreshDisplay(object sender, EventArgs e) {

            standardDisplay.RefreshDisplay(GetFormatter());
        }

        private void EnableKeypad() {

            scientificKeypad.HasMemory = Calculator.MemoryValues.Length != 0;
            scientificKeypad.EnableValidKeys();
        }

        private void HandleEvaluation() {

            try {

                DisplayValue(Calculator.Evaluate().ToString());
                Calculator.Clear();
            }
            catch(DivideByZeroException) {

                standardDisplay.DisplayError(_divideByZeroMessage);
                scientificKeypad.LeaveBasicKeysOn();
            }
            catch(Exception) {

                standardDisplay.DisplayError(_invalidInputMessage);
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

                standardDisplay.DisplayError(_divideByZeroMessage);
                scientificKeypad.LeaveBasicKeysOn();
            }
            catch(Exception) {

                standardDisplay.DisplayError(_invalidInputMessage);
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

        private void RemoveFocus(object sender, EventArgs e) {

            memoryPanel.Focus();
        }

        private void ChangeAngularUnit(object sender, EventArgs e) {

            Calculator.ChangeAngularUnit();
        }

        private void KeypadButtonMouseClick(object sender, EventArgs e) {

            standardDisplay.Clear();
            string key = ((Button)sender).Tag.ToString();

            if(Checker.IsActionKey(key)) {

                HandleActionKey(key);

                return;
            }

            HandleCalculation(key);
        }

        private void EnableKeypadFromError(object sender, EventArgs e) {

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

        private void OpenMemoryPanel() {

            memoryPanel.Extend(scientificKeypad.MainAreaHeight);
            scientificKeypad.LeaveMemoryKeyOn();
        }

        private void CloseMemoryPanel() {

            memoryPanel.Shrink();
            EnableKeypad();
        }

        private void MemoryPanelExtended(object sender, EventArgs e) {

            MemoryPanelActivated = true;
            memoryPanel.ShowItems(Calculator.MemoryValues, NumberFormatter);
        }

        private void MemoryPanelShrunken(object sender, EventArgs e) {

            MemoryPanelActivated = false;
            scientificKeypad.BringToFront();
        }

        private void ToggleMemoryPanel(object sender, EventArgs e) {

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

        private void RefreshMemoryPanel() {

            memoryPanel.RefreshItems(Calculator.MemoryValues, NumberFormatter);
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

        private void MemoryPanelClear(object sender, EventArgs e) {

            MemoryClear(sender, e);
            CloseMemoryPanel();
        }

        private void MemoryRemove(object sender, EventArgs e) {

            int key = memoryPanel.TryGetKey(sender);
            Calculator.MemoryRemove(key);
            RefreshMemoryPanel();
        }

        private void MemoryRecall(object sender, EventArgs e) {

            Calculator.MemoryRecall();
            DisplayValue(Calculator.Input);
        }

        private void MemorySelect(object sender, EventArgs e) {

            int key = memoryPanel.TryGetKey(sender);
            Calculator.MemoryRetrieve(key);
            DisplayValue(Calculator.Input);
            CloseMemoryPanel();
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

            int key = memoryPanel.TryGetKey(sender);
            Calculator.MemoryPlus(key, standardDisplay.RecentValue);
            RefreshMemoryPanel();
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

            int key = memoryPanel.TryGetKey(sender);
            Calculator.MemoryMinus(key, standardDisplay.RecentValue);
            RefreshMemoryPanel();
        }

        private void KeypadButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.ButtonMouseEnter(sender, e);
        }

        private void KeypadButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave(sender, e);
        }

        public void DeactivateMemoryPanel() {

            bool deselected = MemoryPanelActivated && !UIHelper.ContainsPointer(memoryPanel);

            if(deselected) {

                CloseMemoryPanel();
            }

            MemoryPanelDeactivated = deselected;
            scientificKeypad.ExtraKeysSuspended = deselected;
        }
    }
}