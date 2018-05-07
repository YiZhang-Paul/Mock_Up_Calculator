using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public interface IOperatorLookup {

        string SquareRoot { get; }
        string Square { get; }
        string Cube { get; }
        string Exponential { get; }
        string Factorial { get; }
        string Log { get; }
        string Ln { get; }
        string Dms { get; }
        string Degrees { get; }
        string Negate { get; }
        string Reciprocal { get; }
        string PowerOfTen { get; }
        string SineDEG { get; }
        string SineRAD { get; }
        string SineGRAD { get; }
        string CosineDEG { get; }
        string CosineRAD { get; }
        string CosineGRAD { get; }
        string TangentDEG { get; }
        string TangentRAD { get; }
        string TangentGRAD { get; }
        string ArcSinDEG { get; }
        string ArcSinRAD { get; }
        string ArcSinGRAD { get; }
        string ArcCosDEG { get; }
        string ArcCosRAD { get; }
        string ArcCosGRAD { get; }
        string ArcTanDEG { get; }
        string ArcTanRAD { get; }
        string ArcTanGRAD { get; }
        string Sinh { get; }
        string Cosh { get; }
        string Tanh { get; }
        string ArcSinh { get; }
        string ArcCosh { get; }
        string ArcTanh { get; }
        string Power { get; }
        string Exp { get; }
        string NthRoot { get; }
        string Multiply { get; }
        string Divide { get; }
        string Modulus { get; }
        string Plus { get; }
        string Minus { get; }
        string PI { get; }

        List<string[]> Precedence { get; }
        string[] Operators { get; }
        HashSet<string> Unary { get; }
    }
}