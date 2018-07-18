using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ConverterClassLibrary {
    public class TemperatureConverter : UnitConverter {

        protected override string Type { get; set; }
        protected override Dictionary<string, string> Units { get; set; }

        protected override void Initialize() {

            Type = UnitsNet.QuantityType.Temperature.ToString();

            Units = new Dictionary<string, string>() {

                { "celsius", UnitsNet.Units.TemperatureUnit.DegreeCelsius.ToString() },
                { "fahrenheit", UnitsNet.Units.TemperatureUnit.DegreeFahrenheit.ToString() },
                { "kelvin", UnitsNet.Units.TemperatureUnit.Kelvin.ToString() }
            };
        }
    }
}