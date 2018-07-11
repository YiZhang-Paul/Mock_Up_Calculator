using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterClassLibrary;

namespace ConverterClassLibrary {
    public class TimeConverter : UnitConverter {

        private Dictionary<string, decimal> Rates { get; set; }

        protected override void Initialize() {

            Rates = new Dictionary<string, decimal>() {

                { "hours", 1 },
                { "microseconds", 3600000000 },
                { "milliseconds", 3600000 },
                { "seconds", 3600 },
                { "minutes", 60 },
                { "days", 1m / 24 },
                { "weeks", 1m / 168 },
                { "years", 1m / 8766 },
            };
        }

        protected override bool IsValidUnit(string unit) {

            return Rates.ContainsKey(unit.ToLower());
        }

        public override decimal Convert(string current, decimal value, string target) {

            if(!IsValidUnit(current) || !IsValidUnit(target)) {

                throw new InvalidOperationException("Invalid Unit.");
            }

            return value / Rates[current.ToLower()] * Rates[target.ToLower()];
        }
    }
}