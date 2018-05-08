using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using Moq;

namespace UserControlTest {

    public class TestItemDisplayPanel : ItemDisplayPanel<string> {

        public TestItemDisplayPanel(IHelper helper) : base(helper) {}
    }

    [TestClass]
    public class ItemDisplayPanelTest {

        Mock<IHelper> helper;
        TestItemDisplayPanel itemDisplayPanel;

        [TestInitialize]
        public void Setup() {

            helper = new Mock<IHelper>();
            itemDisplayPanel = new TestItemDisplayPanel(helper.Object);
        }

        [TestMethod]
        public void Extend() {

            itemDisplayPanel.Extend(500);

            helper.Verify(x => x.SetHeight(It.IsAny<Control>(), It.IsAny<int>()), Times.Exactly(2));
        }
    }
}