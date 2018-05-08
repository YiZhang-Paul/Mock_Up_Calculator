using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class MemoryItemTest {

        class TestMemoryItemEvents : MemoryItem {

            public TestMemoryItemEvents(

                int key,
                decimal value,
                IFormatter formatter,
                IHelper helper

            ) : base(key, value, formatter, helper) {}

            public void TestPanelClick(object sender, EventArgs e) {

                PanelClick(sender, e);
            }

            public void TestItemDelete(object sender, EventArgs e) {

                ItemDelete(sender, e);
            }

            public void TestItemPlus(object sender, EventArgs e) {

                ItemPlus(sender, e);
            }

            public void TestItemMinus(object sender, EventArgs e) {

                ItemMinus(sender, e);
            }

            public void TestButtonMouseEnter(object sender, EventArgs e) {

                ButtonMouseEnter(sender, e);
            }

            public void TestButtonMouseLeave(object sender, EventArgs e) {

                ButtonMouseLeave(sender, e);
            }

            public void TestPanelMouseEnter(object sender, EventArgs e) {

                PanelMouseEnter(sender, e);
            }

            public void TestPanelMouseLeave(object sender, EventArgs e) {

                PanelMouseLeave(sender, e);
            }
        }

        int eventCounter = 0;

        Mock<IFormatter> formatter;
        Mock<IHelper> helper;
        Button button;
        TestMemoryItemEvents item;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            formatter = new Mock<IFormatter>();
            formatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5,999,999");

            helper = new Mock<IHelper>();
            button = new Button();

            item = new TestMemoryItemEvents(1, 5999999, formatter.Object, helper.Object);
            item.Parent = new Panel();
            item.OnSelect += CheckEventFiring;
            item.OnDelete += CheckEventFiring;
            item.OnPlus += CheckEventFiring;
            item.OnMinus += CheckEventFiring;
        }

        [TestMethod]
        public void DisplayValue() {

            Assert.AreEqual(1, item.Key);
            Assert.AreEqual(5999999, item.RawValue);
            Assert.AreEqual("5,999,999", item.FormattedValue);
        }

        [TestMethod]
        public void TestEventFired() {

            eventCounter = 0;

            item.TestItemDelete(null, null);
            item.TestPanelClick(null, null);
            item.TestItemPlus(null, null);
            item.TestItemMinus(null, null);

            Assert.AreEqual(4, eventCounter);
        }

        [TestMethod]
        public void ButtonMouseEnter() {

            button.FlatAppearance.BorderColor = Color.BlanchedAlmond;

            item.TestButtonMouseEnter(button, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, button.FlatAppearance.BorderColor);
        }

        [TestMethod]
        public void ButtonMouseLeave() {

            item.TestButtonMouseLeave(button, null);

            helper.Verify(x => x.ButtonMouseLeave(button, null), Times.Once);
        }

        [TestMethod]
        public void MouseEnterWhenVisible() {

            item.Visible = true;
            item.BackColor = Color.BlanchedAlmond;

            item.TestPanelMouseEnter(null, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseEnterWhenInvisible() {

            item.Visible = false;
            item.BackColor = Color.BlanchedAlmond;

            item.TestPanelMouseEnter(null, null);

            Assert.AreEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseLeaveWhenVisibleAndMouseNotOver() {

            helper.Setup(x => x.ContainsPointer(It.IsAny<Control>(), It.IsAny<Point>()))
                  .Returns(false);

            item.Visible = true;
            item.BackColor = Color.BlanchedAlmond;

            item.TestPanelMouseLeave(null, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseLeaveWhenInvisible() {

            item.Visible = false;
            item.BackColor = Color.BlanchedAlmond;

            item.TestPanelMouseLeave(null, null);

            Assert.AreEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseLeaveWhenMouseOver() {

            helper.Setup(x => x.ContainsPointer(It.IsAny<Control>(), It.IsAny<Point>()))
                  .Returns(true);

            item.Visible = true;
            item.BackColor = Color.BlanchedAlmond;

            item.TestPanelMouseLeave(null, null);

            Assert.AreEqual(Color.BlanchedAlmond, item.BackColor);
        }
    }
}