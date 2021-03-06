﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ConverterClassLibrary {
    public class AngleConverter : UnitConverter {

        protected override string Type { get; set; }
        protected override Dictionary<string, string> Units { get; set; }

        protected override void Initialize() {

            Type = UnitsNet.QuantityType.Angle.ToString();

            Units = new Dictionary<string, string>() {

                { "radians", UnitsNet.Units.AngleUnit.Radian.ToString() },
                { "degrees", UnitsNet.Units.AngleUnit.Degree.ToString() },
                { "gradians", UnitsNet.Units.AngleUnit.Gradian.ToString() }
            };
        }

        protected override bool IsSpecialUnit(string unit) {

            return unit.ToLower() == "dms" || unit.ToLower() == "degrees";
        }

        protected override bool NeedSpecialConversion(string current, string target) {

            return IsSpecialUnit(current) && IsSpecialUnit(target);
        }

        private string GetDecimal(decimal decimals, int padding) {

            if(decimals == 0) {

                return string.Empty.PadRight(padding, '0');
            }

            return decimals.ToString().Substring(2).PadRight(padding, '0');
        }

        private decimal DmsToDegree(decimal dms) {

            decimal integer = Math.Abs(Math.Truncate(dms));
            string decimals = GetDecimal(Math.Abs(dms) - integer, 4);
            decimal minute = decimal.Parse(decimals.Substring(0, 2));
            decimal second = decimal.Parse(decimals.Substring(2, 2));

            return (integer + (minute + second / 60) / 60) * (dms < 0 ? -1 : 1);
        }

        private decimal DegreeToDms(decimal degree) {

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

        protected override decimal HandleSpecialConversion(string current, decimal value, string target) {

            return current.ToLower() == "dms" ? DmsToDegree(value) : DegreeToDms(value);
        }
    }
}