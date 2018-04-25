using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UtilityClassLibrary {
    public class InputBuffer : IInputBuffer {

        private StringBuilder Buffer { get; set; }
        private IFormatter Formatter { get; set; }
        private string Content { get { return Buffer.ToString(); } }

        public bool IsEmpty { get; private set; }
        public bool IsDecimal { get { return Regex.IsMatch(Content, @"\."); } }
        public bool IsNegative { get { return Content[0] == '-'; } }
        public decimal Value { get { return decimal.Parse(Content); } }
        public string Formatted { get { return Formatter.Format(Content, IsDecimal); } }

        public InputBuffer(IFormatter formatter) {

            Buffer = new StringBuilder();
            Formatter = formatter;
            Clear();
        }

        public void Clear() {

            Set("0");
            IsEmpty = true;
        }

        public void Add(string input) {

            if(Content.Length >= (IsDecimal ? 30 : 29)) {

                return;
            }

            if(Content == "0") {

                Set(input == "." ? "0." : input);
            }
            else if(input != "." || !IsDecimal) {

                Buffer.Append(input);
            }

            IsEmpty = false;
        }

        public void Set(string input) {

            Buffer.Clear();
            Buffer.Append(input);
        }

        public void Undo() {

            if(!IsDecimal && Math.Abs(Value).ToString().Length == 1) {

                Clear();
            }
            else {

                Buffer.Remove(Buffer.Length - 1, 1);
            }
        }

        public void Negate() {

            Set(IsNegative ? Content.Substring(1) : "-" + Content);
        }
    }
}