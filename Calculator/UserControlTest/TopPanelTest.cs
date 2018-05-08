using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;

namespace UserControlTest {
    [TestClass]
    public class TopPanelTest {

        bool onMouseHoldFired = false;
        bool onMouseDragFired = false;
        bool onMinimizeFired = false;
        bool onSizeToggleFired = false;
        bool onExitFired = false;

        TopPanel topPanel;

        private void CheckMouseHoldFiring(object sender, EventArgs e) {

            onMouseHoldFired = true;
        }

        private void CheckMouseDragFiring(object sender, EventArgs e) {

            onMouseDragFired = true;
        }

        private void CheckMinimizeFiring(object sender, EventArgs e) {

            onMinimizeFired = true;
        }

        private void CheckSizeToggleFiring(object sender, EventArgs e) {

            onSizeToggleFired = true;
        }

        private void CheckExitFiring(object sender, EventArgs e) {

            onExitFired = true;
        }

        [TestInitialize]
        public void Setup() {

            topPanel = new TopPanel();
            topPanel.OnMouseHold += CheckMouseHoldFiring;
            topPanel.OnMouseDrag += CheckMouseDragFiring;
            topPanel.OnMinimize += CheckMinimizeFiring;
            topPanel.OnSizeToggle += CheckSizeToggleFiring;
            topPanel.OnExit += CheckExitFiring;
        }

        [TestMethod]
        public void OnMouseHoldFired() {

            Assert.IsFalse(onMouseHoldFired);

            topPanel.GetPointerLocation(null, null);

            Assert.IsTrue(onMouseHoldFired);
        }

        [TestMethod]
        public void OnMouseDragFired() {

            Assert.IsFalse(onMouseDragFired);

            topPanel.Drag(null, null);

            Assert.IsTrue(onMouseDragFired);
        }

        [TestMethod]
        public void OnMinimizeFired() {

            Assert.IsFalse(onMinimizeFired);

            topPanel.Minimize(null, null);

            Assert.IsTrue(onMinimizeFired);
        }

        [TestMethod]
        public void OnSizeToggleFired() {

            Assert.IsFalse(onSizeToggleFired);

            topPanel.ToggleSize(null, null);

            Assert.IsTrue(onSizeToggleFired);
        }

        [TestMethod]
        public void OnExitFired() {

            Assert.IsFalse(onExitFired);

            topPanel.ExitApplication(null, null);

            Assert.IsTrue(onExitFired);
        }
    }
}