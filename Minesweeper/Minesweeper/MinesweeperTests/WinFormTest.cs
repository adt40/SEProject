using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
namespace MinesweeperTests
{
    [TestClass]
    public class WinFormTest
    {

        [TestMethod]
        public void randomMapTest()
        {
            WinForm win = new WinForm(new GameForm(5,5,1));
            win.Show();
            Assert.AreEqual(win.Height, 200); //check that it detected a random map

        }

        [TestMethod]
        public void customMapTest()
        {
            WinForm win = new WinForm(new GameForm("testmap.map"));
            win.Show();
            Assert.IsTrue(win.Height > 200); //check that it detected a custom map

        }

        [TestMethod]
        public void uploadTest()
        {
            WinForm win = new WinForm(new GameForm("testmap.map"));
            win.Show();
            win.button2_Click(null, null);
            win.Dispose();
            Assert.IsTrue(true); //This method is straight line code; just assure that it runs without error
            
        }

    }
}
