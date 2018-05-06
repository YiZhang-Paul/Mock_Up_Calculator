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
    public partial class HistoryPanel : ItemDisplayPanel<Tuple<string, decimal>>, IHistoryItemDisplay {

        private IFormatter ExpressionFormatter { get; set; }
        private IFormatter NumberFormatter { get; set; }

        public event EventHandler OnHistorySelect;

        public HistoryPanel() {

            InitializeComponent();
        }

        public HistoryPanel(IFormatter expressionFormatter, IFormatter numberFormatter) : this() {

            ExpressionFormatter = expressionFormatter;
            NumberFormatter = numberFormatter;
            Initialize();
        }

        public void ResetPointer() {

            ItemPointer = 0;
        }

        private HistoryItem CreateItem(string expression, decimal result) {

            var item = new HistoryItem(expression, result, ExpressionFormatter, NumberFormatter);
            item.Parent = MainPanel;
            item.OnSelect += HistorySelect;

            return item;
        }

        public void ClearItems() {

            var items = MainPanel.Controls.OfType<HistoryItem>().ToArray();

            for(int i = 0; i < items.Length; i++) {

                items[i].Dispose();
            }

            ClearMessage();
            ScrollBar.Visible = false;
        }

        public void ShowItems(Tuple<string, decimal>[] expressions) {

            if(expressions.Length == 0) {

                ShowMessage("There's no history yet");

                return;
            }

            Items = expressions;

            for(int i = 0, j = Items.Length - 1 - ItemPointer; i < VisibleItems; i++, j--) {

                if(j < 0) {

                    break;
                }

                var item = CreateItem(Items[j].Item1, Items[j].Item2);
                item.Width = Width;
                item.Height = ItemHeight - ItemMargin;
                item.Top = ItemHeight * i + ItemMargin;
            }

            SetScrollBar();
        }

        public void RefreshItems(Tuple<string, decimal>[] expressions) {

            ClearItems();
            ShowItems(expressions);
        }

        private void HistorySelect(object sender, EventArgs e) {

            OnHistorySelect(sender, e);
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