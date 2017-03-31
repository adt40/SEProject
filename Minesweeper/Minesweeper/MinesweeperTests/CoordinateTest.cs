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
            Coordinate c4 = new Coordinate(0, 1);
            Map m = new Map(5, 5, 3);

            Assert.IsTrue(c1.Equals(c1));
            Assert.IsFalse(c1.Equals(null));
            Assert.IsFalse(c1.Equals(m));
            Assert.IsTrue(c1.Equals(c2));
            Assert.IsFalse(c1.Equals(c3));
            Assert.IsFalse(c1.Equals(c4));
        }
    }
}
