using System;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGameFormMakeButton()
        {
            int testmapx = 0;
            int testmapy = 0;
            int testbomb = 0;
            //mapx = 0, mapy = 0
            GameForm testgame1 = new GameForm(0, 0, 0);
            Assert.AreEqual(testmapx, testgame1.mapX);
            Assert.AreEqual(testmapy, testgame1.mapY);
            
            //mapx = 0, mapy > 0
            GameForm testgame2 = new GameForm(0, 1, 0);
            testmapy = 1;
            Assert.AreEqual(testmapx, testgame1.mapX);
            Assert.AreEqual(testmapy, testgame1.mapY);

            //mapx > 0, mapy = 0
            GameForm testgame3 = new GameForm(1, 0, 0);
            testmapx = 1;
            testmapy = 0;
            Assert.AreEqual(testmapx, testgame1.mapX);
            Assert.AreEqual(testmapy, testgame1.mapY);

            //mapx > 0, mapy > 0
            GameForm testgame4 = new GameForm(1, 1, 0);
            testmapx = 1;
            testmapy = 1;
            Assert.AreEqual(testmapx, testgame1.mapX);
            Assert.AreEqual(testmapy, testgame1.mapY);

            //numBombs = 0
            GameForm testgame5 = new GameForm(5, 5, 0);
            Assert.AreEqual(testbomb, testgame1.numBombs);
            //numBombs > 0
            GameForm testgame6 = new GameForm(5, 5, 1);
            testbomb = 1;
            Assert.AreEqual(testbomb, testgame1.numBombs);
        }
        [TestMethod]
        public void TestGameFormMapClick()
        {
            String poup = "test.map";
            String poup1 = "test1.map";
            String poup2 = "test2.map";
            String poup3 = "test3.map";
            bool check = true;
            int testmapx = 0;
            int testmapy = 0;
            int testbomb = 0;
            //File Format
            GameForm testgame1 = new GameForm(poup);
            Assert.AreEqual(check, testgame1.checkFile);

            //File does not match read width/height
            GameForm testgame2 = new GameForm(poup);
            //File contains unknown chars
            GameForm testgame3 = new GameForm(poup);

            //Width = 0, height = 0
            GameForm testgame4 = new GameForm(poup1);
            Assert.AreEqual(testmapx, testgame1.mapX);
            Assert.AreEqual(testmapy, testgame1.mapY);
            //numBombs = 0
            GameForm testgame5 = new GameForm(poup2);
            Assert.AreEqual(testbomb, testgame1.numBombs);
            //numBombs > 0
            GameForm testgame6 = new GameForm(poup3);
            testbomb = 1; //custom map poup3 will have 1 bomb
            Assert.AreEqual(testbomb, testgame1.numBombs);
            //A square has bomb
            //A square does not have a bomb
            //^these are both verification and can be done by clicking
        }
        [TestMethod]
        public void TestGameRevealZero()
        {   
            //using a test map file to test each case
            //test cases for Width = 0, height = 0
            GameForm testgame1 = new GameForm(0, 0, 0);
            //Width = 0, height > 0
            GameForm testgame2 = new GameForm(0, 1, 0);
            //Width > 0, height = 0
            GameForm testgame3 = new GameForm(1, 0, 0);
            //Width > 0, height > 0
            GameForm testgame4 = new GameForm(1, 1, 0);
            //numBombs = 0
            GameForm testgame5 = new GameForm(5, 5, 0);
            //numBombs > 0
            GameForm testgame6 = new GameForm(5, 5, 1);
            //A square has bomb
            GameForm testgame7 = new GameForm(0, 0, 0);
            //A square does not have a bomb
            GameForm testgame8 = new GameForm(0, 0, 0);
        }
    }
}
