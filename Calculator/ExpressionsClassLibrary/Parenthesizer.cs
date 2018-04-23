using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public class Parenthesizer : IParenthesize {

        private List<HashSet<string>> Precedence { get; set; }

        public Parenthesizer() {

            SetPrecedence();
        }

        private void SetPrecedence() {

            Precedence = new List<HashSet<string>>();

            Precedence.Add(new HashSet<string>() {

                "√", "¹⁄ x", "eˣ", "sqr", "cube",
                "fact", "log", "ln", "dms", "degrees", "negate",
                "sin", "cos", "tan", "sinh", "cosh", "tanh",
                "sin⁻¹", "cos⁻¹", "tan⁻¹", "sinh⁻¹", "cosh⁻¹", "tanh⁻¹"
            });

            Precedence.Add(new HashSet<string>() {

                "^", "Exp", "yroot"
            });

            Precedence.Add(new HashSet<string>() {

                "×", "÷", "Mod"
            });

            Precedence.Add(new HashSet<string>() {

                "+", "−"
            });
        }

        private string[] Tokenize(string expression) {

            return null;
        }

        public string Parenthesize(string expression) {

            return "";
        }
    }
}