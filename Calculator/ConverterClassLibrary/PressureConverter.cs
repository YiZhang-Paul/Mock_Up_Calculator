using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ConverterClassLibrary {
    public class PressureConverter : UnitConverter {

        protected override string Type { get; set; }
        protected override Dictionary<string, string> Units { get; set; }

        protected override void Initialize() {

            Type = UnitsNet.QuantityType.Pressure.ToString();

            Units = new Dictionary<string, string>() {

                { "atmospheres", UnitsNet.Units.PressureUnit.Atmosphere.ToString() },
                { "bars", UnitsNet.Units.PressureUnit.Bar.ToString() },
                { "kilopascals", UnitsNet.Units.PressureUnit.Kilopascal.ToString() },
                { "millimetres of mercury", UnitsNet.Units.PressureUnit.MillimeterOfMercury.ToString() },
                { "pascals", UnitsNet.Units.PressureUnit.Pascal.ToString() },
                { "pounds per square inch", UnitsNet.Units.PressureUnit.PoundForcePerSquareInch.ToString() }
            };
        }
    }
}