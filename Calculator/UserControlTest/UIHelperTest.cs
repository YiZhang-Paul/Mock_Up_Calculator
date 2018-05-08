using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using UtilityClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class UIHelperTest {

        event EventHandler OnTest;

        bool eventFired = false;

        Form form;
        Panel panel1;
        Panel panel2;
        Panel panel3;
        Button button1;
        Button button2;
        Button button3;
        Mock<IButtonTracker> tracker;
        UIHelper helper;

        private void CheckEventFiring(object sender, EventArgs e) {

            eventFired = true;
        }

        [TestInitialize]
        public void Setup() {

            form = new Form();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tracker = new Mock<IButtonTracker>();
            helper = new UIHelper();
            OnTest += CheckEventFiring;
        }

        [TestMethod]
        public void GetControlsOfType() {

            panel1.Parent = form;
            panel2.Parent = form;
            panel3.Parent = panel1;
            var panels = new List<Panel>();

            helper.ControlsOfType<Panel>(form, panels);

            Assert.AreEqual(3, panels.Count);
            Assert.IsTrue(panels.Contains(panel1));
            Assert.IsTrue(panels.Contains(panel2));
            Assert.IsTrue(panels.Contains(panel3));
        }

        [TestMethod]
        public void UpdateKeyTextWithoutAppend() {

            button1.Text = "This is a test";

            helper.UpdateKeyText(button1, "test", "!", false);

            Assert.AreEqual("This is a !", button1.Text);
        }

        [TestMethod]
        public void UpdateKeyTextWithAppend() {

            button1.Text = "This is a test";

            helper.UpdateKeyText(button1, "test", "!", true);

            Assert.AreEqual("This is a test!", button1.Text);
        }

        [TestMethod]
        public void DisableKeys() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(true);
            var buttons = new Button[] { button1, button2, button3 };

            helper.DisableKeys(buttons, tracker.Object);

            Assert.IsTrue(buttons.All(button => tracker.Object.IsDisabled(button)));
        }

        [TestMethod]
        public void EnableKeys() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(false);
            var buttons = new Button[] { button1, button2, button3 };

            helper.EnableKeys(buttons, tracker.Object);

            Assert.IsTrue(buttons.All(button => !tracker.Object.IsDisabled(button)));
        }

        [TestMethod]
        public void CenterToPoint() {

            var point = new Point(50, 50);

            helper.CenterToPoint(form, point);

            Assert.AreEqual(point.Y, form.Top + form.Height / 2);
            Assert.AreEqual(point.X, form.Left + form.Width / 2);
        }

        [TestMethod]
        public void CenterToScreen() {

            var screen = Screen.FromControl(form).WorkingArea;

            helper.CenterToScreen(form);

            Assert.AreEqual(screen.Height / 2, form.Top + form.Height / 2);
            Assert.AreEqual(screen.Width / 2, form.Left + form.Width / 2);
        }

        [TestMethod]
        public void ScaleControlWithoutCentering() {

            var screen = Screen.FromControl(form).WorkingArea;
            int y = form.Top;
            int x = form.Left;

            helper.ScaleTo(form, 200, 200, false);

            Assert.AreEqual(200, form.Width);
            Assert.AreEqual(200, form.Height);
            Assert.AreEqual(y, form.Top);
            Assert.AreEqual(x, form.Left);
        }

        [TestMethod]
        public void ScaleControlWithCentering() {

            var screen = Screen.FromControl(form).WorkingArea;

            helper.ScaleTo(form, 200, 200, true);

            Assert.AreEqual(200, form.Width);
            Assert.AreEqual(200, form.Height);
            Assert.AreEqual(screen.Height / 2 - form.Height / 2, form.Top);
            Assert.AreEqual(screen.Width / 2 - form.Width / 2, form.Left);
        }

        [TestMethod]
        public void SetHeight() {

            int height = form.Height;
            form.Top = 0;

            helper.SetHeight(form, 200);

            Assert.AreEqual(height - 200, form.Top);
            Assert.AreEqual(200, form.Height);

            height = form.Height;
            form.Top = 0;

            helper.SetHeight(form, 350);

            Assert.AreEqual(height - 350, form.Top);
            Assert.AreEqual(350, form.Height);
        }

        [TestMethod]
        public void AddLabel() {

            helper.AddLabel(panel1, "This is a test", 11, 5, 6);

            var label = panel1.Controls.OfType<Label>().First();

            Assert.AreEqual("This is a test", label.Text);
            Assert.AreEqual(11, label.Font.Size);
            Assert.AreEqual(5, label.Left);
            Assert.AreEqual(6, label.Top);
        }

        [TestMethod]
        public void GetViewport() {

            var viewport = Screen.FromControl(form).WorkingArea;

            Assert.AreEqual(viewport.Y, helper.GetViewport(form).Y);
            Assert.AreEqual(viewport.X, helper.GetViewport(form).X);
        }

        [TestMethod]
        public void GetPointerLocation() {

            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 150, 100, -120);
            var location = helper.GetPointerLocation(mouseEvent);

            Assert.AreEqual(100, location.Y);
            Assert.AreEqual(150, location.X);
        }

        [TestMethod]
        public void ControlContainsPointer() {

            var screen = Screen.FromControl(form).WorkingArea;
            form.Top = 0;
            form.Left = 0;
            form.Width = screen.Width;
            form.Height = screen.Height;

            Assert.IsTrue(helper.ContainsPointer(form, Cursor.Position));
        }

        [TestMethod]
        public void ControlDoesNotContainPointer() {

            var screen = Screen.FromControl(form).WorkingArea;
            form.Top = 0;
            form.Left = 0;
            form.Width = 1;
            form.Height = 1;

            Assert.IsFalse(helper.ContainsPointer(form, new Point(100, 100)));
        }

        [TestMethod]
        public void DragWindowWithLeftMouseButton() {

            form.Top = 0;
            form.Left = 0;
            var mouseEvent = new MouseEventArgs(MouseButtons.Left, 0, 200, 200, 0);

            helper.DragWindow(mouseEvent, form, new Point(100, 100));

            Assert.AreEqual(100, form.Top);
            Assert.AreEqual(100, form.Left);
        }

        [TestMethod]
        public void DragWindowWithRightMouseButton() {

            form.Top = 0;
            form.Left = 0;
            var mouseEvent = new MouseEventArgs(MouseButtons.Right, 0, 200, 200, 0);

            helper.DragWindow(mouseEvent, form, new Point(100, 100));

            Assert.AreEqual(0, form.Top);
            Assert.AreEqual(0, form.Left);
        }

        [TestMethod]
        public void ButtonMouseEnter() {

            button1.FlatAppearance.BorderColor = button1.BackColor;

            helper.ButtonMouseEnter(button1, null);

            Assert.AreNotEqual(button1.FlatAppearance.BorderColor, button1.BackColor);
        }

        [TestMethod]
        public void ButtonMouseLeave() {

            Assert.AreNotEqual(button1.FlatAppearance.BorderColor, button1.BackColor);

            helper.ButtonMouseLeave(button1, null);

            Assert.AreEqual(button1.FlatAppearance.BorderColor, button1.BackColor);
        }

        [TestMethod]
        public void DrawUnderline() {

            var paintEvent = new PaintEventArgs(panel1.CreateGraphics(), new Rectangle());

            helper.DrawUnderline(button1, paintEvent);
        }

        [TestMethod]
        public void RaiseButtonEventWhenEnabled() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(false);
            eventFired = false;

            helper.RaiseButtonEvent(button1, null, OnTest, tracker.Object);

            Assert.IsTrue(eventFired);
        }

        [TestMethod]
        public void RaiseButtonEventWhenDisabled() {

            tracker.Setup(x => x.IsDisabled(It.IsAny<Button>())).Returns(true);
            eventFired = false;

            helper.RaiseButtonEvent(button1, null, OnTest, tracker.Object);

            Assert.IsFalse(eventFired);
        }
    }
}