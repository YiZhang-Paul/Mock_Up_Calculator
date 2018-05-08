using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;

namespace UserControlTest {
    [TestClass]
    public class TopPanelTest {

        class TestTopPanel : TopPanel {

            public void TestGetPointerLocation(object sender, MouseEventArgs e) {

                GetPointerLocation(sender, e);
            }

            public void TestDrag(object sender, MouseEventArgs e) {

                Drag(sender, e);
            }

            public void TestMinimize(object sender, MouseEventArgs e) {

                Minimize(sender, e);
            }

            public void TestToggleSize(object sender, MouseEventArgs e) {

                ToggleSize(sender, e);
            }

            public void TestExitApplication(object sender, MouseEventArgs e) {

                ExitApplication(sender, e);
            }
        }

        int eventCounter = 0;

        TestTopPanel topPanel;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            topPanel = new TestTopPanel();
            topPanel.OnMouseHold += CheckEventFiring;
            topPanel.OnMouseDrag += CheckEventFiring;
            topPanel.OnMinimize += CheckEventFiring;
            topPanel.OnSizeToggle += CheckEventFiring;
            topPanel.OnExit += CheckEventFiring;
        }

        [TestMethod]
        public void TestEventFired() {

            eventCounter = 0;

            topPanel.TestGetPointerLocation(null, null);
            topPanel.TestDrag(null, null);
            topPanel.TestMinimize(null, null);
            topPanel.TestToggleSize(null, null);
            topPanel.TestExitApplication(null, null);

            Assert.AreEqual(5, eventCounter);
        }
    }
}