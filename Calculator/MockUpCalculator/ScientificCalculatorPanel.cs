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
    public partial class ScientificCalculatorPanel : BaseCalculatorPanel {

        private bool MemoryPanelActivated { get; set; }
        private bool MemoryPanelDeactivated { get; set; }
        private IFormatter EngineeringFormatter { get; set; }
        private new IScientificCalculator Calculator { get; set; }

        protected override IFormatter ActiveFormatter {

            get {

                if(scientificKeypad.EngineeringMode) {

                    return EngineeringFormatter;
                }

                return base.ActiveFormatter;
            }
        }

        public ScientificCalculatorPanel(

            IScientificCalculator calculator,
            IKeyChecker checker,
            IFormatter numberFormatter,
            IFormatter engineeringFormatter

        ) : base(checker, numberFormatter, calculator) {

            InitializeComponent();
            Display = standardDisplay;
            EngineeringFormatter = engineeringFormatter;
            Calculator = calculator;
            SetupKeypad();
            SetupMemoryPanel();
            DisplayValue(Calculator.Input);
        }

        private void SetupKeypad() {

            Keypad = scientificKeypad;
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

        protected override void HandleOperator(string key) {

            base.HandleOperator(Calculator.CheckTrigonometricKey(key));
        }

        private void RemoveFocus(object sender, EventArgs e) {

            memoryPanel.Focus();
        }

        private void ChangeAngularUnit(object sender, EventArgs e) {

            Calculator.ChangeAngularUnit();
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