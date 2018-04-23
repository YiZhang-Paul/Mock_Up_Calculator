using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;

namespace ExpressionsTest {
    [TestClass]
    public class NodeTest {

        Node withBothChild;
        Node withNoChild;

        [TestInitialize]
        public void Setup() {

            withBothChild = new Node(new Node(), new Node());
            withNoChild = new Node();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Left Child Already Exists.")]
        public void LeftChildAlreadyExists() {

            withBothChild.AddLeft(new Node());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Right Child Already Exists.")]
        public void RightChildAlreadyExists() {

            withBothChild.AddRight(new Node());
        }

        [TestMethod]
        public void AddLeft() {

            withNoChild.AddLeft(new Node());

            Assert.IsNotNull(withNoChild.Left);
            Assert.IsNull(withNoChild.Right);
            Assert.AreEqual(withNoChild, withNoChild.Left.Parent);
        }

        [TestMethod]
        public void AddRight() {

            withNoChild.AddRight(new Node());

            Assert.IsNotNull(withNoChild.Right);
            Assert.IsNull(withNoChild.Left);
            Assert.AreEqual(withNoChild, withNoChild.Right.Parent);
        }
    }
}