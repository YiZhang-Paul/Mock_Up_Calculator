using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTreeClassLibrary {
    public class ParseTree : IParseTree {

        private INode Root { get; set; }

        public ParseTree() {

            Clear();
        }

        private void Clear() {

            Root = new Node();
        }

        private string[] GetTokens(string expression) {

            return expression.Split(' ').Where(token => token != " ").ToArray();
        }

        public void Parse(string expression) {

            Clear();
            var node = Root;

            foreach(string token in GetTokens(expression)) {

                if(node == null) {

                    throw new ArgumentException("Invalid Expression.");
                }

                decimal value = 0;

                if(token == "(") {

                    node.AddLeft(new Node(node));
                    node = node.Left;
                }
                else if(token == ")") {

                    node = node.Parent;
                }
                else if(token == "+") {

                    node.Value = 1;
                    node.AddRight(new Node(node));
                    node = node.Right;
                }
                else if(decimal.TryParse(token, out value)) {

                    node.Value = value;
                    node = node.Parent;
                }
                else {

                    throw new ArgumentException("Invalid Expression.");
                }
            }
        }

        public decimal Evaluate() {

            return -1;
        }
    }
}