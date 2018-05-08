using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using UtilityClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class ScientificKeypadTest {

        class TestScientificKeypad : ScientificKeypad {

            public TestScientificKeypad(

                IHelper helper,
                IButtonTracker tracker

            ) : base(helper, tracker) {}

            public void TestButtonMouseEnter(object sender, EventArgs e) {

                ButtonMouseEnter(sender, e);
            }

            public void TestButtonMouseLeave(object sender, EventArgs e) {

                ButtonMouseLeave(sender, e);
            }

            public void TestButtonMouseClick(object sender, EventArgs e) {

                ButtonMouseClick(sender, e);
            }

            public void TestToggleExtension(object sender, EventArgs e) {

                ToggleExtension(sender, e);
            }

            public void TestToggleHypotenuse(object sender, EventArgs e) {

                ToggleHypotenuse(sender, e);
            }

            public void TestToggleEngineeringFormat(object sender, EventArgs e) {

                ToggleEngineeringFormat(sender, e);
            }

            public void TestToggleAngularUnit(object sender, EventArgs e) {

                ToggleAngularUnit(sender, e);
            }

            public void TestResizeUnitKeyText(object sender, EventArgs e) {

                ResizeUnitKeyText(sender, e);
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
        Mock<IButtonTracker> tracker;
        TestScientificKeypad keypad;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            helper = new Mock<IHelper>();
            tracker = new Mock<IButtonTracker>();

            keypad = new TestScientificKeypad(helper.Object, tracker.Object);
            keypad.OnButtonMouseEnter += CheckEventFiring;
            keypad.OnButtonMouseLeave += CheckEventFiring;
            keypad.OnButtonMouseClick += CheckEventFiring;
            keypad.OnAngularUnitToggle += CheckEventFiring;
            keypad.OnEngineeringModeToggle += CheckEventFiring;
            keypad.OnMemoryStore += CheckEventFiring;
            keypad.OnMemoryAdd += CheckEventFiring;
            keypad.OnMemorySubtract += CheckEventFiring;
            keypad.OnMemoryClear += CheckEventFiring;
            keypad.OnMemoryRecall += CheckEventFiring;
            keypad.OnMemoryToggle += CheckEventFiring;
        }

        [TestMethod]
        public void LeaveMemoryKeyOn() {

            keypad.LeaveMemoryKeyOn();

            helper.Verify(x => x.EnableKeys(It.IsAny<Button[]>(), tracker.Object), Times.Once);
        }

        [TestMethod]
        public void ToggleExtensionKeyDisabled() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(true);
            var button = new Button();

            Assert.IsFalse(keypad.ExtensionToggled);

            keypad.TestToggleExtension(button, null);

            Assert.IsFalse(keypad.ExtensionToggled);
        }

        [TestMethod]
        public void ToggleExtension() {

            var button = new Button();

            Assert.IsFalse(keypad.ExtensionToggled);

            keypad.TestToggleExtension(button, null);

            Assert.IsTrue(keypad.ExtensionToggled);

            keypad.TestToggleExtension(button, null);

            Assert.IsFalse(keypad.ExtensionToggled);
        }

        [TestMethod]
        public void ToggleHypotenuseKeyDisabled() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(true);
            var button = new Button();

            Assert.IsFalse(keypad.TrigonometricToggled);

            keypad.TestToggleHypotenuse(button, null);

            Assert.IsFalse(keypad.TrigonometricToggled);
        }

        [TestMethod]
        public void ToggleHypotenuse() {

            var button = new Button();

            Assert.IsFalse(keypad.TrigonometricToggled);

            keypad.TestToggleHypotenuse(button, null);

            Assert.IsTrue(keypad.TrigonometricToggled);

            keypad.TestToggleHypotenuse(button, null);

            Assert.IsFalse(keypad.TrigonometricToggled);
        }

        [TestMethod]
        public void ToggleEngineeringFormatKeyDisabled() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(true);
            var button = new Button();

            Assert.IsFalse(keypad.EngineeringMode);

            keypad.TestToggleEngineeringFormat(button, null);

            Assert.IsFalse(keypad.EngineeringMode);
        }

        [TestMethod]
        public void ToggleEngineeringFormat() {

            var button = new Button();

            Assert.IsFalse(keypad.EngineeringMode);

            keypad.TestToggleEngineeringFormat(button, null);

            Assert.IsTrue(keypad.EngineeringMode);

            keypad.TestToggleEngineeringFormat(button, null);

            Assert.IsFalse(keypad.EngineeringMode);
        }

        [TestMethod]
        public void ToggleAngularUnitKeyDisabled() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(true);
            var button = new Button();

            Assert.AreEqual(0, keypad.AngularUnit);

            keypad.TestToggleAngularUnit(button, null);

            Assert.AreEqual(0, keypad.AngularUnit);
        }

        [TestMethod]
        public void ToggleAngularUnit() {

            var button = new Button();

            Assert.AreEqual(0, keypad.AngularUnit);

            keypad.TestToggleAngularUnit(button, null);

            Assert.AreEqual(1, keypad.AngularUnit);

            keypad.TestToggleAngularUnit(button, null);

            Assert.AreEqual(2, keypad.AngularUnit);

            keypad.TestToggleAngularUnit(button, null);

            Assert.AreEqual(0, keypad.AngularUnit);
        }

        [TestMethod]
        public void UnitKeyTextSizeDoesNotChange() {

            Assert.AreEqual(0, keypad.AngularUnit);

            var button = new Button();
            keypad.TestResizeUnitKeyText(button, null);
            float size = button.Font.Size;

            keypad.TestToggleAngularUnit(button, null);
            keypad.TestResizeUnitKeyText(button, null);

            Assert.AreEqual(1, keypad.AngularUnit);
            Assert.IsTrue(button.Font.Size - size < 0.01);

            keypad.TestToggleAngularUnit(button, null);
            button.Text = string.Empty;
            keypad.TestResizeUnitKeyText(button, null);

            Assert.AreEqual(2, keypad.AngularUnit);
            Assert.IsTrue(button.Font.Size - size < 0.01);

            keypad.TestToggleAngularUnit(button, null);
            keypad.TestResizeUnitKeyText(button, null);

            Assert.AreEqual(0, keypad.AngularUnit);
            Assert.IsTrue(button.Font.Size - size < 0.01);
        }

        [TestMethod]
        public void UnitKeyTextSizeChanges() {

            Assert.AreEqual(0, keypad.AngularUnit);

            var button = new Button();
            keypad.TestResizeUnitKeyText(button, null);
            float size = button.Font.Size;

            keypad.TestToggleAngularUnit(button, null);
            keypad.TestToggleAngularUnit(button, null);
            button.Text = "".PadLeft(50, '#');
            keypad.TestResizeUnitKeyText(button, null);

            Assert.AreEqual(2, keypad.AngularUnit);
            Assert.IsTrue(button.Font.Size < size);
        }

        [TestMethod]
        public void TestEventFired() {

            eventCounter = 0;
            var button = new Button();

            keypad.TestButtonMouseClick(button, null);
            keypad.TestButtonMouseLeave(button, null);
            keypad.TestToggleEngineeringFormat(button, null);
            keypad.TestToggleAngularUnit(button, null);
            keypad.TestMemoryStoreClick(button, null);
            keypad.TestMemoryAddClick(button, null);
            keypad.TestMemorySubtractClick(button, null);
            keypad.TestMemoryClearClick(button, null);
            keypad.TestMemoryRecallClick(button, null);
            keypad.TestMemoryToggleClick(button, null);

            Assert.AreEqual(9, eventCounter);

            keypad.TestButtonMouseEnter(button, null);

            helper.Verify(x => x.RaiseButtonEvent(

                button, null, It.IsAny<EventHandler>(), It.IsAny<IButtonTracker>()

            ), Times.Exactly(2));
        }
    }
}