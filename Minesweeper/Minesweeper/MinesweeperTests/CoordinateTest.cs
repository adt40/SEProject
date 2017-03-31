using System;
using System.Text;
using System.Collections.Generic;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperTests
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void HashCodeTest()
        {
            //Ensure hashcode returns a value
            Coordinate c = new Coordinate(0, 0);
            Assert.IsNotNull(c.GetHashCode());            
        }

        [TestMethod]
        public void EqualsTest()
        {
            Coordinate c1 = new Coordinate(0, 0);
            Coordinate c2 = new Coordinate(0, 0);
            Coordinate c3 = new Coordinate(1, 1);

            Assert.IsTrue(c1.Equals(c1));
            Assert.IsTrue(c1.Equals(c2));
            Assert.IsFalse(c1.Equals(c3));
        }
    }
}
