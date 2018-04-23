using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UtilityClassLibrary {
    public class Formatter : IFormatter {

        private string RemoveLeadingComma(string digits) {

            return Regex.Replace(digits, "^,|(?<=-),", "");
        }

        private string AddComma(string digits) {

            var result = new StringBuilder();

            for(int i = digits.Length - 1; i >= 0; i--) {

                bool hasComma = (digits.Length - i) % 3 == 0;
                result.Append(digits[i] + (hasComma ? "," : ""));
            }

            return RemoveLeadingComma(string.Join("", result.ToString().Reverse()));
        }

        public string Format(string digits, bool keepDecimal = false) {

            bool isDecimal = Regex.IsMatch(digits, @"\.");
            string integer = isDecimal ? digits.Split('.')[0] : digits;
            string decimals = isDecimal ? digits.Split('.')[1] : "";

            return AddComma(integer) + (keepDecimal || isDecimal ? "." : "") + decimals;
        }
    }
}