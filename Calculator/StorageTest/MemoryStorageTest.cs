using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageClassLibrary;

namespace StorageTest {
    [TestClass]
    public class MemoryStorageTest {

        MemoryStorage storage;

        [TestInitialize]
        public void Setup() {

            storage = new MemoryStorage(new decimal[] { 6, 7, 12 });
        }

        [TestMethod]
        public void Clear() {

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);

            storage.Clear();

            Assert.AreEqual(0, storage.Size);
            Assert.AreEqual(0, storage.Last);
        }

        [TestMethod]
        public void Store() {

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, storage.Values);

            storage.Store(99);

            Assert.AreEqual(4, storage.Size);
            Assert.AreEqual(99, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12, 99 }, storage.Values);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void RemoveWithInvalidKey() {

            Assert.AreEqual(3, storage.Size);

            storage.Remove(storage.Size);
        }

        [TestMethod]
        public void Remove() {

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, storage.Values);

            storage.Remove(1);

            Assert.AreEqual(2, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 12 }, storage.Values);

            storage.Remove(1);

            Assert.AreEqual(1, storage.Size);
            Assert.AreEqual(6, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6 }, storage.Values);

            storage.Remove(0);

            Assert.AreEqual(0, storage.Size);
            Assert.AreEqual(0, storage.Last);
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
            Assert.AreEqual(12, storage.Retrieve(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void PlusWithInvalidKey() {

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

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, storage.Values);

            storage.Plus(1, 8);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 15, 12 }, storage.Values);

            storage.Plus(1, -50);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, -35, 12 }, storage.Values);

            storage.Plus(0, 100);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 106, -35, 12 }, storage.Values);

            storage.Plus(2, -100);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(-88, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 106, -35, -88 }, storage.Values);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Invalid Key.")]
        public void MinusWithInvalidKey() {

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

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 7, 12 }, storage.Values);

            storage.Minus(1, 8);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, -1, 12 }, storage.Values);

            storage.Minus(1, -50);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { 6, 49, 12 }, storage.Values);

            storage.Minus(0, 100);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(12, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { -94, 49, 12 }, storage.Values);

            storage.Minus(2, -100);

            Assert.AreEqual(3, storage.Size);
            Assert.AreEqual(112, storage.Last);
            CollectionAssert.AreEqual(new decimal[] { -94, 49, 112 }, storage.Values);
        }
    }
}