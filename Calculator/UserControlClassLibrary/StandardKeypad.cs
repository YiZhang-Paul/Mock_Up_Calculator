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
    public partial class StandardKeypad : UserControl, IKeypad {

        protected IButtonTracker Tracker { get; set; }
        protected HashSet<Button> AllKeys { get; set; }
        protected HashSet<Button> MemoryKeys { get; set; }
        protected HashSet<Button> BasicKeys { get; set; }

        public bool IsDisabled { get; private set; }

        public event EventHandler OnKeypadEnable;
        public event EventHandler OnButtonMouseClick;
        public event EventHandler OnButtonMouseEnter;
        public event EventHandler OnButtonMouseLeave;

        public StandardKeypad() {

            InitializeComponent();
            Initialize();
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
            EnableKeys();
        }

        public void EnableKeys() {

            UIHelper.EnableKeys(AllKeys, Tracker);
            UIHelper.DisableKeys(MemoryKeys, Tracker);
            IsDisabled = false;
        }

        public void DisableKeys() {

            UIHelper.DisableKeys(AllKeys, Tracker);
            UIHelper.EnableKeys(BasicKeys, Tracker);
            IsDisabled = true;
        }

        protected virtual void ButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.RaiseButtonEvent(sender, e, OnButtonMouseEnter, Tracker);
        }

        protected virtual void ButtonMouseLeave(object sender, EventArgs e) {

            OnButtonMouseLeave(sender, e);
        }

        protected virtual void ButtonMouseClick(object sender, EventArgs e) {

            if(IsDisabled && BasicKeys.Contains((Button)sender)) {

                EnableKeys();
                OnKeypadEnable(sender, e);

                return;
            }

            UIHelper.RaiseButtonEvent(sender, e, OnButtonMouseClick, Tracker);
        }
    }
}