﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UtilityClassLibrary {
    public class InputBuffer : IInputBuffer {

        private StringBuilder Buffer { get; set; }

        public string Content { get { return Buffer.ToString(); } }
        public decimal Value { get { return decimal.Parse(Content); } }
        public bool IsEmpty { get; private set; }
        public bool IsDecimal { get { return Regex.IsMatch(Content, @"\."); } }
        public bool IsNegative { get { return Content[0] == '-'; } }

        public InputBuffer() {

            Buffer = new StringBuilder();
            Clear();
        }

        public void Clear() {

            Set("0");
            IsEmpty = true;
        }

        private bool CanAdd(string input) {

            if(!IsDecimal) {
                //decimal type supports numbers up to 28 digits in length
                return input == "." || Content.Length < 28;
            }

            return Content.Split('.')[1].Length < 28;
        }

        public void Add(string input) {

            if(!CanAdd(input)) {

                return;
            }
            //value input will overwrite empty buffer
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
            IsEmpty = false;
        }

        public void Undo() {
            //when buffer has only one digit, undo operation will restore buffer to initial state
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