using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using UtilityClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class KeypadTest {

        class TestKeypad : Keypad {

            public Point TestClientCenter { get { return ClientCenter; } }
            public HashSet<Button> TestBasicKeys { get { return BasicKeys; } }

            public TestKeypad(

                IButtonTracker tracker,
                IHelper helper,
                bool disabled

            ) : base(tracker, helper, disabled) {

                BasicKeys = new HashSet<Button>();
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

            public void TestShowKeys(object sender, EventArgs e) {

                ShowKeys(sender, e);
            }

            public void TestLoadKeypad(object sender, EventArgs e) {

                LoadKeypad(sender, e);
            }
        }

        int eventCounter = 0;

        Mock<IHelper> helper;
        Mock<IButtonTracker> tracker;
        TestKeypad keypad;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            helper = new Mock<IHelper>();
            tracker = new Mock<IButtonTracker>();
            keypad = new TestKeypad(tracker.Object, helper.Object, false);
            keypad.OnMemoryStore += CheckEventFiring;
            keypad.OnMemoryAdd += CheckEventFiring;
            keypad.OnMemorySubtract += CheckEventFiring;
            keypad.OnMemoryClear += CheckEventFiring;
            keypad.OnMemoryRecall += CheckEventFiring;
            keypad.OnMemoryToggle += CheckEventFiring;
        }

        [TestMethod]
        public void EnableValidKeysWhenMemoryIsEmpty() {

            keypad.HasMemory = false;

            keypad.EnableValidKeys();

            Assert.IsFalse(keypad.IsDisabled);
            helper.Verify(x => x.EnableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Once);
            helper.Verify(x => x.DisableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Once);
        }

        [TestMethod]
        public void EnableValidKeysWhenMemoryIsNotEmpty() {

            keypad.HasMemory = true;

            keypad.EnableValidKeys();

            Assert.IsFalse(keypad.IsDisabled);
            helper.Verify(x => x.EnableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Once);
            helper.Verify(x => x.DisableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Never);
        }

        [TestMethod]
        public void EnableAllKeys() {

            keypad.EnableAllKeys();

            helper.Verify(x => x.EnableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Once);
        }

        [TestMethod]
        public void DisableAllKeys() {

            keypad.DisableAllKeys();

            helper.Verify(x => x.DisableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Once);
        }

        [TestMethod]
        public void LeaveBasicKeysOn() {

            Assert.IsFalse(keypad.IsDisabled);

            keypad.LeaveBasicKeysOn();

            Assert.IsTrue(keypad.IsDisabled);

            helper.Verify(x => x.EnableKeys(

                It.IsAny<IEnumerable<Button>>(), tracker.Object

            ), Times.Once);

            helper.Verify(x => x.DisableKeys(

                It.IsAny<IEnumerable<Button>>(), tracker.Object

            ), Times.Once);
        }

        [TestMethod]
        public void ShowKeys() {

            keypad.TestLoadKeypad(null, null);

            Assert.AreNotEqual(DockStyle.Fill, keypad.Dock);

            keypad.Width = keypad.TestClientCenter.X / 2;
            keypad.Height = keypad.TestClientCenter.Y / 2;

            keypad.TestShowKeys(null, null);

            Assert.AreNotEqual(DockStyle.Fill, keypad.Dock);

            keypad.Width = keypad.TestClientCenter.X * 2;
            keypad.Height = keypad.TestClientCenter.Y * 2;

            keypad.TestShowKeys(null, null);

            Assert.AreEqual(DockStyle.Fill, keypad.Dock);
        }

        [TestMethod]
        public void LoadKeypad() {

            var width = keypad.Width;
            var height = keypad.Height;

            keypad.TestLoadKeypad(null, null);

            Assert.AreEqual(keypad.Anchor, AnchorStyles.None);
            Assert.IsTrue(Math.Abs(width * 0.95 - keypad.Width) <= 1);
            Assert.IsTrue(Math.Abs(height * 0.95 - keypad.Height) <= 1);
        }

        [TestMethod]
        public void ButtonMouseClickWhenKeypadIsDisabled() {

            eventCounter = 0;
            var button = new Button();
            keypad = new TestKeypad(tracker.Object, helper.Object, true);
            keypad.OnKeypadEnable += CheckEventFiring;
            keypad.TestBasicKeys.Add(button);

            keypad.TestButtonMouseClick(button, null);

            Assert.AreEqual(1, eventCounter);
            Assert.IsFalse(keypad.IsDisabled);

            helper.Verify(x => x.EnableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Once);

            helper.Verify(x => x.RaiseButtonEvent(

                button, null, It.IsAny<EventHandler>(), tracker.Object

            ), Times.Never);
        }

        [TestMethod]
        public void ButtonMouseClickWhenKeypadIsEnabled() {

            eventCounter = 0;
            var button = new Button();

            keypad.TestButtonMouseClick(button, null);

            Assert.AreEqual(0, eventCounter);
            helper.Verify(x => x.RaiseButtonEvent(

                button, null, It.IsAny<EventHandler>(), tracker.Object

            ), Times.Once);
        }

        [TestMethod]
        public void TestEventFiredWhenKeysDisabled() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(true);

            eventCounter = 0;
            var button = new Button();

            keypad.TestMemoryStoreClick(button, null);
            keypad.TestMemoryAddClick(button, null);
            keypad.TestMemorySubtractClick(button, null);
            keypad.TestMemoryClearClick(button, null);
            keypad.TestMemoryRecallClick(button, null);
            keypad.TestMemoryToggleClick(button, null);

            Assert.AreEqual(0, eventCounter);
        }

        [TestMethod]
        public void TestEventFiredWhenKeysEnabled() {

            eventCounter = 0;
            var button = new Button();

            keypad.TestMemoryStoreClick(button, null);
            keypad.TestMemoryAddClick(button, null);
            keypad.TestMemorySubtractClick(button, null);
            keypad.TestMemoryClearClick(button, null);
            keypad.TestMemoryRecallClick(button, null);
            keypad.TestMemoryToggleClick(button, null);

            Assert.AreEqual(6, eventCounter);
        }
    }
}