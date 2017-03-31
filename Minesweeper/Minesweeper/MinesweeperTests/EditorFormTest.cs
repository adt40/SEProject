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
    }
}
