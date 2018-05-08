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
        private IHelper Helper { get; set; }

        public string RawExpression { get; private set; }
        public string FormattedExpression { get; private set; }
        public decimal RawResult { get; private set; }
        public string FormattedResult { get; private set; }

        public event EventHandler OnSelect;

        public HistoryItem() {

            InitializeComponent();
        }

        public HistoryItem(

            string expression,
            decimal result,
            IFormatter expressionFormatter,
            IFormatter numberFormatter,
            IHelper helper

        ) : this() {

            RawExpression = expression;
            RawResult = result;
            ExpressionFormatter = expressionFormatter;
            NumberFormatter = numberFormatter;
            Helper = helper;
            FormatInput();
            DisplayExpression();
        }

        private void FormatInput() {

            FormattedExpression = ExpressionFormatter.Format(RawExpression) + " =";
            FormattedResult = NumberFormatter.Format(RawResult.ToString());
        }

        public void DisplayExpression() {

            expressionLabel.Text = FormattedExpression;
            resultLabel.Text = FormattedResult;
        }

        private void SetBackColor(Color color) {

            BackColor = color;
            expressionLabel.BackColor = color;
            resultLabel.BackColor = color;
        }

        public void PanelClick(object sender, EventArgs e) {

            OnSelect(this, e);
        }

        public void PanelMouseEnter(object sender, EventArgs e) {

            if(Visible) {

                SetBackColor(Color.FromArgb(58, 58, 58));
                Parent.Focus();
            }
        }

        public void PanelMouseLeave(object sender, EventArgs e) {

            if(Visible && !Helper.ContainsPointer(mainLayout, Cursor.Position)) {

                SetBackColor(Color.FromArgb(39, 39, 39));
            }
        }
    }
}