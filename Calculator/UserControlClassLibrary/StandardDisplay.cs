using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UtilityClassLibrary;

namespace UserControlClassLibrary {
    public partial class StandardDisplay : UserControl, IDisplay {

        private IFormatter Formatter { get; set; }

        public StandardDisplay() {

            InitializeComponent();
            Formatter = new Formatter();
        }

        private int CountLength(string input) {

            if(!Regex.IsMatch(input, "[0-9]")) {

                return Regex.Matches(input, @"\S").Count;
            }

            return Regex.Matches(input, "[0-9]").Count;
        }

        private void ResizeLabel(Label label, float limit = 0.5f) {

            float size = label.Parent.Height * limit;
            float width = label.Parent.Width;
            int length = CountLength(label.Text);

            if(size * length > width) {

                size = width / length;
            }

            label.Font = new Font(label.Font.FontFamily, size);
        }

        public void Clear() {

            resultLabel.Text = string.Empty;
            expressionLabel.Text = string.Empty;
        }

        public void DisplayResult(string result) {

            resultLabel.Text = Formatter.Format(result);
            ResizeLabel(resultLabel);
        }

        public void DisplayExpression(string expression) {

            expressionLabel.Text = expression;
        }

        public void DisplayError(string message) {

            resultLabel.Text = message;
            ResizeLabel(resultLabel, 1);
        }
    }
}