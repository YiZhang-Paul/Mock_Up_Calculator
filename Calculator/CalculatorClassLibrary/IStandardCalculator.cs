using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClassLibrary {
    public interface IStandardCalculator : ICalculator {

        decimal LastResult { get; }
        string Expression { get; }
        decimal[] MemoryValues { get; }

        void MemoryClear();
        void MemoryRemove(int key);
        void MemoryRecall();
        void MemoryRetrieve(int key);
        void MemoryStore(decimal value);
        void MemoryPlus(int key, decimal value);
        void MemoryMinus(int key, decimal value);
        void ClearInput();
        bool IsSpecialKey(string input);
    }
}