using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsClassLibrary {
    public class OperatorLookup : IOperatorLookup {

        #region List of Supported Operators
        public string SquareRoot { get { return "√"; } }
        public string Square { get { return "sqr"; } }
        public string Cube { get { return "cube"; } }
        public string Exponential { get { return "eˣ"; } }
        public string Factorial { get { return "fact"; } }
        public string Log { get { return "log"; } }
        public string Ln { get { return "ln"; } }
        public string Dms { get { return "dms"; } }
        public string Degrees { get { return "degrees"; } }
        public string Negate { get { return "negate"; } }
        public string Reciprocal { get { return "¹⁄x"; } }
        public string PowerOfTen { get { return "10ˣ"; } }
        public string SineDEG { get { return "sin₀"; } }
        public string SineRAD { get { return "sinᵣ"; } }
        public string SineGRAD { get { return "sin₉"; } }
        public string CosineDEG { get { return "cos₀"; } }
        public string CosineRAD { get { return "cosᵣ"; } }
        public string CosineGRAD { get { return "cos₉"; } }
        public string TangentDEG { get { return "tan₀"; } }
        public string TangentRAD { get { return "tanᵣ"; } }
        public string TangentGRAD { get { return "tan₉"; } }
        public string ArcSinDEG { get { return "sin₀⁻¹"; } }
        public string ArcSinRAD { get { return "sinᵣ⁻¹"; } }
        public string ArcSinGRAD { get { return "sin₉⁻¹"; } }
        public string ArcCosDEG { get { return "cos₀⁻¹"; } }
        public string ArcCosRAD { get { return "cosᵣ⁻¹"; } }
        public string ArcCosGRAD { get { return "cos₉⁻¹"; } }
        public string ArcTanDEG { get { return "tan₀⁻¹"; } }
        public string ArcTanRAD { get { return "tanᵣ⁻¹"; } }
        public string ArcTanGRAD { get { return "tan₉⁻¹"; } }
        public string Sinh { get { return "sinh"; } }
        public string Cosh { get { return "cosh"; } }
        public string Tanh { get { return "tanh"; } }
        public string ArcSinh { get { return "sinh⁻¹"; } }
        public string ArcCosh { get { return "cosh⁻¹"; } }
        public string ArcTanh { get { return "tanh⁻¹"; } }
        public string Power { get { return "^"; } }
        public string Exp { get { return "Exp"; } }
        public string NthRoot { get { return "yroot"; } }
        public string Multiply { get { return "×"; } }
        public string Divide { get { return "÷"; } }
        public string Modulus { get { return "Mod"; } }
        public string Plus { get { return "+"; } }
        public string Minus { get { return "−"; } }
        public string PI { get { return "π"; } }
        #endregion

        public List<string[]> Precedence {

            get {
                //operator precedence from highest to lowest
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

        public string[] Operators {

            get {

                return Precedence.Aggregate(new List<string>(), (all, group) => {

                    all.AddRange(group);

                    return all;

                }).ToArray();
            }
        }

        public HashSet<string> Unary {

            get {

                return new HashSet<string>(Precedence.First());
            }
        }
    }
}