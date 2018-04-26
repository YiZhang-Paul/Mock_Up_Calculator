using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityClassLibrary;

namespace UserControlClassLibrary {
    public partial class StandardDisplay : UserControl, IDisplay {

        private IFormatter Formatter { get; set; }

        public StandardDisplay() {

            InitializeComponent();
            Formatter = new Formatter();
        }

        public void Clear() {

            resultLabel.Text = string.Empty;
            expressionLabel.Text = string.Empty;
        }

        public void DisplayResult(string result) {

            resultLabel.Text = Formatter.Format(result);
        }

        public void DisplayExpression(string expression) {

            expressionLabel.Text = expression;
        }

        public void DisplayError(string message) {

            resultLabel.Text = message;
        }
    }
}