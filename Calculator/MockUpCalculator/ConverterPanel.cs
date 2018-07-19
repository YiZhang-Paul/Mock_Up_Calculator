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
using ConverterClassLibrary;
using FormatterClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class ConverterPanel : UserControl {

        protected IInputBuffer Buffer { get; set; }
        protected IKeyChecker Checker { get; set; }
        protected IFormatter NumberFormatter { get; set; }
        protected IUnitConverter UnitConverter { get; set; }
        protected IHelper Helper { get; set; }
        protected IConverterDisplay Display { get; set; }
        protected IKeypad Keypad { get; set; }
        protected string[] Units { get; set; }

        public ConverterPanel() {

            InitializeComponent();
        }

        public ConverterPanel(

            IInputBuffer buffer,
            IKeyChecker checker,
            IFormatter formatter,
            IUnitConverter converter,
            IConverterDisplay display,
            string[] units

        ) {

            InitializeComponent();
            Buffer = buffer;
            Checker = checker;
            NumberFormatter = formatter;
            UnitConverter = converter;
            Helper = new UIHelper();
            Units = units.ToArray();
            SetupDisplay(display, units);
            SetupKeypad();
        }

        private void SetupDisplay(IConverterDisplay display, string[] units) {

            ((Control)display).Parent = mainLayout;
            ((Control)display).Dock = DockStyle.Fill;
            Display = display;
            Display.OnUnitChange += ChangeSelectedUnit;
            Display.PopulateOptions(units);
            RefreshDisplay();
        }

        private void SetupKeypad() {

            Keypad = basicKeypad;
            basicKeypad.OnButtonMouseClick += KeypadButtonMouseClick;
            basicKeypad.OnButtonMouseEnter += KeypadButtonMouseEnter;
            basicKeypad.OnButtonMouseLeave += KeypadButtonMouseLeave;
        }

        protected virtual void HandleActionKey(string key) {

            if(key == "CE") {

                Buffer.Clear();

                return;
            }

            Buffer.Undo();
        }

        protected virtual string Convert(string target, string format) {

            decimal input = decimal.Parse(Buffer.Content);
            decimal output = UnitConverter.Convert(Display.InputUnit, input, target);
            string finalFormat = output == Math.Truncate(output) ? "N0" : format;

            return output.ToString(finalFormat);
        }

        protected virtual void ShowMainOutput() {

            string output = Convert(Display.MainOutputUnit, "N4");

            Display.DisplayMainOutput(output, NumberFormatter);
        }

        protected virtual void ShowOtherOutputs() {

            var outputs = new Tuple<string, string>[2];
            var unitsToSkip = new HashSet<string>() {

                Display.InputUnit, Display.MainOutputUnit
            };

            for(int i = 0, j = 0; i < Units.Length; i++) {

                if(unitsToSkip.Contains(Units[i])) {

                    continue;
                }

                string output = Convert(Units[i], "N1");
                outputs[j++] = new Tuple<string, string>(output, Units[i]);

                if(j == outputs.Length) {

                    break;
                }
            }

            Display.DisplayExtraOutputs(outputs, NumberFormatter);
        }

        protected virtual void RefreshDisplay() {

            Display.Clear();
            Display.DisplayInput(Buffer.Content, NumberFormatter);
            ShowMainOutput();

            if(Buffer.Content != "0" || Display.MainOutputValue != "0") {

                ShowOtherOutputs();
            }
        }

        protected virtual void KeypadButtonMouseClick(object sender, EventArgs e) {

            string key = ((Button)sender).Tag.ToString();

            if(Checker.IsActionKey(key)) {

                HandleActionKey(key);
            }
            else {

                Buffer.Add(key);
            }

            RefreshDisplay();
        }

        private void ChangeSelectedUnit(object sender, EventArgs e) {

            RefreshDisplay();
        }

        protected virtual void KeypadButtonMouseEnter(object sender, EventArgs e) {

            Helper.ButtonMouseEnter(sender, e);
        }

        protected virtual void KeypadButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave(sender, e);
        }
    }
}