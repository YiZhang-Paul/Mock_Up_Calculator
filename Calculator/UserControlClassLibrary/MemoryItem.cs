﻿using System;
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

        public int Key { get; private set; }
        public decimal Value { get; private set; }

        public event EventHandler OnDelete;
        public event EventHandler OnSelect;
        public event EventHandler OnPlus;
        public event EventHandler OnMinus;

        public MemoryItem() {

            InitializeComponent();
        }

        public MemoryItem(int key, decimal value, IFormatter formatter) : this() {

            Key = key;
            Value = value;
            Formatter = formatter;
            DisplayValue();
        }

        public void DisplayValue() {

            displayLabel.Text = Formatter.Format(Value.ToString());
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

        private void PanelClick(object sender, EventArgs e) {

            OnSelect(this, e);
        }

        private void btnClear_Click(object sender, EventArgs e) {

            RemoveFocus();
            OnDelete(this, e);
        }

        private void btnPlus_Click(object sender, EventArgs e) {

            RemoveFocus();
            OnPlus(this, e);
        }

        private void btnMinus_Click(object sender, EventArgs e) {

            RemoveFocus();
            OnMinus(this, e);
        }

        private void ButtonMouseEnter(object sender, EventArgs e) {

            ((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
            UIHelper.ReceiveFocus(Parent);
        }

        private void ButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave((Button)sender, e);
        }

        private void PanelMouseEnter(object sender, EventArgs e) {

            if(Visible) {

                SetBackColor(Color.FromArgb(58, 58, 58));
                UIHelper.ReceiveFocus(Parent);
            }
        }

        private void PanelMouseLeave(object sender, EventArgs e) {

            if(Visible && !UIHelper.ContainsPointer(mainLayout)) {

                SetBackColor(Color.FromArgb(39, 39, 39));
            }
        }
    }
}