using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ConverterClassLibrary {
    public abstract class UnitConverter : IUnitConverter {

        protected abstract string Type { get; set; }
        protected abstract Dictionary<string, string> Units { get; set; }

        public UnitConverter() {

            Initialize();
        }

        protected abstract void Initialize();

        protected virtual bool IsValidUnit(string unit) {

            return Units.ContainsKey(unit.ToLower()) || IsSpecialUnit(unit);
        }

        protected virtual bool IsSpecialUnit(string unit) {

            return false;
        }

        protected virtual bool NeedSpecialConversion(string current, string target) {

            return false;
        }

        //hook for template method
        protected virtual decimal HandleSpecialConversion(string current, decimal value, string target) {

            return 0;
        }

        //template method
        public decimal Convert(string current, decimal value, string target) {

            if(!IsValidUnit(current) || !IsValidUnit(target)) {

                throw new InvalidOperationException("Invalid Unit.");
            }

            if(current.ToLower() == target.ToLower()) {

                return value;
            }

            if(NeedSpecialConversion(current, target)) {

                return HandleSpecialConversion(current, value, target);
            }

            return (decimal)UnitsNet.UnitConverter.ConvertByName(

                value, Type, Units[current.ToLower()], Units[target.ToLower()]
            );
        }
    }
}