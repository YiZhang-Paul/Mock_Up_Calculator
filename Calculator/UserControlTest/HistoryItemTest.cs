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

        class TestHistoryItem : HistoryItem {

            public TestHistoryItem(

                string expression,
                decimal result,
                IFormatter expressionFormatter,
                IFormatter numberFormatter,
                IHelper helper

            ) : base(expression, result, expressionFormatter, numberFormatter, helper) {}

            public void TestPanelClick(object sender, EventArgs e) {

                PanelClick(sender, e);
            }

            public void TestPanelMouseEnter(object sender, EventArgs e) {

                PanelMouseEnter(sender, e);
            }

            public void TestPanelMouseLeave(object sender, EventArgs e) {

                PanelMouseLeave(sender, e);
            }
        }

        int eventCounter = 0;
        const string expression = "5 + 6 fact";
        const decimal result = 70025;

        Mock<IFormatter> expressionFormatter;
        Mock<IFormatter> numberFormatter;
        Mock<IHelper> helper;
        TestHistoryItem item;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventCounter++;
        }

        [TestInitialize]
        public void Setup() {

            eventCounter = 0;

            expressionFormatter = new Mock<IFormatter>();
            expressionFormatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5 + fact(6)");

            numberFormatter = new Mock<IFormatter>();
            numberFormatter.Setup(x => x.Format(It.IsAny<string>())).Returns("70,025");

            helper = new Mock<IHelper>();

            item = new TestHistoryItem(

                expression,
                result,
                expressionFormatter.Object,
                numberFormatter.Object,
                helper.Object
            );

            item.Parent = new Panel();
            item.OnSelect += CheckEventFiring;
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

            eventCounter = 0;

            item.TestPanelClick(null, null);

            Assert.AreEqual(1, eventCounter);
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