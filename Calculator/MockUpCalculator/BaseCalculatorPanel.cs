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
    public partial class BaseCalculatorPanel : UserControl {

        protected const string _divideByZeroMessage = "Cannot divide by zero";
        protected const string _invalidInputMessage = "Invalid input";

        protected IKeyChecker Checker { get; set; }
        protected IFormatter NumberFormatter { get; set; }
        protected IStandardCalculator Calculator { get; set; }
        protected IKeypad Keypad { get; set; }
        protected ICalculatorDisplay Display { get; set; }
        protected virtual IFormatter ActiveFormatter { get { return NumberFormatter; } }

        public BaseCalculatorPanel(

            IKeyChecker checker,
            IFormatter numberFormatter,
            IStandardCalculator calculator

        ) {

            InitializeComponent();
            Checker = checker;
            NumberFormatter = numberFormatter;
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
            Display.DisplayExpression(Calculator.Expression);
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

            Display.DisplayExpression(Calculator.Expression);
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
    }
}