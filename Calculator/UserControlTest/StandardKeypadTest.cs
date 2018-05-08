using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using UtilityClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class StandardKeypadTest {

        class TestStandardKeypad : StandardKeypad {

            public TestStandardKeypad(IHelper helper) : base(helper) {}

            public void TestButtonMouseEnter(object sender, EventArgs e) {

                ButtonMouseEnter(sender, e);
            }

            public void TestButtonMouseLeave(object sender, EventArgs e) {

                ButtonMouseLeave(sender, e);
            }

            public void TestButtonMouseClick(object sender, EventArgs e) {

                ButtonMouseClick(sender, e);
            }

            public void TestMemoryStoreClick(object sender, EventArgs e) {

                MemoryStoreClick(sender, e);
            }

            public void TestMemoryAddClick(object sender, EventArgs e) {

                MemoryAddClick(sender, e);
            }

            public void TestMemorySubtractClick(object sender, EventArgs e) {

                MemorySubtractClick(sender, e);
            }

            public void TestMemoryClearClick(object sender, EventArgs e) {

                MemoryClearClick(sender, e);
            }

            public void TestMemoryRecallClick(object sender, EventArgs e) {

                MemoryRecallClick(sender, e);
            }

            public void TestMemoryToggleClick(object sender, EventArgs e) {

                MemoryToggleClick(sender, e);
            }
        }

        int eventCounter = 0;

        Mock<IHelper> helper;
        TestStandardKeypad keypad;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            helper = new Mock<IHelper>();
            keypad = new TestStandardKeypad(helper.Object);
            keypad.OnButtonMouseEnter += CheckEventFiring;
            keypad.OnButtonMouseLeave += CheckEventFiring;
            keypad.OnButtonMouseClick += CheckEventFiring;
            keypad.OnMemoryStore += CheckEventFiring;
            keypad.OnMemoryAdd += CheckEventFiring;
            keypad.OnMemorySubtract += CheckEventFiring;
            keypad.OnMemoryClear += CheckEventFiring;
            keypad.OnMemoryRecall += CheckEventFiring;
            keypad.OnMemoryToggle += CheckEventFiring;
        }

        [TestMethod]
        public void MainAreaHeight() {

            Assert.IsTrue(keypad.MainAreaHeight > 0);
            Assert.IsTrue(keypad.MainAreaHeight < keypad.Height);
        }

        [TestMethod]
        public void LeaveMemoryKeyOn() {

            keypad.LeaveMemoryKeyOn();

            helper.Verify(x => x.EnableKeys(

                It.IsAny<Button[]>(), It.IsAny<IButtonTracker>()

            ), Times.Once);
        }

        [TestMethod]
        public void TestEventFired() {

            eventCounter = 0;
            var button = new Button();

            keypad.TestButtonMouseLeave(button, null);
            keypad.TestMemoryStoreClick(button, null);
            keypad.TestMemoryAddClick(button, null);
            keypad.TestMemorySubtractClick(button, null);
            keypad.TestMemoryClearClick(button, null);
            keypad.TestMemoryRecallClick(button, null);
            keypad.TestMemoryToggleClick(button, null);

            Assert.AreEqual(7, eventCounter);

            keypad.TestButtonMouseEnter(button, null);
            keypad.TestButtonMouseClick(button, null);

            helper.Verify(x => x.RaiseButtonEvent(

                button, null, It.IsAny<EventHandler>(), It.IsAny<IButtonTracker>()

            ), Times.Exactly(2));
        }
    }
}