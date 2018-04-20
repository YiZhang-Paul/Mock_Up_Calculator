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
        public string Operator { get; private set; }
        public decimal Operand { get; private set; }

        public Node() {}

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

        public Node(INode parent, string token) : this(parent) {
            //TODO: is valid operator
            if(token == string.Empty) {

                throw new ArgumentException("Must Provide the Operator.");
            }

            Operator = token;
        }

        public Node(INode parent, decimal operand) : this(parent) {

            Operand = operand;
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

        public bool IsLeaf() {

            return Left == null && Right == null;
        }
    }
}