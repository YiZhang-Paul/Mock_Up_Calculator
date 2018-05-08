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
    public partial class MemoryItem : UserControl, IMemoryItem {

        private IFormatter Formatter { get; set; }
        private IHelper Helper { get; set; }

        public int Key { get; private set; }
        public decimal RawValue { get; private set; }
        public string FormattedValue { get; private set; }

        public event EventHandler OnDelete;
        public event EventHandler OnSelect;
        public event EventHandler OnPlus;
        public event EventHandler OnMinus;

        public MemoryItem() {

            InitializeComponent();
        }

        public MemoryItem(

            int key,
            decimal value,
            IFormatter formatter,
            IHelper helper

        ) : this() {

            Key = key;
            RawValue = value;
            Formatter = formatter;
            Helper = helper;
            FormatValue();
            DisplayValue();
        }

        private void FormatValue() {

            FormattedValue = Formatter.Format(RawValue.ToString());
        }

        public void DisplayValue() {

            displayLabel.Text = FormattedValue;
        }

        private void SetBackColor(Color color) {

            BackColor = color;
            displayLabel.BackColor = color;

            foreach(var button in new Button[] { btnClear, btnPlus, btnMinus }) {

                button.BackColor = color;
                button.FlatAppearance.BorderColor = color;
            }
        }

        private void RemoveFocus() {

            displayLabel.Focus();
        }

        public void PanelClick(object sender, EventArgs e) {

            OnSelect(this, e);
        }

        public void ItemDelete(object sender, EventArgs e) {

            RemoveFocus();
            OnDelete(this, e);
        }

        public void ItemPlus(object sender, EventArgs e) {

            RemoveFocus();
            OnPlus(this, e);
        }

        public void ItemMinus(object sender, EventArgs e) {

            RemoveFocus();
            OnMinus(this, e);
        }

        public void ButtonMouseEnter(object sender, EventArgs e) {

            ((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
            Parent.Focus();
        }

        public void ButtonMouseLeave(object sender, EventArgs e) {

            Helper.ButtonMouseLeave((Button)sender, e);
        }

        public void PanelMouseEnter(object sender, EventArgs e) {

            if(Visible) {

                SetBackColor(Color.FromArgb(58, 58, 58));
                Parent.Focus();
            }
        }

        public void PanelMouseLeave(object sender, EventArgs e) {

            if(Visible && !Helper.ContainsPointer(mainLayout, Cursor.Position)) {

                SetBackColor(Color.FromArgb(39, 39, 39));
            }
        }
    }
}