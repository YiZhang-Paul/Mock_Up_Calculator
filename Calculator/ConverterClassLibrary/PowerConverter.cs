using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ConverterClassLibrary {
    public class PowerConverter : UnitConverter {

        protected override string Type { get; set; }
        protected override Dictionary<string, string> Units { get; set; }

        protected override void Initialize() {

            Type = UnitsNet.QuantityType.Power.ToString();

            Units = new Dictionary<string, string>() {

                { "watts", UnitsNet.Units.PowerUnit.Watt.ToString() },
                { "kilowatts", UnitsNet.Units.PowerUnit.Kilowatt.ToString() },
                { "horsepower (us)", UnitsNet.Units.PowerUnit.MechanicalHorsepower.ToString() }
            };
        }

        protected override bool IsSpecialUnit(string unit) {

            return unit.ToLower() == "foot-pounds/minute" || unit.ToLower() == "btus/minute";
        }

        protected override bool NeedSpecialConversion(string current, string target) {

            return IsSpecialUnit(current) || IsSpecialUnit(target);
        }

        private decimal BTUsPerMinuteToWatts(decimal value) {

            string current = UnitsNet.Units.PowerUnit.BritishThermalUnitPerHour.ToString();
            string target = Units["watts"];

            return (decimal)UnitsNet.UnitConverter.ConvertByName(value * 60, Type, current, target);
        }

        private decimal WattsToBTUsPerMinute(decimal value) {

            string current = Units["watts"];
            string target = UnitsNet.Units.PowerUnit.BritishThermalUnitPerHour.ToString();

            return (decimal)UnitsNet.UnitConverter.ConvertByName(value, Type, current, target) / 60;
        }

        private decimal FootPoundsPerMinuteToWatts(decimal value) {

            return value / 60 * 1.355817948m;
        }

        private decimal WattsToFootPoundsPerMinute(decimal value) {

            return value / 1.355817948m * 60;
        }

        private decimal ToWatts(string current, decimal value) {

            if(!IsSpecialUnit(current)) {

                current = Units[current.ToLower()];

                return (decimal)UnitsNet.UnitConverter.ConvertByName(value, Type, current, Units["watts"]);
            }

            if(current.ToLower() == "btus/minute") {

                return BTUsPerMinuteToWatts(value);
            }

            return FootPoundsPerMinuteToWatts(value);
        }

        private decimal FromWatts(string target, decimal value) {

            if(!IsSpecialUnit(target)) {

                target = Units[target.ToLower()];

                return (decimal)UnitsNet.UnitConverter.ConvertByName(value, Type, Units["watts"], target);
            }

            if(target.ToLower() == "btus/minute") {

                return WattsToBTUsPerMinute(value);
            }

            return WattsToFootPoundsPerMinute(value);
        }

        protected override decimal HandleSpecialConversion(string current, decimal value, string target) {

            return FromWatts(target, ToWatts(current, value));
        }
    }
}