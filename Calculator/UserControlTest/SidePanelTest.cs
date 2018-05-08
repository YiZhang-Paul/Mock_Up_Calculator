using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class SidePanelTest {

        class TestSidePanel : SidePanel {

            public TestSidePanel(IHelper helper) : base(helper) {}

            public void TestClearMenu() {

                ClearMenu();
            }

            public void TestControlMouseClick(object sender, EventArgs e) {

                ControlMouseClick(sender, e);
            }

            public void TestLabelMouseEnter(object sender, EventArgs e) {

                LabelMouseEnter(sender, e);
            }

            public void TestLabelMouseLeave(object sender, EventArgs e) {

                LabelMouseLeave(sender, e);
            }

            public void TestPanelMouseEnter(object sender, EventArgs e) {

                PanelMouseEnter(sender, e);
            }

            public void TestPanelMouseLeave(object sender, EventArgs e) {

                PanelMouseLeave(sender, e);
            }

            public void TestKeypadButtonMouseEnter(object sender, EventArgs e) {

                KeypadButtonMouseEnter(sender, e);
            }

            public void TestKeypadButtonMouseLeave(object sender, EventArgs e) {

                KeypadButtonMouseLeave(sender, e);
            }

            public void TestToggleMenu(object sender, EventArgs e) {

                ToggleMenu(sender, e);
            }

            public void TestExtendPanel(object sender, EventArgs e) {

                ExtendPanel(sender, e);
            }

            public void TestShrinkPanel(object sender, EventArgs e) {

                ShrinkPanel(sender, e);
            }
        }

        int eventCounter = 0;

        List<string[]> items = new List<string[]>() {

            new string[] { "Calculator", "Standard", "Scientific" },
            new string[] { "Converter", "Currency" }
        };

        Panel panel;
        Label label1;
        Label label2;
        Mock<IHelper> helper;
        TestSidePanel sidePanel;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            panel = new Panel();
            label1 = new Label();
            label2 = new Label();
            label1.Parent = panel;
            label2.Parent = panel;

            helper = new Mock<IHelper>();
            sidePanel = new TestSidePanel(helper.Object);
            sidePanel.OnExtended += CheckEventFiring;
            sidePanel.OnShrunken += CheckEventFiring;
            sidePanel.OnSelect += CheckEventFiring;
        }

        [TestMethod]
        public void Extend() {

            sidePanel.Extend(400);

            Assert.AreEqual(1, sidePanel.Width);
        }

        [TestMethod]
        public void Shrink() {

            sidePanel.Shrink();
        }

        [TestMethod]
        public void KeypadButtonMouseEnter() {

            sidePanel.TestKeypadButtonMouseEnter(null, null);

            helper.Verify(x => x.ButtonMouseEnter(null, null), Times.Once);
        }

        [TestMethod]
        public void KeypadButtonMouseLeave() {

            sidePanel.TestKeypadButtonMouseLeave(null, null);

            helper.Verify(x => x.ButtonMouseLeave(null, null), Times.Once);
        }

        [TestMethod]
        public void ToggleMenu() {

            sidePanel.TestToggleMenu(null, null);
        }

        [TestMethod]
        public void ShowMenu() {

            sidePanel.ShowMenu(items, "Scientific");

            Assert.AreEqual("Scientific", sidePanel.Selected);
        }

        [TestMethod]
        public void ClearMenu() {

            sidePanel.ShowMenu(items, "Scientific");

            Assert.AreEqual("Scientific", sidePanel.Selected);

            sidePanel.TestClearMenu();

            Assert.AreEqual("Scientific", sidePanel.Selected);
        }

        [TestMethod]
        public void LabelMouseEnter() {

            panel.BackColor = Color.BlanchedAlmond;
            label1.BackColor = Color.BlanchedAlmond;
            label2.BackColor = Color.BlanchedAlmond;

            sidePanel.TestLabelMouseEnter(label1, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, panel.BackColor);
            Assert.AreNotEqual(Color.BlanchedAlmond, label1.BackColor);
            Assert.AreEqual(Color.BlanchedAlmond, label2.BackColor);
        }

        [TestMethod]
        public void LabelMouseLeave() {

            sidePanel.ShowMenu(items, "Scientific");
            panel.BackColor = Color.BlanchedAlmond;
            panel.Tag = string.Empty;
            label1.BackColor = Color.BlanchedAlmond;
            label1.Tag = "Scientific";
            label2.BackColor = Color.BlanchedAlmond;
            label2.Tag = string.Empty;

            sidePanel.TestLabelMouseLeave(label1, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, panel.BackColor);
            Assert.AreNotEqual(Color.BlanchedAlmond, label1.BackColor);
            Assert.AreEqual(Color.BlanchedAlmond, label2.BackColor);
        }

        [TestMethod]
        public void PanelMouseEnter() {

            panel.BackColor = Color.BlanchedAlmond;
            label1.BackColor = Color.BlanchedAlmond;
            label2.BackColor = Color.BlanchedAlmond;

            sidePanel.TestPanelMouseEnter(panel, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, panel.BackColor);
            Assert.AreNotEqual(Color.BlanchedAlmond, label1.BackColor);
            Assert.AreNotEqual(Color.BlanchedAlmond, label2.BackColor);
        }

        [TestMethod]
        public void PanelMouseLeave() {

            sidePanel.ShowMenu(items, "Scientific");
            panel.BackColor = Color.BlanchedAlmond;
            panel.Tag = string.Empty;
            label1.BackColor = Color.BlanchedAlmond;
            label1.Tag = "Scientific";
            label2.BackColor = Color.BlanchedAlmond;
            label2.Tag = string.Empty;

            sidePanel.TestPanelMouseLeave(panel, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, panel.BackColor);
            Assert.AreNotEqual(Color.BlanchedAlmond, label1.BackColor);
            Assert.AreNotEqual(Color.BlanchedAlmond, label2.BackColor);
        }

        [TestMethod]
        public void OnExtendedFired() {

            eventCounter = 0;

            sidePanel.Extend(500);
            sidePanel.Width = 459;

            sidePanel.TestExtendPanel(null, null);

            Assert.AreEqual(0, eventCounter);

            sidePanel.TestExtendPanel(null, null);

            Assert.AreEqual(1, eventCounter);
        }

        [TestMethod]
        public void OnShrunkenFired() {

            eventCounter = 0;

            sidePanel.Width = 87;

            sidePanel.TestShrinkPanel(null, null);

            Assert.AreEqual(0, eventCounter);

            sidePanel.TestShrinkPanel(null, null);

            Assert.AreEqual(1, eventCounter);
        }

        [TestMethod]
        public void OnSelectFired() {

            eventCounter = 0;

            sidePanel.TestControlMouseClick(null, null);

            Assert.AreEqual(1, eventCounter);
        }
    }
}