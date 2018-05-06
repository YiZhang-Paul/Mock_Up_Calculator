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
    public partial class MemoryPanel : ItemDisplayPanel<decimal>, IMemoryItemDisplay {

        private IFormatter Formatter { get; set; }

        public event EventHandler OnMemoryDelete;
        public event EventHandler OnMemorySelect;
        public event EventHandler OnMemoryPlus;
        public event EventHandler OnMemoryMinus;

        public MemoryPanel() {

            InitializeComponent();
        }

        public MemoryPanel(IFormatter formatter) : this() {

            Formatter = formatter;
            Initialize();
        }

        public void ResetPointer() {

            ItemPointer = 0;
        }

        private MemoryItem CreateItem(int key, decimal value, IFormatter formatter) {

            var item = new MemoryItem(key, value, formatter);
            item.Parent = MainPanel;
            item.OnDelete += MemoryClear;
            item.OnSelect += MemorySelect;
            item.OnPlus += MemoryPlus;
            item.OnMinus += MemoryMinus;

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

        public void ShowItems(decimal[] values) {

            if(values.Length == 0) {

                ShowMessage("There's nothing saved in memory");

                return;
            }

            Items = values;

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

        public void RefreshItems(decimal[] values) {

            ClearItems();
            ShowItems(values);
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

        public override void Shrink() {

            ClearItems();
            base.Shrink();
        }

        protected override void ScrollUp() {

            int pointer = ItemPointer;
            base.ScrollUp();

            if(pointer != ItemPointer) {

                RefreshItems(Items);
            }
        }

        protected override void ScrollDown() {

            int pointer = ItemPointer;
            base.ScrollDown();

            if(pointer != ItemPointer) {

                RefreshItems(Items);
            }
        }
    }
}