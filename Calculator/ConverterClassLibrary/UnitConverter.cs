using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public class UnitConverter : IUnitConverter {

        public decimal DegreeToRadian(decimal degree) {

            return degree / 180 * (decimal)Math.PI;
        }

        public decimal RadianToDegree(decimal radian) {

            return radian * 180 / (decimal)Math.PI;
        }

        public decimal DmsToDegree(decimal dms) {

            decimal integer = Math.Abs(Math.Truncate(dms));
            decimal remain = Math.Abs(dms) - integer;
            string tail = remain == 0 ? "0000" : remain.ToString().Substring(2).PadRight(4, '0');
            decimal minute = decimal.Parse(tail.Substring(0, 2));
            decimal second = decimal.Parse(tail.Substring(2, 2));

            return (integer + (minute + second / 60) / 60) * (dms < 0 ? -1 : 1);
        }

        public decimal DegreeToDms(decimal degree) {

            decimal integer = Math.Truncate(degree);
            decimal remain = Math.Abs(degree - integer) * 60;
            decimal minute = Math.Truncate(remain);
            decimal second = Math.Truncate((remain - minute) * 60);
            remain = (remain - minute) * 60 - second;

            return decimal.Parse(string.Join("", new string[] {

                integer.ToString() + ".",
                minute.ToString().PadLeft(2, '0'),
                second.ToString().PadLeft(2, '0'),
                remain.ToString().PadRight(4, '0').Substring(2)
            }));
        }
    }
}