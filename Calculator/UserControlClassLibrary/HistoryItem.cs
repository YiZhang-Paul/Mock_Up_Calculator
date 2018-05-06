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
    public partial class HistoryItem : UserControl, IHistoryItem {

        private IFormatter ExpressionFormatter { get; set; }
        private IFormatter NumberFormatter { get; set; }

        public string Expression { get; private set; }
        public decimal Result { get; private set; }

        public event EventHandler OnSelect;

        public HistoryItem() {

            InitializeComponent();
        }

        public HistoryItem(

            string expression,
            decimal result,
            IFormatter expressionFormatter,
            IFormatter numberFormatter

        ) : this() {

            Expression = expression;
            Result = result;
            ExpressionFormatter = expressionFormatter;
            NumberFormatter = numberFormatter;
            DisplayExpression();
        }

        public void DisplayExpression() {

            expressionLabel.Text = ExpressionFormatter.Format(Expression);
            resultLabel.Text = NumberFormatter.Format(Result.ToString());
        }

        private void SetBackColor(Color color) {

            BackColor = color;
            expressionLabel.BackColor = color;
            resultLabel.BackColor = color;
        }
    }
}