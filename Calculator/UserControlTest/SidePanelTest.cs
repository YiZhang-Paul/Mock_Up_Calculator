using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class SidePanelTest {

        bool onExtendedFired = false;
        bool onShrunkenFired = false;
        bool onSelectFired = false;

        List<string[]> items = new List<string[]>() {

            new string[] { "Calculator", "Standard", "Scientific" },
            new string[] { "Converter", "Currency" }

        };

        Mock<IHelper> helper;
        SidePanel sidePanel;

        private void CheckExtendedFiring(object sender, EventArgs e) {

            onExtendedFired = true;
        }

        private void CheckShrunkenFiring(object sender, EventArgs e) {

            onShrunkenFired = true;
        }

        private void CheckSelectFiring(object sender, EventArgs e) {

            onSelectFired = true;
        }

        [TestInitialize]
        public void Setup() {

            helper = new Mock<IHelper>();
            sidePanel = new SidePanel(helper.Object);
            sidePanel.OnExtended += CheckExtendedFiring;
            sidePanel.OnShrunken += CheckShrunkenFiring;
            sidePanel.OnSelect += CheckSelectFiring;
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

            sidePanel.KeypadButtonMouseEnter(null, null);

            helper.Verify(x => x.ButtonMouseEnter(null, null), Times.Once);
        }

        [TestMethod]
        public void KeypadButtonMouseLeave() {

            sidePanel.KeypadButtonMouseLeave(null, null);

            helper.Verify(x => x.ButtonMouseLeave(null, null), Times.Once);
        }

        [TestMethod]
        public void ToggleMenu() {

            sidePanel.ToggleMenu(null, null);
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

            sidePanel.ClearMenu();

            Assert.AreEqual("Scientific", sidePanel.Selected);
        }

        [TestMethod]
        public void OnExtendedFired() {

            Assert.IsFalse(onExtendedFired);

            sidePanel.Extend(500);
            sidePanel.Width = 459;

            sidePanel.ExtendPanel(null, null);

            Assert.IsFalse(onExtendedFired);

            sidePanel.ExtendPanel(null, null);

            Assert.IsTrue(onExtendedFired);
        }

        [TestMethod]
        public void OnShrunkenFired() {

            Assert.IsFalse(onShrunkenFired);

            sidePanel.Width = 87;

            sidePanel.ShrinkPanel(null, null);

            Assert.IsFalse(onShrunkenFired);

            sidePanel.ShrinkPanel(null, null);

            Assert.IsTrue(onShrunkenFired);
        }

        [TestMethod]
        public void OnSelectFired() {

            Assert.IsFalse(onSelectFired);

            sidePanel.ControlMouseClick(null, null);

            Assert.IsTrue(onSelectFired);
        }
    }
}