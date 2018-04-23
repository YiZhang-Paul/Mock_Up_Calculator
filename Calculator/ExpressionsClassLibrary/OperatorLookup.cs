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
        public static string Reciprocal { get { return "¹⁄ x"; } }
        public static string Sine { get { return "sin"; } }
        public static string Cosine { get { return "cos"; } }
        public static string Tangent { get { return "tan"; } }
        public static string HyperbolicSine { get { return "sinh"; } }
        public static string HyperbolicCosine { get { return "cosh"; } }
        public static string HyperbolicTangent { get { return "tanh"; } }
        public static string InverseSine { get { return "sin⁻¹"; } }
        public static string InverseCosine { get { return "cos⁻¹"; } }
        public static string InverseTangent { get { return "tan⁻¹"; } }
        public static string InverseHyperbolicSine { get { return "sinh⁻¹"; } }
        public static string InverseHyperbolicCosine { get { return "cosh⁻¹"; } }
        public static string InverseHyperbolicTangent { get { return "tanh⁻¹"; } }
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

                        SquareRoot, Square, Cube, Exponential,
                        Factorial, Log, Ln, Dms, Degrees, Negate,
                        Reciprocal, Sine, Cosine, Tangent, HyperbolicSine,
                        HyperbolicCosine, HyperbolicTangent, InverseSine,
                        InverseCosine, InverseTangent, InverseHyperbolicSine,
                        InverseHyperbolicCosine, InverseHyperbolicTangent
                    },

                    new string[] { Power, Exp, NthRoot },
                    new string[] { Multiply, Divide, Modulus },
                    new string[] { Plus, Minus }
                };
            }
        }
    }
}