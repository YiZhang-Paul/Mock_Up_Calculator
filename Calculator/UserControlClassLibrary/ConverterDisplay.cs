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

        public virtual string InputUnit { get { return inputUnitBox.SelectedValue.ToString(); } }
        public virtual string InputValue { get { return inputLabel.Text; } }
        public virtual string MainOutputUnit { get { return outputUnitBox.SelectedValue.ToString(); } }
        public virtual string MainOutputValue { get { return outputLabel.Text; } }
        public Label[] ExtraOutputLabels { get; private set; }

        protected Label InputLabel { get { return inputLabel; } }
        protected Label OutputLabel { get { return outputLabel; } }
        protected Label ExtraOutputTitleLabel { get { return extraOutputTitleLabel; } }
        protected ComboBox InputUnitBox { get { return inputUnitBox; } }
        protected ComboBox OutputUnitBox { get { return outputUnitBox; } }

        public ConverterDisplay() {

            InitializeComponent();
            ExtraOutputLabels = new Label[] { extraOutputLabelOne, extraOutputLabelTwo };
            AdjustComboBoxWidth();
        }

        private void RemoveFocus(object sender, EventArgs e) {

            inputLabel.Focus();
        }

        protected virtual void AdjustComboBoxWidth() {

            int width = (int)(displayLayout.Width * 0.9);
            inputUnitBox.Width = width;
            outputUnitBox.Width = width;
        }

        public virtual void PopulateOptions(string[] units) {

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

        public virtual void DisplayInput(string input, IFormatter formatter) {

            inputLabel.Text = formatter.Format(input);
        }

        public virtual void DisplayMainOutput(string output, IFormatter formatter) {

            outputLabel.Text = formatter.Format(output);
        }

        public virtual void DisplayExtraOutputs(Tuple<string, string>[] outputs, IFormatter formatter) {

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