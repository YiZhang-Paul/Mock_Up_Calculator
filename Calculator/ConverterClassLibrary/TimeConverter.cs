using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterClassLibrary;
using UnitsNet;

namespace ConverterClassLibrary {
    public class TimeConverter : UnitConverter {

        private string Type { get; set; }
        private Dictionary<string, string> Units { get; set; }

        protected override void Initialize() {

            Type = UnitsNet.QuantityType.Duration.ToString();

            Units = new Dictionary<string, string>() {

                { "microseconds", UnitsNet.Units.DurationUnit.Microsecond.ToString() },
                { "milliseconds", UnitsNet.Units.DurationUnit.Millisecond.ToString() },
                { "seconds", UnitsNet.Units.DurationUnit.Second.ToString() },
                { "minutes", UnitsNet.Units.DurationUnit.Minute.ToString() },
                { "hours", UnitsNet.Units.DurationUnit.Hour.ToString() },
                { "days", UnitsNet.Units.DurationUnit.Day.ToString() },
                { "weeks", UnitsNet.Units.DurationUnit.Week.ToString() },
                { "years", UnitsNet.Units.DurationUnit.Year365.ToString() }
            };
        }

        protected override bool IsValidUnit(string unit) {

            return Units.ContainsKey(unit.ToLower());
        }

        public override decimal Convert(string current, decimal value, string target) {

            if(!IsValidUnit(current) || !IsValidUnit(target)) {

                throw new InvalidOperationException("Invalid Unit.");
            }

            current = Units[current.ToLower()];
            target = Units[target.ToLower()];

            return (decimal)UnitsNet.UnitConverter.ConvertByName(value, Type, current, target);
        }
    }
}