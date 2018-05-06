using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ExpressionsClassLibrary;

namespace FormatterClassLibrary {
    public class ExpressionFormatter : IFormatter {

        private HashSet<string> Unarys { get; set; }

        public ExpressionFormatter(HashSet<string> unarys) {

            Unarys = unarys;
        }

        private string[] Tokenize(string expression) {

            return expression.Split(' ');
        }

        private HashSet<string> UnaryOperatorUsed(string expression) {

            var tokens = Tokenize(expression);

            return new HashSet<string>(tokens.Where(token => Unarys.Contains(token)));
        }

        private bool HasUnformattedUnary(string expression, HashSet<string> unarys) {

            return unarys.Any(unary => Regex.IsMatch(expression, unary + @"(?!\s*\()"));
        }

        private string GetOperand(string[] tokens, int index) {

            if(tokens[index] != ")") {

                return tokens[index];
            }

            for(int i = index - 1, counter = 1; i >= 0; i--) {

                if(tokens[i].Last() == '(' || tokens[i] == ")") {

                    counter += tokens[i] == ")" ? 1 : -1;
                }

                if(counter == 0) {

                    return string.Join(" ", tokens.Skip(i).Take(index - i + 1));
                }
            }

            return string.Empty;
        }

        private string EscapeParentheses(string pattern) {

            return Regex.Replace(pattern, @"\(|\)", match => "\\" + match.Value);
        }

        private string FormatUnary(string expression, HashSet<string> unarys) {

            var tokens = Tokenize(expression);

            for(int i = 0; i < tokens.Length; i++) {

                if(unarys.Contains(tokens[i])) {

                    string operand = GetOperand(tokens, i - 1);
                    string pattern = EscapeParentheses(operand + " " + tokens[i]);
                    string replace = tokens[i] + "( " + operand + " )";

                    return Regex.Replace(expression, pattern, replace);
                }
            }

            return expression;
        }

        private string FormatOperators(string expression) {

            var unarysUsed = UnaryOperatorUsed(expression);

            while(HasUnformattedUnary(expression, unarysUsed)) {

                expression = FormatUnary(expression, unarysUsed);
            }

            return expression;
        }

        private string RemoveParenthesesSpacing(string expression) {

            return Regex.Replace(expression, @"\(\s+|\s+\)", match => match.Value.Trim());
        }

        public string Format(string expression) {

            expression = FormatOperators(expression);

            return RemoveParenthesesSpacing(expression);
        }
    }
}