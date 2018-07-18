using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ConverterClassLibrary {
    public class TemperatureConverter : UnitConverter {

        private string Type { get; set; }
        private Dictionary<string, string> Units { get; set; }

        protected override void Initialize() {

            Type = UnitsNet.QuantityType.Temperature.ToString();

            Units = new Dictionary<string, string>() {

                { "celsius", UnitsNet.Units.TemperatureUnit.DegreeCelsius.ToString() },
                { "fahrenheit", UnitsNet.Units.TemperatureUnit.DegreeFahrenheit.ToString() },
                { "kelvin", UnitsNet.Units.TemperatureUnit.Kelvin.ToString() }
            };
        }

        protected override bool IsValidUnit(string unit) {

            return Units.ContainsKey(unit.ToLower());
        }

        public override decimal Convert(string current, decimal value, string target) {

            if(!IsValidUnit(current) || !IsValidUnit(target)) {

                throw new InvalidOperationException("Invalid Unit.");
            }

            if(current.ToLower() == target.ToLower()) {

                return value;
            }

            current = Units[current.ToLower()];
            target = Units[target.ToLower()];

            return (decimal)UnitsNet.UnitConverter.ConvertByName(value, Type, current, target);
        }
    }
}