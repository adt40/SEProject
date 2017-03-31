using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperTests
{
    [TestClass]
    class SquareTest
    {
        [TestMethod]
        public void InstantiateTest()
        {
            //No methods used in square, just ensure square instantiates
            Square square = new Square(new Coordinate(0, 0), false);
            Assert.IsTrue(true);
        }
    }
}
