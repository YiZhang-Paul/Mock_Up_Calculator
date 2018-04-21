using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityClassLibrary;
using System.Windows.Forms;

namespace UtilityTest {
    [TestClass]
    public class ButtonTrackerTest {

        ButtonTracker tracker;
        Button button1;
        Button button2;
        Button button3;

        [TestInitialize]
        public void Setup() {

            tracker = new ButtonTracker();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
        }

        [TestMethod]
        public void DisableKeys() {

            tracker.Disable(button1);
            tracker.Disable(button2);

            Assert.IsTrue(tracker.IsDisabled(button1));
            Assert.IsTrue(tracker.IsDisabled(button2));
            Assert.IsFalse(tracker.IsDisabled(button3));
        }

        [TestMethod]
        public void EnableKeys() {

            tracker.Enable(button1);
            tracker.Enable(button2);

            Assert.IsFalse(tracker.IsDisabled(button1));
            Assert.IsFalse(tracker.IsDisabled(button2));
            Assert.IsFalse(tracker.IsDisabled(button3));
        }
    }
}