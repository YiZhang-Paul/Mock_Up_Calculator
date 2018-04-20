﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseTreeClassLibrary;

namespace ParseTreeTest {
    [TestClass]
    public class NodeTest {

        string token = "+";
        Node nodeWithNoChild;
        Node nodeWithBothChild;

        [TestInitialize]
        public void Setup() {

            nodeWithNoChild = new Node();
            nodeWithBothChild = new Node(new Node(), new Node());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Child Node Cannot Have Null Parent.")]
        public void ChildNodeWithNullParent() {

            nodeWithNoChild = new Node(null, token);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Operator Passed.")]
        public void ChildNodeWithInvalidOperator() {

            nodeWithNoChild = new Node(nodeWithBothChild, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Left Child Already Exists.")]
        public void AddLeftChildWhenAlreadyExist() {

            nodeWithBothChild.AddLeft(new Node());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Right Child Already Exists.")]
        public void AddRightChildWhenAlreadyExist() {

            nodeWithBothChild.AddRight(new Node());
        }

        [TestMethod]
        public void AddLeftChild() {

            nodeWithNoChild.AddLeft(new Node(nodeWithNoChild, token));

            Assert.AreEqual(token, nodeWithNoChild.Left.Operator);
            Assert.AreEqual(nodeWithNoChild, nodeWithNoChild.Left.Parent);
            Assert.IsNull(nodeWithNoChild.Right);
        }

        [TestMethod]
        public void AddRightChild() {

            nodeWithNoChild.AddRight(new Node(nodeWithNoChild, token));

            Assert.AreEqual(token, nodeWithNoChild.Right.Operator);
            Assert.AreEqual(nodeWithNoChild, nodeWithNoChild.Right.Parent);
            Assert.IsNull(nodeWithNoChild.Left);
        }

        [TestMethod]
        public void IsLeafNode() {

            Assert.IsFalse(nodeWithBothChild.IsLeaf());
            Assert.IsTrue(nodeWithBothChild.Left.IsLeaf());
            Assert.IsTrue(nodeWithBothChild.Right.IsLeaf());
        }
    }
}