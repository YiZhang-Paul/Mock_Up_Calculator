using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class StandardDisplayTest {

        Mock<IFormatter> expressionFormatter;
        Mock<IFormatter> numberFormatter;
        StandardDisplay standardDisplay;

        [TestInitialize]
        public void Setup() {

            expressionFormatter = new Mock<IFormatter>();
            expressionFormatter.Setup(x => x.Format(It.IsAny<string>())).Returns("log(15) + 6");

            numberFormatter = new Mock<IFormatter>();
            numberFormatter.Setup(x => x.Format(It.IsAny<string>())).Returns("55,055,055.9");

            standardDisplay = new StandardDisplay();
            standardDisplay.Parent = new Panel();
        }

        [TestMethod]
        public void ResizeLabelWhenParentIsTooSmall() {

            standardDisplay.Height = 1;
            standardDisplay.DisplayResult("55055055.9", numberFormatter.Object);
        }

        [TestMethod]
        public void DisplayExpression() {

            standardDisplay.DisplayExpression("15 log + 6", expressionFormatter.Object);

            Assert.AreEqual("log(15) + 6", standardDisplay.Expression);
        }

        [TestMethod]
        public void DisplayResult() {

            standardDisplay.DisplayResult("55055055.9", numberFormatter.Object);

            Assert.AreEqual(55055055.9m, standardDisplay.RecentValue);
            Assert.AreEqual("55,055,055.9", standardDisplay.Input);
        }

        [TestMethod]
        public void Clear() {

            standardDisplay.DisplayExpression("15 log + 6", expressionFormatter.Object);
            standardDisplay.DisplayResult("55055055.9", numberFormatter.Object);
            Assert.AreEqual("log(15) + 6", standardDisplay.Expression);
            Assert.AreEqual("55,055,055.9", standardDisplay.Input);
            Assert.AreEqual(55055055.9m, standardDisplay.RecentValue);

            standardDisplay.Clear();

            Assert.AreEqual(string.Empty, standardDisplay.Expression);
            Assert.AreEqual(string.Empty, standardDisplay.Input);
            Assert.AreEqual(55055055.9m, standardDisplay.RecentValue);
        }

        [TestMethod]
        public void DisplayError() {

            standardDisplay.DisplayError("Divide By Zero.");

            Assert.AreEqual("Divide By Zero.", standardDisplay.Input);
        }

        [TestMethod]
        public void RefreshDisplay() {

            standardDisplay.DisplayResult("55055055.9", numberFormatter.Object);

            Assert.AreEqual("55,055,055.9", standardDisplay.Input);
            Assert.AreEqual(55055055.9m, standardDisplay.RecentValue);

            standardDisplay.DisplayError("Divide By Zero.");

            Assert.AreEqual("Divide By Zero.", standardDisplay.Input);
            Assert.AreEqual(55055055.9m, standardDisplay.RecentValue);

            standardDisplay.RefreshDisplay(numberFormatter.Object);
            Assert.AreEqual("55,055,055.9", standardDisplay.Input);
            Assert.AreEqual(55055055.9m, standardDisplay.RecentValue);
        }

        [TestMethod]
        public void ExpressionMouseHover() {

            standardDisplay.ExpressionMouseHover(new Label(), null);
            standardDisplay.ScrollPanelMouseHover(new Panel(), null);
        }

        [TestMethod]
        public void UnableToScroll() {

            standardDisplay.Width = 150;
            standardDisplay.ScrollPanel.Width = 1;
            int left = standardDisplay.ScrollPanel.Left;
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            standardDisplay.ScrollExpression(null, mouseEvent);

            Assert.AreEqual(left, standardDisplay.ScrollPanel.Left);
        }

        [TestMethod]
        public void ScrollLeft() {

            const int left = -200;
            standardDisplay.Width = 150;
            standardDisplay.ScrollPanel.Width = 200;
            standardDisplay.ScrollPanel.Left = left;
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 120);

            standardDisplay.ScrollExpression(null, mouseEvent);

            Assert.IsTrue(left < standardDisplay.ScrollPanel.Left);
        }

        [TestMethod]
        public void ScrollRight() {

            const int left = 200;
            standardDisplay.Width = 150;
            standardDisplay.ScrollPanel.Width = 200;
            standardDisplay.ScrollPanel.Left = left;
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, -120);

            standardDisplay.ScrollExpression(null, mouseEvent);

            Assert.IsTrue(left > standardDisplay.ScrollPanel.Left);
        }
    }
}