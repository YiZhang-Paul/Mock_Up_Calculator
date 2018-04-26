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
            expressionLabel.MouseWheel += ScrollExpression;
            scrollPanel.MouseWheel += ScrollExpression;
        }

        private int CountLength(string input) {

            if(!Regex.IsMatch(input, "[0-9]")) {

                return Regex.Matches(input, @"\S").Count;
            }

            return Regex.Matches(input, "[0-9]").Count;
        }

        private void ResizeLabelText(Label label, float limit = 0.9f) {

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
            ResizeLabelText(resultLabel, 0.5f);
        }

        public void DisplayExpression(string expression) {

            expressionLabel.Text = expression;
            scrollPanel.Width = expressionLabel.Width;
            scrollPanel.Left = MinScrollX();
            ShowArrows();
        }

        public void DisplayError(string message) {

            resultLabel.Text = message;
            ResizeLabelText(resultLabel, 1);
        }

        private bool CanScroll() {

            int width = Parent.Width - leftArrowPanel.Width - rightArrowPanel.Width;

            return scrollPanel.Width > width;
        }

        private int MaxScrollX() {

            return Parent.Left + expressionLabel.Padding.Right + leftArrowPanel.Width;
        }

        private int MinScrollX() {

            return Parent.Right - rightArrowPanel.Width - scrollPanel.Width;
        }

        private void ShowArrows() {

            leftArrowLabel.Visible = scrollPanel.Left < MaxScrollX();
            rightArrowLabel.Visible = scrollPanel.Left > MinScrollX();
        }

        private void ScrollLeft(int speed) {

            if(!CanScroll()) {

                return;
            }

            int maxX = MaxScrollX();
            scrollPanel.Left = Math.Min(scrollPanel.Left + speed, maxX);
        }

        private void ScrollRight(int speed) {

            int minX = MinScrollX();
            scrollPanel.Left = Math.Max(scrollPanel.Left - speed, minX);
        }

        private void ScrollExpression(object sender, MouseEventArgs e) {

            const int speed = 25;

            if(e.Delta > 0) {

                ScrollLeft(speed);
            }
            else {

                ScrollRight(speed);
            }

            ShowArrows();
        }

        private void expressionLabel_MouseHover(object sender, EventArgs e) {

            ((Label)sender).Focus();
        }

        private void scrollPanel_MouseHover(object sender, EventArgs e) {

            ((Panel)sender).Focus();
        }
    }
}