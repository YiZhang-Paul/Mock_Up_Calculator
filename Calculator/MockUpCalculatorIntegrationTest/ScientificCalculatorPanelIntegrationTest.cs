using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockUpCalculator;

namespace MockUpCalculatorIntegrationTest {
    [TestClass]
    public class ScientificCalculatorPanelIntegrationTest {

        ServiceLookup service;
        ScientificCalculatorPanel calculatorPanel;

        [TestInitialize]
        public void Setup() {

            service = new ServiceLookup();
            calculatorPanel = service.GetScientificCalculatorPanel();
        }

        [TestMethod]
        public void CheckTrigonometricKey() {
        }
    }
}