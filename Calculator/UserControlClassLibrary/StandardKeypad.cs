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
    public partial class StandardKeypad : Keypad {

        public override int MainAreaHeight { get { return Height - extraKeysLayout.Height; } }

        public StandardKeypad() {

            InitializeComponent();
            Initialize();
        }

        public StandardKeypad(IHelper helper) : this() {

            Helper = helper;
        }

        public override void LeaveMemoryKeyOn() {

            base.LeaveMemoryKeyOn();
            Helper.EnableKeys(new Button[] { btnMemory }, Tracker);
        }

        private void RemoveFocus() {

            mainLayout.Focus();
        }

        protected override void ButtonMouseEnter(object sender, EventArgs e) {

            base.ButtonMouseEnter(sender, e);
        }

        protected override void ButtonMouseLeave(object sender, EventArgs e) {

            base.ButtonMouseLeave(sender, e);
        }

        protected override void ButtonMouseClick(object sender, EventArgs e) {

            RemoveFocus();
            base.ButtonMouseClick(sender, e);
        }

        protected override void MemoryStoreClick(object sender, EventArgs e) {

            RemoveFocus();
            base.MemoryStoreClick(sender, e);
        }

        protected override void MemoryAddClick(object sender, EventArgs e) {

            RemoveFocus();
            base.MemoryAddClick(sender, e);
        }

        protected override void MemorySubtractClick(object sender, EventArgs e) {

            RemoveFocus();
            base.MemorySubtractClick(sender, e);
        }

        protected override void MemoryClearClick(object sender, EventArgs e) {

            RemoveFocus();
            base.MemoryClearClick(sender, e);
        }

        protected override void MemoryRecallClick(object sender, EventArgs e) {

            RemoveFocus();
            base.MemoryRecallClick(sender, e);
        }

        protected override void MemoryToggleClick(object sender, EventArgs e) {

            RemoveFocus();
            base.MemoryToggleClick(sender, e);
        }
    }
}