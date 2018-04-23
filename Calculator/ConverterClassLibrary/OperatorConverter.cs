using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public class OperatorConverter : IOperatorConverter {

        private Dictionary<string, int> Values { get; set; }
        private Dictionary<int, string> Operators { get; set; }
        private HashSet<string> UnaryOperators { get; set; }

        public OperatorConverter(List<string[]> operators) {

            Initialize(operators);
        }

        private void Initialize(List<string[]> operators) {

            Values = new Dictionary<string, int>();
            Operators = new Dictionary<int, string>();
            UnaryOperators = new HashSet<string>(operators.First());

            for(int i = 0, counter = 0; i < operators.Count; i++) {

                for(int j = 0; j < operators[i].Length; j++, counter++) {

                    Values[operators[i][j]] = counter;
                    Operators[counter] = operators[i][j];
                }
            }
        }

        public bool IsOperator(string token) {

            return Values.ContainsKey(token);
        }

        public bool IsUnary(string token) {

            return UnaryOperators.Contains(token);
        }

        public bool IsBinary(string token) {

            if(!IsOperator(token)) {

                return false;
            }

            return !IsUnary(token);
        }

        public int ToValue(string token) {

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