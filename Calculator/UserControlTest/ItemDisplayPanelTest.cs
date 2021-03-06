﻿using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlClassLibrary;
using Moq;

namespace UserControlTest {

    [TestClass]
    public class ItemDisplayPanelTest {

        class TestItemDisplayPanel : ItemDisplayPanel<string> {

            public TestItemDisplayPanel(IHelper helper) : base(helper) {}
        }

        Mock<IHelper> helper;
        TestItemDisplayPanel itemDisplayPanel;

        [TestInitialize]
        public void Setup() {

            helper = new Mock<IHelper>();
            itemDisplayPanel = new TestItemDisplayPanel(helper.Object);
            itemDisplayPanel.Parent = new Panel();
        }

        [TestMethod]
        public void Extend() {

            itemDisplayPanel.Extend(500);

            helper.Verify(x => x.SetHeight(It.IsAny<Control>(), It.IsAny<int>()), Times.Exactly(2));
        }
    }
}