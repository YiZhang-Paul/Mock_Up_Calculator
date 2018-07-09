using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public class ExpressionBuilder : IExpressionBuilder {

        private enum KeyType { Value, Unary, Binary, Left, Right, Empty };

        private Deque<string> Buffer { get; set; }
        private Deque<KeyType> KeyHistory { get; set; }
        private IParenthesize Parenthesizer { get; set; }

        public string Expression { get { return string.Join(" ", Buffer); } }

        public ExpressionBuilder(IParenthesize parenthesizer) {

            Buffer = new Deque<string>();
            KeyHistory = new Deque<KeyType>() { KeyType.Empty };
            Parenthesizer = parenthesizer;
        }

        //constructor used for testing purpose only
        public ExpressionBuilder(

            IParenthesize parenthesizer,
            string expression,
            int type

        ) : this(parenthesizer) {

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

            KeyHistory.Add(typeTable[type]);
        }

        public void Clear() {

            Buffer.Clear();
            KeyHistory = new Deque<KeyType>() { KeyType.Empty };
        }

        public void Undo() {

            Buffer.RemoveBack();
            KeyHistory.RemoveBack();
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

        public bool CanAddValue() {
            //value input after another value, unary operators or right parenthesis is not allowed
            var invalidTypes = new HashSet<KeyType>() {

                KeyType.Value,
                KeyType.Unary,
                KeyType.Right
            };

            return !invalidTypes.Contains(KeyHistory.Last());
        }

        public void AddValue(decimal input) {

            if(!CanAddValue()) {

                throw new InvalidOperationException("Operands Must be Separated by Operators.");
            }

            Buffer.Add(input.ToString());
            KeyHistory.Add(KeyType.Value);
        }

        public void AddUnary(string input) {
            //unary operator input cannot follow binary operators
            if(KeyHistory.Last() == KeyType.Binary) {

                throw new InvalidOperationException("Missing Operand.");
            }
            /*
             * when unary operator input follows left parenthesis or nothing,
             * a value of zero will be added as default operand
             */
            if(KeyHistory.Last() == KeyType.Left || KeyHistory.Last() == KeyType.Empty) {

                AddValue(0);
            }

            Buffer.Add(input);
            KeyHistory.Add(KeyType.Unary);
        }

        public void AddBinary(string input) {
            //consecutive binary operator input is not allowed
            if(KeyHistory.Last() == KeyType.Binary) {

                throw new InvalidOperationException("Missing Operand.");
            }
            /*
             * when binary operator input follows left parenthesis or nothing,
             * a value of zero will be added as default operand
             */
            if(KeyHistory.Last() == KeyType.Left || KeyHistory.Last() == KeyType.Empty) {

                AddValue(0);
            }

            Buffer.Add(input);
            KeyHistory.Add(KeyType.Binary);
        }

        private void AddLeftParenthesis(string input) {
            //left parenthesis cannot immediately follow a value or unary operator
            if(KeyHistory.Last() == KeyType.Value || KeyHistory.Last() == KeyType.Unary) {

                throw new InvalidOperationException("Missing Operators.");
            }
            //left parenthesis cannot immediately follow right parenthesis
            if(KeyHistory.Last() == KeyType.Right) {

                throw new InvalidOperationException("Mismatched Parentheses.");
            }

            Buffer.Add(input);
            KeyHistory.Add(KeyType.Left);
        }

        private void AddRightParenthesis(string input) {
            //right parenthesis cannot immediately follow binary operator
            if(KeyHistory.Last() == KeyType.Binary) {

                throw new InvalidOperationException("Missing Operand.");
            }
            //parentheses must match
            if(MissingParentheses(Expression) < 1) {

                throw new InvalidOperationException("Mismatched Parentheses.");
            }

            if(KeyHistory.Last() == KeyType.Left) {

                AddValue(0);
            }

            Buffer.Add(input);
            KeyHistory.Add(KeyType.Right);
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