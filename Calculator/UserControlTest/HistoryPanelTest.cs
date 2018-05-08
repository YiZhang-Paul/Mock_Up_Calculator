using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class HistoryPanelTest {

        class TestHistoryPanel : HistoryPanel {

            public TestHistoryPanel(

                IFormatter expressionFormatter,
                IFormatter numberFormatter

            ) : base(expressionFormatter, numberFormatter) {}

            public void TestHistorySelect(object sender, EventArgs e) {

                HistorySelect(sender, e);
            }
        }

        int eventCounter = 0;

        Tuple<string, decimal>[] expressions = new Tuple<string, decimal>[] {

            new Tuple<string, decimal>("5 + 6", 11),
            new Tuple<string, decimal>("3 fact", 6),
            new Tuple<string, decimal>("7 - 9", -2),
            new Tuple<string, decimal>("(5 + 6) % 6", 5),
            new Tuple<string, decimal>("2 sqr + 2", 6)
        };

        Mock<IFormatter> expressionFormatter;
        Mock<IFormatter> numberFormatter;
        TestHistoryPanel historyPanel;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            var panel = new Panel();
            panel.Height = 200;
            expressionFormatter = new Mock<IFormatter>();
            numberFormatter = new Mock<IFormatter>();
            historyPanel = new TestHistoryPanel(expressionFormatter.Object, numberFormatter.Object);
            historyPanel.Parent = panel;
            historyPanel.OnHistorySelect += CheckEventFiring;
        }

        [TestMethod]
        public void ShowEmptyExpressions() {

            historyPanel.ShowItems(new Tuple<string, decimal>[0]);

            Assert.AreEqual(0, historyPanel.Items.Length);
            Assert.AreEqual(0, historyPanel.ItemPointer);
        }

        [TestMethod]
        public void ShowExpressions() {

            historyPanel.ShowItems(expressions);

            Assert.AreEqual(5, historyPanel.Items.Length);
            Assert.AreEqual(0, historyPanel.ItemPointer);
        }

        [TestMethod]
        public void UnableToScroll() {

            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(0, historyPanel.ItemPointer);
        }

        [TestMethod]
        public void ScrollUp() {

            historyPanel.ShowItems(expressions);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(1, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(2, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(3, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(3, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(3, historyPanel.ItemPointer);
        }

        [TestMethod]
        public void ScrollDown() {

            historyPanel.ShowItems(expressions);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(1, historyPanel.ItemPointer);

            mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 120);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(0, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(0, historyPanel.ItemPointer);
        }

        [TestMethod]
        public void ResetPointer() {

            historyPanel.ShowItems(expressions);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, historyPanel.ItemPointer);

            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(1, historyPanel.ItemPointer);

            historyPanel.ResetPointer();

            Assert.AreEqual(0, historyPanel.ItemPointer);
        }

        [TestMethod]
        public void ClearPanel() {

            historyPanel.ShowItems(expressions);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);
            historyPanel.ScrollPanel(null, mouseEvent);
            historyPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(2, historyPanel.ItemPointer);
            Assert.AreEqual(5, historyPanel.Items.Length);

            historyPanel.ClearPanel(null, null);

            Assert.AreEqual(0, historyPanel.ItemPointer);
            Assert.AreEqual(5, historyPanel.Items.Length);
        }

        [TestMethod]
        public void Shrink() {

            historyPanel.ShowItems(expressions);

            Assert.AreEqual(5, historyPanel.Items.Length);

            historyPanel.Shrink();

            Assert.AreEqual(5, historyPanel.Items.Length);
        }

        [TestMethod]
        public void OnHistorySelectFired() {

            eventCounter = 0;

            historyPanel.TestHistorySelect(null, null);

            Assert.AreEqual(1, eventCounter);
        }
    }
}