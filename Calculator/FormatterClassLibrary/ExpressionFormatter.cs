using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ExpressionsClassLibrary;

namespace FormatterClassLibrary {
    public class ExpressionFormatter : IFormatter {

        private string[] Tokenize(string expression) {

            return expression.Split(' ').Where(token => token != " ").ToArray();
        }

        private HashSet<string> FindUnaryOperator(string expression) {

            var tokens = Tokenize(expression);
            var unarys = OperatorLookup.UnaryOperator;

            return new HashSet<string>(tokens.Where(token => unarys.Contains(token)));
        }

        private bool HasUnformattedUnaryOperator(string expression, HashSet<string> unarys) {

            return unarys.Any(unary => Regex.IsMatch(expression, unary + @"(?!\s*\()"));
        }

        private string GetOperand(string[] tokens, int index) {

            if(tokens[index] != ")") {

                return tokens[index];
            }

            int counter = 1;

            for(int i = index - 1; i >= 0; i--) {

                if(tokens[i].Last() == '(' || tokens[i] == ")") {

                    counter += tokens[i] == ")" ? 1 : -1;
                }

                if(counter == 0) {

                    return string.Join(" ", tokens.Skip(i).Take(index - i + 1));
                }
            }

            return string.Empty;
        }

        private string FormatUnary(string expression, HashSet<string> unarys) {

            var tokens = Tokenize(expression);

            for(int i = 0; i < tokens.Length; i++) {

                if(unarys.Contains(tokens[i])) {

                    var operand = GetOperand(tokens, i - 1);
                    var pattern = Regex.Replace(operand + " " + tokens[i], @"\(|\)", match => "\\" + match.Value);
                    var replace = tokens[i] + "( " + operand + " )";

                    return Regex.Replace(expression, pattern, replace);
                }
            }

            return expression;
        }

        private string FormatUnaryOperator(string expression) {

            var unarys = FindUnaryOperator(expression);

            while(HasUnformattedUnaryOperator(expression, unarys)) {

                expression = FormatUnary(expression, unarys);
            }

            return expression;
        }

        private string RemoveParenthesesSpacing(string expression) {

            return Regex.Replace(expression, @"\(\s+|\s+\)", match => match.Value.Trim());
        }

        public string Format(string expression) {

            expression = FormatUnaryOperator(expression);

            return RemoveParenthesesSpacing(expression);
        }
    }
}