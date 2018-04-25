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
        public static string Sine { get { return "sin"; } }
        public static string Cosine { get { return "cos"; } }
        public static string Tangent { get { return "tan"; } }
        public static string Sinh { get { return "sinh"; } }
        public static string Cosh { get { return "cosh"; } }
        public static string Tanh { get { return "tanh"; } }
        public static string ArcSin { get { return "sin⁻¹"; } }
        public static string ArcCos { get { return "cos⁻¹"; } }
        public static string ArcTan { get { return "tan⁻¹"; } }
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

        public static List<string[]> Operators {

            get {

                return new List<string[]>() {

                    new string[] {

                        SquareRoot, Square, Cube,
                        Exponential, Factorial, Log,
                        Ln, Dms, Degrees, Negate,
                        Reciprocal, PowerOfTen,
                        Sine, Cosine, Tangent,
                        Sinh, Cosh, Tanh,
                        ArcSin, ArcCos, ArcTan,
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