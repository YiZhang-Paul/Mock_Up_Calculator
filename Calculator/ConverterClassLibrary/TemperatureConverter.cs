using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public class TemperatureConverter : UnitConverter {

        private Dictionary<string, Dictionary<string, Func<decimal, decimal>>> Formulas { get; set; }

        protected override void Initialize() {

            var fahrenheitTable = new Dictionary<string, Func<decimal, decimal>>() {

                { "celsius", FahrenheitToCelsius },
                { "kelvin", FahrenheitToKelvin }
            };

            var celsiusTable = new Dictionary<string, Func<decimal, decimal>>() {

                { "fahrenheit", CelsiusToFahrenheit },
                { "kelvin", CelsiusToKelvin }
            };

            var kelvinTable = new Dictionary<string, Func<decimal, decimal>>() {

                { "fahrenheit", KelvinToFahrenheit },
                { "celsius", KelvinToCelsius }
            };

            Formulas = new Dictionary<string, Dictionary<string, Func<decimal, decimal>>>() {

                { "fahrenheit", fahrenheitTable },
                { "celsius", celsiusTable },
                { "kelvin", kelvinTable }
            };
        }

        protected override bool IsValidUnit(string unit) {

            return Formulas.ContainsKey(unit.ToLower());
        }

        private decimal FahrenheitToCelsius(decimal fahrenheit) {

            return (fahrenheit - 32) * 5 / 9;
        }

        private decimal FahrenheitToKelvin(decimal fahrenheit) {

            return (fahrenheit - 32) * 5 / 9 + 273.15m;
        }

        private decimal CelsiusToFahrenheit(decimal celsius) {

            return (celsius * 9 / 5) + 32;
        }

        private decimal CelsiusToKelvin(decimal celsius) {

            return celsius + 273.15m;
        }

        private decimal KelvinToFahrenheit(decimal kelvin) {

            return (kelvin - 273.15m) * 9 / 5 + 32;
        }

        private decimal KelvinToCelsius(decimal kelvin) {

            return kelvin - 273.15m;
        }

        public override decimal Convert(string current, decimal value, string target) {

            if(!IsValidUnit(current) || !IsValidUnit(target)) {

                throw new InvalidOperationException("Invalid Unit.");
            }

            if(current.ToLower() == target.ToLower()) {

                return value;
            }

            return Formulas[current.ToLower()][target.ToLower()](value);
        }
    }
}