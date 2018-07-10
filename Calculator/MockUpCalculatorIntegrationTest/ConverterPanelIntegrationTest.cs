using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockUpCalculator;
using UtilityClassLibrary;
using UserControlClassLibrary;
using FormatterClassLibrary;
using ConverterClassLibrary;

namespace MockUpCalculatorIntegrationTest {
    [TestClass]
    public class ConverterPanelIntegrationTest {

        class TestConverterPanel : ConverterPanel {

            public IInputBuffer TestBuffer { get { return Buffer; } }
            public IConverterDisplay TestDisplay { get { return Display; } }

            public TestConverterPanel(

                IInputBuffer buffer,
                IKeyChecker checker,
                IFormatter formatter,
                IUnitConverter converter,
                string[] units

            ) : base(buffer, checker, formatter, converter, units) {}

            public void SetBuffer(string content) {

                Buffer.Set(content);
            }

            public void TestKeypadButtonMouseClick(object sender, EventArgs e) {

                KeypadButtonMouseClick(sender, e);
            }
        }

        Button button;
        ServiceLookup service;
        TestConverterPanel converterPanel;

        [TestInitialize]
        public void Setup() {

            button = new Button();

            service = new ServiceLookup();
            service.LoadConverterPanelAsset();

            converterPanel = new TestConverterPanel(

                service.InputBuffer,
                service.KeyChecker,
                service.NumberFormatter,
                new AngleConverter(),
                new string[] { "Degrees", "Radians", "Gradians" }
            );
        }

        [TestMethod]
        public void ClearInput() {

            button.Tag = "CE";
            converterPanel.SetBuffer("543");

            Assert.AreEqual("543", converterPanel.TestBuffer.Content);

            converterPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual("0", converterPanel.TestBuffer.Content);
        }

        [TestMethod]
        public void UndoInput() {

            button.Tag = "⌫";
            converterPanel.SetBuffer("54");

            Assert.AreEqual("54", converterPanel.TestBuffer.Content);

            converterPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual("5", converterPanel.TestBuffer.Content);

            converterPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual("0", converterPanel.TestBuffer.Content);
        }

        [TestMethod]
        public void RefreshDisplay() {

            button.Tag = "0";
            converterPanel.SetBuffer("1");

            Assert.AreEqual("1", converterPanel.TestBuffer.Content);

            converterPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual("10", converterPanel.TestDisplay.InputValue);
            Assert.AreEqual("0.1745", converterPanel.TestDisplay.MainOutputValue);

            converterPanel.SetBuffer("0");

            Assert.AreEqual("0", converterPanel.TestBuffer.Content);

            converterPanel.TestKeypadButtonMouseClick(button, null);

            Assert.AreEqual("0", converterPanel.TestDisplay.InputValue);
            Assert.AreEqual("0", converterPanel.TestDisplay.MainOutputValue);
        }
    }
}