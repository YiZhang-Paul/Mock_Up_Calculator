using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public class OperatorConverter : IOperatorConverter {

        private Dictionary<string, int> Values { get; set; }
        private Dictionary<int, string> Operators { get; set; }
        private HashSet<string> Unary { get; set; }

        public OperatorConverter(string[] operators, HashSet<string> unarys) {

            Initialize(operators, unarys);
        }

        private void Initialize(string[] operators, HashSet<string> unarys) {

            Values = new Dictionary<string, int>();
            Operators = new Dictionary<int, string>();
            Unary = unarys;
            //allows bi-directional conversion between operators and numerical values
            for(int i = 0; i < operators.Length; i++) {

                Values[operators[i]] = i;
                Operators[i] = operators[i];
            }
        }

        public bool IsOperator(string token) {

            return Values.ContainsKey(token);
        }

        public bool IsUnary(string token) {

            return Unary.Contains(token);
        }

        public bool IsBinary(string token) {

            return IsOperator(token) && !IsUnary(token);
        }

        public int ToValue(string token) {
            //use -1 to indicate invalid operator
            if(!IsOperator(token)) {

                return -1;
            }

            return Values[token];
        }

        public string ToOperator(int value) {

            string token = null;
            Operators.TryGetValue(value, out token);

            return token;
        }
    }
}