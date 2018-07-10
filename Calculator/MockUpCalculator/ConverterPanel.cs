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

        public ConverterPanel() {

            InitializeComponent();
        }

        public ConverterPanel(

            IInputBuffer buffer,
            IKeyChecker checker,
            IFormatter formatter,
            IUnitConverter converter,
            string[] units

        ) {

            InitializeComponent();
            Buffer = buffer;
            Checker = checker;
            NumberFormatter = formatter;
            UnitConverter = converter;
            Display = converterDisplay;
            Helper = new UIHelper();
            SetupKeypad();
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

        protected virtual decimal Convert() {

            decimal input = decimal.Parse(Buffer.Content);

            return UnitConverter.Convert("degrees", input, "radians");
        }

        protected virtual void RefreshDisplay(decimal output) {

            Display.DisplayInput(Buffer.Content, NumberFormatter);
            Display.DisplayOutput(output == 0 ? "0" : output.ToString("N4"), NumberFormatter);
        }

        protected virtual void KeypadButtonMouseClick(object sender, EventArgs e) {

            Display.Clear();
            string key = ((Button)sender).Tag.ToString();

            if(Checker.IsActionKey(key)) {

                HandleActionKey(key);
            }
            else {

                Buffer.Add(key);
            }

            RefreshDisplay(Convert());
        }

        protected virtual void KeypadButtonMouseEnter(object sender, EventArgs e) {

            Helper.ButtonMouseEnter(sender, e);
        }

        protected virtual void KeypadButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave(sender, e);
        }
    }
}