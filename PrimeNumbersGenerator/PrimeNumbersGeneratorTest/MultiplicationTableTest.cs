using NUnit.Framework;
using PrimeNumbersGenerator;
using System;
using System.Collections.Generic;

namespace PrimeNumbersGeneratorTest
{
    [TestFixture]
    public class MultiplicationTableTest
    {
        [Test]
        public void GetGrid_ArgumentNullExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => MultiplicationTable.GetGrid(null));
        }

        [Test]
        public void GetGrid_ZeroElementsInput_OneElementGrid()
        {
            var result = MultiplicationTable.GetGrid(new List<ulong>());

            Assert.AreEqual(1, result.GetLength(0));
            Assert.AreEqual(1, result.GetLength(1));
            Assert.AreEqual(0, result[0, 0]);
        }

        [Test]
        public void GetGrid_TwolementsInput_ThreeElementGrid()
        {
            var expected = new ulong[3, 3] { { 2, 2, 3 }, { 2, 4, 6 }, { 3, 6, 9 } };

            var result = MultiplicationTable.GetGrid(new List<ulong>() { 2, 3 });

            Assert.AreEqual(expected, result);
        }
    }
}
