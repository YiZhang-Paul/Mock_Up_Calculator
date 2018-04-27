using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UtilityClassLibrary {
    public class EngineeringFormatter : IFormatter {

        private string RemoveLeadZero(string number) {

            return Regex.Replace(number, @"0*e", "e");
        }

        private string RemoveTrailZero(string number) {

            bool isDigit = Regex.IsMatch(number, @"\+0*$");

            return Regex.Replace(number, @"\+0*", isDigit ? "+0" : "+");
        }

        public string Format(string number) {

            string result = RemoveLeadZero(decimal.Parse(number).ToString("e"));

            return RemoveTrailZero(result);
        }
    }
}