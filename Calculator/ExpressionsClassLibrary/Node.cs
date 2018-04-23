using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public class Node : INode {

        public INode Parent { get; set; }
        public INode Left { get; private set; }
        public INode Right { get; private set; }
        public bool IsOperand { get; set; }
        public decimal Value { get; set; }

        public Node() { }

        public Node(INode left, INode right) {

            Left = left;
            Right = right;
            Left.Parent = this;
            Right.Parent = this;
        }

        public void AddLeft(INode child) {

            if(Left != null) {

                throw new InvalidOperationException("Left Child Already Exists.");
            }

            Left = child;
            child.Parent = this;
        }

        public void AddRight(INode child) {

            if(Right != null) {

                throw new InvalidOperationException("Right Child Already Exists.");
            }

            Right = child;
            child.Parent = this;
        }
    }
}