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

        private MemoryItem CreateItem(int key, decimal value) {

            var item = new MemoryItem(key, value, Formatter, new UIHelper());
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

                var item = CreateItem(j, Items[j]);
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

        public void MemoryClear(object sender, EventArgs e) {

            if(ItemPointer > 0 && ItemPointer == Items.Length - 2) {

                ItemPointer--;
            }

            OnMemoryDelete(sender, e);
        }

        public void MemorySelect(object sender, EventArgs e) {

            OnMemorySelect(sender, e);
        }

        public void MemoryPlus(object sender, EventArgs e) {

            OnMemoryPlus(sender, e);
        }

        public void MemoryMinus(object sender, EventArgs e) {

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