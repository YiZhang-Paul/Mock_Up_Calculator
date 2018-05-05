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
    public partial class ScientificCalculatorPanel : CalculatorPanel {

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

            IKeyChecker checker,
            IFormatter numberFormatter,
            IFormatter expressionFormatter,
            IFormatter engineeringFormatter,
            IScientificCalculator calculator

        ) : base(checker, numberFormatter, expressionFormatter, calculator) {

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
            scientificKeypad.OnMemoryStore += CalculatorMemoryStore;
            scientificKeypad.OnMemoryClear += CalculatorMemoryClear;
            scientificKeypad.OnMemoryRecall += CalculatorMemoryRecall;
            scientificKeypad.OnMemoryAdd += CalculatorMemoryPlus;
            scientificKeypad.OnMemorySubtract += CalculatorMemoryMinus;
            scientificKeypad.OnButtonMouseClick += KeypadButtonMouseClick;
            scientificKeypad.OnButtonMouseEnter += KeypadButtonMouseEnter;
            scientificKeypad.OnButtonMouseLeave += KeypadButtonMouseLeave;
        }

        private void SetupMemoryPanel() {

            MemoryPanel = memoryPanel;
            MemoryPanel.OnMemoryDelete += MemoryPanelRemove;
            MemoryPanel.OnClear += MemoryPanelClear;
            MemoryPanel.OnMemorySelect += MemoryPanelSelect;
            MemoryPanel.OnMemoryPlus += MemoryPanelPlus;
            MemoryPanel.OnMemoryMinus += MemoryPanelMinus;
            MemoryPanel.OnExtended += MemoryPanelExtended;
            MemoryPanel.OnShrunken += MemoryPanelShrunken;
        }

        protected override void HandleOperator(string key) {

            base.HandleOperator(Calculator.CheckTrigonometricKey(key));
        }

        private void ChangeAngularUnit(object sender, EventArgs e) {

            Calculator.ChangeAngularUnit();
        }
    }
}