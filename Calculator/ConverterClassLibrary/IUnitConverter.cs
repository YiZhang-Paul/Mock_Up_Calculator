using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public interface IUnitConverter {

        decimal DegreeToRadian(decimal degree);
        decimal RadianToDegree(decimal radian);
        decimal DmsToDegree(decimal dms);
        decimal DegreeToDms(decimal degree);
    }
}