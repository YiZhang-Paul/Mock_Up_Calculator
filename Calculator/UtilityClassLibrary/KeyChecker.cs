using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UtilityClassLibrary {
    public class KeyChecker : IKeyChecker {

        public bool IsInputKey(string input) {

            return Regex.IsMatch(input, "^([0-9.]|π)$");
        }

        public bool IsActionKey(string input) {

            return Regex.IsMatch(input, "^(CE|C|⌫|=)$");
        }

        public bool IsFunctionKey(string input) {

            return !IsInputKey(input) && !IsActionKey(input) && !IsMemoryKey(input);
        }

        public bool IsMemoryKey(string input) {

            return Regex.IsMatch(input, @"^(MC|MR|M\+|M-|MS|M▾)$");
        }
    }
}