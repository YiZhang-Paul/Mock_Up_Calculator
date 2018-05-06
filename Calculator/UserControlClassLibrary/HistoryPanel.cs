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
    public partial class HistoryPanel : ItemDisplayPanel<string>, IHistoryItemDisplay {

        public event EventHandler OnHistorySelect;

        public HistoryPanel() {

            InitializeComponent();
        }

        public void ClearItems() {}

        public void ShowItems(string[] values) {}

        public void RefreshItems(string[] values) {}
    }
}