using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockUpCalculator;
using UserControlClassLibrary;
using Moq;

namespace MockUpCalculatorIntegrationTest {
    [TestClass]
    public class MainFormlIntegrationTest {

        class TestMainForm : MainForm {

            public Rectangle TestViewport { get { return Viewport; } }
            public ICalculatorPanel TestCalculatorPanel { get { return CalculatorPanel; } }
            public TableLayoutPanel TestMainLayout { get { return MainLayout; } }

            public void SetHelper(IHelper helper) {

                Helper = helper;
            }

            public void SetCalculatorPanel(ICalculatorPanel panel) {

                CalculatorPanel = panel;
            }

            public void SetSidePanel(ISidePanel panel) {

                SidePanel = panel;
            }

            public void TestToStandardCalculator() {

                ToStandardCalculator();
            }

            public void TestToScientificCalculatorPanel() {

                ToScientificCalculatorPanel();
            }

            public void TestToggleHistoryPanel(object sender, MouseEventArgs e) {

                ToggleHistoryPanel(sender, e);
            }

            public void TestSavePointerLocation(object sender, MouseEventArgs e) {

                SavePointerLocation(sender, e);
            }

            public void TestChangeMenuClick(object sender, MouseEventArgs e) {

                ChangeMenuClick(sender, e);
            }

            public void TestShowSidePanel(object sender, MouseEventArgs e) {

                ShowSidePanel(sender, e);
            }

            public void TestHideSidePanel(object sender, MouseEventArgs e) {

                HideSidePanel(sender, e);
            }

            public void TestDeactivateBackPanel(object sender, MouseEventArgs e) {

                DeactivateBackPanel(sender, e);
            }

            public void TestKeypadButtonMouseEnter(object sender, EventArgs e) {

                KeypadButtonMouseEnter(sender, e);
            }

            public void TestKeypadButtonMouseLeave(object sender, EventArgs e) {

                KeypadButtonMouseLeave(sender, e);
            }

            public void TestSelectCalculator(object sender, EventArgs e) {

                SelectCalculator(sender, e);
            }

            public void TestFormResizeBegin(object sender, EventArgs e) {

                FormResizeBegin(sender, e);
            }

            public void TestFormResizeEnd(object sender, EventArgs e) {

                FormResizeEnd(sender, e);
            }

            public void TestDragWindow(object sender, MouseEventArgs e) {

                DragWindow(sender, e);
            }

            public void TestMinimize(object sender, EventArgs e) {

                Minimize(sender, e);
            }

            public void TestZoomToMax(object sender, EventArgs e) {

                ZoomToMax(sender, e);
            }

            public void TestToggleWindowSize(object sender, EventArgs e) {

                ToggleWindowSize(sender, e);
            }

            public void TestFinishLoadUI(object sender, EventArgs e) {

                FinishLoadUI(sender, e);
            }

            public void TestZoomUI(object sender, EventArgs e) {

                ZoomUI(sender, e);
            }

            public void TestLoadUI(object sender, EventArgs e) {

                LoadUI(sender, e);
            }

            public void TestCloseUI(object sender, EventArgs e) {

                CloseUI(sender, e);
            }

            public void TestExit(object sender, EventArgs e) {

                Exit(sender, e);
            }

            public void TestResizeWindow(ref Message message, Point cursor) {

                ResizeWindow(ref message, cursor);
            }

            public void TestWndProc(ref Message message) {

                WndProc(ref message);
            }
        }

        Mock<IHelper> helper;
        Mock<ISidePanel> sidePanel;
        Mock<ICalculatorPanel> calculatorPanel;
        TestMainForm form;

        [TestInitialize]
        public void Setup() {

            helper = new Mock<IHelper>();
            sidePanel = new Mock<ISidePanel>();
            calculatorPanel = new Mock<ICalculatorPanel>();
            form = new TestMainForm();
        }

        [TestCleanup]
        public void Cleanup() {

            form.Dispose();
        }

        [TestMethod]
        public void GetViewport() {

            form.SetHelper(helper.Object);
            var viewport = form.TestViewport;

            helper.Verify(x => x.GetViewport(form), Times.Once);
        }

        [TestMethod]
        public void ToggleHistoryPanel() {

            form.SetCalculatorPanel(calculatorPanel.Object);
            form.TestToggleHistoryPanel(null, null);

            calculatorPanel.Verify(x => x.ToggleHistoryPanel(null, null), Times.Once);
        }

        [TestMethod]
        public void SavePointerLocation() {

            form.SetHelper(helper.Object);
            form.TestSavePointerLocation(null, null);

            helper.Verify(x => x.GetPointerLocation(null), Times.Once);
        }

        [TestMethod]
        public void ChangeMenuClick() {

            form.SetSidePanel(sidePanel.Object);
            form.TestChangeMenuClick(null, null);

            sidePanel.Verify(x => x.Extend(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void ToggleSidePanel() {

            form.SetSidePanel(sidePanel.Object);
            form.TestShowSidePanel(null, null);
            form.TestHideSidePanel(null, null);

            sidePanel.Verify(x => x.ShowMenu(

                It.IsAny<List<string[]>>(), It.IsAny<string>()

            ), Times.Once);
        }

        [TestMethod]
        public void DeactivateBackPanel() {

            form.SetCalculatorPanel(calculatorPanel.Object);
            form.TestDeactivateBackPanel(null, null);

            calculatorPanel.Verify(x => x.DeactivateBackPanel(), Times.Once);
        }

        [TestMethod]
        public void DragWindowWhileMaximized() {

            form.WindowState = FormWindowState.Maximized;
            form.TestDragWindow(null, null);

            helper.Verify(x => x.DragWindow(null, form, It.IsAny<Point>()), Times.Never);
        }

        [TestMethod]
        public void DragWindowWhileNotMaximized() {

            form.SetHelper(helper.Object);
            form.TestDragWindow(null, null);

            helper.Verify(x => x.DragWindow(null, form, It.IsAny<Point>()), Times.Once);
        }

        [TestMethod]
        public void Minimize() {

            form.WindowState = FormWindowState.Maximized;

            Assert.AreEqual(FormWindowState.Maximized, form.WindowState);

            form.TestMinimize(null, null);

            Assert.AreEqual(FormWindowState.Minimized, form.WindowState);
        }

        [TestMethod]
        public void ToggleWindowSizeToNormal() {

            form.SetHelper(helper.Object);
            form.SetCalculatorPanel(calculatorPanel.Object);
            form.SetSidePanel(sidePanel.Object);
            form.WindowState = FormWindowState.Maximized;

            Assert.AreEqual(FormWindowState.Maximized, form.WindowState);

            form.TestToggleWindowSize(null, null);

            Assert.AreEqual(FormWindowState.Normal, form.WindowState);
            helper.Verify(x => x.ScaleTo(form, It.IsAny<int>(), It.IsAny<int>(), false), Times.Once);
            helper.Verify(x => x.CenterToPoint(form, It.IsAny<Point>()), Times.Once);
            calculatorPanel.Verify(x => x.AdjustSize(), Times.Once);
            sidePanel.Verify(x => x.AdjustSize(), Times.Once);
        }

        [TestMethod]
        public void ToggleWindowSizeToMaximize() {

            form.SetHelper(helper.Object);
            form.WindowState = FormWindowState.Normal;

            Assert.AreEqual(FormWindowState.Normal, form.WindowState);

            form.TestToggleWindowSize(null, null);

            helper.Verify(x => x.ScaleTo(form, It.IsAny<int>(), It.IsAny<int>(), true), Times.Once);
        }

        [TestMethod]
        public void ZoomToMax() {

            form.SetHelper(helper.Object);
            form.SetCalculatorPanel(calculatorPanel.Object);
            form.SetSidePanel(sidePanel.Object);
            form.WindowState = FormWindowState.Normal;
            form.Width = 400;
            form.Height = 400;
            helper.Setup(x => x.GetViewport(It.IsAny<Form>()))
                  .Returns(new Rectangle(0, 0, 421, 421));

            Assert.AreEqual(FormWindowState.Normal, form.WindowState);

            form.Width = 420;
            form.Height = 420;
            form.TestZoomToMax(null, null);

            Assert.AreEqual(FormWindowState.Normal, form.WindowState);
            helper.Verify(x => x.ScaleTo(form, It.IsAny<int>(), It.IsAny<int>(), true), Times.Once);
            calculatorPanel.Verify(x => x.AdjustSize(), Times.Once);
            sidePanel.Verify(x => x.AdjustSize(), Times.Once);

            form.Width = 440;
            form.Height = 440;
            form.TestZoomToMax(null, null);

            Assert.AreEqual(FormWindowState.Maximized, form.WindowState);
            helper.Verify(x => x.ScaleTo(form, It.IsAny<int>(), It.IsAny<int>(), true), Times.Exactly(2));
            calculatorPanel.Verify(x => x.AdjustSize(), Times.Exactly(3));
            sidePanel.Verify(x => x.AdjustSize(), Times.Exactly(3));
        }

        [TestMethod]
        public void KeypadButtonMouseEnter() {

            var button = new Button();
            form.SetHelper(helper.Object);
            form.TestKeypadButtonMouseEnter(button, null);

            helper.Verify(x => x.ButtonMouseEnter(button, null), Times.Once);
        }

        [TestMethod]
        public void KeypadButtonMouseLeave() {

            var button = new Button();
            form.SetHelper(helper.Object);
            form.TestKeypadButtonMouseLeave(button, null);

            helper.Verify(x => x.ButtonMouseLeave(button, null), Times.Once);
        }

        [TestMethod]
        public void ToStandardCalculator() {

            Assert.IsNull(form.TestCalculatorPanel);

            form.TestToStandardCalculator();

            Assert.IsInstanceOfType(form.TestCalculatorPanel, typeof(StandardCalculatorPanel));
        }

        [TestMethod]
        public void ToScientificCalculatorPanel() {

            Assert.IsNull(form.TestCalculatorPanel);

            form.TestToScientificCalculatorPanel();

            Assert.IsInstanceOfType(form.TestCalculatorPanel, typeof(ScientificCalculatorPanel));
        }

        [TestMethod]
        public void SelectCalculator() {

            var button = new Button();
            form.TestToScientificCalculatorPanel();

            Assert.IsInstanceOfType(form.TestCalculatorPanel, typeof(ScientificCalculatorPanel));

            button.Tag = "Scientific";
            form.TestSelectCalculator(button, null);

            Assert.IsInstanceOfType(form.TestCalculatorPanel, typeof(ScientificCalculatorPanel));

            button.Tag = "Standard";
            form.TestSelectCalculator(button, null);

            Assert.IsInstanceOfType(form.TestCalculatorPanel, typeof(StandardCalculatorPanel));

            button.Tag = "Scientific";
            form.TestSelectCalculator(button, null);

            Assert.IsInstanceOfType(form.TestCalculatorPanel, typeof(ScientificCalculatorPanel));
        }

        [TestMethod]
        public void ResizeForm() {

            form.TestToScientificCalculatorPanel();
            form.TestFormResizeBegin(null, null);

            Assert.IsFalse(form.TestMainLayout.Visible);

            form.TestFormResizeEnd(null, null);
        }

        [TestMethod]
        public void FinishLoadUI() {

            form.Opacity = 0.02;

            Assert.AreEqual(0.02, form.Opacity);

            form.TestFinishLoadUI(null, null);

            Assert.IsTrue(form.Opacity < 1);

            form.Opacity = 0.99;

            Assert.AreEqual(0.99, form.Opacity);

            form.TestFinishLoadUI(null, null);

            Assert.AreEqual(1, form.Opacity);
        }

        [TestMethod]
        public void ZoomUI() {

            form.SetHelper(helper.Object);
            int width = form.Width;
            int height = form.Height;

            form.Width = width / 2;
            form.Height = height / 2;
            form.TestZoomUI(null, null);

            Assert.AreEqual(1, form.Opacity);
            helper.Verify(x => x.ScaleTo(

                form, It.IsAny<int>(), It.IsAny<int>(), true

            ), Times.Once);

            form.Width = width;
            form.Height = height;
            form.TestZoomUI(null, null);

            Assert.AreEqual(0.9, form.Opacity);
            helper.Verify(x => x.ScaleTo(

                form, It.IsAny<int>(), It.IsAny<int>(), true

            ), Times.Exactly(3));
        }

        [TestMethod]
        public void LoadUI() {

            form.SetHelper(helper.Object);
            form.TestLoadUI(null, null);

            helper.Verify(x => x.ScaleTo(

                form, It.IsAny<int>(), It.IsAny<int>(), true

            ), Times.Once);
        }

        [TestMethod]
        public void CloseUI() {

            int width = form.Width;
            int height = form.Height;

            Assert.AreEqual(1, form.Opacity);

            form.TestExit(null, null);
            form.TestCloseUI(null, null);

            Assert.AreEqual(width, form.Width);
            Assert.AreEqual(height, form.Height);
            Assert.IsTrue(form.Opacity < 1);
            Assert.IsTrue(form.Opacity > 0.7);

            form.Opacity = 0.7;
            form.TestCloseUI(null, null);

            Assert.IsTrue(form.Opacity < 0.7);
            Assert.AreNotEqual(width, form.Width);
            Assert.AreNotEqual(height, form.Height);
        }

        [TestMethod]
        public void WndProcResize() {

            var message = new Message();
            message.Msg = 0x84;
            form.TestWndProc(ref message);
            message.Result = (IntPtr)100;

            form.TestResizeWindow(ref message, new Point(-1, -1));

            Assert.AreEqual((IntPtr)100, message.Result);

            form.TestResizeWindow(ref message, new Point(1, 1));

            Assert.AreEqual((IntPtr)13, message.Result);
        }

        [TestMethod]
        public void WndProcMouseClick() {

            form.SetHelper(helper.Object);
            form.SetCalculatorPanel(calculatorPanel.Object);
            var message = new Message();
            message.Msg = 0x201;

            helper.Setup(x => x.ContainsPointer(It.IsAny<Control>(), It.IsAny<Point>())).Returns(true);
            form.TestWndProc(ref message);

            calculatorPanel.Verify(x => x.DeactivateBackPanel(), Times.Never);

            helper.Setup(x => x.ContainsPointer(It.IsAny<Control>(), It.IsAny<Point>())).Returns(false);
            form.TestWndProc(ref message);

            calculatorPanel.Verify(x => x.DeactivateBackPanel(), Times.Once);
        }
    }
}