using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlClassLibrary {
    public partial class SidePanel : UserControl, IExpandable {

        private int TargetWidth { get; set; }
        private string Selected { get; set; }

        public event EventHandler OnExtended;
        public event EventHandler OnShrunken;
        public event EventHandler OnSelect;

        public SidePanel() {

            InitializeComponent();
        }

        private void ClearMenu() {

            var items = mainPanel.Controls.OfType<Panel>().ToArray();

            for(int i = 0; i < items.Length; i++) {

                if(items[i] != topPanel) {

                    items[i].Dispose();
                }
            }
        }

        public void ShowMenu(List<string[]> items, string current) {

            for(int i = 0, total = 0; i < items.Count; i++) {

                for(int j = 0; j < items[i].Length; j++, total++) {

                    var label = new Label();
                    label.Left = btnChangeCalculator.Width + (j == 0 ? 0 : 8);
                    label.Text = items[i][j];

                    label.Font = new Font(

                        btnChangeCalculator.Font.FontFamily,
                        j == 0 ? 15 : 12
                    );

                    var dimension = TextRenderer.MeasureText(label.Text, label.Font);
                    label.Width = dimension.Width;
                    label.Height = dimension.Height;
                    label.Top = (topPanel.Height - label.Height) / 2;

                    if(i == 0 && j == 0) {

                        label.Parent = topPanel;

                        continue;
                    }

                    var item = new Panel();
                    label.Parent = item;
                    item.Parent = mainPanel;
                    item.Height = topPanel.Height;
                    item.Width = Width;
                    item.Top = item.Height * total;
                    item.Show();

                    if(j != 0) {

                        bool selected = current == label.Text;
                        int rgb = selected ? 53 : 40;
                        item.BackColor = Color.FromArgb(rgb, rgb, rgb);
                        item.MouseEnter += PanelMouseEnter;
                        item.MouseLeave += PanelMouseLeave;
                        item.Click += ControlMouseClick;
                        label.MouseEnter += LabelMouseEnter;
                        label.MouseLeave += LabelMouseLeave;
                        label.Click += ControlMouseClick;
                        item.Tag = label.Text;
                        label.Tag = label.Text;

                        if(selected) {

                            Selected = current;
                        }
                    }
                }
            }
        }

        private void ControlMouseEnter(object sender, EventArgs e) {

            ((Control)sender).BackColor = Color.FromArgb(67, 67, 67);
        }

        private void ControlMouseLeave(object sender, EventArgs e) {

            var control = (Control)sender;
            int rgb = control.Tag.ToString() == Selected ? 53 : 40;
            control.BackColor = Color.FromArgb(rgb, rgb, rgb);
        }

        private void ControlMouseClick(object sender, EventArgs e) {

            OnSelect(sender, e);
            Shrink();
        }

        private void LabelMouseEnter(object sender, EventArgs e) {

            ControlMouseEnter(sender, e);
            ControlMouseEnter(((Control)sender).Parent, e);
        }

        private void LabelMouseLeave(object sender, EventArgs e) {

            ControlMouseLeave(sender, e);
            ControlMouseLeave(((Control)sender).Parent, e);
        }

        private void PanelMouseEnter(object sender, EventArgs e) {

            ControlMouseEnter(sender, e);

            foreach(var child in ((Control)sender).Controls) {

                ControlMouseEnter(child, e);
            }
        }

        private void PanelMouseLeave(object sender, EventArgs e) {

            ControlMouseLeave(sender, e);

            foreach(var child in ((Control)sender).Controls) {

                ControlMouseLeave(child, e);
            }
        }

        private void ExtendPanel(object sender, EventArgs e) {

            int speed = Math.Min(40, TargetWidth - Width);
            Width += speed;
            Left = 0;

            if(Width >= TargetWidth) {

                expandTimer.Tick -= ExtendPanel;
                expandTimer.Stop();
                OnExtended(sender, e);
            }
        }

        private void ShrinkPanel(object sender, EventArgs e) {

            int speed = Math.Min(40, Width - 1);
            Width -= speed;
            Left = 0;

            if(Width <= 1) {

                expandTimer.Tick -= ShrinkPanel;
                expandTimer.Stop();
                ClearMenu();
                OnShrunken(sender, e);
            }
        }

        public void Extend(int width) {

            Width = 1;
            TargetWidth = width;
            expandTimer.Tick -= ShrinkPanel;
            expandTimer.Tick += ExtendPanel;
            expandTimer.Start();
            BringToFront();
        }

        public void Shrink() {

            expandTimer.Tick -= ExtendPanel;
            expandTimer.Tick += ShrinkPanel;
            expandTimer.Start();
        }

        private void KeypadButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.ButtonMouseEnter(sender, e);
        }

        private void KeypadButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave(sender, e);
        }

        private void btnChangeCalculator_Click(object sender, EventArgs e) {

            Shrink();
        }
    }
}