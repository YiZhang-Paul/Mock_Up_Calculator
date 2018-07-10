using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using FormatterClassLibrary;
using Moq;

namespace UserControlTest {
    [TestClass]
    public class ConverterDisplayTest {

        ConverterDisplay display;
        Mock<IFormatter> formatter;

        [TestInitialize]
        public void Setup() {

            display = new ConverterDisplay();
            formatter = new Mock<IFormatter>();
        }

        [TestMethod]
        public void DisplayInput() {

            formatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5,512");

            Assert.AreEqual("0", display.Input);

            display.DisplayInput("5512", formatter.Object);

            Assert.AreEqual("5,512", display.Input);
        }

        [TestMethod]
        public void DisplayOutput() {

            formatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5,512");

            Assert.AreEqual("0", display.Output);

            display.DisplayOutput("5512", formatter.Object);

            Assert.AreEqual("5,512", display.Output);
        }
    }
}