﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MinesweeperTests
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void TestGenerateFromInts()
        {
            Map testMap = new Map(5, 5, 3);
            Assert.AreEqual(testMap.testNumBombs(), 3);
            Assert.IsNotNull(testMap.squares);
        }

        [TestMethod]
        public void TestGenerateFromFileAndSetAdjBombVals()
        {
            Map testMap = new Map("testmap.map");
            testMap.SetAdjBombVals();
            String expectedLayout = "0001B\n" +
                                    "01121\n" +
                                    "01B10\n" +
                                    "12110\n" +
                                    "B1000\n";
            Assert.AreEqual(testMap.viewBombsAndNums(), expectedLayout);
            Assert.AreEqual(testMap.testNumBombs(), 3);
        }

        [TestMethod]
        public void TestCreateMapFile()
        {
            Map testMap = new Map("testmap.map");
            testMap.CreateMapFile("createdmap");
            String readText = File.ReadAllText("createdmap.map");
            String expectedText = "5\r\n" +
                                  "5\r\n" +
                                  "OOOOX\r\n" +
                                  "OOOOO\r\n" +
                                  "OOXOO\r\n" +
                                  "OOOOO\r\n" +
                                  "XOOOO\r\n";
            Assert.IsTrue(expectedText.Equals(readText));
        }
    }
}
