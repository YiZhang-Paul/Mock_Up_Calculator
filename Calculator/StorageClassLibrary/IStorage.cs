using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageClassLibrary {
    public interface IStorage<T> {

        int Size { get; }
        T Last { get; }

        void Clear();
        void Store(T item);
        void Remove(int index);
    }
}