using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExpressionsClassLibrary {
    public class Parenthesizer : IParenthesize {

        private List<HashSet<string>> Precedence { get; set; }

        public Parenthesizer() {

            SetPrecedence();
        }

        private void SetPrecedence() {

            Precedence = new List<HashSet<string>>();

            Precedence.Add(new HashSet<string>() {

                "√", "¹⁄ x", "eˣ", "sqr", "cube",
                "fact", "log", "ln", "dms", "degrees", "negate",
                "sin", "cos", "tan", "sinh", "cosh", "tanh",
                "sin⁻¹", "cos⁻¹", "tan⁻¹", "sinh⁻¹", "cosh⁻¹", "tanh⁻¹"
            });

            Precedence.Add(new HashSet<string>() {

                "^", "Exp", "yroot"
            });

            Precedence.Add(new HashSet<string>() {

                "×", "÷", "Mod"
            });

            Precedence.Add(new HashSet<string>() {

                "+", "−"
            });
        }

        private bool IsNested(string item) {

            return item.First() == '(' && item.Last() == ')';
        }

        private string[] GetItems(string expression) {

            return expression.Split(' ').Where(item => item != " ").ToArray();
        }

        private string GetNested(string[] items, ref int index) {

            int counter = 1;
            var nested = new StringBuilder();

            while(index + 1 < items.Length) {

                nested.Append(items[index++] + " ");

                if(items[index] == "(" || items[index] == ")") {

                    counter += items[index] == "(" ? 1 : -1;

                    if(counter == 0) {

                        nested.Append(")");

                        break;
                    }
                }
            }

            return nested.ToString();
        }

        private string[] Tokenize(string expression) {

            var items = GetItems(expression);
            var tokens = new List<string>();

            for(int i = 0; i < items.Length; i++) {

                if(items[i] == "(") {

                    tokens.Add(GetNested(items, ref i));

                    continue;
                }

                tokens.Add(items[i]);
            }

            return tokens.ToArray();
        }

        private void Nest(List<string> nested, string[] tokens, bool isUnary, ref int index) {

            string head = "[ " + nested.Last() + " ";
            string tail = (isUnary ? "" : " " + tokens[index + 1]) + " ]";
            nested[nested.Count - 1] = head + tokens[index] + tail;

            if(!isUnary) {

                index++;
            }
        }

        private string UnNest(string expression) {

            return expression.Substring(1, expression.Length - 2).Trim();
        }

        private string ChangeParentheses(string expression) {

            return Regex.Replace(expression, @"\[|\]", match => {

                return match.Value == "[" ? "(" : ")";
            });
        }

        private string TryParenthesize(string expression, bool topLevel = true) {

            var tokens = Tokenize(expression);

            for(int i = 0; i < Precedence.Count; i++) {

                var nested = new List<string>();

                for(int j = 0; j < tokens.Length; j++) {

                    if(Precedence[i].Contains(tokens[j])) {

                        Nest(nested, tokens, i == 0, ref j);

                        continue;
                    }

                    if(IsNested(tokens[j])) {

                        nested.Add(TryParenthesize(UnNest(tokens[j]), false));

                        continue;
                    }

                    nested.Add(tokens[j]);
                }

                tokens = nested.ToArray();
            }

            return topLevel ? ChangeParentheses(tokens[0]) : tokens[0];
        }

        public string Parenthesize(string expression) {

            return TryParenthesize(expression);
        }
    }
}