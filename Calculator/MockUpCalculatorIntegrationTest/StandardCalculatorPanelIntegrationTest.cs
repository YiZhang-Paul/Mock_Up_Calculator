using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockUpCalculator;
using UserControlClassLibrary;
using CalculatorClassLibrary;
using FormatterClassLibrary;
using UtilityClassLibrary;
using Moq;

namespace MockUpCalculatorIntegrationTest {
    [TestClass]
    public class StandardCalculatorPanelIntegrationTest {

        class TestStandardCalculatorPanel : StandardCalculatorPanel {

            public string DivideByZero { get { return _divideByZeroMessage; } }
            public string InvalidInput { get { return _invalidInputMessage; } }
            public bool TestBackPanelActivated { get { return BackPanelActivated; } }
            public bool TestBackPanelDeactivated { get { return BackPanelDeactivated; } }
            public IHelper TestHelper { get { return Helper; } }
            public IKeypad TestKeypad { get { return Keypad; } }
            public IStandardCalculator TestCalculator { get { return Calculator; } }
            public ICalculatorDisplay TestDisplay { get { return Display; } }
            public IExpandable TestActiveBackPanel { get { return ActiveBackPanel; } }
            public IHistoryItemDisplay TestHistoryPanel { get { return HistoryPanel; } }
            public IMemoryItemDisplay TestMemoryPanel { get { return MemoryPanel; } }
            public List<Tuple<string, decimal>> TestHistory { get { return History; } }

            public TestStandardCalculatorPanel(

                IKeyChecker checker,
                IFormatter numberFormatter,
                IFormatter expressionFormatter,
                IStandardCalculator calculator

            ) : base(checker, numberFormatter, expressionFormatter, calculator) {}

            public void SetHelper(IHelper helper) {

                Helper = helper;
            }

            public void SetActiveBackPanel(IExpandable panel, Control parent) {

                ActiveBackPanel = panel;

                if(panel != null) {

                    ((Control)ActiveBackPanel).Parent = parent;
                }
            }

            public void SetBackPanelDeactivated(bool value) {

                BackPanelDeactivated = value;
            }

            public void SetBackPanelActivated(bool value) {

                BackPanelActivated = value;
            }

            public void TestRefreshDisplay(object sender, EventArgs e) {

                RefreshDisplay(sender, e);
            }

            public void TestKeypadButtonMouseClick(object sender, EventArgs e) {

                KeypadButtonMouseClick(sender, e);
            }

            public void TestEnableKeypadFromError(object sender, EventArgs e) {

                EnableKeypadFromError(sender, e);
            }

            public void TestKeypadButtonMouseEnter(object sender, EventArgs e) {

                KeypadButtonMouseEnter(sender, e);
            }

            public void TestKeypadButtonMouseLeave(object sender, EventArgs e) {

                KeypadButtonMouseLeave(sender, e);
            }

            public void TestToggleHistoryPanel(object sender, EventArgs e) {

                ToggleHistoryPanel(sender, e);
            }

            public void TestToggleMemoryPanel(object sender, EventArgs e) {

                ToggleMemoryPanel(sender, e);
            }

            public void TestBackPanelShrunken(object sender, EventArgs e) {

                BackPanelShrunken(sender, e);
            }

            public void TestHistoryPanelSelect(object sender, EventArgs e) {

                HistoryPanelSelect(sender, e);
            }

            public void TestHistoryPanelExtended(object sender, EventArgs e) {

                HistoryPanelExtended(sender, e);
            }

            public void TestHistoryPanelClear(object sender, EventArgs e) {

                HistoryPanelClear(sender, e);
            }

            public void TestCalculatorMemoryStore(object sender, EventArgs e) {

                CalculatorMemoryStore(sender, e);
            }

            public void TestCalculatorMemoryClear(object sender, EventArgs e) {

                CalculatorMemoryClear(sender, e);
            }

            public void TestCalculatorMemoryRecall(object sender, EventArgs e) {

                CalculatorMemoryRecall(sender, e);
            }

            public void TestCalculatorMemoryPlus(object sender, EventArgs e) {

                CalculatorMemoryPlus(sender, e);
            }

            public void TestCalculatorMemoryMinus(object sender, EventArgs e) {

                CalculatorMemoryMinus(sender, e);
            }

            public void TestMemoryPanelRemove(object sender, EventArgs e) {

                MemoryPanelRemove(sender, e);
            }

            public void TestMemoryPanelClear(object sender, EventArgs e) {

                MemoryPanelClear(sender, e);
            }

            public void TestMemoryPanelSelect(object sender, EventArgs e) {

                MemoryPanelSelect(sender, e);
            }

            public void TestMemoryPanelPlus(object sender, EventArgs e) {

                MemoryPanelPlus(sender, e);
            }

            public void TestMemoryPanelMinus(object sender, EventArgs e) {

                MemoryPanelMinus(sender, e);
            }

            public void TestMemoryPanelExtended(object sender, EventArgs e) {

                MemoryPanelExtended(sender, e);
            }
        }

        Mock<IHelper> helper;
        ServiceLookup service;
        TestStandardCalculatorPanel calculatorPanel;

        private void InputKey(string input, Action<object, EventArgs> callback) {

            var button = new Button();
            button.Tag = input;
            callback(button, null);
        }

        private void InputKeys(string[] inputs, Action<object, EventArgs> callback) {

            foreach(string input in inputs) {

                InputKey(input, callback);
            }
        }

        [TestInitialize]
        public void Setup() {

            helper = new Mock<IHelper>();

            service = new ServiceLookup();
            service.LoadCalculatorPanelAsset();

            calculatorPanel = new TestStandardCalculatorPanel(

                service.KeyChecker,
                service.NumberFormatter,
                service.ExpressionFormatter,

                new StandardCalculator(

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
        public void AdjustSizeWithNoActiveBackPanel() {

            Assert.IsNull(calculatorPanel.TestActiveBackPanel);

            calculatorPanel.AdjustSize();

            Assert.IsNull(calculatorPanel.TestActiveBackPanel);
        }

        [TestMethod]
        public void AdjustSizeWithActiveBackPanel() {

            var panel = new MemoryPanel();
            var parent = new Panel();
            panel.Width = 750;
            parent.Width = 450;
            calculatorPanel.SetActiveBackPanel(panel, parent);

            Assert.IsNotNull(calculatorPanel.TestActiveBackPanel);
            Assert.AreEqual(750, ((Control)calculatorPanel.TestActiveBackPanel).Width);
            Assert.AreEqual(450, parent.Width);

            calculatorPanel.AdjustSize();

            Assert.IsNotNull(calculatorPanel.TestActiveBackPanel);
            Assert.AreEqual(450, ((Control)calculatorPanel.TestActiveBackPanel).Width);
            Assert.AreEqual(0, ((Control)calculatorPanel.TestActiveBackPanel).Left);
            Assert.AreEqual(450, parent.Width);
        }

        [TestMethod]
        public void RefreshDisplay() {

            calculatorPanel.TestRefreshDisplay(null, null);

            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void ClearAllInputs() {

            string[] inputs = { "10", "+", "12" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual("10 +", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("12", calculatorPanel.TestDisplay.Input);

            InputKey("C", calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(string.Empty, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void ClearCurrentInput() {

            string[] inputs = { "10", "+", "12" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual("10 +", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("12", calculatorPanel.TestDisplay.Input);

            InputKey("CE", calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual("10 +", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void UndoLastInput() {

            string[] inputs = { "2", "fact", "+", "12" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual("fact(2) +", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("12", calculatorPanel.TestDisplay.Input);

            InputKey("⌫", calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual("fact(2) +", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("1", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void HandleSpecialEvaluation() {

            string[] inputs = { "2", ".", "9" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(string.Empty, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("2.9", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void HandleValidEvaluation() {

            string[] inputs = { "2", "fact", "+", "12" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual("fact(2) +", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("12", calculatorPanel.TestDisplay.Input);
            Assert.AreEqual(0, calculatorPanel.TestHistory.Count);

            InputKey("=", calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(string.Empty, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("14", calculatorPanel.TestDisplay.Input);
            Assert.AreEqual(1, calculatorPanel.TestHistory.Count);
            Assert.AreEqual("2 fact + 12", calculatorPanel.TestHistory.Last().Item1);
            Assert.AreEqual(14, calculatorPanel.TestHistory.Last().Item2);
        }

        [TestMethod]
        public void HandleDivideByZeroWhenEvaluating() {

            string[] inputs = { "2", service.Operators.Divide, "0", "=" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(string.Empty, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual(calculatorPanel.DivideByZero, calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void HandleDivideByZeroWhenEnteringKeys() {

            string divide = service.Operators.Divide;
            string[] inputs = { "2", divide, "0", "+" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual("2 " + divide + " 0", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual(calculatorPanel.DivideByZero, calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void HandleInvalidInputWhenEvaluating() {

            string max = decimal.MaxValue.ToString();
            string[] inputs = { max, service.Operators.Plus, max, "=" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(string.Empty, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual(calculatorPanel.InvalidInput, calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void HandleInvalidInputWhenEnteringKeys() {

            string max = decimal.MaxValue.ToString();
            string plus = service.Operators.Plus;
            string[] inputs = { max, plus, max, "+" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(max + " " + plus + " " + max, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual(calculatorPanel.InvalidInput, calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void EnableKeypadFromErrorWithInputKey() {

            InputKey("7", calculatorPanel.TestEnableKeypadFromError);

            Assert.AreEqual(string.Empty, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("7", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void EnableKeypadFromErrorWithActionKey() {

            InputKey("CE", calculatorPanel.TestEnableKeypadFromError);

            Assert.AreEqual(string.Empty, calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void KeypadButtonMouseEnter() {

            calculatorPanel.SetHelper(helper.Object);

            calculatorPanel.TestKeypadButtonMouseEnter(null, null);

            helper.Verify(x => x.ButtonMouseEnter(null, null), Times.Once);
        }

        [TestMethod]
        public void KeypadButtonMouseLeave() {

            calculatorPanel.SetHelper(helper.Object);

            calculatorPanel.TestKeypadButtonMouseLeave(null, null);

            helper.Verify(x => x.ButtonMouseLeave(null, null), Times.Once);
        }

        [TestMethod]
        public void ToggleHistoryPanel() {

            calculatorPanel.SetBackPanelDeactivated(true);

            Assert.IsTrue(calculatorPanel.TestBackPanelDeactivated);

            calculatorPanel.TestToggleHistoryPanel(null, null);

            Assert.IsFalse(calculatorPanel.TestBackPanelDeactivated);

            calculatorPanel.SetBackPanelActivated(true);
            calculatorPanel.TestToggleHistoryPanel(null, null);

            calculatorPanel.SetBackPanelActivated(false);
            calculatorPanel.TestToggleHistoryPanel(null, null);
        }

        [TestMethod]
        public void ToggleMemoryPanel() {

            calculatorPanel.SetBackPanelDeactivated(true);

            Assert.IsTrue(calculatorPanel.TestBackPanelDeactivated);

            calculatorPanel.TestToggleMemoryPanel(null, null);

            Assert.IsFalse(calculatorPanel.TestBackPanelDeactivated);

            calculatorPanel.SetBackPanelActivated(true);
            calculatorPanel.TestToggleMemoryPanel(null, null);

            calculatorPanel.SetBackPanelActivated(false);
            calculatorPanel.TestToggleMemoryPanel(null, null);
        }

        [TestMethod]
        public void BackPanelShrunken() {

            calculatorPanel.SetBackPanelActivated(true);

            calculatorPanel.TestBackPanelShrunken(null, null);

            Assert.IsFalse(calculatorPanel.TestBackPanelActivated);
        }

        [TestMethod]
        public void DeactivateBackPanel() {

            calculatorPanel.SetActiveBackPanel(null, null);
            calculatorPanel.DeactivateBackPanel();

            Assert.IsFalse(calculatorPanel.TestBackPanelDeactivated);
            Assert.IsFalse(calculatorPanel.TestKeypad.ExtraKeysSuspended);

            calculatorPanel.SetActiveBackPanel(new MemoryPanel(), new Panel());
            calculatorPanel.SetBackPanelActivated(true);
            calculatorPanel.SetHelper(helper.Object);

            helper.SetupSequence(x => x.ContainsPointer(It.IsAny<Control>(), It.IsAny<Point>()))
                  .Returns(true)
                  .Returns(false);

            calculatorPanel.DeactivateBackPanel();

            Assert.IsFalse(calculatorPanel.TestBackPanelDeactivated);
            Assert.IsFalse(calculatorPanel.TestKeypad.ExtraKeysSuspended);

            calculatorPanel.DeactivateBackPanel();

            Assert.IsTrue(calculatorPanel.TestBackPanelDeactivated);
            Assert.IsTrue(calculatorPanel.TestKeypad.ExtraKeysSuspended);
        }

        [TestMethod]
        public void HistoryPanelSelect() {

            var item = new HistoryItem(

                "5 + 6",
                11,
                service.ExpressionFormatter,
                service.NumberFormatter,
                helper.Object
            );

            calculatorPanel.TestHistoryPanelSelect(item, null);

            Assert.AreEqual("5 +", calculatorPanel.TestDisplay.Expression);
            Assert.AreEqual("6", calculatorPanel.TestDisplay.Input);

            item = new HistoryItem(

                string.Empty,
                0,
                service.ExpressionFormatter,
                service.NumberFormatter,
                helper.Object
            );

            calculatorPanel.TestHistoryPanelSelect(item, null);

            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void CalculatorMemoryStoreWithInvalidInput() {

            const string text = "Not a value";

            Assert.AreEqual(0, calculatorPanel.TestCalculator.MemoryValues.Length);

            calculatorPanel.TestDisplay.DisplayError(text);
            calculatorPanel.TestCalculatorMemoryStore(null, null);

            Assert.AreEqual(0, calculatorPanel.TestCalculator.MemoryValues.Length);
            Assert.AreEqual(text, calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void CalculatorMemoryStoreWithValidInput() {

            Assert.AreEqual(0, calculatorPanel.TestCalculator.MemoryValues.Length);

            calculatorPanel.TestCalculatorMemoryStore(null, null);

            Assert.AreEqual(1, calculatorPanel.TestCalculator.MemoryValues.Length);
            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void CalculatorMemoryClear() {

            Assert.AreEqual(0, calculatorPanel.TestCalculator.MemoryValues.Length);

            calculatorPanel.TestCalculatorMemoryStore(null, null);

            Assert.AreEqual(1, calculatorPanel.TestCalculator.MemoryValues.Length);
            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);

            calculatorPanel.TestCalculatorMemoryClear(null, null);

            Assert.AreEqual(0, calculatorPanel.TestCalculator.MemoryValues.Length);
            Assert.AreEqual("0", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void CalculatorMemoryRecall() {

            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("5", calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(1, calculatorPanel.TestCalculator.MemoryValues.Length);
            Assert.AreEqual("5", calculatorPanel.TestDisplay.Input);

            calculatorPanel.TestCalculatorMemoryRecall(null, null);

            Assert.AreEqual(1, calculatorPanel.TestCalculator.MemoryValues.Length);
            Assert.AreEqual("9", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void CalculatorMemoryPlus() {

            var calculator = calculatorPanel.TestCalculator;

            Assert.AreEqual(0, calculator.MemoryValues.Length);

            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryPlus(null, null);

            CollectionAssert.AreEqual(new decimal[] { 9 }, calculator.MemoryValues);

            InputKey("7", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);

            CollectionAssert.AreEqual(new decimal[] { 9, 7 }, calculator.MemoryValues);

            InputKey("1", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryPlus(null, null);

            CollectionAssert.AreEqual(new decimal[] { 9, 8 }, calculator.MemoryValues);
        }

        [TestMethod]
        public void CalculatorMemoryMinus() {

            var calculator = calculatorPanel.TestCalculator;

            Assert.AreEqual(0, calculator.MemoryValues.Length);

            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryMinus(null, null);

            CollectionAssert.AreEqual(new decimal[] { -9 }, calculator.MemoryValues);

            InputKey("7", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);

            CollectionAssert.AreEqual(new decimal[] { -9, 7 }, calculator.MemoryValues);

            InputKey("1", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryMinus(null, null);

            CollectionAssert.AreEqual(new decimal[] { -9, 6 }, calculator.MemoryValues);
        }

        [TestMethod]
        public void MemoryPanelRemove() {

            var calculator = calculatorPanel.TestCalculator;
            InputKey("7", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("3", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);

            CollectionAssert.AreEqual(new decimal[] { 7, 9, 3 }, calculator.MemoryValues);

            var item = new MemoryItem(1, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelRemove(item, null);

            CollectionAssert.AreEqual(new decimal[] { 7, 3 }, calculator.MemoryValues);
        }

        [TestMethod]
        public void MemoryPanelClear() {

            var calculator = calculatorPanel.TestCalculator;
            InputKey("7", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("3", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);

            CollectionAssert.AreEqual(new decimal[] { 7, 9, 3 }, calculator.MemoryValues);

            var item = new MemoryItem(1, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelClear(item, null);

            Assert.AreEqual(0, calculator.MemoryValues.Length);
        }

        [TestMethod]
        public void MemoryPanelSelect() {

            var calculator = calculatorPanel.TestCalculator;
            InputKey("7", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("3", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);

            CollectionAssert.AreEqual(new decimal[] { 7, 9, 3 }, calculator.MemoryValues);

            var item = new MemoryItem(0, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelSelect(item, null);

            Assert.AreEqual("7", calculatorPanel.TestDisplay.Input);

            item = new MemoryItem(1, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelSelect(item, null);

            Assert.AreEqual("9", calculatorPanel.TestDisplay.Input);
        }

        [TestMethod]
        public void MemoryPanelPlus() {

            var calculator = calculatorPanel.TestCalculator;
            InputKey("7", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("3", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            calculatorPanel.TestDisplay.DisplayResult("25", service.NumberFormatter);

            CollectionAssert.AreEqual(new decimal[] { 7, 9, 3 }, calculator.MemoryValues);

            var item = new MemoryItem(0, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelPlus(item, null);

            CollectionAssert.AreEqual(new decimal[] { 32, 9, 3 }, calculator.MemoryValues);

            item = new MemoryItem(1, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelPlus(item, null);

            CollectionAssert.AreEqual(new decimal[] { 32, 34, 3 }, calculator.MemoryValues);
        }

        [TestMethod]
        public void MemoryPanelMinus() {

            var calculator = calculatorPanel.TestCalculator;
            InputKey("7", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("9", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            InputKey("3", calculatorPanel.TestKeypadButtonMouseClick);
            calculatorPanel.TestCalculatorMemoryStore(null, null);
            calculatorPanel.TestDisplay.DisplayResult("25", service.NumberFormatter);

            CollectionAssert.AreEqual(new decimal[] { 7, 9, 3 }, calculator.MemoryValues);

            var item = new MemoryItem(0, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelMinus(item, null);

            CollectionAssert.AreEqual(new decimal[] { -18, 9, 3 }, calculator.MemoryValues);

            item = new MemoryItem(1, 0, service.NumberFormatter, helper.Object);
            calculatorPanel.TestMemoryPanelMinus(item, null);

            CollectionAssert.AreEqual(new decimal[] { -18, -16, 3 }, calculator.MemoryValues);
        }

        [TestMethod]
        public void MemoryPanelExtended() {

            Assert.IsFalse(calculatorPanel.TestBackPanelActivated);
            Assert.IsNull(calculatorPanel.TestActiveBackPanel);

            calculatorPanel.TestMemoryPanelExtended(null, null);

            Assert.IsTrue(calculatorPanel.TestBackPanelActivated);
            Assert.AreEqual(calculatorPanel.TestMemoryPanel, calculatorPanel.TestActiveBackPanel);
        }

        [TestMethod]
        public void HistoryPanelClear() {

            string[] inputs = { "5", service.Operators.Multiply, "7", "=" };
            InputKeys(inputs, calculatorPanel.TestKeypadButtonMouseClick);

            Assert.AreEqual(1, calculatorPanel.TestHistory.Count);

            calculatorPanel.TestHistoryPanelClear(null, null);

            Assert.AreEqual(0, calculatorPanel.TestHistory.Count);
        }

        [TestMethod]
        public void HistoryPanelExtended() {

            Assert.IsNull(calculatorPanel.TestActiveBackPanel);
            Assert.IsFalse(calculatorPanel.TestBackPanelActivated);

            calculatorPanel.TestHistoryPanelExtended(null, null);

            Assert.AreEqual(calculatorPanel.TestActiveBackPanel, calculatorPanel.TestHistoryPanel);
            Assert.IsTrue(calculatorPanel.TestBackPanelActivated);
        }
    }
}