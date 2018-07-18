using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterTest {
    [TestClass]
    public class DataConverterTest {

        DataConverter converter;

        private bool IsAccurate(decimal expected, decimal actual, int precision = 3) {

            return Math.Abs(actual - expected) < (0.2m / (decimal)Math.Pow(10, precision));
        }

        [TestInitialize]
        public void Setup() {

            converter = new DataConverter();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidCurrentUnit() {

            converter.Convert("bit", 5, "bytes");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Units.")]
        public void InvalidTargetUnit() {

            converter.Convert("bits", 5, "byte");
        }

        [TestMethod]
        public void BitsToBits() {

            Assert.AreEqual(5, converter.Convert("bits", 5, "bits"));
            Assert.AreEqual(15, converter.Convert("bits", 15, "bits"));
            Assert.AreEqual(0.5m, converter.Convert("bits", 0.5m, "bits"));
        }

        [TestMethod]
        public void BitsToBytes() {

            Assert.IsTrue(IsAccurate(0.625m, converter.Convert("bits", 5, "bytes")));
            Assert.IsTrue(IsAccurate(1.875m, converter.Convert("bits", 15, "bytes")));
            Assert.IsTrue(IsAccurate(0.0625m, converter.Convert("bits", 0.5m, "bytes")));
        }

        [TestMethod]
        public void BitsToKilobits() {

            Assert.IsTrue(IsAccurate(0.005m, converter.Convert("bits", 5, "kilobits")));
            Assert.IsTrue(IsAccurate(0.015m, converter.Convert("bits", 15, "kilobits")));
            Assert.IsTrue(IsAccurate(0.0005m, converter.Convert("bits", 0.5m, "kilobits")));
        }

        [TestMethod]
        public void BitsToKibibits() {

            Assert.IsTrue(IsAccurate(0.004883m, converter.Convert("bits", 5, "kibibits")));
            Assert.IsTrue(IsAccurate(0.014648m, converter.Convert("bits", 15, "kibibits")));
            Assert.IsTrue(IsAccurate(0.000488m, converter.Convert("bits", 0.5m, "kibibits")));
        }

        [TestMethod]
        public void BitsToKilobytes() {

            Assert.IsTrue(IsAccurate(0.000625m, converter.Convert("bits", 5, "kilobytes")));
            Assert.IsTrue(IsAccurate(0.001875m, converter.Convert("bits", 15, "kilobytes")));
            Assert.IsTrue(IsAccurate(0.000063m, converter.Convert("bits", 0.5m, "kilobytes")));
        }

        [TestMethod]
        public void BitsToKibibytes() {

            Assert.IsTrue(IsAccurate(0.00061m, converter.Convert("bits", 5, "kibibytes")));
            Assert.IsTrue(IsAccurate(0.001831m, converter.Convert("bits", 15, "kibibytes")));
            Assert.IsTrue(IsAccurate(0.000061m, converter.Convert("bits", 0.5m, "kibibytes")));
        }

        [TestMethod]
        public void BitsToMegabits() {

            Assert.IsTrue(IsAccurate(0.000005m, converter.Convert("bits", 5, "megabits")));
            Assert.IsTrue(IsAccurate(0.000015m, converter.Convert("bits", 15, "megabits")));
            Assert.IsTrue(IsAccurate(0.0000005m, converter.Convert("bits", 0.5m, "megabits")));
        }

        [TestMethod]
        public void BitsToMebibits() {

            Assert.IsTrue(IsAccurate(0.000005m, converter.Convert("bits", 5, "mebibits")));
            Assert.IsTrue(IsAccurate(0.000014m, converter.Convert("bits", 15, "mebibits")));
            Assert.IsTrue(IsAccurate(0.00000047683716m, converter.Convert("bits", 0.5m, "mebibits")));
        }

        [TestMethod]
        public void BitsToMegabytes() {

            Assert.IsTrue(IsAccurate(0.000000625m, converter.Convert("bits", 5, "megabytes")));
            Assert.IsTrue(IsAccurate(0.000002m, converter.Convert("bits", 15, "megabytes")));
            Assert.IsTrue(IsAccurate(0.0000000625m, converter.Convert("bits", 0.5m, "megabytes")));
        }

        [TestMethod]
        public void BitsToMebibytes() {

            Assert.IsTrue(IsAccurate(0.00000059604645m, converter.Convert("bits", 5, "mebibytes")));
            Assert.IsTrue(IsAccurate(0.000002m, converter.Convert("bits", 15, "mebibytes")));
            Assert.IsTrue(IsAccurate(0.00000005960465m, converter.Convert("bits", 0.5m, "mebibytes")));
        }

        [TestMethod]
        public void MegaBytesToGigabits() {

            Assert.IsTrue(IsAccurate(0.04m, converter.Convert("megabytes", 5, "gigabits")));
            Assert.IsTrue(IsAccurate(0.12m, converter.Convert("megabytes", 15, "gigabits")));
            Assert.IsTrue(IsAccurate(0.004m, converter.Convert("megabytes", 0.5m, "gigabits")));
        }

        [TestMethod]
        public void MegaBytesToGibibits() {

            Assert.IsTrue(IsAccurate(0.037253m, converter.Convert("megabytes", 5, "gibibits")));
            Assert.IsTrue(IsAccurate(0.111759m, converter.Convert("megabytes", 15, "gibibits")));
            Assert.IsTrue(IsAccurate(0.003725m, converter.Convert("megabytes", 0.5m, "gibibits")));
        }

        [TestMethod]
        public void MegaBytesToGigabytes() {

            Assert.IsTrue(IsAccurate(0.005m, converter.Convert("megabytes", 5, "gigabytes")));
            Assert.IsTrue(IsAccurate(0.015m, converter.Convert("megabytes", 15, "gigabytes")));
            Assert.IsTrue(IsAccurate(0.0005m, converter.Convert("megabytes", 0.5m, "gigabytes")));
        }

        [TestMethod]
        public void MegaBytesToGibibytes() {

            Assert.IsTrue(IsAccurate(0.004657m, converter.Convert("megabytes", 5, "gibibytes")));
            Assert.IsTrue(IsAccurate(0.01397m, converter.Convert("megabytes", 15, "gibibytes")));
            Assert.IsTrue(IsAccurate(0.000466m, converter.Convert("megabytes", 0.5m, "gibibytes")));
        }

        [TestMethod]
        public void MegaBytesToTerabits() {

            Assert.IsTrue(IsAccurate(0.00004m, converter.Convert("megabytes", 5, "terabits")));
            Assert.IsTrue(IsAccurate(0.00012m, converter.Convert("megabytes", 15, "terabits")));
            Assert.IsTrue(IsAccurate(0.000004m, converter.Convert("megabytes", 0.5m, "terabits")));
        }

        [TestMethod]
        public void MegaBytesToTebibits() {

            Assert.IsTrue(IsAccurate(0.000036m, converter.Convert("megabytes", 5, "tebibits")));
            Assert.IsTrue(IsAccurate(0.000109m, converter.Convert("megabytes", 15, "tebibits")));
            Assert.IsTrue(IsAccurate(0.000004m, converter.Convert("megabytes", 0.5m, "tebibits")));
        }

        [TestMethod]
        public void MegaBytesToTerabytes() {

            Assert.IsTrue(IsAccurate(0.000005m, converter.Convert("megabytes", 5, "terabytes")));
            Assert.IsTrue(IsAccurate(0.000015m, converter.Convert("megabytes", 15, "terabytes")));
            Assert.IsTrue(IsAccurate(0.0000005m, converter.Convert("megabytes", 0.5m, "terabytes")));
        }

        [TestMethod]
        public void MegaBytesToTebibytes() {

            Assert.IsTrue(IsAccurate(0.000005m, converter.Convert("megabytes", 5, "tebibytes")));
            Assert.IsTrue(IsAccurate(0.000014m, converter.Convert("megabytes", 15, "tebibytes")));
            Assert.IsTrue(IsAccurate(0.00000045474735m, converter.Convert("megabytes", 0.5m, "tebibytes")));
        }

        [TestMethod]
        public void GigabytesToPetabits() {

            Assert.IsTrue(IsAccurate(0.00004m, converter.Convert("gigabytes", 5, "petabits")));
            Assert.IsTrue(IsAccurate(0.00012m, converter.Convert("gigabytes", 15, "petabits")));
            Assert.IsTrue(IsAccurate(0.000004m, converter.Convert("gigabytes", 0.5m, "petabits")));
        }

        [TestMethod]
        public void GigabytesToPebibits() {

            Assert.IsTrue(IsAccurate(0.000036m, converter.Convert("gigabytes", 5, "pebibits")));
            Assert.IsTrue(IsAccurate(0.000107m, converter.Convert("gigabytes", 15, "pebibits")));
            Assert.IsTrue(IsAccurate(0.000004m, converter.Convert("gigabytes", 0.5m, "pebibits")));
        }

        [TestMethod]
        public void GigabytesToPetabytes() {

            Assert.IsTrue(IsAccurate(0.000005m, converter.Convert("gigabytes", 5, "petabytes")));
            Assert.IsTrue(IsAccurate(0.000015m, converter.Convert("gigabytes", 15, "petabytes")));
            Assert.IsTrue(IsAccurate(0.0000005m, converter.Convert("gigabytes", 0.5m, "petabytes")));
        }

        [TestMethod]
        public void GigabytesToPebibytes() {

            Assert.IsTrue(IsAccurate(0.000004m, converter.Convert("gigabytes", 5, "pebibytes")));
            Assert.IsTrue(IsAccurate(0.000013m, converter.Convert("gigabytes", 15, "pebibytes")));
            Assert.IsTrue(IsAccurate(0.00000044408921m, converter.Convert("gigabytes", 0.5m, "pebibytes")));
        }

        [TestMethod]
        public void GigabytesToExabits() {

            Assert.IsTrue(IsAccurate(0.00000004m, converter.Convert("gigabytes", 5, "exabits")));
            Assert.IsTrue(IsAccurate(0.00000012m, converter.Convert("gigabytes", 15, "exabits")));
            Assert.IsTrue(IsAccurate(0.000000004m, converter.Convert("gigabytes", 0.5m, "exabits")));
        }

        [TestMethod]
        public void GigabytesToExbibits() {

            Assert.IsTrue(IsAccurate(0.00000003469447m, converter.Convert("gigabytes", 5, "exbibits")));
            Assert.IsTrue(IsAccurate(0.00000010408341m, converter.Convert("gigabytes", 15, "exbibits")));
            Assert.IsTrue(IsAccurate(0.00000000346945m, converter.Convert("gigabytes", 0.5m, "exbibits")));
        }

        [TestMethod]
        public void GigabytesToExabytes() {

            Assert.IsTrue(IsAccurate(0.000000005m, converter.Convert("gigabytes", 5, "exabytes")));
            Assert.IsTrue(IsAccurate(0.000000015m, converter.Convert("gigabytes", 15, "exabytes")));
            Assert.IsTrue(IsAccurate(0.0000000005m, converter.Convert("gigabytes", 0.5m, "exabytes")));
        }

        [TestMethod]
        public void GigabytesToExbibytes() {

            Assert.IsTrue(IsAccurate(0.00000000433681m, converter.Convert("gigabytes", 5, "exbibytes")));
            Assert.IsTrue(IsAccurate(0.00000001301043m, converter.Convert("gigabytes", 15, "exbibytes")));
            Assert.IsTrue(IsAccurate(0.00000000043368m, converter.Convert("gigabytes", 0.5m, "exbibytes")));
        }
    }
}