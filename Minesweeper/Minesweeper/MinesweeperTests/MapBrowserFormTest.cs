using System;
using Minesweeper;
using System.Diagnostics;
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
            browser.Show();
            Assert.IsTrue(0 < browser.LocalFiles.Count);
            browser.Hide();
        }

        [TestMethod]
        public void ReadOnlineFilesTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            browser.Show();
            Assert.IsTrue(0 < browser.OnlineFiles.Count);
            browser.Hide();
        }

        [TestMethod]
        public void RemoveExcessFilenameTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            String removed = browser.RemoveExcessFilename("C:\\cygwin64\\home\\Austin\\SEProject\\Minesweeper\\Minesweeper\\Minesweeper\\bin\\Debug\\HeckinFileM8.map");
            Assert.AreEqual(removed, "HeckinFileM8");
        }

        [TestMethod]
        public void PopulateLocalListTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            browser.Show();
            Assert.IsTrue(0 < browser.getYourMapsList().Items.Count);
            browser.Hide();
            
        }

        [TestMethod]
        public void PopulateOnlineListTest()
        {
            MapBrowserForm browser = new MapBrowserForm();
            browser.Show();
            Assert.IsTrue(0 < browser.getOnlineMapsList().Items.Count);
            browser.Hide();
        }
    }
}
