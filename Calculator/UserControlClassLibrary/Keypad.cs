using System;
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
    public partial class Keypad : UserControl, IKeypad {

        protected IButtonTracker Tracker { get; set; }
        protected HashSet<Button> AllKeys { get; set; }
        protected HashSet<Button> MemoryKeys { get; set; }
        protected HashSet<Button> BasicKeys { get; set; }
        protected Point ClientCenter { get; set; }

        public bool HasMemory { get; set; }
        public bool IsDisabled { get; private set; }
        public bool ExtraKeysSuspended { get; set; }
        public virtual int MainAreaHeight { get; private set; }

        public event EventHandler OnKeypadEnable;
        public event EventHandler OnMemoryStore;
        public event EventHandler OnMemoryAdd;
        public event EventHandler OnMemorySubtract;
        public event EventHandler OnMemoryRecall;
        public event EventHandler OnMemoryClear;
        public event EventHandler OnMemoryToggle;
        public event EventHandler OnButtonMouseClick;
        public event EventHandler OnButtonMouseEnter;
        public event EventHandler OnButtonMouseLeave;

        public Keypad() {

            InitializeComponent();
        }

        private Button[] GetAllKeys() {

            var keys = new List<Button>();
            UIHelper.ControlsOfType<Button>(this, keys);

            return keys.ToArray();
        }

        private bool IsMemoryKey(Button button) {

            return Regex.IsMatch(button.Text, "^(MC|MR|M▾)$");
        }

        private bool IsBasicKey(Button button) {

            return Regex.IsMatch(button.Text, "^([0-9=]|CE|C|⌫)$");
        }

        protected virtual void RecordKeys() {

            AllKeys = new HashSet<Button>(GetAllKeys());
            MemoryKeys = new HashSet<Button>(AllKeys.Where(IsMemoryKey));
            BasicKeys = new HashSet<Button>(AllKeys.Where(IsBasicKey));
        }

        protected void Initialize() {

            Tracker = new ButtonTracker();
            RecordKeys();
            EnableValidKeys();
        }

        public void EnableAllKeys() {

            UIHelper.EnableKeys(AllKeys, Tracker);
        }

        public void EnableValidKeys() {

            UIHelper.EnableKeys(AllKeys, Tracker);

            if(!HasMemory) {

                DisableMemoryKeys();
            }

            IsDisabled = false;
        }

        public void DisableAllKeys() {

            UIHelper.DisableKeys(AllKeys, Tracker);
        }

        public void LeaveBasicKeysOn() {

            UIHelper.DisableKeys(AllKeys, Tracker);
            UIHelper.EnableKeys(BasicKeys, Tracker);
            IsDisabled = true;
        }

        public virtual void LeaveMemoryKeyOn() {

            UIHelper.DisableKeys(AllKeys, Tracker);
        }

        private void CheckMemory() {

            if(!HasMemory) {

                HasMemory = true;
                EnableMemoryKeys();
            }
        }

        protected void EnableMemoryKeys() {

            UIHelper.EnableKeys(MemoryKeys, Tracker);
        }

        protected void DisableMemoryKeys() {

            UIHelper.DisableKeys(MemoryKeys, Tracker);
        }

        protected virtual void ButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.RaiseButtonEvent(sender, e, OnButtonMouseEnter, Tracker);
        }

        protected virtual void ButtonMouseLeave(object sender, EventArgs e) {

            OnButtonMouseLeave(sender, e);
        }

        protected virtual void ButtonMouseClick(object sender, EventArgs e) {

            if(IsDisabled && BasicKeys.Contains((Button)sender)) {

                EnableValidKeys();
                OnKeypadEnable(sender, e);

                return;
            }

            UIHelper.RaiseButtonEvent(sender, e, OnButtonMouseClick, Tracker);
        }

        protected bool CanUseExtraKey(Button button) {

            return !ExtraKeysSuspended && !Tracker.IsDisabled(button);
        }

        protected virtual void MemoryStoreClick(object sender, EventArgs e) {

            if(!CanUseExtraKey((Button)sender)) {

                return;
            }

            CheckMemory();
            OnMemoryStore(sender, e);
        }

        protected virtual void MemoryAddClick(object sender, EventArgs e) {

            if(!CanUseExtraKey((Button)sender)) {

                return;
            }

            CheckMemory();
            OnMemoryAdd(sender, e);
        }

        protected virtual void MemorySubtractClick(object sender, EventArgs e) {

            if(!CanUseExtraKey((Button)sender)) {

                return;
            }

            CheckMemory();
            OnMemorySubtract(sender, e);
        }

        protected virtual void MemoryClearClick(object sender, EventArgs e) {

            if(!CanUseExtraKey((Button)sender)) {

                return;
            }

            HasMemory = false;
            DisableMemoryKeys();
            OnMemoryClear(sender, e);
        }

        protected virtual void MemoryRecallClick(object sender, EventArgs e) {

            if(!CanUseExtraKey((Button)sender)) {

                return;
            }

            OnMemoryRecall(sender, e);
        }

        protected virtual void MemoryToggleClick(object sender, EventArgs e) {

            if(!CanUseExtraKey((Button)sender)) {

                return;
            }

            OnMemoryToggle(sender, e);
        }

        protected void SaveClientCenter() {

            ClientCenter = new Point(Width / 2, Height / 2);
        }

        protected void ScaleTo(float scale) {

            Width = (int)(Width * scale);
            Height = (int)(Height * scale);
            Top = ClientCenter.Y - Height / 2;
            Left = ClientCenter.X - Width / 2;
        }

        private void ShowKeys(object sender, EventArgs e) {

            float scale = 1.015f;
            ScaleTo(scale);

            if(Width * scale >= ClientCenter.X * 2 || Height * scale >= ClientCenter.Y * 2) {

                Dock = DockStyle.Fill;
                loadTimer.Tick -= ShowKeys;
                loadTimer.Stop();
            }
        }

        protected virtual void LoadKeypad(object sender, EventArgs e) {

            SaveClientCenter();
            Anchor = AnchorStyles.None;
            ScaleTo(0.95f);
            loadTimer.Tick += ShowKeys;
            loadTimer.Start();
        }
    }
}