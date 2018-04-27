using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public class OperatorLookup {

        public static string SquareRoot { get { return "√"; } }
        public static string Square { get { return "sqr"; } }
        public static string Cube { get { return "cube"; } }
        public static string Exponential { get { return "eˣ"; } }
        public static string Factorial { get { return "fact"; } }
        public static string Log { get { return "log"; } }
        public static string Ln { get { return "ln"; } }
        public static string Dms { get { return "dms"; } }
        public static string Degrees { get { return "degrees"; } }
        public static string Negate { get { return "negate"; } }
        public static string Reciprocal { get { return "¹⁄x"; } }
        public static string PowerOfTen { get { return "10ˣ"; } }
        public static string SineDEG { get { return "sin₀"; } }
        public static string SineRAD { get { return "sinᵣ"; } }
        public static string SineGRAD { get { return "sin₉"; } }
        public static string CosineDEG { get { return "cos₀"; } }
        public static string CosineRAD { get { return "cosᵣ"; } }
        public static string CosineGRAD { get { return "cos₉"; } }
        public static string TangentDEG { get { return "tan₀"; } }
        public static string TangentRAD { get { return "tanᵣ"; } }
        public static string TangentGRAD { get { return "tan₉"; } }
        public static string ArcSinDEG { get { return "sin₀⁻¹"; } }
        public static string ArcSinRAD { get { return "sinᵣ⁻¹"; } }
        public static string ArcSinGRAD { get { return "sin₉⁻¹"; } }
        public static string ArcCosDEG { get { return "cos₀⁻¹"; } }
        public static string ArcCosRAD { get { return "cosᵣ⁻¹"; } }
        public static string ArcCosGRAD { get { return "cos₉⁻¹"; } }
        public static string ArcTanDEG { get { return "tan₀⁻¹"; } }
        public static string ArcTanRAD { get { return "tanᵣ⁻¹"; } }
        public static string ArcTanGRAD { get { return "tan₉⁻¹"; } }
        public static string Sinh { get { return "sinh"; } }
        public static string Cosh { get { return "cosh"; } }
        public static string Tanh { get { return "tanh"; } }
        public static string ArcSinh { get { return "sinh⁻¹"; } }
        public static string ArcCosh { get { return "cosh⁻¹"; } }
        public static string ArcTanh { get { return "tanh⁻¹"; } }
        public static string Power { get { return "^"; } }
        public static string Exp { get { return "Exp"; } }
        public static string NthRoot { get { return "yroot"; } }
        public static string Multiply { get { return "×"; } }
        public static string Divide { get { return "÷"; } }
        public static string Modulus { get { return "Mod"; } }
        public static string Plus { get { return "+"; } }
        public static string Minus { get { return "−"; } }
        public static string PI { get { return "π"; } }

        public static List<string[]> Operators {

            get {

                return new List<string[]>() {

                    new string[] {

                        SquareRoot, Square, Cube,
                        Exponential, Factorial, Log,
                        Ln, Dms, Degrees, Negate,
                        Reciprocal, PowerOfTen,
                        SineDEG, SineRAD, SineGRAD,
                        CosineDEG, CosineRAD, CosineGRAD,
                        TangentDEG, TangentRAD, TangentGRAD,
                        ArcSinDEG, ArcSinRAD, ArcSinGRAD,
                        ArcCosDEG, ArcCosRAD, ArcCosGRAD,
                        ArcTanDEG, ArcTanRAD, ArcTanGRAD,
                        Sinh, Cosh, Tanh,
                        ArcSinh, ArcCosh, ArcTanh
                    },

                    new string[] { Power, Exp, NthRoot },
                    new string[] { Multiply, Divide, Modulus },
                    new string[] { Plus, Minus }
                };
            }
        }
    }
}