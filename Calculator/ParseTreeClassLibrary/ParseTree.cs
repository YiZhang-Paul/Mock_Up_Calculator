using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTreeClassLibrary {
    public class ParseTree : IParseTree {

        private INode Root { get; set; }

        public ParseTree() {

            Root = new Node();
        }

        public void Clear() {

            Root = new Node();
        }

        private string[] GetTokens(string expression) {

            return expression.Split(' ').Where(token => token != " ").ToArray();
        }

        public void Parse(string expression) {

        }

        public decimal Evaluate() {

            return -1;
        }
    }
}