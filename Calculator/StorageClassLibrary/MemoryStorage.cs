using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageClassLibrary {
    public class MemoryStorage : IMemoryStorage {

        private List<decimal> Values { get; set; }

        public int Size { get { return Values.Count; } }
        public decimal Last { get { return Size == 0 ? 0 : Values.Last(); } }

        public MemoryStorage() {

            Values = new List<decimal>();
        }

        public MemoryStorage(IEnumerable<decimal> values) : this() {

            foreach(var value in values) {

                Store(value);
            }
        }

        public void Clear() {

            Values.Clear();
        }

        public void Store(decimal value) {

            Values.Add(value);
        }

        public void Remove(int key) {

            Values.RemoveAt(key);
        }

        public decimal Retrieve(int key) {

            return Values[key];
        }

        public void Plus(int key, decimal value) {

            Values[key] += value;
        }

        public void Minus(int key, decimal value) {

            Values[key] -= value;
        }
    }
}