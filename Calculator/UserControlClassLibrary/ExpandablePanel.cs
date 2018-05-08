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
    public partial class ExpandablePanel : UserControl, IExpandable, IDisplayPanel {

        protected int TargetHeight { get; set; }
        protected Panel BottomPanel { get; set; }
        protected Panel ScrollBar { get; set; }
        protected Button ClearButton { get; set; }
        protected IHelper Helper { get; set; }

        public Panel MainPanel { get; set; }

        public event EventHandler OnExtended;
        public event EventHandler OnShrunken;
        public event EventHandler OnClear;

        public ExpandablePanel() {

            InitializeComponent();
        }

        public ExpandablePanel(IHelper helper) : this() {

            Initialize();

            if(helper != null) {

                Helper = helper;
            }
        }

        protected virtual void Initialize() {

            MainPanel = mainPanel;
            BottomPanel = bottomPanel;
            ScrollBar = scrollBar;
            ClearButton = btnClear;
            Helper = new UIHelper();
        }

        public void ShowMessage(string message) {

            Helper.AddLabel(MainPanel, message, 11, 10, 15);
        }

        public void ClearMessage() {

            var labels = MainPanel.Controls.OfType<Label>().ToArray();

            if(labels.Length > 0) {

                labels[0].Dispose();
            }
        }

        protected virtual void ResizeBottomPanel() {

            Helper.SetHeight(BottomPanel, TargetHeight / 3);
            BottomPanel.Width = Width;
            Helper.SetHeight(ClearButton, BottomPanel.Height / 2);
            ClearButton.Width = ClearButton.Height;
            ClearButton.Left = Width - ClearButton.Width - 4;
        }

        public void ExtendPanel(object sender, EventArgs e) {

            int speed = Math.Min(65, TargetHeight - Height);
            Top -= speed;
            Height += speed;

            if(Height >= TargetHeight) {

                expandTimer.Tick -= ExtendPanel;
                expandTimer.Stop();
                OnExtended(sender, e);
            }
        }

        public void ShrinkPanel(object sender, EventArgs e) {

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

        public void ButtonMouseEnter(object sender, EventArgs e) {

            ((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
        }

        public void ButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave((Button)sender, e);
        }

        public void PanelMouseEnter(object sender, EventArgs e) {

            ((Control)sender).Focus();
        }

        public void ItemClear(object sender, EventArgs e) {

            OnClear(sender, e);
        }
    }
}