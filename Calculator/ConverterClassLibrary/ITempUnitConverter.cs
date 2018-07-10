using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterClassLibrary {
    public interface ITempUnitConverter {

        decimal RadianToDegree(decimal radian);
        decimal DegreeToRadian(decimal degree);
        decimal RadianToGradian(decimal radian);
        decimal GradianToRadian(decimal gradian);
        decimal DmsToDegree(decimal dms);
        decimal DegreeToDms(decimal degree);
    }
}