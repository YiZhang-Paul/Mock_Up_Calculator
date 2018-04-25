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

        public string Format(string number) {

            bool isDecimal = Regex.IsMatch(number, @"\.");
            string integer = isDecimal ? number.Split('.')[0] : number;
            string decimals = isDecimal ? number.Split('.')[1] : "";

            return AddComma(integer) + (isDecimal ? "." : "") + decimals;
        }
    }
}