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

        bool onExtendedFired = false;
        bool onShrunkenFired = false;
        bool onClearFired = false;

        Mock<IHelper> helper;
        Button button;
        ExpandablePanel expandablePanel;

        private void CheckExtendedFiring(object sender, EventArgs e) {

            onExtendedFired = true;
        }

        private void CheckShrunkenFiring(object sender, EventArgs e) {

            onShrunkenFired = true;
        }

        private void CheckClearFiring(object sender, EventArgs e) {

            onClearFired = true;
        }

        [TestInitialize]
        public void Setup() {

            helper = new Mock<IHelper>();
            button = new Button();
            expandablePanel = new ExpandablePanel(null);
            expandablePanel.OnExtended += CheckExtendedFiring;
            expandablePanel.OnShrunken += CheckShrunkenFiring;
            expandablePanel.OnClear += CheckClearFiring;
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

            expandablePanel = new ExpandablePanel(helper.Object);

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

            expandablePanel.ButtonMouseEnter(button, null);

            Assert.AreNotEqual(Color.Red, button.FlatAppearance.BorderColor);
        }

        [TestMethod]
        public void ButtonMouseLeave() {

            expandablePanel = new ExpandablePanel(helper.Object);

            expandablePanel.ButtonMouseLeave(button, null);

            helper.Verify(x => x.ButtonMouseLeave(button, null), Times.Once);
        }

        [TestMethod]
        public void PanelMouseEnter() {

            expandablePanel.PanelMouseEnter(button, null);
        }

        [TestMethod]
        public void OnExtendedFired() {

            Assert.IsFalse(onExtendedFired);

            expandablePanel.Extend(500);
            expandablePanel.Height = 434;

            expandablePanel.ExtendPanel(null, null);

            Assert.IsFalse(onExtendedFired);

            expandablePanel.ExtendPanel(null, null);

            Assert.IsTrue(onExtendedFired);
        }

        [TestMethod]
        public void OnShrunkenFired() {

            Assert.IsFalse(onShrunkenFired);

            expandablePanel.BackColor = Color.FromArgb(76, 1, 1, 1);
            expandablePanel.ShrinkPanel(null, null);

            Assert.IsFalse(onShrunkenFired);

            expandablePanel.ShrinkPanel(null, null);

            Assert.IsTrue(onShrunkenFired);
        }

        [TestMethod]
        public void OnClearFired() {

            Assert.IsFalse(onClearFired);

            expandablePanel.ItemClear(null, null);

            Assert.IsTrue(onClearFired);
        }
    }
}