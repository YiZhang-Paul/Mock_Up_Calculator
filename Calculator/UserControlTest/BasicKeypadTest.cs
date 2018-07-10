using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using UtilityClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class BasicKeypadTest {

        class TestBasicKeypad : BasicKeypad {

            public TestBasicKeypad(IHelper helper) : base(helper) {}

            public void TestButtonMouseEnter(object sender, EventArgs e) {

                ButtonMouseEnter(sender, e);
            }

            public void TestButtonMouseLeave(object sender, EventArgs e) {

                ButtonMouseLeave(sender, e);
            }

            public void TestButtonMouseClick(object sender, EventArgs e) {

                ButtonMouseClick(sender, e);
            }
        }

        int eventCounter = 0;

        Mock<IHelper> helper;
        TestBasicKeypad keypad;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            helper = new Mock<IHelper>();
            keypad = new TestBasicKeypad(helper.Object);
            keypad.OnButtonMouseEnter += CheckEventFiring;
            keypad.OnButtonMouseLeave += CheckEventFiring;
            keypad.OnButtonMouseClick += CheckEventFiring;
        }

        [TestMethod]
        public void TestEventFired() {

            eventCounter = 0;
            var button = new Button();

            keypad.TestButtonMouseLeave(button, null);

            Assert.AreEqual(1, eventCounter);

            keypad.TestButtonMouseEnter(button, null);
            keypad.TestButtonMouseClick(button, null);

            helper.Verify(x => x.RaiseButtonEvent(

                button, null, It.IsAny<EventHandler>(), It.IsAny<IButtonTracker>()

            ), Times.Exactly(2));
        }
    }
}