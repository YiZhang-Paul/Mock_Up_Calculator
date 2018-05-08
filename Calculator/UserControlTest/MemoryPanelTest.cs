using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class MemoryPanelTest {

        class TestMemoryPanel : MemoryPanel {

            public TestMemoryPanel(IFormatter formatter) : base(formatter) {}

            public void TestMemoryClear(object sender, EventArgs e) {

                MemoryClear(sender, e);
            }

            public void TestMemorySelect(object sender, EventArgs e) {

                MemorySelect(sender, e);
            }

            public void TestMemoryPlus(object sender, EventArgs e) {

                MemoryPlus(sender, e);
            }

            public void TestMemoryMinus(object sender, EventArgs e) {

                MemoryMinus(sender, e);
            }
        }

        int eventCounter = 0;
        decimal[] values = new decimal[] { 1, 2, 3, 4, 5 };

        Mock<IFormatter> formatter;
        TestMemoryPanel memoryPanel;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            var panel = new Panel();
            panel.Height = 200;
            formatter = new Mock<IFormatter>();
            memoryPanel = new TestMemoryPanel(formatter.Object);
            memoryPanel.Parent = panel;
            memoryPanel.OnMemoryDelete += CheckEventFiring;
            memoryPanel.OnMemorySelect += CheckEventFiring;
            memoryPanel.OnMemoryPlus += CheckEventFiring;
            memoryPanel.OnMemoryMinus += CheckEventFiring;
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

            memoryPanel.TestMemoryClear(null, null);

            Assert.AreEqual(1, memoryPanel.ItemPointer);

            memoryPanel.TestMemoryClear(null, null);

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

            memoryPanel.TestMemoryClear(null, null);

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
        public void TestEventFired() {

            eventCounter = 0;

            memoryPanel.TestMemoryClear(null, null);
            memoryPanel.TestMemorySelect(null, null);
            memoryPanel.TestMemoryPlus(null, null);
            memoryPanel.TestMemoryMinus(null, null);

            Assert.AreEqual(4, eventCounter);
        }
    }
}