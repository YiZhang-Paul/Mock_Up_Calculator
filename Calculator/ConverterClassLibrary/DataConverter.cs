using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ConverterClassLibrary {
    public class DataConverter : UnitConverter {

        protected override string Type { get; set; }
        protected override Dictionary<string, string> Units { get; set; }

        protected override void Initialize() {

            Type = UnitsNet.QuantityType.BitRate.ToString();

            Units = new Dictionary<string, string>() {

                { "bits", UnitsNet.Units.BitRateUnit.BitPerSecond.ToString() },
                { "bytes", UnitsNet.Units.BitRateUnit.BytePerSecond.ToString() },
                { "kilobits", UnitsNet.Units.BitRateUnit.KilobitPerSecond.ToString() },
                { "kibibits", UnitsNet.Units.BitRateUnit.KibibitPerSecond.ToString() },
                { "kilobytes", UnitsNet.Units.BitRateUnit.KilobytePerSecond.ToString() },
                { "kibibytes", UnitsNet.Units.BitRateUnit.KibibytePerSecond.ToString() },
                { "megabits", UnitsNet.Units.BitRateUnit.MegabitPerSecond.ToString() },
                { "mebibits", UnitsNet.Units.BitRateUnit.MebibitPerSecond.ToString() },
                { "megabytes", UnitsNet.Units.BitRateUnit.MegabytePerSecond.ToString() },
                { "mebibytes", UnitsNet.Units.BitRateUnit.MebibytePerSecond.ToString() },
                { "gigabits", UnitsNet.Units.BitRateUnit.GigabitPerSecond.ToString() },
                { "gibibits", UnitsNet.Units.BitRateUnit.GibibitPerSecond.ToString() },
                { "gigabytes", UnitsNet.Units.BitRateUnit.GigabytePerSecond.ToString() },
                { "gibibytes", UnitsNet.Units.BitRateUnit.GibibytePerSecond.ToString() },
                { "terabits", UnitsNet.Units.BitRateUnit.TerabitPerSecond.ToString() },
                { "tebibits", UnitsNet.Units.BitRateUnit.TebibitPerSecond.ToString() },
                { "terabytes", UnitsNet.Units.BitRateUnit.TerabytePerSecond.ToString() },
                { "tebibytes", UnitsNet.Units.BitRateUnit.TebibytePerSecond.ToString() },
                { "petabits", UnitsNet.Units.BitRateUnit.PetabitPerSecond.ToString() },
                { "pebibits", UnitsNet.Units.BitRateUnit.PebibitPerSecond.ToString() },
                { "petabytes", UnitsNet.Units.BitRateUnit.PetabytePerSecond.ToString() },
                { "pebibytes", UnitsNet.Units.BitRateUnit.PebibytePerSecond.ToString() },
                { "exabits", UnitsNet.Units.BitRateUnit.ExabitPerSecond.ToString() },
                { "exbibits", UnitsNet.Units.BitRateUnit.ExbibitPerSecond.ToString() },
                { "exabytes", UnitsNet.Units.BitRateUnit.ExabytePerSecond.ToString() },
                { "exbibytes", UnitsNet.Units.BitRateUnit.ExbibytePerSecond.ToString() }
            };
        }
    }
}