using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ExpressionsClassLibrary;
using ConverterClassLibrary;
using StorageClassLibrary;
using UtilityClassLibrary;

namespace CalculatorClassLibrary {
    public class ScientificCalculator : StandardCalculator, IScientificCalculator {

        public int AngularUnit { get; private set; }

        public ScientificCalculator(

            IInputBuffer buffer,
            IOperatorLookup lookup,
            IUnitConverter unitConverter,
            IOperatorConverter operatorConverter,
            IExpressionBuilder builder,
            IExpressionParser parser,
            IEvaluate evaluator,
            IMemoryStorage memory

        ) : base(

            buffer,
            lookup,
            unitConverter,
            operatorConverter,
            builder,
            parser,
            evaluator,
            memory

        ) { }

        public void ChangeAngularUnit() {

            AngularUnit = (AngularUnit + 1) % 3;
        }

        private bool IsTrigonometricKey(string input) {

            return Regex.IsMatch(input, "(sin|cos|tan)(?!h)");
        }

        private string GetAngularNotation() {

            if(AngularUnit == 0) {

                return "₀";
            }

            return AngularUnit == 1 ? "ᵣ" : "₉";
        }

        public string CheckTrigonometricKey(string input) {

            if(!IsTrigonometricKey(input)) {

                return input;
            }

            return Regex.Replace(input, "(sin|cos|tan)(?!₀|ᵣ|₉|h)", match => {

                return match.Value + GetAngularNotation();
            });
        }
    }
}