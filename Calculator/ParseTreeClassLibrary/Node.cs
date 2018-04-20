using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTreeClassLibrary {
    public class Node : INode {

        public INode Parent { get; private set; }
        public INode Left { get; private set; }
        public INode Right { get; private set; }
        public bool IsOperand { get; set; }
        public decimal Value { get; set; }

        public bool IsLeaf {

            get {

                return Left == null && Right == null;
            }
        }

        public Node() { }

        public Node(INode parent) {

            if(parent == null) {

                throw new ArgumentNullException("Parent Must not be Null.");
            }

            Parent = parent;
        }

        public Node(INode left, INode right) {

            Left = left;
            Right = right;
        }

        public void AddLeft(INode child) {

            if(Left != null) {

                throw new InvalidOperationException("Left Child Already Exists.");
            }

            Left = child;
        }

        public void AddRight(INode child) {

            if(Right != null) {

                throw new InvalidOperationException("Right Child Already Exists.");
            }

            Right = child;
        }
    }
}