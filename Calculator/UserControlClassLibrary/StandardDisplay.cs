﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FormatterClassLibrary;

namespace UserControlClassLibrary {
    public partial class StandardDisplay : UserControl, ICalculatorDisplay {

        public decimal RecentValue { get; private set; }
        public string Expression { get { return expressionLabel.Text; } }
        public string Input { get { return resultLabel.Text; } }
        public Panel ScrollPanel { get { return scrollPanel; } }

        public StandardDisplay() {

            InitializeComponent();
            expressionLabel.MouseWheel += ScrollExpression;
            scrollPanel.MouseWheel += ScrollExpression;
        }

        private Size GetTextSize(Label label, float size) {

            var font = new Font(label.Font.FontFamily, size, GraphicsUnit.Pixel);

            return TextRenderer.MeasureText(label.Text, font);
        }

        private void SetFontSize(Label label, float size) {

            label.Font = new Font(label.Font.FontFamily, size, GraphicsUnit.Pixel);
        }

        private void ResizeLabelText(Label label, float limit = 0.7f) {

            float size = label.Parent.Height * limit;
            float width = label.Parent.Width * 0.95f;

            while(size > 1) {

                if(GetTextSize(label, size).Width <= width) {

                    break;
                }

                size--;
            }

            SetFontSize(label, size);
        }

        public void Clear() {

            resultLabel.Text = string.Empty;
            expressionLabel.Text = string.Empty;
        }

        public void RefreshDisplay(IFormatter formatter) {

            DisplayResult(RecentValue.ToString(), formatter);
        }

        public void DisplayResult(string result, IFormatter formatter) {

            RecentValue = decimal.Parse(result);
            resultLabel.Text = formatter.Format(result);
            ResizeLabelText(resultLabel);
        }

        public void DisplayExpression(string expression, IFormatter formatter) {

            expressionLabel.Text = formatter.Format(expression);
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

            int maxX = MaxScrollX();
            scrollPanel.Left = Math.Min(scrollPanel.Left + speed, maxX);
        }

        private void ScrollRight(int speed) {

            int minX = MinScrollX();
            scrollPanel.Left = Math.Max(scrollPanel.Left - speed, minX);
        }

        public void ScrollExpression(object sender, MouseEventArgs e) {

            if(!CanScroll()) {

                return;
            }

            const int speed = 25;

            if(e.Delta > 0) {

                ScrollLeft(speed);
            }
            else {

                ScrollRight(speed);
            }

            ShowArrows();
        }

        public void ExpressionMouseHover(object sender, EventArgs e) {

            ((Label)sender).Focus();
        }

        public void ScrollPanelMouseHover(object sender, EventArgs e) {

            ((Panel)sender).Focus();
        }
    }
}