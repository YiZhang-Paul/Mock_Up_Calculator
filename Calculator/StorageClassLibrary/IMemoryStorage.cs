using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageClassLibrary {
    public interface IMemoryStorage : IStorage<decimal> {

        decimal[] Values { get; }

        decimal Retrieve(int key);
        void Plus(int key, decimal value);
        void Minus(int key, decimal value);
    }
}