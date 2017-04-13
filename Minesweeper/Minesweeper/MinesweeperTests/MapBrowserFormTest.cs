using System;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperTests
{
    [TestClass]
    public class MapBrowserFormTest
    {
        [TestMethod]
        public void ReadLocalFilesTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            Assert.IsTrue(0 < browser.LocalFiles.Count);
        }

        [TestMethod]
        public void RemoveExcessFilenameTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            String removed = browser.RemoveExcessFilename("C:\\cygwin64\\home\\Austin\\SEProject\\Minesweeper\\Minesweeper\\Minesweeper\\bin\\Debug\\HeckinFileM8.map");
            Assert.AreEqual(removed, "HeckinFileM8.map");
        }

        [TestMethod]
        public void PopulateLocalListTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            Assert.IsTrue(0 < browser.getYourMapsList().Items.Count);
        }

        [TestMethod]
        public void PopulateOnlineListTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            Assert.IsTrue(0 < browser.getOnlineMapsList().Items.Count);
        }
    }
}
