using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityClassLibrary;

namespace CalculatorClassLibrary {
    public class ExpressionBuilder : IExpressionBuilder {

        private enum KeyType : int { Value, Binary, Unary, LeftParentheses, RightParentheses };

        private StringBuilder Buffer { get; set; }
        private KeyType LastKey { get; set; }

        private string LastNestedExpression {

            get {

                string expression = Expression;
                int counter = 0;

                for(int i = expression.Length - 1, j = -1; i >= 0; i--) {

                    if(j == -1 && expression[i] == ')') {

                        j = i;
                    }

                    if(expression[i] == '(' || expression[i] == ')') {

                        counter += expression[i] == ')' ? 1 : -1;
                    }

                    if(counter == 0) {

                        expression = expression.Substring(i, j - i + 1);

                        break;
                    }
                }

                if(counter != 0) {

                    throw new InvalidOperationException("Invalid Expression.");
                }

                return expression;
            }
        }

        public string Expression { get { return Buffer.ToString().Trim(); } }

        public ExpressionBuilder() {

            Clear();
        }

        public ExpressionBuilder(string expression, int keyType) {

            Buffer = new StringBuilder(expression);

            var typeTable = new Dictionary<int, KeyType>() {

                { 0, KeyType.Value },
                { 1, KeyType.Binary },
                { 2, KeyType.Unary },
                { 3, KeyType.LeftParentheses },
                { 4, KeyType.RightParentheses },
            };

            LastKey = typeTable[keyType];
        }

        public void Clear() {

            Buffer = new StringBuilder("( ");
            LastKey = KeyType.LeftParentheses;
        }

        public void AddValue(decimal input) {

            switch(LastKey) {

                case KeyType.Unary :
                case KeyType.Binary :

                    Buffer.Append(input.ToString() + " ) ");
                    LastKey = KeyType.RightParentheses;

                    break;

                case KeyType.LeftParentheses :

                    Buffer.Append(input.ToString() + " ");
                    LastKey = KeyType.Value;

                    break;

                default :

                    throw new ArgumentException("Operands Must be Separated by Operators.");
            }
        }

        public void AddParentheses(string input) {

            var type = input == "(" ? KeyType.LeftParentheses : KeyType.RightParentheses;

            if(type != LastKey) {

                throw new ArgumentException("Invalid Nested Expression.");
            }

            Buffer.Append(input + " ");
        }

        public void AddUnaryOperator(string input) {

            string prefix = string.Empty;

            switch(LastKey) {

                case KeyType.Binary :
                case KeyType.LeftParentheses :

                    prefix = LastKey == KeyType.Binary ? "( " : "";
                    Buffer.Append(prefix + input + " ");
                    LastKey = KeyType.Unary;

                    break;


                case KeyType.RightParentheses :

                    string affix = LastNestedExpression;
                    prefix = Expression.Substring(0, Expression.Length - affix.Length);
                    Buffer = new StringBuilder(prefix + "( " + input + " " + affix + " ) ");

                    break;

                default :

                    throw new ArgumentException("Missing Operand.");
            }
        }

        public void AddBinaryOperator(string input) {

            switch(LastKey) {

                case KeyType.Unary :
                case KeyType.Binary :
                case KeyType.LeftParentheses :

                    throw new ArgumentException("Missing Operand Before Operator.");

                default :

                    Buffer.Append(input + " ");
                    LastKey = KeyType.Binary;

                    break;
            }
        }
    }
}