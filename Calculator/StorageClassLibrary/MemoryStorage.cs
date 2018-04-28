using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageClassLibrary {
    public class MemoryStorage : IMemoryStorage {

        private List<decimal> Buffer { get; set; }

        public int Size { get { return Buffer.Count; } }
        public decimal Last { get { return Size == 0 ? 0 : Buffer.Last(); } }
        public decimal[] Values { get { return Buffer.ToArray(); } }

        public MemoryStorage() {

            Buffer = new List<decimal>();
        }

        public MemoryStorage(IEnumerable<decimal> values) : this() {

            foreach(var value in values) {

                Store(value);
            }
        }

        public void Clear() {

            Buffer.Clear();
        }

        public void Store(decimal value) {

            Buffer.Add(value);
        }

        public void Remove(int key) {

            Buffer.RemoveAt(key);
        }

        public decimal Retrieve(int key) {

            return Buffer[key];
        }

        public void Plus(int key, decimal value) {

            Buffer[key] += value;
        }

        public void Minus(int key, decimal value) {

            Buffer[key] -= value;
        }
    }
}