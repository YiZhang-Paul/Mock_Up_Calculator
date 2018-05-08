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
    public partial class SidePanel : UserControl, IExpandable, IMenu {

        private int TargetWidth { get; set; }
        private IHelper Helper { get; set; }

        public string Selected { get; private set; }

        public event EventHandler OnExtended;
        public event EventHandler OnShrunken;
        public event EventHandler OnSelect;

        public SidePanel() {

            InitializeComponent();
            Helper = new UIHelper();
        }

        public SidePanel(IHelper helper) : this() {

            Helper = helper;
        }

        protected void ClearMenu() {

            var items = mainPanel.Controls.OfType<Panel>().ToArray();

            for(int i = 0; i < items.Length; i++) {

                if(items[i] != topPanel) {

                    items[i].Dispose();
                }
            }
        }

        private Label GetLabel(string text, bool isOption) {

            var label = new Label();

            label.Text = text;
            label.Left = btnChange.Width + (isOption ? 0 : 8);
            label.Font = new Font(btnChange.Font.FontFamily, isOption ? 15 : 12);
            label.Top = (topPanel.Height - label.Height) / 2;

            return label;
        }

        private Panel GetPanel(int top) {

            var panel = new Panel();

            panel.Parent = mainPanel;
            panel.Height = topPanel.Height;
            panel.Width = Width;
            panel.Top = top;
            panel.Show();

            return panel;
        }

        private void SetupMenuItem(Panel panel, Label label, bool isSelected) {

            int rgb = isSelected ? 53 : 40;
            panel.BackColor = Color.FromArgb(rgb, rgb, rgb);
            panel.MouseEnter += PanelMouseEnter;
            panel.MouseLeave += PanelMouseLeave;
            panel.Click += ControlMouseClick;
            panel.Tag = label.Text;
            label.MouseEnter += LabelMouseEnter;
            label.MouseLeave += LabelMouseLeave;
            label.Click += ControlMouseClick;
            label.Tag = label.Text;
            Selected = isSelected ? label.Text : Selected;
        }

        public void ShowMenu(List<string[]> items, string current) {

            for(int i = 0, total = 0; i < items.Count; i++) {

                for(int j = 0; j < items[i].Length; j++, total++) {

                    var label = GetLabel(items[i][j], j == 0);

                    if(i == 0 && j == 0) {

                        label.Parent = topPanel;

                        continue;
                    }

                    var panel = GetPanel(topPanel.Height * total);
                    label.Parent = panel;

                    if(j != 0) {

                        SetupMenuItem(panel, label, current == label.Text);
                    }
                }
            }
        }

        protected void ControlMouseEnter(object sender, EventArgs e) {

            ((Control)sender).BackColor = Color.FromArgb(67, 67, 67);
        }

        protected void ControlMouseLeave(object sender, EventArgs e) {

            var control = (Control)sender;
            int rgb = control.Tag.ToString() == Selected ? 53 : 40;
            control.BackColor = Color.FromArgb(rgb, rgb, rgb);
        }

        protected void ControlMouseClick(object sender, EventArgs e) {

            OnSelect(sender, e);
            Shrink();
        }

        protected void LabelMouseEnter(object sender, EventArgs e) {

            ControlMouseEnter(sender, e);
            ControlMouseEnter(((Control)sender).Parent, e);
        }

        protected void LabelMouseLeave(object sender, EventArgs e) {

            ControlMouseLeave(sender, e);
            ControlMouseLeave(((Control)sender).Parent, e);
        }

        protected void PanelMouseEnter(object sender, EventArgs e) {

            ControlMouseEnter(sender, e);

            foreach(var child in ((Control)sender).Controls) {

                ControlMouseEnter(child, e);
            }
        }

        protected void PanelMouseLeave(object sender, EventArgs e) {

            ControlMouseLeave(sender, e);

            foreach(var child in ((Control)sender).Controls) {

                ControlMouseLeave(child, e);
            }
        }

        protected void KeypadButtonMouseEnter(object sender, EventArgs e) {

            Helper.ButtonMouseEnter(sender, e);
        }

        protected void KeypadButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave(sender, e);
        }

        protected void ToggleMenu(object sender, EventArgs e) {

            Shrink();
        }

        protected void ExtendPanel(object sender, EventArgs e) {

            int speed = Math.Min(40, TargetWidth - Width);
            Width += speed;
            Left = 0;

            if(Width >= TargetWidth) {

                expandTimer.Tick -= ExtendPanel;
                expandTimer.Stop();
                OnExtended(sender, e);
            }
        }

        protected void ShrinkPanel(object sender, EventArgs e) {

            int speed = Math.Min(85, Width - 1);
            Width -= speed;
            Left = 0;

            if(Width <= 1) {

                ClearMenu();
                expandTimer.Tick -= ShrinkPanel;
                expandTimer.Stop();
                OnShrunken(sender, e);
            }
        }

        public void Extend(int width) {

            Width = 1;
            TargetWidth = width;
            Height = Parent.Height;
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
    }
}