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
            formatter.Setup(x => x.Format(It.IsAny<string>())).Returns("5,512");
        }

        [TestMethod]
        public void PopulateOptions() {

            display.PopulateOptions(new string[] { "Bar", "Foo" });

            Assert.AreEqual("Bar", display.InputUnit);
            Assert.AreEqual("Foo", display.MainOutputUnit);

            display.PopulateOptions(new string[] { "Doe", "Jane", "John" });

            Assert.AreEqual("Doe", display.InputUnit);
            Assert.AreEqual("Jane", display.MainOutputUnit);
        }

        [TestMethod]
        public void DisplayInput() {

            Assert.AreEqual("0", display.InputValue);

            display.DisplayInput("5512", formatter.Object);

            Assert.AreEqual("5,512", display.InputValue);
        }

        [TestMethod]
        public void DisplayMainOutput() {

            Assert.AreEqual("0", display.MainOutputValue);

            display.DisplayMainOutput("5512", formatter.Object);

            Assert.AreEqual("5,512", display.MainOutputValue);
        }

        [TestMethod]
        public void DisplayMaximumNumberOfExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "Gradians"),
                new Tuple<string, string>("5512", "Radians")
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual("5,512 gradians", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual("5,512 radians", display.ExtraOutputLabels[1].Text);
        }

        [TestMethod]
        public void DisplayFewerExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "Gradians"),
                null
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual("5,512 gradians", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual(string.Empty, display.ExtraOutputLabels[1].Text);
        }

        [TestMethod]
        public void DisplayMoreExtraOutputs() {

            var outputs = new Tuple<string, string>[] {

                new Tuple<string, string>("5512", "Gradians"),
                new Tuple<string, string>("5512", "Radians"),
                new Tuple<string, string>("5512", "Degrees")
            };

            display.DisplayExtraOutputs(outputs, formatter.Object);

            Assert.AreEqual("5,512 gradians", display.ExtraOutputLabels[0].Text);
            Assert.AreEqual("5,512 radians", display.ExtraOutputLabels[1].Text);
        }

        [TestMethod]
        public void Clear() {

            display.DisplayInput("5512", formatter.Object);
            display.DisplayMainOutput("5512", formatter.Object);

            Assert.AreEqual("5,512", display.InputValue);
            Assert.AreEqual("5,512", display.MainOutputValue);

            display.Clear();

            Assert.AreEqual(string.Empty, display.InputValue);
            Assert.AreEqual(string.Empty, display.MainOutputValue);
        }
    }
}