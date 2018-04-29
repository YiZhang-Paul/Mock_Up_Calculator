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
    public partial class MemoryPanel : UserControl, IMemoryItemDisplay {

        private int VisibleItems { get { return Math.Max(3, TargetHeight / 108); } }
        private int TargetHeight { get; set; }
        private int ItemHeight { get { return TargetHeight / VisibleItems; } }
        private int ItemMargin { get; set; }
        private int ItemPointer { get; set; }
        private decimal[] Items { get; set; }
        private IFormatter Formatter { get; set; }

        public event EventHandler OnMemoryDelete;
        public event EventHandler OnMemoryClear;
        public event EventHandler OnMemorySelect;
        public event EventHandler OnMemoryPlus;
        public event EventHandler OnMemoryMinus;
        public event EventHandler OnExtended;
        public event EventHandler OnShrunken;

        public MemoryPanel() {

            InitializeComponent();
            Initialize();
        }

        private void Initialize() {

            ItemMargin = 15;
            mainPanel.MouseWheel += ScrollPanel;
        }

        public int TryGetKey(object sender) {

            return ((IMemoryItem)sender).Key;
        }

        private MemoryItem CreateItem(int key, decimal value, IFormatter formatter) {

            var item = new MemoryItem(key, value, formatter);
            item.Parent = mainPanel;
            item.OnDelete += MemoryClear;
            item.OnMemorySelect += MemorySelect;
            item.OnMemoryPlus += MemoryPlus;
            item.OnMemoryMinus += MemoryMinus;

            return item;
        }

        private void ShowMessage(string message) {

            UIHelper.AddLabel(mainPanel, message, 11, 10, 15);
        }

        private void ClearMessage() {

            var labels = mainPanel.Controls.OfType<Label>().ToArray();

            if(labels.Length != 0) {

                labels[0].Dispose();
            }
        }

        public void ClearItems() {

            var items = mainPanel.Controls.OfType<MemoryItem>().ToArray();

            for(int i = 0; i < items.Length; i++) {

                items[i].Dispose();
            }

            ClearMessage();
            scrollBar.Visible = false;
        }

        private bool CanScroll() {

            return ItemPointer > 0 || Items.Length > VisibleItems - 1;
        }

        private void SetScrollBar() {

            scrollBar.Visible = CanScroll();

            if(!scrollBar.Visible) {

                return;
            }

            int height = Height - bottomPanel.Height;
            int padding = height / 10;
            height -= padding;
            double percentage = (double)ItemPointer / (Items.Length - 2);
            scrollBar.Height = (int)((double)height / Items.Length * (VisibleItems - 1));
            scrollBar.Top = padding + (int)((height - scrollBar.Height) * percentage);
            scrollBar.Left = Parent.Right - scrollBar.Width * 2 - 1;
        }

        public void ShowItems(decimal[] values, IFormatter formatter) {

            if(values.Length == 0) {

                ShowMessage("There's nothing saved in memory");

                return;
            }

            Items = values;
            Formatter = formatter;

            for(int i = 0, j = Items.Length - 1 - ItemPointer; i < VisibleItems; i++, j--) {

                if(j < 0) {

                    break;
                }

                var item = CreateItem(j, Items[j], Formatter);
                item.Width = Width;
                item.Height = ItemHeight - ItemMargin;
                item.Top = ItemHeight * i + ItemMargin;
            }

            SetScrollBar();
        }

        public void RefreshItems(decimal[] values, IFormatter formatter) {

            ClearItems();
            ShowItems(values, formatter);
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

            OnMemoryClear(sender, e);
        }

        private void MemoryClear(object sender, EventArgs e) {

            if(ItemPointer == Items.Length - 2 && ItemPointer > 0) {

                ItemPointer--;
            }

            OnMemoryDelete(sender, e);
        }

        private void MemorySelect(object sender, EventArgs e) {

            OnMemorySelect(sender, e);
        }

        private void MemoryPlus(object sender, EventArgs e) {

            OnMemoryPlus(sender, e);
        }

        private void MemoryMinus(object sender, EventArgs e) {

            OnMemoryMinus(sender, e);
        }

        private void ExtendPanel(object sender, EventArgs e) {

            int speed = Math.Min(65, TargetHeight - Height);
            Top -= speed;
            Height += speed;

            if(Height >= TargetHeight) {

                memoryTimer.Tick -= ExtendPanel;
                memoryTimer.Stop();
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
                memoryTimer.Tick -= ShrinkPanel;
                memoryTimer.Stop();
                OnShrunken(sender, e);
            }
        }

        private void ResizeBottomPanel() {

            UIHelper.SetHeight(bottomPanel, ItemHeight);
            bottomPanel.Width = Width;
            UIHelper.SetHeight(btnClear, bottomPanel.Height / 2);
            btnClear.Width = btnClear.Height;
        }

        public void Extend(int height) {

            TargetHeight = height;
            memoryTimer.Tick -= ShrinkPanel;
            memoryTimer.Tick += ExtendPanel;
            memoryTimer.Start();
            ResizeBottomPanel();
            BringToFront();
        }

        public void Shrink() {

            ClearItems();
            ItemPointer = 0;
            memoryTimer.Tick -= ExtendPanel;
            memoryTimer.Tick += ShrinkPanel;
            memoryTimer.Start();
        }

        private void ScrollUp() {

            if(ItemPointer >= Items.Length - 2) {

                return;
            }

            ItemPointer++;
            RefreshItems(Items, Formatter);
        }

        private void ScrollDown() {

            if(ItemPointer <= 0) {

                return;
            }

            ItemPointer--;
            RefreshItems(Items, Formatter);
        }

        private void ScrollPanel(object sender, MouseEventArgs e) {

            if(!CanScroll()) {

                return;
            }

            if(e.Delta > 0) {

                ScrollDown();

                return;
            }

            ScrollUp();
        }
    }
}