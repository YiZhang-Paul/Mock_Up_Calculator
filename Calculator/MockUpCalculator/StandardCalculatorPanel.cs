using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorClassLibrary;
using FormatterClassLibrary;
using UserControlClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class StandardCalculatorPanel : CalculatorPanel {

        public StandardCalculatorPanel(

            IKeyChecker checker,
            IFormatter numberFormatter,
            IFormatter expressionFormatter,
            IStandardCalculator calculator

        ) : base(checker, numberFormatter, expressionFormatter, calculator) {

            InitializeComponent();
            Display = standardDisplay;
            SetupKeypad();
            SetupMemoryPanel(keypadPanel);
            DisplayValue(Calculator.Input);
        }

        private void SetupKeypad() {

            Keypad = standardKeypad;
            standardKeypad.OnKeypadEnable += EnableKeypadFromError;
            standardKeypad.OnMemoryToggle += ToggleMemoryPanel;
            standardKeypad.OnMemoryStore += CalculatorMemoryStore;
            standardKeypad.OnMemoryClear += CalculatorMemoryClear;
            standardKeypad.OnMemoryRecall += CalculatorMemoryRecall;
            standardKeypad.OnMemoryAdd += CalculatorMemoryPlus;
            standardKeypad.OnMemorySubtract += CalculatorMemoryMinus;
            standardKeypad.OnButtonMouseClick += KeypadButtonMouseClick;
            standardKeypad.OnButtonMouseEnter += KeypadButtonMouseEnter;
            standardKeypad.OnButtonMouseLeave += KeypadButtonMouseLeave;
        }
    }
}