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
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class StandardCalculatorPanel : BaseCalculatorPanel {

        public StandardCalculatorPanel(

            IKeyChecker checker,
            IFormatter numberFormatter,
            IStandardCalculator calculator

        ) : base(checker, numberFormatter, calculator) {

            InitializeComponent();
            Display = standardDisplay;
            SetupKeypad();
            DisplayValue(Calculator.Input);
        }

        private void SetupKeypad() {

            Keypad = standardKeypad;
            //standardKeypad.OnKeypadEnable += EnableKeypadFromError;
            //standardKeypad.OnMemoryToggle += ToggleMemoryPanel;
            //standardKeypad.OnMemoryStore += MemoryStore;
            //standardKeypad.OnMemoryClear += MemoryClear;
            //standardKeypad.OnMemoryRecall += MemoryRecall;
            //standardKeypad.OnMemoryAdd += MemoryPlus;
            //standardKeypad.OnMemorySubtract += MemoryMinus;
            standardKeypad.OnButtonMouseClick += KeypadButtonMouseClick;
            standardKeypad.OnButtonMouseEnter += KeypadButtonMouseEnter;
            standardKeypad.OnButtonMouseLeave += KeypadButtonMouseLeave;
        }
    }
}