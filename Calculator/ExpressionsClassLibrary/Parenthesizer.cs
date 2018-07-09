using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExpressionsClassLibrary {
    public class Parenthesizer : IParenthesize {

        private List<HashSet<string>> Precedence { get; set; }

        public Parenthesizer(List<string[]> operators) {

            SetPrecedence(operators);
        }

        private void SetPrecedence(List<string[]> operators) {

            Precedence = new List<HashSet<string>>();

            foreach(var precedence in operators) {

                Precedence.Add(new HashSet<string>(precedence));
            }
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
                    //when matching parentheses is found
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
                //nested expression is considered as one token
                if(items[i] == "(") {

                    tokens.Add(GetNested(items, ref i));

                    continue;
                }

                tokens.Add(items[i]);
            }

            return tokens.ToArray();
        }

        private void Nest(List<string> nested, string[] tokens, bool isUnary, ref int index) {
            //first operand is temporarily stored as last item in nested list
            string operand1 = nested.Last() + " ";
            string operand2 = isUnary ? "" : " " + tokens[index + 1];
            //use square brackets to differentiate from unprocessed tokens
            nested[nested.Count - 1] = "[ " + operand1 + tokens[index] + operand2 + " ]";
            //skip second operand when handling binary operators
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
                    //when current token is operator
                    if(Precedence[i].Contains(tokens[j])) {

                        Nest(nested, tokens, i == 0, ref j);

                        continue;
                    }
                    //when current token is nested expression
                    if(IsNested(tokens[j])) {

                        nested.Add(TryParenthesize(UnNest(tokens[j]), false));

                        continue;
                    }
                    //when current token is operand
                    nested.Add(tokens[j]);
                }

                tokens = nested.ToArray();
            }
            //all tokens will be combined together when parenthesized
            return topLevel ? ChangeParentheses(tokens[0]) : tokens[0];
        }

        public string Parenthesize(string expression) {

            return TryParenthesize(expression);
        }
    }
}