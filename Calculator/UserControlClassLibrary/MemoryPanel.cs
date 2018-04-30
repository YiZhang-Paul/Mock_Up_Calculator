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
    public partial class MemoryPanel : ExpandableDisplayPanel, IMemoryItemDisplay {

        private int VisibleItems { get { return Math.Max(3, TargetHeight / 108); } }
        private int ItemHeight { get { return TargetHeight / VisibleItems; } }
        private int ItemMargin { get; set; }
        private int ItemPointer { get; set; }
        private decimal[] Items { get; set; }
        private IFormatter Formatter { get; set; }

        public event EventHandler OnMemoryDelete;
        public event EventHandler OnMemorySelect;
        public event EventHandler OnMemoryPlus;
        public event EventHandler OnMemoryMinus;

        public MemoryPanel() {

            InitializeComponent();
            Initialize();
        }

        protected override void Initialize() {

            base.Initialize();
            ItemMargin = 15;
            MainPanel.MouseWheel += ScrollPanel;
            OnClear += ClearPanel;
        }

        public int TryGetKey(object sender) {

            return ((IMemoryItem)sender).Key;
        }

        private MemoryItem CreateItem(int key, decimal value, IFormatter formatter) {

            var item = new MemoryItem(key, value, formatter);
            item.Parent = MainPanel;
            item.OnDelete += MemoryClear;
            item.OnMemorySelect += MemorySelect;
            item.OnMemoryPlus += MemoryPlus;
            item.OnMemoryMinus += MemoryMinus;

            return item;
        }

        public void ClearItems() {

            var items = MainPanel.Controls.OfType<MemoryItem>().ToArray();

            for(int i = 0; i < items.Length; i++) {

                items[i].Dispose();
            }

            ClearMessage();
            ScrollBar.Visible = false;
        }

        private bool CanScroll() {

            return ItemPointer > 0 || Items.Length > VisibleItems - 1;
        }

        private void SetScrollBar() {

            ScrollBar.Visible = CanScroll();

            if(!ScrollBar.Visible) {

                return;
            }

            int height = Height - BottomPanel.Height;
            int padding = height / 10;
            height -= padding;
            double percentage = (double)ItemPointer / (Items.Length - 2);
            ScrollBar.Height = (int)((double)height / Items.Length * (VisibleItems - 1));
            ScrollBar.Top = padding + (int)((height - ScrollBar.Height) * percentage);
            ScrollBar.Left = Parent.Right - ScrollBar.Width * 2 - 1;
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

        private void ClearPanel(object sender, EventArgs e) {

            ItemPointer = 0;
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

        protected override void ResizeBottomPanel() {

            UIHelper.SetHeight(BottomPanel, ItemHeight);
            BottomPanel.Width = Width;
            UIHelper.SetHeight(ClearButton, BottomPanel.Height / 2);
            ClearButton.Width = ClearButton.Height;
            ClearButton.Left = Width - ClearButton.Width - 4;
        }

        public override void Shrink() {

            ClearItems();
            base.Shrink();
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