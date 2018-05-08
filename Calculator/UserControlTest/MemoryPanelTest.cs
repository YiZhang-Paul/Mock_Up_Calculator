using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class MemoryPanelTest {

        bool onMemoryDeleteFired = false;
        bool onMemorySelectFired = false;
        bool onMemoryPlusFired = false;
        bool onMemoryMinusFired = false;
        decimal[] values = new decimal[] { 1, 2, 3, 4, 5 };

        Mock<IFormatter> formatter;
        MemoryPanel memoryPanel;

        private void CheckMemoryDeleteFiring(object sender, EventArgs e) {

            onMemoryDeleteFired = true;
        }

        private void CheckMemorySelectFiring(object sender, EventArgs e) {

            onMemorySelectFired = true;
        }

        private void CheckMemoryPlusFiring(object sender, EventArgs e) {

            onMemoryPlusFired = true;
        }

        private void CheckMemoryMinusFiring(object sender, EventArgs e) {

            onMemoryMinusFired = true;
        }

        [TestInitialize]
        public void Setup() {

            var panel = new Panel();
            panel.Height = 200;
            formatter = new Mock<IFormatter>();
            memoryPanel = new MemoryPanel(formatter.Object);
            memoryPanel.Parent = panel;
            memoryPanel.OnMemoryDelete += CheckMemoryDeleteFiring;
            memoryPanel.OnMemorySelect += CheckMemorySelectFiring;
            memoryPanel.OnMemoryPlus += CheckMemoryPlusFiring;
            memoryPanel.OnMemoryMinus += CheckMemoryMinusFiring;
        }

        [TestMethod]
        public void ShowEmptyValues() {

            memoryPanel.ShowItems(new decimal[0]);

            Assert.AreEqual(0, memoryPanel.Items.Length);
            Assert.AreEqual(0, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void ShowValues() {

            memoryPanel.ShowItems(values);

            Assert.AreEqual(5, memoryPanel.Items.Length);
            Assert.AreEqual(0, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void UnableToScroll() {

            memoryPanel.ShowItems(new decimal[] { 1 });
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(0, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void ScrollUp() {

            memoryPanel.ShowItems(values);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(1, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(2, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(3, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(3, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(3, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void ScrollDown() {

            memoryPanel.ShowItems(values);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(1, memoryPanel.ItemPointer);

            mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 120);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(0, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(0, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void ResetPointer() {

            memoryPanel.ShowItems(values);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            Assert.AreEqual(0, memoryPanel.ItemPointer);

            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(1, memoryPanel.ItemPointer);

            memoryPanel.ResetPointer();

            Assert.AreEqual(0, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void MemoryDeleteWhenNotScrolledToBottom() {

            memoryPanel.ShowItems(values);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);
            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(1, memoryPanel.ItemPointer);

            memoryPanel.MemoryClear(null, null);

            Assert.AreEqual(1, memoryPanel.ItemPointer);

            memoryPanel.MemoryClear(null, null);

            Assert.AreEqual(1, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void MemoryDeleteWhenScrolledToBottom() {

            memoryPanel.ShowItems(values);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);
            memoryPanel.ScrollPanel(null, mouseEvent);
            memoryPanel.ScrollPanel(null, mouseEvent);
            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(3, memoryPanel.ItemPointer);

            memoryPanel.MemoryClear(null, null);

            Assert.AreEqual(2, memoryPanel.ItemPointer);
        }

        [TestMethod]
        public void ClearPanel() {

            memoryPanel.ShowItems(values);
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);
            memoryPanel.ScrollPanel(null, mouseEvent);
            memoryPanel.ScrollPanel(null, mouseEvent);

            Assert.AreEqual(2, memoryPanel.ItemPointer);
            Assert.AreEqual(5, memoryPanel.Items.Length);

            memoryPanel.ClearPanel(null, null);

            Assert.AreEqual(0, memoryPanel.ItemPointer);
            Assert.AreEqual(5, memoryPanel.Items.Length);
        }

        [TestMethod]
        public void Shrink() {

            memoryPanel.ShowItems(values);

            Assert.AreEqual(5, memoryPanel.Items.Length);

            memoryPanel.Shrink();

            Assert.AreEqual(5, memoryPanel.Items.Length);
        }

        [TestMethod]
        public void OnMemoryDeleteFired() {

            Assert.IsFalse(onMemoryDeleteFired);

            memoryPanel.MemoryClear(null, null);

            Assert.IsTrue(onMemoryDeleteFired);
        }

        [TestMethod]
        public void OnMemorySelectFired() {

            Assert.IsFalse(onMemorySelectFired);

            memoryPanel.MemorySelect(null, null);

            Assert.IsTrue(onMemorySelectFired);
        }

        [TestMethod]
        public void OnMemoryPlusFired() {

            Assert.IsFalse(onMemoryPlusFired);

            memoryPanel.MemoryPlus(null, null);

            Assert.IsTrue(onMemoryPlusFired);
        }

        [TestMethod]
        public void OnMemoryMinusFired() {

            Assert.IsFalse(onMemoryMinusFired);

            memoryPanel.MemoryMinus(null, null);

            Assert.IsTrue(onMemoryMinusFired);
        }
    }
}