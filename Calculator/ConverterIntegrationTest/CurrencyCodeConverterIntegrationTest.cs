using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConverterClassLibrary;

namespace ConverterIntegrationTest {
    [TestClass]
    public class CurrencyCodeConverterIntegrationTest {

        CurrencyCodeConverter converter;

        [TestInitialize]
        public void Setup() {

            converter = new CurrencyCodeConverter("countryInformation.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException),
         "Invalid File Path.")]
        public void InvalidFile() {

            converter = new CurrencyCodeConverter("invalid.invalid");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Code.")]
        public void InvalidCurrencyCode() {

            converter.ToCountryCode("GGG");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
         "Invalid Code.")]
        public void InvalidCountryCode() {

            converter.ToCurrencyCode("ZZ");
        }

        [TestMethod]
        public void ToCountryCode() {

            CollectionAssert.AreEqual(

                new string[] { "CK", "NU", "NZ", "PN", "TK" },
                converter.ToCountryCode("NZD").OrderBy(code => code).ToArray()
            );

            CollectionAssert.AreEqual(

                new string[] { "GB", "GS", "IM", "JE", "SH" },
                converter.ToCountryCode("GBP").OrderBy(code => code).ToArray()
            );

            CollectionAssert.AreEqual(

                new string[] { "KH" },
                converter.ToCountryCode("KHR").OrderBy(code => code).ToArray()
            );
        }

        [TestMethod]
        public void ToCurrencyCode() {

            Assert.AreEqual("NZD", converter.ToCurrencyCode("CK"));
            Assert.AreEqual("NZD", converter.ToCurrencyCode("NU"));
            Assert.AreEqual("NZD", converter.ToCurrencyCode("NZ"));
            Assert.AreEqual("NZD", converter.ToCurrencyCode("PN"));
            Assert.AreEqual("NZD", converter.ToCurrencyCode("TK"));
            Assert.AreEqual("GBP", converter.ToCurrencyCode("GB"));
            Assert.AreEqual("GBP", converter.ToCurrencyCode("IM"));
            Assert.AreEqual("GBP", converter.ToCurrencyCode("SH"));
            Assert.AreEqual("KHR", converter.ToCurrencyCode("KH"));
        }
    }
}