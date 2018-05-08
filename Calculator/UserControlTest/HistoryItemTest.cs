using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class HistoryItemTest {

        bool onSelectFired = false;

        const string expression = "5 + 6 fact";
        const decimal result = 70025;

        Mock<IFormatter> expressionFormatter;
        Mock<IFormatter> numberFormatter;
        Mock<IHelper> helper;
        HistoryItem item;

        private void CheckSelectFiring(object sender, EventArgs e) {

            onSelectFired = true;
        }

        [TestInitialize]
        public void Setup() {

            expressionFormatter = new Mock<IFormatter>();
            expressionFormatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5 + fact(6)");

            numberFormatter = new Mock<IFormatter>();
            numberFormatter.Setup(x => x.Format(It.IsAny<string>())).Returns("70,025");

            helper = new Mock<IHelper>();

            item = new HistoryItem(

                expression,
                result,
                expressionFormatter.Object,
                numberFormatter.Object,
                helper.Object
            );

            item.Parent = new Panel();
            item.OnSelect += CheckSelectFiring;
        }

        [TestMethod]
        public void DisplayExpression() {

            Assert.AreEqual(expression, item.RawExpression);
            Assert.AreEqual("5 + fact(6) =", item.FormattedExpression);
            Assert.AreEqual(result, item.RawResult);
            Assert.AreEqual("70,025", item.FormattedResult);
        }

        [TestMethod]
        public void OnSelectFired() {

            Assert.IsFalse(onSelectFired);

            item.PanelClick(null, null);

            Assert.IsTrue(onSelectFired);
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