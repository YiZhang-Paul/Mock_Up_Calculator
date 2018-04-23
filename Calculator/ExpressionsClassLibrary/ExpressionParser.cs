using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterClassLibrary;

namespace ExpressionsClassLibrary {
    public class ExpressionParser : IExpressionParser {

        private IOperatorConverter Converter { get; set; }

        public ExpressionParser(IOperatorConverter converter) {

            Converter = converter;
        }

        private string[] Tokenize(string expression) {

            return expression.Split(' ').Where(token => token != " ").ToArray();
        }

        private void SaveOperator(INode node, decimal value) {

            node.Value = value;
            node.IsOperand = false;
        }

        private void SaveOperand(INode node, decimal value) {

            node.Value = value;
            node.IsOperand = true;
        }

        private INode ParseUnary(INode node, string token) {

            SaveOperator(node, Converter.ToValue(token));

            return node;
        }

        private INode ParseBinary(INode node, string token) {

            SaveOperator(node, Converter.ToValue(token));
            node.AddRight(new Node());

            return node.Right;
        }

        private INode ParseOperator(INode node, string token) {

            if(Converter.IsUnary(token)) {

                return ParseUnary(node, token);
            }

            return ParseBinary(node, token);
        }

        private INode ParseOperand(INode node, decimal value) {

            SaveOperand(node, value);

            return node.Parent;
        }

        private INode ParseParenthesis(INode node, string token) {

            if(token == "(") {

                node.AddLeft(new Node());

                return node.Left;
            }

            return node.Parent;
        }

        public INode Parse(string expression) {

            var root = new Node();
            var node = root;

            foreach(string token in Tokenize(expression)) {

                if(node == null) {

                    throw new ArgumentException("Invalid Expression.");
                }

                decimal value = 0;

                if(decimal.TryParse(token, out value)) {

                    node = (Node)ParseOperand(node, value);
                }
                else if(Converter.IsOperator(token)) {

                    node = (Node)ParseOperator(node, token);
                }
                else if(token == "(" || token == ")") {

                    node = (Node)ParseParenthesis(node, token);
                }
                else {

                    throw new ArgumentException("Invalid Expression.");
                }
            }

            return root;
        }
    }
}