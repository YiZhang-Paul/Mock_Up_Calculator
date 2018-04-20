﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterClassLibrary;
using CalculatorClassLibrary;

namespace ParseTreeClassLibrary {
    public class ParseTree : IParseTree {

        private INode Root { get; set; }
        private ICalculator Calculator { get; set; }
        private IOperatorConverter Converter { get; set; }

        public ParseTree(ICalculator calculator, IOperatorConverter converter) {

            Clear();
            Calculator = calculator;
            Converter = converter;
        }

        private void Clear() {

            Root = new Node();
        }

        private string[] GetTokens(string expression) {

            return expression.Split(' ').Where(token => token != " ").ToArray();
        }

        private void SetOperator(INode node, decimal value) {

            node.Value = value;
            node.IsOperand = false;
        }

        private void SetOperand(INode node, decimal value) {

            node.Value = value;
            node.IsOperand = true;
        }

        private INode ParseNumber(INode node, decimal value) {

            SetOperand(node, value);

            return node.Parent;
        }

        private INode ParseOperator(INode node, string token) {

            SetOperator(node, Converter.toValue(token));
            node.AddRight(new Node(node));

            return node.Right;
        }

        private INode ParseParentheses(INode node, string token) {

            if(token == "(") {

                node.AddLeft(new Node(node));

                return node.Left;
            }

            return node.Parent;
        }

        public void Parse(string expression) {

            Clear();
            var node = Root;

            foreach(string token in GetTokens(expression)) {

                if(node == null) {

                    throw new ArgumentException("Invalid Expression.");
                }

                decimal value = 0;

                if(decimal.TryParse(token, out value)) {

                    node = ParseNumber(node, value);
                }
                else if(Converter.IsOperator(token)) {

                    node = ParseOperator(node, token);
                }
                else if(token == "(" || token == ")") {

                    node = ParseParentheses(node, token);
                }
                else {

                    throw new ArgumentException("Invalid Expression.");
                }
            }
        }

        private decimal EvaluateNode(INode node) {

            if(node == null) {

                return 0;
            }

            if(node.IsOperand) {

                return node.Value;
            }

            return Calculator.Evaluate(

                Converter.toOperator((int)node.Value),
                EvaluateNode(node.Left),
                EvaluateNode(node.Right)
            );
        }

        public decimal Evaluate() {

            return EvaluateNode(Root);
        }
    }
}