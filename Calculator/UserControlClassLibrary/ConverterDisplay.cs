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

        public string Input { get { return inputLabel.Text; } }
        public string Output { get { return outputLabel.Text; } }

        public ConverterDisplay() {

            InitializeComponent();
        }

        public void DisplayInput(string input, IFormatter formatter) {

            inputLabel.Text = formatter.Format(input);
        }

        public void DisplayOutput(string output, IFormatter formatter) {

            outputLabel.Text = formatter.Format(output);
        }
    }
}