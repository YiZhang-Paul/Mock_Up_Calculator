using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionsClassLibrary;

namespace ExpressionsTest {
    [TestClass]
    public class ParenthesizerTest {

        Parenthesizer parenthesizer;

        [TestInitialize]
        public void Setup() {

            parenthesizer = new Parenthesizer();
        }

        [TestMethod]
        public void TestMethod1() {

            parenthesizer.Parenthesize("( ( 5 + 6 ) * 6 ) + ( 8 + 9 ) ^ 7");
        }
    }
}