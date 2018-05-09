using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockUpCalculator;

namespace MockUpCalculatorIntegrationTest {
    [TestClass]
    public class MainFormlIntegrationTest {

        MainForm form;

        [TestInitialize]
        public void Setup() {

            form = new MainForm();
        }

        [TestMethod]
        public void TestMethod1() {
        }
    }
}