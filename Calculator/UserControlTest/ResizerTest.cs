using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;

namespace UserControlTest {
    [TestClass]
    public class ResizerTest {

        Form form;
        Resizer resizer;
        const int thickness = 15;

        [TestInitialize]
        public void Setup() {

            form = new Form();
            resizer = new Resizer(form, thickness);
        }

        [TestMethod]
        public void WndProcMessageKeys() {

            CollectionAssert.AreEqual(new int[] { 13, 14, 16, 17, 10, 11, 12, 15 }, resizer.Keys);
        }

        [TestMethod]
        public void TopLeftHitBox() {

            int key = resizer.Keys[0];

            Assert.AreEqual(resizer.Boxes[key]().Left, 0);
            Assert.AreEqual(resizer.Boxes[key]().Top, 0);
            Assert.AreEqual(resizer.Boxes[key]().Width, thickness);
            Assert.AreEqual(resizer.Boxes[key]().Height, thickness);
        }

        [TestMethod]
        public void TopRightHitBox() {

            int key = resizer.Keys[1];

            Assert.AreEqual(resizer.Boxes[key]().Left, form.ClientSize.Width - thickness);
            Assert.AreEqual(resizer.Boxes[key]().Top, 0);
            Assert.AreEqual(resizer.Boxes[key]().Width, thickness);
            Assert.AreEqual(resizer.Boxes[key]().Height, thickness);
        }

        [TestMethod]
        public void BottomLeftHitBox() {

            int key = resizer.Keys[2];

            Assert.AreEqual(resizer.Boxes[key]().Left, 0);
            Assert.AreEqual(resizer.Boxes[key]().Top, form.ClientSize.Height - thickness);
            Assert.AreEqual(resizer.Boxes[key]().Width, thickness);
            Assert.AreEqual(resizer.Boxes[key]().Height, thickness);
        }

        [TestMethod]
        public void BottomRightHitBox() {

            int key = resizer.Keys[3];

            Assert.AreEqual(resizer.Boxes[key]().Left, form.ClientSize.Width - thickness);
            Assert.AreEqual(resizer.Boxes[key]().Top, form.ClientSize.Height - thickness);
            Assert.AreEqual(resizer.Boxes[key]().Width, thickness);
            Assert.AreEqual(resizer.Boxes[key]().Height, thickness);
        }

        [TestMethod]
        public void LeftHitBox() {

            int key = resizer.Keys[4];

            Assert.AreEqual(resizer.Boxes[key]().Left, 0);
            Assert.AreEqual(resizer.Boxes[key]().Top, 0);
            Assert.AreEqual(resizer.Boxes[key]().Width, thickness);
            Assert.AreEqual(resizer.Boxes[key]().Height, form.ClientSize.Height);
        }

        [TestMethod]
        public void RightHitBox() {

            int key = resizer.Keys[5];

            Assert.AreEqual(resizer.Boxes[key]().Left, form.ClientSize.Width - thickness);
            Assert.AreEqual(resizer.Boxes[key]().Top, 0);
            Assert.AreEqual(resizer.Boxes[key]().Width, thickness);
            Assert.AreEqual(resizer.Boxes[key]().Height, form.ClientSize.Height);
        }

        [TestMethod]
        public void TopHitBox() {

            int key = resizer.Keys[6];

            Assert.AreEqual(resizer.Boxes[key]().Left, 0);
            Assert.AreEqual(resizer.Boxes[key]().Top, 0);
            Assert.AreEqual(resizer.Boxes[key]().Width, form.ClientSize.Width);
            Assert.AreEqual(resizer.Boxes[key]().Height, thickness);
        }

        [TestMethod]
        public void BottomHitBox() {

            int key = resizer.Keys[7];

            Assert.AreEqual(resizer.Boxes[key]().Left, 0);
            Assert.AreEqual(resizer.Boxes[key]().Top, form.ClientSize.Height - thickness);
            Assert.AreEqual(resizer.Boxes[key]().Width, form.ClientSize.Width);
            Assert.AreEqual(resizer.Boxes[key]().Height, thickness);
        }
    }
}