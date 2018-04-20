using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTreeClassLibrary {
    public class OperatorConverter : IOperatorConverter {

        private string[] _operators = { "+", "-", "*", "/", "%", "!", "^", "log", "ln" };

        private Dictionary<string, int> Values { get; set; }
        private Dictionary<int, string> Operators { get; set; }

        public OperatorConverter() {

            initialize();
        }

        private void initialize() {

            Values = new Dictionary<string, int>();
            Operators = new Dictionary<int, string>();

            for(int i = 0; i < _operators.Length; i++) {

                Values[_operators[i]] = i;
                Operators[i] = _operators[i];
            }
        }

        public bool IsOperator(string token) {

            return Values.ContainsKey(token);
        }

        public int toValue(string token) {

            if(!IsOperator(token)) {

                return -1;
            }

            return Values[token];
        }

        public string toOperator(int value) {

            string token = null;
            Operators.TryGetValue(value, out token);

            return token;
        }
    }
}