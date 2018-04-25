using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityClassLibrary {
    public interface IInputBuffer {

        string Content { get; }
        decimal Value { get; }
        bool IsEmpty { get; }
        bool IsDecimal { get; }
        bool IsNegative { get; }

        void Clear();
        void Add(string input);
        void Set(string input);
        void Undo();
        void Negate();
    }
}