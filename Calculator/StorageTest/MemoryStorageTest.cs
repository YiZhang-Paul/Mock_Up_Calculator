using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageClassLibrary;

namespace StorageTest {
    [TestClass]
    public class MemoryStorageTest {

        MemoryStorage storage;

        [TestInitialize]
        public void Setup() {

            storage = new MemoryStorage(new decimal[] { 6, 7, 3 });
        }

        [TestMethod]
        public void Clear() {

            Assert.AreEqual(3, storage.Last);

            storage.Clear();

            Assert.AreEqual(0, storage.Last);
        }

        [TestMethod]
        public void Store() {

            Assert.AreEqual(3, storage.Last);

            storage.Store(99);

            Assert.AreEqual(99, storage.Last);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void RemoveWithInvalidKey() {

            Assert.AreEqual(3, storage.Last);

            storage.Remove(storage.Size);
        }

        [TestMethod]
        public void Remove() {

            Assert.AreEqual(3, storage.Last);

            storage.Remove(storage.Size - 1);

            Assert.AreEqual(7, storage.Last);

            storage.Remove(storage.Size - 1);

            Assert.AreEqual(6, storage.Last);

            storage.Remove(storage.Size - 1);

            Assert.AreEqual(0, storage.Last);
            Assert.AreEqual(0, storage.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void RetrieveWithInvalidKey() {

            storage.Retrieve(storage.Size);
        }

        [TestMethod]
        public void Retrieve() {

            Assert.AreEqual(6, storage.Retrieve(0));
            Assert.AreEqual(7, storage.Retrieve(1));
            Assert.AreEqual(3, storage.Retrieve(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void PlusWithInvalidKey() {

            Assert.AreEqual(3, storage.Last);

            storage.Plus(storage.Size, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Large.")]
        public void OverflowWhenPlus() {

            storage = new MemoryStorage(new decimal[] { decimal.MaxValue });

            Assert.AreEqual(1, storage.Size);
            Assert.AreEqual(decimal.MaxValue, storage.Last);

            storage.Plus(0, 1);
        }

        [TestMethod]
        public void Plus() {

            Assert.AreEqual(6, storage.Retrieve(0));
            Assert.AreEqual(7, storage.Retrieve(1));
            Assert.AreEqual(3, storage.Retrieve(2));

            storage.Plus(0, 12);

            Assert.AreEqual(18, storage.Retrieve(0));

            storage.Plus(0, -7);

            Assert.AreEqual(11, storage.Retrieve(0));

            storage.Plus(1, -8);

            Assert.AreEqual(-1, storage.Retrieve(1));

            storage.Plus(2, 99);

            Assert.AreEqual(102, storage.Retrieve(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void MinusWithInvalidKey() {

            Assert.AreEqual(3, storage.Last);

            storage.Minus(storage.Size, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException),
         "Operand is Too Small.")]
        public void OverflowWhenMinus() {

            storage = new MemoryStorage(new decimal[] { -decimal.MaxValue });

            Assert.AreEqual(1, storage.Size);
            Assert.AreEqual(-decimal.MaxValue, storage.Last);

            storage.Minus(0, 1);
        }

        [TestMethod]
        public void Minus() {

            Assert.AreEqual(6, storage.Retrieve(0));
            Assert.AreEqual(7, storage.Retrieve(1));
            Assert.AreEqual(3, storage.Retrieve(2));

            storage.Minus(0, 12);

            Assert.AreEqual(-6, storage.Retrieve(0));

            storage.Minus(0, -7);

            Assert.AreEqual(1, storage.Retrieve(0));

            storage.Minus(1, -8);

            Assert.AreEqual(15, storage.Retrieve(1));

            storage.Minus(2, 99);

            Assert.AreEqual(-96, storage.Retrieve(2));
        }
    }
}