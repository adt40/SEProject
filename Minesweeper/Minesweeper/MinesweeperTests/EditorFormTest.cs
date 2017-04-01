using System;
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
    public class EditorFormTest
    {
        [TestMethod]
        public void FormLoadTest()
        {
            int testmapx = 0;
            int testmapy = 0;
            //mapx = 0, mapy = 0
            EditorForm testEditor1 = new EditorForm(0, 0);
            Assert.AreEqual(testmapx, testEditor1.mapX);
            Assert.AreEqual(testmapy, testEditor1.mapY);

            //mapx = 0, mapy > 0
            EditorForm testEditor2 = new EditorForm(0, 10);
            testmapy = 10;
            Assert.AreEqual(testmapx, testEditor2.mapX);
            Assert.AreEqual(testmapy, testEditor2.mapY);

            //mapx > 0, mapy = 0
            EditorForm testEditor3 = new EditorForm(10, 0);
            testmapx = 10;
            testmapy = 0;
            Assert.AreEqual(testmapx, testEditor3.mapX);
            Assert.AreEqual(testmapy, testEditor3.mapY);

            //mapx > 0, mapy > 0
            EditorForm testEditor4 = new EditorForm(10, 10);
            testmapx = 10;
            testmapy = 10;
            Assert.AreEqual(testmapx, testEditor4.mapX);
            Assert.AreEqual(testmapy, testEditor4.mapY);
        }
        [TestMethod]
        public void MapClickedTest()
        {
            // check an empty space can be clicked and if it's a bomb
            bool bomb = true;
            Coordinate checker = new Coordinate(0, 0);
            EditorForm testEditor1 = new EditorForm(5, 5);
            Button sender = new Button();
            testEditor1.Form3_Load(sender, null);

            testEditor1.MapClicked(testEditor1.buttons[0, 0], null);

            Assert.AreEqual(checker, testEditor1.check);
            Assert.AreEqual(bomb, testEditor1.map.squares[checker].isBomb);
            //check a filled space can be clicked and now not a bomb
            testEditor1.MapClicked(testEditor1.buttons[0, 0], null);
            bomb = false;
            Assert.AreEqual(checker, testEditor1.check);
            Assert.AreEqual(bomb, testEditor1.map.squares[checker].isBomb);
        }
        [TestMethod]
        public void updateAdjTest()
        {
            String checka = "B";
            String neighbor = "1";
            Coordinate checker = new Coordinate(0, 0);
            EditorForm testEditor1 = new EditorForm(5, 5);
            Button sender = new Button();
            testEditor1.Form3_Load(sender, null);
            testEditor1.map.squares[checker].isBomb = !testEditor1.map.squares[checker].isBomb;
            testEditor1.updateAdj();
            //checking to see if bombs are there after "click"
            Assert.AreEqual(checka, testEditor1.buttons[0, 0].Text);
            Coordinate[] adjCheck = { new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(1, 0) };
            //checking the appended numbers next to bomb
            foreach (Coordinate c in adjCheck)
            {
                Assert.AreEqual(neighbor, testEditor1.buttons[c.x, c.y].Text);
            }
        }
    }
}
