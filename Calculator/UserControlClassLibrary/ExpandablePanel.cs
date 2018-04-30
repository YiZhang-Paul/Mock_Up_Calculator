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
    public partial class ExpandableDisplayPanel : UserControl, IExpandable, IDisplayPanel {

        protected int TargetHeight { get; set; }
        protected Panel MainPanel { get; set; }
        protected Panel BottomPanel { get; set; }
        protected Panel ScrollBar { get; set; }
        protected Button ClearButton { get; set; }

        public event EventHandler OnExtended;
        public event EventHandler OnShrunken;
        public event EventHandler OnClear;

        public ExpandableDisplayPanel() {

            InitializeComponent();
        }

        protected virtual void Initialize() {

            MainPanel = mainPanel;
            BottomPanel = bottomPanel;
            ScrollBar = scrollBar;
            ClearButton = btnClear;
        }

        public void ShowMessage(string message) {

            UIHelper.AddLabel(MainPanel, message, 11, 10, 15);
        }

        public void ClearMessage() {

            var labels = MainPanel.Controls.OfType<Label>().ToArray();

            for(int i = 0; i < labels.Length; i++) {

                labels[i].Dispose();
            }
        }

        protected virtual void ResizeBottomPanel() {

            UIHelper.SetHeight(BottomPanel, TargetHeight / 3);
            BottomPanel.Width = Width;
            UIHelper.SetHeight(ClearButton, BottomPanel.Height / 2);
            ClearButton.Width = ClearButton.Height;
            ClearButton.Left = Width - ClearButton.Width - 4;
        }

        private void ExtendPanel(object sender, EventArgs e) {

            int speed = Math.Min(65, TargetHeight - Height);
            Top -= speed;
            Height += speed;

            if(Height >= TargetHeight) {

                expandTimer.Tick -= ExtendPanel;
                expandTimer.Stop();
                OnExtended(sender, e);
            }
        }

        private void ShrinkPanel(object sender, EventArgs e) {

            int alpha = Math.Max(0, BackColor.A - 75);
            int red = BackColor.R;
            int green = BackColor.G;
            int blue = BackColor.B;
            BackColor = Color.FromArgb(alpha, red, green, blue);

            if(alpha <= 0) {

                Top += Height - 50;
                Height = 50;
                BackColor = Color.FromArgb(255, red, green, blue);
                expandTimer.Tick -= ShrinkPanel;
                expandTimer.Stop();
                OnShrunken(sender, e);
            }
        }

        public virtual void Extend(int height) {

            TargetHeight = height;
            expandTimer.Tick -= ShrinkPanel;
            expandTimer.Tick += ExtendPanel;
            expandTimer.Start();
            ResizeBottomPanel();
            BringToFront();
        }

        public virtual void Shrink() {

            expandTimer.Tick -= ExtendPanel;
            expandTimer.Tick += ShrinkPanel;
            expandTimer.Start();
        }

        private void ButtonMouseEnter(object sender, EventArgs e) {

            ((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
        }

        private void ButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave((Button)sender, e);
        }

        private void mainPanel_MouseEnter(object sender, EventArgs e) {

            UIHelper.ReceiveFocus(sender);
        }

        private void btnClear_Click(object sender, EventArgs e) {

            OnClear(sender, e);
        }
    }
}