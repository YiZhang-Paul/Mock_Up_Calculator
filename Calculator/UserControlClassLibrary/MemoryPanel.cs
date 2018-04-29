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

        private int VisibleItems { get; set; }
        private int ItemMargin { get; set; }

        public event EventHandler OnDelete;
        public event EventHandler OnMemoryPlus;
        public event EventHandler OnMemoryMinus;

        public MemoryPanel() {

            InitializeComponent();
            VisibleItems = 3;
            ItemMargin = 15;
        }

        public int TryGetKey(object sender) {

            return ((IMemoryItem)sender).Key;
        }

        private MemoryItem CreateItem(int key, decimal value, IFormatter formatter) {

            var item = new MemoryItem(key, value, formatter);
            item.Parent = mainPanel;
            item.Visible = false;
            item.OnDelete += MemoryClear;
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
        }

        public void ShowItems(decimal[] values, IFormatter formatter) {

            if(values.Length == 0) {

                ShowMessage("There's nothing saved in memory");

                return;
            }

            int totalHeight = (int)((double)Height / VisibleItems);

            for(int i = values.Length - 1, j = 0; i >= 0; i--, j++) {

                var item = CreateItem(i, values[i], formatter);
                item.Height = totalHeight - ItemMargin;

                if(j < VisibleItems) {

                    item.Top = totalHeight * j + ItemMargin;
                    item.Visible = true;
                }
            }
        }

        public void RefreshItems(decimal[] values, IFormatter formatter) {

            ClearItems();
            ShowItems(values, formatter);
        }

        private void MemoryClear(object sender, EventArgs e) {

            OnDelete(sender, e);
        }

        private void MemoryPlus(object sender, EventArgs e) {

            OnMemoryPlus(sender, e);
        }

        private void MemoryMinus(object sender, EventArgs e) {

            OnMemoryMinus(sender, e);
        }
    }
}