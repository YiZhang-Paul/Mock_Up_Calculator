using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public partial class ConverterDisplay : UserControl, IConverterDisplay {

        public event EventHandler OnUnitChange;

        public string InputUnit { get { return inputUnitBox.SelectedValue.ToString(); } }
        public string InputValue { get { return inputLabel.Text; } }
        public string MainOutputUnit { get { return outputUnitBox.SelectedValue.ToString(); } }
        public string MainOutputValue { get { return outputLabel.Text; } }
        public Label[] ExtraOutputLabels { get; private set; }

        public ConverterDisplay() {

            InitializeComponent();
            ExtraOutputLabels = new Label[] { extraOutputLabelOne, extraOutputLabelTwo };
        }

        private void RemoveFocus(object sender, EventArgs e) {

            inputLabel.Focus();
        }

        public void PopulateOptions(string[] units) {

            inputUnitBox.DataSource = units.ToArray();
            outputUnitBox.DataSource = units.ToArray();
            outputUnitBox.SelectedIndex = 1;
        }

        public void Clear() {

            inputLabel.Text = string.Empty;
            outputLabel.Text = string.Empty;
            extraOutputTitleLabel.Visible = false;
            extraOutputLabelOne.Text = string.Empty;
            extraOutputLabelTwo.Text = string.Empty;
        }

        public void DisplayInput(string input, IFormatter formatter) {

            inputLabel.Text = formatter.Format(input);
        }

        public void DisplayMainOutput(string output, IFormatter formatter) {

            outputLabel.Text = formatter.Format(output);
        }

        public void DisplayExtraOutputs(Tuple<string, string>[] outputs, IFormatter formatter) {

            extraOutputTitleLabel.Visible = true;

            for(int i = 0; i < outputs.Length; i++) {

                if(i == ExtraOutputLabels.Length) {

                    return;
                }

                if(outputs[i] != null) {

                    ExtraOutputLabels[i].Text = formatter.Format(outputs[i].Item1);
                    ExtraOutputLabels[i].Text += " " + outputs[i].Item2.ToLower();
                }
            }
        }

        protected void ChangeSelectedUnit(object sender, EventArgs e) {

            OnUnitChange(sender, e);
        }
    }
}