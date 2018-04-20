using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityClassLibrary {
    public interface IInputBuffer {

        bool IsEmpty { get; }
        bool IsDecimal { get; }
        bool IsNegative { get; }
        decimal Value { get; }
        string Formatted { get; }

        void Clear();
        void Add(string input);
        void Set(string input);
        void Undo();
        void Negate();
    }
}