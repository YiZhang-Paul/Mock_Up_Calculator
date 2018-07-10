using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public interface IUnitConverter {

        decimal Convert(string current, decimal value, string target);
    }
}