using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public class UnitConverter : IUnitConverter {

        public decimal RadianToDegree(decimal radian) {

            return radian / (decimal)Math.PI * 180;
        }

        public decimal DegreeToRadian(decimal degree) {

            return degree / 180 * (decimal)Math.PI;
        }

        public decimal RadianToGradian(decimal radian) {

            return radian / 0.0157075m;
        }

        public decimal GradianToRadian(decimal gradian) {

            return gradian * 0.0157075m;
        }

        private string GetDecimal(decimal decimals, int padding) {

            if(decimals == 0) {

                return string.Empty.PadRight(padding, '0');
            }

            return decimals.ToString().Substring(2).PadRight(padding, '0');
        }

        public decimal DmsToDegree(decimal dms) {

            decimal integer = Math.Abs(Math.Truncate(dms));
            string decimals = GetDecimal(Math.Abs(dms) - integer, 4);
            decimal minute = decimal.Parse(decimals.Substring(0, 2));
            decimal second = decimal.Parse(decimals.Substring(2, 2));

            return (integer + (minute + second / 60) / 60) * (dms < 0 ? -1 : 1);
        }

        public decimal DegreeToDms(decimal degree) {

            decimal integer = Math.Truncate(degree);
            decimal remain = Math.Abs(degree - integer) * 60;
            decimal minute = Math.Truncate(remain);
            decimal second = Math.Truncate((remain - minute) * 60);

            return decimal.Parse(string.Join("", new string[] {

                integer.ToString() + ".",
                minute.ToString().PadLeft(2, '0'),
                second.ToString().PadLeft(2, '0'),
                GetDecimal((remain - minute) * 60 - second, 4)
            }));
        }
    }
}