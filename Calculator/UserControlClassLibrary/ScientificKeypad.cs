﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UtilityClassLibrary;

namespace UserControlClassLibrary {
    public partial class ScientificKeypad : Keypad, IScientificKeypad {

        private HashSet<Button> TrigonometricKeys { get; set; }
        private float UnitKeyFontSize { get; set; }

        public int AngularUnit { get; private set; }
        public bool EngineeringMode { get; private set; }
        public bool ExtensionToggled { get; private set; }
        public bool TrigonometricToggled { get; private set; }
        public override int MainAreaHeight { get { return Height - extraKeysLayout.Height; } }

        public event EventHandler OnAngularUnitToggle;
        public event EventHandler OnEngineeringModeToggle;

        public ScientificKeypad() {

            InitializeComponent();
            Initialize();
            UnitKeyFontSize = btnDegRadGrad.Font.SizeInPoints;
        }

        public ScientificKeypad(IHelper helper, IButtonTracker tracker) : this() {

            Helper = helper;
            Tracker = tracker;
        }

        private bool IsTrigonometricKey(Button button) {

            return Regex.IsMatch(button.Text, "sin|cos|tan");
        }

        protected override void RecordKeys() {

            base.RecordKeys();
            TrigonometricKeys = new HashSet<Button>(AllKeys.Where(IsTrigonometricKey));
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

        protected void ToggleExtension(object sender, EventArgs e) {

            var button = (Button)sender;

            if(Tracker.IsDisabled(button)) {

                return;
            }

            ExtensionToggled = !ExtensionToggled;
            RemoveFocus();

            if(ExtensionToggled) {

                button.Paint += Helper.DrawUnderline;
                extensionTwoPanel.BringToFront();
            }
            else {

                button.Paint -= Helper.DrawUnderline;
                extensionOnePanel.BringToFront();
            }
        }

        private void UpdateTrigonometricKeys() {

            foreach(var key in TrigonometricKeys) {

                string pattern = TrigonometricToggled ? "sin|cos|tan" : "h";
                string replace = TrigonometricToggled ? "h" : string.Empty;
                Helper.UpdateKeyText(key, pattern, replace, TrigonometricToggled);
            }
        }

        protected void ToggleHypotenuse(object sender, EventArgs e) {

            var button = (Button)sender;

            if(!CanUseExtraKey(button)) {

                return;
            }

            TrigonometricToggled = !TrigonometricToggled;
            UpdateTrigonometricKeys();
            RemoveFocus();

            if(TrigonometricToggled) {

                button.Paint += Helper.DrawUnderline;
            }
            else {

                button.Paint -= Helper.DrawUnderline;
            }
        }

        protected void ToggleEngineeringFormat(object sender, EventArgs e) {

            var button = (Button)sender;

            if(!CanUseExtraKey(button)) {

                return;
            }

            EngineeringMode = !EngineeringMode;
            OnEngineeringModeToggle(sender, e);
            RemoveFocus();

            if(EngineeringMode) {

                button.Paint += Helper.DrawUnderline;
            }
            else {

                button.Paint -= Helper.DrawUnderline;
            }
        }

        protected void ToggleAngularUnit(object sender, EventArgs e) {

            var button = (Button)sender;

            if(!CanUseExtraKey(button)) {

                return;
            }

            AngularUnit = (AngularUnit + 1) % 3;
            OnAngularUnitToggle(sender, e);
            RemoveFocus();

            if(AngularUnit == 0) {

                button.Text = "DEG";

                return;
            }

            button.Text = AngularUnit == 1 ? "RAD" : "GRAD";
        }

        protected void ResizeUnitKeyText(object sender, EventArgs e) {

            var button = (Button)sender;
            float size = UnitKeyFontSize;

            if(AngularUnit != 2) {

                button.Font = new Font(button.Font.FontFamily, size);

                return;
            }

            float maxWidth = (button.Width - 2 * button.FlatAppearance.BorderSize) / 5 * 3.5f;

            if(size * button.Text.Length > maxWidth) {

                size *= maxWidth / (size * button.Text.Length);
            }

            button.Font = new Font(button.Font.FontFamily, size);
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