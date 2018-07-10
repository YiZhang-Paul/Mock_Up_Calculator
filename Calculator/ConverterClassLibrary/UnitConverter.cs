using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public abstract class UnitConverter : IUnitConverter {

        public UnitConverter() {

            Initialize();
        }

        protected abstract void Initialize();

        protected abstract bool IsValidUnit(string unit);

        public abstract decimal Convert(string current, decimal value, string target);
    }
}