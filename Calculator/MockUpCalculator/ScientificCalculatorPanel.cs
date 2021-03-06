﻿using System;
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

        public virtual bool EngineeringModeOn { get { return scientificKeypad.EngineeringMode; } }

        protected override IFormatter ActiveFormatter {

            get {

                if(EngineeringModeOn) {

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
            SetupMemoryPanel(keypadPanel);
            SetupHistoryPanel(keypadPanel);
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

        protected override void HandleOperator(string key) {

            base.HandleOperator(Calculator.CheckTrigonometricKey(key));
        }

        protected void ChangeAngularUnit(object sender, EventArgs e) {

            Calculator.ChangeAngularUnit();
        }
    }
}