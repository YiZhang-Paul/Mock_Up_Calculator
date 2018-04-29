using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlClassLibrary;
using ExpressionsClassLibrary;
using CalculatorClassLibrary;
using FormatterClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculator {
    public partial class MainForm : BaseForm {

        private IFormatter NumberFormatter { get; set; }
        private IFormatter EngineeringFormatter { get; set; }
        private IScientificCalculator Calculator { get; set; }
        private ScientificCalculatorPanel CalculatorPanel { get; set; }

        public MainForm() {

            InitializeComponent();
            Initialize();
        }

        private void SetupTopPanel() {

            topPanel.OnMouseHold += SavePointerLocation;
            topPanel.OnMouseDrag += DragWindow;
            topPanel.OnMinimize += Minimize;
            topPanel.OnSizeToggle += ToggleWindowSize;
            topPanel.OnExit += Exit;
        }

        protected override void Initialize() {

            base.Initialize();
            Checker = new KeyChecker();
            Calculator = new ScientificCalculator();
            NumberFormatter = new NumberFormatter();
            EngineeringFormatter = new EngineeringFormatter();
            MainLayout = mainLayout;
            BottomPanel = bottomPanel;
            SetupTopPanel();
            CalculatorPanel = new ScientificCalculatorPanel(Calculator, Checker, NumberFormatter, EngineeringFormatter);
            CalculatorPanel.Parent = uiLayout;
            CalculatorPanel.Dock = DockStyle.Fill;
            CalculatorPanel.Show();
        }

        private void RemoveFocus(object sender, EventArgs e) {

            currentCalculatorLabel.Focus();
        }

        private void KeypadButtonMouseEnter(object sender, EventArgs e) {

            UIHelper.ButtonMouseEnter(sender, e);
        }

        private void KeypadButtonMouseLeave(object sender, EventArgs e) {

            UIHelper.ButtonMouseLeave(sender, e);
        }

        private void MainCalculator_Deactivate(object sender, EventArgs e) {

            CalculatorPanel.DeactivateMemoryPanel();
        }

        protected override void WndProc(ref Message message) {

            base.WndProc(ref message);

            const int notify = 0x210; //WM_PARENTNOTIFY
            const int click = 0x201;  //WM_LBUTTONDOWN

            if(message.Msg == click || (message.Msg == notify && (int)message.WParam == click)) {

                if(!UIHelper.ContainsPointer(topPanel)) {

                    CalculatorPanel.DeactivateMemoryPanel();
                }
            }
        }
    }
}