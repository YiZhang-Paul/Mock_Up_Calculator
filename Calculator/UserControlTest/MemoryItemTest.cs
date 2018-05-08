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

        bool onSelectFired = false;
        bool onDeleteFired = false;
        bool onPlusFired = false;
        bool onMinusFired = false;

        Mock<IFormatter> formatter;
        Mock<IHelper> helper;
        Button button;
        MemoryItem item;

        private void CheckSelectFiring(object sender, EventArgs e) {

            onSelectFired = true;
        }

        private void CheckDeleteFiring(object sender, EventArgs e) {

            onDeleteFired = true;
        }

        private void CheckPlusFiring(object sender, EventArgs e) {

            onPlusFired = true;
        }

        private void CheckMinusFiring(object sender, EventArgs e) {

            onMinusFired = true;
        }

        [TestInitialize]
        public void Setup() {

            formatter = new Mock<IFormatter>();
            formatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5,999,999");

            helper = new Mock<IHelper>();
            button = new Button();

            item = new MemoryItem(1, 5999999, formatter.Object, helper.Object);
            item.Parent = new Panel();
            item.OnSelect += CheckSelectFiring;
            item.OnDelete += CheckDeleteFiring;
            item.OnPlus += CheckPlusFiring;
            item.OnMinus += CheckMinusFiring;
        }

        [TestMethod]
        public void DisplayValue() {

            Assert.AreEqual(1, item.Key);
            Assert.AreEqual(5999999, item.RawValue);
            Assert.AreEqual("5,999,999", item.FormattedValue);
        }

        [TestMethod]
        public void OnSelectFired() {

            Assert.IsFalse(onSelectFired);

            item.PanelClick(null, null);

            Assert.IsTrue(onSelectFired);
        }

        [TestMethod]
        public void OnDeleteFired() {

            Assert.IsFalse(onDeleteFired);

            item.ItemDelete(null, null);

            Assert.IsTrue(onDeleteFired);
        }

        [TestMethod]
        public void OnPlusFired() {

            Assert.IsFalse(onPlusFired);

            item.ItemPlus(null, null);

            Assert.IsTrue(onPlusFired);
        }

        [TestMethod]
        public void OnMinusFired() {

            Assert.IsFalse(onMinusFired);

            item.ItemMinus(null, null);

            Assert.IsTrue(onMinusFired);
        }

        [TestMethod]
        public void ButtonMouseEnter() {

            button.FlatAppearance.BorderColor = Color.BlanchedAlmond;

            item.ButtonMouseEnter(button, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, button.FlatAppearance.BorderColor);
        }

        [TestMethod]
        public void ButtonMouseLeave() {

            item.ButtonMouseLeave(button, null);

            helper.Verify(x => x.ButtonMouseLeave(button, null), Times.Once);
        }

        [TestMethod]
        public void MouseEnterWhenVisible() {

            item.Visible = true;
            item.BackColor = Color.BlanchedAlmond;

            item.PanelMouseEnter(null, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseEnterWhenInvisible() {

            item.Visible = false;
            item.BackColor = Color.BlanchedAlmond;

            item.PanelMouseEnter(null, null);

            Assert.AreEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseLeaveWhenVisibleAndMouseNotOver() {

            helper.Setup(x => x.ContainsPointer(It.IsAny<Control>(), It.IsAny<Point>()))
                  .Returns(false);

            item.Visible = true;
            item.BackColor = Color.BlanchedAlmond;

            item.PanelMouseLeave(null, null);

            Assert.AreNotEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseLeaveWhenInvisible() {

            item.Visible = false;
            item.BackColor = Color.BlanchedAlmond;

            item.PanelMouseLeave(null, null);

            Assert.AreEqual(Color.BlanchedAlmond, item.BackColor);
        }

        [TestMethod]
        public void MouseLeaveWhenMouseOver() {

            helper.Setup(x => x.ContainsPointer(It.IsAny<Control>(), It.IsAny<Point>()))
                  .Returns(true);

            item.Visible = true;
            item.BackColor = Color.BlanchedAlmond;

            item.PanelMouseLeave(null, null);

            Assert.AreEqual(Color.BlanchedAlmond, item.BackColor);
        }
    }
}