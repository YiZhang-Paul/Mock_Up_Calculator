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
    public partial class standardDisplay : UserControl, IDisplay {

        private IFormatter Formatter { get; set; }

        public standardDisplay() {

            InitializeComponent();
            Formatter = new Formatter();
        }

        public void Display(string result, string expression) {

            resultLabel.Text = Formatter.Format(result);
            expressionLabel.Text = expression;
        }
    }
}