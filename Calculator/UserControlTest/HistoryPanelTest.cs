using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class HistoryPanelTest {

        bool onHistorySelectFired = false;
        Tuple<string, decimal>[] expressions = new Tuple<string, decimal>[] {

            new Tuple<string, decimal>("5 + 6", 11),
            new Tuple<string, decimal>("3 fact", 6),
            new Tuple<string, decimal>("7 - 9", -2),
            new Tuple<string, decimal>("(5 + 6) % 6", 5),
            new Tuple<string, decimal>("2 sqr + 2", 6)
        };

        Mock<IFormatter> expressionFormatter;
        Mock<IFormatter> numberFormatter;
        HistoryPanel historyPanel;

        private void CheckHistorySelectFiring(object sender, EventArgs e) {

            onHistorySelectFired = true;
        }

        [TestInitialize]
        public void Setup() {

            var panel = new Panel();
            panel.Height = 200;
            expressionFormatter = new Mock<IFormatter>();
            numberFormatter = new Mock<IFormatter>();
            historyPanel = new HistoryPanel(expressionFormatter.Object, numberFormatter.Object);
            historyPanel.Parent = panel;
            historyPanel.OnHistorySelect += CheckHistorySelectFiring;
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

            Assert.IsFalse(onHistorySelectFired);

            historyPanel.HistorySelect(null, null);

            Assert.IsTrue(onHistorySelectFired);
        }
    }
}