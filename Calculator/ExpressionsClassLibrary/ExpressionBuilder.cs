using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public class ExpressionBuilder : IExpressionBuilder {

        private enum KeyType { Value, Unary, Binary, Left, Right, Empty };

        private Deque<string> Buffer { get; set; }
        private KeyType LastKey { get; set; }
        private IParenthesize Parenthesizer { get; set; }

        public string Expression { get { return string.Join(" ", Buffer); } }

        public ExpressionBuilder(IParenthesize parenthesizer) {

            Buffer = new Deque<string>();
            LastKey = KeyType.Empty;
            Parenthesizer = parenthesizer;
        }

        public ExpressionBuilder(IParenthesize parenthesizer, string expression, int type) : this(parenthesizer) {

            if(type < 0 || type > 5) {

                throw new ArgumentException("Invalid Key Type.");
            }

            var typeTable = new Dictionary<int, KeyType>() {

                { 0, KeyType.Value },
                { 1, KeyType.Unary },
                { 2, KeyType.Binary },
                { 3, KeyType.Left },
                { 4, KeyType.Right },
                { 5, KeyType.Empty },
            };

            if(expression != null) {

                Buffer.Add(expression);
            }

            LastKey = typeTable[type];
        }

        public void Clear() {

            Buffer.Clear();
            LastKey = KeyType.Empty;
        }

        private int MissingParentheses(string expression) {

            int total = 0;

            foreach(char item in expression) {

                if(item == '(' || item == ')') {

                    total += item == '(' ? 1 : -1;
                }
            }

            return total;
        }

        public void AddValue(decimal input) {

            switch(LastKey) {

                case KeyType.Value :
                case KeyType.Unary :
                case KeyType.Right :

                    throw new InvalidOperationException("Operands Must be Separated by Operators.");

                default :

                    Buffer.Add(input.ToString());
                    LastKey = KeyType.Value;

                    break;
            }
        }

        public void AddUnary(string input) {

            if(LastKey == KeyType.Binary) {

                throw new InvalidOperationException("Missing Operand.");
            }

            if(LastKey == KeyType.Left || LastKey == KeyType.Empty) {

                AddValue(0);
            }

            Buffer.Add(input);
            LastKey = KeyType.Unary;
        }

        public void AddBinary(string input) {

            if(LastKey == KeyType.Binary) {

                throw new InvalidOperationException("Missing Operand.");
            }

            if(LastKey == KeyType.Left || LastKey == KeyType.Empty) {

                AddValue(0);
            }

            Buffer.Add(input);
            LastKey = KeyType.Binary;
        }

        private void AddLeftParenthesis(string input) {

            if(LastKey == KeyType.Value || LastKey == KeyType.Unary) {

                throw new InvalidOperationException("Missing Operators.");
            }

            if(LastKey == KeyType.Right) {

                throw new InvalidOperationException("Mismatched Parentheses.");
            }

            Buffer.Add(input);
            LastKey = KeyType.Left;
        }

        private void AddRightParenthesis(string input) {

            if(LastKey == KeyType.Binary) {

                throw new InvalidOperationException("Missing Operand.");
            }

            if(MissingParentheses(Expression) < 1) {

                throw new InvalidOperationException("Mismatched Parentheses.");
            }

            if(LastKey == KeyType.Left) {

                AddValue(0);
            }

            Buffer.Add(input);
            LastKey = KeyType.Right;
        }

        public void AddParentheses(string input) {

            if(input == "(") {

                AddLeftParenthesis(input);

                return;
            }

            AddRightParenthesis(input);
        }

        public string Build() {

            string result = Parenthesizer.Parenthesize(Expression);

            return MissingParentheses(result) == 0 ? result : null;
        }
    }
}