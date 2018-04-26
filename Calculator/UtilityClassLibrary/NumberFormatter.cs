using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UtilityClassLibrary {
    public class NumberFormatter : IFormatter {

        private decimal GetInteger(string number) {

            return Math.Truncate(decimal.Parse(number));
        }

        private string GetSign(string number) {

            return Regex.Match(number.Trim(), @"^\D(?=\d*)").Value;
        }

        private string GetDecimals(string number) {

            return Regex.Match(number, @"\.\d*").Value;
        }

        public string Format(string number) {

            string integer = Math.Abs(GetInteger(number)).ToString("N0");

            return GetSign(number) + integer + GetDecimals(number);
        }
    }
}