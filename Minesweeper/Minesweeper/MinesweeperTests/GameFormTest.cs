﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperTests
{
    [TestClass]
    public class GameFormTest
    {
        [TestMethod]
        public void FormLoadTest()
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
            Assert.AreEqual(testmapx, testgame2.mapX);
            Assert.AreEqual(testmapy, testgame2.mapY);

            //mapx > 0, mapy = 0
            GameForm testgame3 = new GameForm(1, 0, 0);
            testmapx = 1;
            testmapy = 0;
            Assert.AreEqual(testmapx, testgame3.mapX);
            Assert.AreEqual(testmapy, testgame3.mapY);

            //mapx > 0, mapy > 0
            GameForm testgame4 = new GameForm(1, 1, 0);
            testmapx = 1;
            testmapy = 1;
            Assert.AreEqual(testmapx, testgame4.mapX);
            Assert.AreEqual(testmapy, testgame4.mapY);

            //numBombs = 0
            GameForm testgame5 = new GameForm(5, 5, 0);
            Assert.AreEqual(testbomb, testgame5.numBombs);
            //numBombs > 0
            GameForm testgame6 = new GameForm(5, 5, 1);
            testbomb = 1;
            Assert.AreEqual(testbomb, testgame6.numBombs);
        }

        [TestMethod]
        public void MapLoadingTest()
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
        public void MapClickedTest()
        {
            bool testBomb = true;
            //testing for if there is a bomb
            GameForm testgame = new GameForm(1, 1, 1);
            testgame.MapClicked(testgame.buttons[0, 0], null);
            Assert.AreEqual(testBomb, testgame.bomb);
            //testing for if there is no bomb
            testBomb = false;
            GameForm testgame1 = new GameForm(1, 1, 0);
            testgame.MapClicked(testgame.buttons[0, 0], null);
            Assert.AreEqual(testBomb, testgame.bomb);
            




        }
        [TestMethod]
        public void MapRightClicked()
        {

        }
        [TestMethod]
        public void RevealZerosTest()
        {
            GameForm testForm = new GameForm("testmap.map");
            Button sender = new Button();
            testForm.Form1_Load(sender, null);
            testForm.revealZeros(2, 4);
            Map map = testForm.map;
            Coordinate[] clickedCoordinates = {new Coordinate(3, 1), new Coordinate(4, 1), new Coordinate(3, 2),
                                             new Coordinate(4, 2), new Coordinate(1, 3), new Coordinate(2, 3),
                                             new Coordinate(3, 3), new Coordinate(4, 3), new Coordinate(1, 4),
                                             new Coordinate(2, 4), new Coordinate(3, 4), new Coordinate(4, 4)};
            foreach(Coordinate c in clickedCoordinates)
            {
                Assert.IsTrue(map.squares[c].hasClicked);
            }
           
        }

        [TestMethod]
        public void testFindButtonCoordinates()
        {
            GameForm testForm = new GameForm("testmap.map");
            Button sender = new Button();
            testForm.Form1_Load(sender, null);
            Coordinate found = testForm.findButtonCoordinates(testForm.buttons[1, 4]);
            Coordinate notFound = testForm.findButtonCoordinates(null);
            Coordinate expected = new Coordinate(1, 4);
            Assert.AreEqual(found, expected);
            Assert.IsNull(notFound);
        }

        [TestMethod]
        public void testLoseAt()
        {
            GameForm testForm = new GameForm("testmap.map");
            Button sender = new Button();
            testForm.Form1_Load(sender, null);
            testForm.loseAt(testForm.buttons[4, 0]);
            Button[] bombs = { testForm.buttons[4, 0], testForm.buttons[2, 2], testForm.buttons[0, 4] };
            foreach(Button b in bombs)
            {
                Assert.AreEqual(b.Text, "B");
            }
        }
    }
}
