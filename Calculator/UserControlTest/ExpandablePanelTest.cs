using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class ExpandablePanelTest {

        class TestExpandablePanel : ExpandablePanel {

            public TestExpandablePanel(IHelper helper) : base(helper) {}

            public void TestExtendPanel(object sender, EventArgs e) {

                ExtendPanel(sender, e);
            }

            public void TestShrinkPanel(object sender, EventArgs e) {

                ShrinkPanel(sender, e);
            }

            public void TestButtonMouseEnter(object sender, EventArgs e) {

                ButtonMouseEnter(sender, e);
            }

            public void TestButtonMouseLeave(object sender, EventArgs e) {

                ButtonMouseLeave(sender, e);
            }

            public void TestPanelMouseEnter(object sender, EventArgs e) {

                PanelMouseEnter(sender, e);
            }

            public void TestItemClear(object sender, EventArgs e) {

                ItemClear(sender, e);
            }
        }

        int eventCounter = 0;

        Button button;
        Mock<IHelper> helper;
        TestExpandablePanel expandablePanel;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            button = new Button();
            helper = new Mock<IHelper>();
            expandablePanel = new TestExpandablePanel(null);
            expandablePanel.Parent = new Panel();
            expandablePanel.OnExtended += CheckEventFiring;
            expandablePanel.OnShrunken += CheckEventFiring;
            expandablePanel.OnClear += CheckEventFiring;
        }

        [TestMethod]
        public void ShowMessage() {

            Assert.AreEqual(0, expandablePanel.MainPanel.Controls.OfType<Label>().Count());

            expandablePanel.ShowMessage("This is a test.");

            var labels = expandablePanel.MainPanel.Controls.OfType<Label>();

            Assert.AreEqual(1, labels.Count());
            Assert.AreEqual("This is a test.", labels.First().Text);
        }

        [TestMethod]
        public void ClearEmptyMessage() {

            Assert.AreEqual(0, expandablePanel.MainPanel.Controls.OfType<Label>().Count());

            expandablePanel.ClearMessage();

            Assert.AreEqual(0, expandablePanel.MainPanel.Controls.OfType<Label>().Count());
        }

        [TestMethod]
        public void ClearMessage() {

            Assert.AreEqual(0, expandablePanel.MainPanel.Controls.OfType<Label>().Count());

            expandablePanel.ShowMessage("This is a test.");

            Assert.AreEqual(1, expandablePanel.MainPanel.Controls.OfType<Label>().Count());

            expandablePanel.ClearMessage();

            Assert.AreEqual(0, expandablePanel.MainPanel.Controls.OfType<Label>().Count());
        }

        [TestMethod]
        public void Extend() {

            expandablePanel = new TestExpandablePanel(helper.Object);
            expandablePanel.Parent = new Panel();

            expandablePanel.Extend(500);

            helper.Verify(x => x.SetHeight(It.IsAny<Control>(), It.IsAny<int>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Shrink() {

            expandablePanel.Shrink();
        }

        [TestMethod]
        public void ButtonMouseEnter() {

            button.FlatAppearance.BorderColor = Color.Red;

            expandablePanel.TestButtonMouseEnter(button, null);

            Assert.AreNotEqual(Color.Red, button.FlatAppearance.BorderColor);
        }

        [TestMethod]
        public void ButtonMouseLeave() {

            expandablePanel = new TestExpandablePanel(helper.Object);

            expandablePanel.TestButtonMouseLeave(button, null);

            helper.Verify(x => x.ButtonMouseLeave(button, null), Times.Once);
        }

        [TestMethod]
        public void PanelMouseEnter() {

            expandablePanel.TestPanelMouseEnter(button, null);
        }

        [TestMethod]
        public void OnExtendedFired() {

            eventCounter = 0;

            expandablePanel.Extend(500);
            expandablePanel.Height = 434;

            expandablePanel.TestExtendPanel(null, null);

            Assert.AreEqual(0, eventCounter);

            expandablePanel.TestExtendPanel(null, null);

            Assert.AreEqual(1, eventCounter);
        }

        [TestMethod]
        public void OnShrunkenFired() {

            eventCounter = 0;

            expandablePanel.BackColor = Color.FromArgb(76, 1, 1, 1);
            expandablePanel.TestShrinkPanel(null, null);

            Assert.AreEqual(0, eventCounter);

            expandablePanel.TestShrinkPanel(null, null);

            Assert.AreEqual(1, eventCounter);
        }

        [TestMethod]
        public void OnClearFired() {

            eventCounter = 0;

            expandablePanel.TestItemClear(null, null);

            Assert.AreEqual(1, eventCounter);
        }
    }
}