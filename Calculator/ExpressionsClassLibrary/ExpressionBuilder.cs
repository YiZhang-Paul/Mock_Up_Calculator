using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public class ExpressionBuilder {

        private enum KeyType { Value, Unary, Binary, Left, Right, Empty };

        private Deque<string> Buffer { get; set; }
        private KeyType LastKey { get; set; }

        public string Expression {

            get {

                var expression = new StringBuilder();

                foreach(var term in Buffer) {

                    expression.Append(term + " ");
                }

                return Nest(expression.ToString().Trim());
            }
        }

        public string Parenthesized { get; set; }

        public ExpressionBuilder() {

            Buffer = new Deque<string>();
            LastKey = KeyType.Empty;
        }

        public ExpressionBuilder(int type) : this() {

            if(type < 0 || type > 5) {

                return;
            }

            var typeTable = new Dictionary<int, KeyType>() {

                { 0, KeyType.Value },
                { 1, KeyType.Unary },
                { 2, KeyType.Binary },
                { 3, KeyType.Left },
                { 4, KeyType.Right },
                { 5, KeyType.Empty },
            };

            LastKey = typeTable[type];
        }

        private string Nest(string expression) {

            return "( " + expression + " )";
        }

        public void AddValue(decimal input) {

            switch(LastKey) {

                case KeyType.Value :
                case KeyType.Right :

                    throw new InvalidOperationException("Operands Must be Separated by Operators.");

                default :

                    Buffer.Add(input.ToString());
                    LastKey = KeyType.Value;

                    break;
            }
        }

        public void AddUnary(string input) {


        }

        public void AddBinary(string input) {


        }

        public void AddParentheses(string input) {


        }
    }
}