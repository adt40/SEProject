using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

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

        //[TestMethod]
        //public void MapLoadingTest()
        //{
        //    String poup = "test.map";
        //    String poup1 = "test1.map";
        //    String poup2 = "test2.map";
        //    String poup3 = "test3.map";
        //    bool check = true;
        //    int testmapx = 0;
        //    int testmapy = 0;
        //    int testbomb = 0;
        //    //File Format
        //    GameForm testgame1 = new GameForm(poup);
        //    Assert.AreEqual(check, testgame1.checkFile);

        //    //File does not match read width/height
        //    GameForm testgame2 = new GameForm(poup);
        //    //File contains unknown chars
        //    GameForm testgame3 = new GameForm(poup);

        //    //Width = 0, height = 0
        //    GameForm testgame4 = new GameForm(poup1);
        //    Assert.AreEqual(testmapx, testgame1.mapX);
        //    Assert.AreEqual(testmapy, testgame1.mapY);
        //    //numBombs = 0
        //    GameForm testgame5 = new GameForm(poup2);
        //    Assert.AreEqual(testbomb, testgame1.numBombs);
        //    //numBombs > 0
        //    GameForm testgame6 = new GameForm(poup3);
        //    testbomb = 1; //custom map poup3 will have 1 bomb
        //    Assert.AreEqual(testbomb, testgame1.numBombs);
        //    //A square has bomb
        //    //A square does not have a bomb
        //    //^these are both verification and can be done by clicking
        //}

        [TestMethod]
        public void MapClickedTest()
        {
            GameForm testForm = new GameForm("testmap.map");
            Button sender = new Button();
            testForm.Form1_Load(sender, null);
            Button noBomb = testForm.buttons[0, 0];
            Button AdjNum = testForm.buttons[1, 4];
            Button withBomb = testForm.buttons[4, 0];
            //These calls will represent code coverage. All functionality from each call is tested in other methods
            testForm.MapClicked(noBomb, null);
            testForm.MapClicked(noBomb, null);
            testForm.MapClicked(AdjNum, null);
            testForm.MapClicked(withBomb, null);

            GameForm winForm = new GameForm("GOTTAGOFAST.map");
            winForm.Form1_Load(sender, null);
            Button winButton = winForm.buttons[0, 0];
            winForm.MapClicked(winButton, null);
        }

        [TestMethod]
        public void RevealZerosTest()
        {
            GameForm testForm = new GameForm("testmap.map");
            //Map map = testForm.map;
            Button sender = new Button();
            testForm.Form1_Load(sender, null);
            testForm.revealZeros(4, 4);
            
            Coordinate[] clickedCoordinates = {new Coordinate(3, 3), new Coordinate(3, 4), new Coordinate(4, 3)};
            foreach(Coordinate c in clickedCoordinates)
            {
                Assert.IsTrue(testForm.map.squares[c].hasClicked);
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
            testForm.Show();
            testForm.MapClicked(testForm.buttons[2, 2], null);
            Dictionary<Coordinate, Square> squares = testForm.map.squares;
            
            Coordinate[] bombs = { new Coordinate(2, 2), new Coordinate(0, 4), new Coordinate(4, 0) };
            
            foreach (Coordinate b in bombs)
            {
                Assert.IsTrue(squares[b].hasClicked);

            }
        }

        [TestMethod]
        public void testMapRightClicked()
        {
            GameForm testForm = new GameForm("testmap.map");
            Button sender = new Button();
            testForm.Form1_Load(sender, null);
            MouseEventArgs eLeft = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
            MouseEventArgs eRight = new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0);
            Button rightClicked = testForm.buttons[0, 0];
            testForm.MapRightClicked(rightClicked, eLeft);
            testForm.MapRightClicked(rightClicked, eRight);
            Assert.IsNotNull(rightClicked.BackgroundImage);
            testForm.MapRightClicked(rightClicked, eRight);
            Assert.IsNull(rightClicked.BackgroundImage);
        }

        [TestMethod]
        public void CheckIfWinTest()
        {
            GameForm g = new GameForm(5, 5, 1);
            Assert.IsFalse(g.CheckIfWin());

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Coordinate c = new Coordinate(x, y);
                    if (g.map.squares[c].isBomb)
                    {
                        g.map.squares[c].hasFlag = true;
                    }
                    else
                    {
                        g.map.squares[c].hasClicked = true;

                    }
                }
            }

            Assert.IsTrue(g.CheckIfWin());
        }

        [TestMethod]
        public void colorTextTest()
        {
            GameForm test = new GameForm(5, 5, 1);
            Button b = new Button();
            b.ForeColor = Color.Black;
            test.ColorText(1, b);
            Assert.AreEqual(Color.Blue, b.ForeColor);
            test.ColorText(2, b);
            Assert.AreEqual(Color.ForestGreen, b.ForeColor);
            test.ColorText(3, b);
            Assert.AreEqual(Color.DarkRed, b.ForeColor);
            test.ColorText(4, b);
            Assert.AreEqual(Color.Purple, b.ForeColor);
            test.ColorText(5, b);
            Assert.AreEqual(Color.Orange, b.ForeColor);
            test.ColorText(6, b);
            Assert.AreEqual(Color.DarkBlue, b.ForeColor);
            test.ColorText(7, b);
            Assert.AreEqual(Color.Goldenrod, b.ForeColor);
            test.ColorText(8, b);
            Assert.AreEqual(Color.Brown, b.ForeColor);
            test.ColorText(0, b);
            Assert.AreEqual(Color.Black, b.ForeColor);
        }
    }
}
