using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private bool IsOperator(string item) {

            return Precedence.Any(group => group.Contains(item));
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

        public string Parenthesize(string expression) {

            var tokens = Tokenize(expression);

            return "";
        }
    }
}