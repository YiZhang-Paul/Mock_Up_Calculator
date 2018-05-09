using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockUpCalculator;
using UserControlClassLibrary;
using CalculatorClassLibrary;
using FormatterClassLibrary;
using UtilityClassLibrary;

namespace MockUpCalculatorIntegrationTest {
    [TestClass]
    public class ScientificCalculatorPanelIntegrationTest {

        class TestScientificCalculatorPanel : ScientificCalculatorPanel {

            private bool _EngineeringMode = false;

            public override bool EngineeringModeOn { get { return _EngineeringMode; } }
            public ICalculatorDisplay TestDisplay { get { return Display; } }

            public TestScientificCalculatorPanel(

                IKeyChecker checker,
                IFormatter numberFormatter,
                IFormatter expressionFormatter,
                IFormatter engineeringFormatter,
                IScientificCalculator calculator

            ) : base(checker, numberFormatter, expressionFormatter, engineeringFormatter, calculator) {}

            public void SetEngineeringMode(bool value) {

                _EngineeringMode = value;
            }

            public void TestKeypadButtonMouseClick(object sender, EventArgs e) {

                KeypadButtonMouseClick(sender, e);
            }

            public void TestChangeAngularUnit(object sender, EventArgs e) {

                ChangeAngularUnit(sender, e);
            }
        }

        ServiceLookup service;
        TestScientificCalculatorPanel calculatorPanel;

        [TestInitialize]
        public void Setup() {

            service = new ServiceLookup();
            service.LoadCalculatorPanelAsset();

            calculatorPanel = new TestScientificCalculatorPanel(

                service.KeyChecker,
                service.NumberFormatter,
                service.ExpressionFormatter,
                service.EngineeringFormatter,

                new ScientificCalculator(

                    service.InputBuffer,
                    service.Operators,
                    service.UnitConverter,
                    service.OperatorConverter,
                    service.ExpressionBuilder,
                    service.ExpressionParser,
                    service.Evaluator,
                    service.MemoryStorage
                )
            );
        }

        [TestMethod]
        public void DefaultEngineeringModeOff() {

            Assert.IsFalse(service.GetScientificCalculatorPanel().EngineeringModeOn);
        }

        [TestMethod]
        public void EngineeringModeOn() {

            var button = new Button();
            button.Tag = "5";
            calculatorPanel.SetEngineeringMode(true);
            calculatorPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual("5.e+0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void EngineeringModeOff() {

            var button = new Button();
            button.Tag = "5";
            calculatorPanel.SetEngineeringMode(false);
            calculatorPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual("5", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void AngleInDegrees() {

            var button = new Button();

            button.Tag = "5";
            calculatorPanel.TestKeypadButtonMouseClick(button, null);
            button.Tag = "sin";
            calculatorPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual(service.Operators.SineDEG + "(5)", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("0.0871557427476581", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void AngleInRadians() {

            var button = new Button();

            calculatorPanel.TestChangeAngularUnit(null, null);

            button.Tag = "5";
            calculatorPanel.TestKeypadButtonMouseClick(button, null);
            button.Tag = "sin";
            calculatorPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual(service.Operators.SineRAD + "(5)", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("-0.958924274663138", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void AngleInGradians() {

            var button = new Button();

            calculatorPanel.TestChangeAngularUnit(null, null);
            calculatorPanel.TestChangeAngularUnit(null, null);

            button.Tag = "5";
            calculatorPanel.TestKeypadButtonMouseClick(button, null);
            button.Tag = "sin";
            calculatorPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual(service.Operators.SineGRAD + "(5)", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("0.078456786528392", calculatorPanel.TestDisplay.Input);
        }
    }
}