using NUnit.Framework;
using PrimeNumbersGenerator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbersGeneratorTest
{
    [TestFixture]
    public class PrimeServiceTest
    {
        private PrimeService _primeService;

        [SetUp]
        public void SetUp()
        {
            _primeService = PrimeService.Instance;
        }

        [Test]
        public void IsPrime_ReturnFalse()
        {
            var factors = new List<ulong> { 2, 3 };

            var result = _primeService.IsPrime(4, factors);

            Assert.IsFalse(result, "4 should not be prime");
        }

        [Test]
        public void IsPrime_ReturnTrue()
        {
            var factors = new List<ulong> { 2, 3 };

            var result = _primeService.IsPrime(5, factors);

            Assert.IsTrue(result, "5 should be prime");
        }

        [Test]
        public void IsPrime_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => _primeService.IsPrime(5, null));
        }

        [Test]
        public void FindPrimes_ArgumentCheck()
        {
            Assert.Throws<ArgumentException>(() => _primeService.FindPrimes(0));
        }

        [Test]
        public void FindPrimes_CorrectCountOfPrimeNumbersIsGenerated()
        {
            var result = _primeService.FindPrimes(5);

            Assert.AreEqual(5, result.Count(), "5 primes should be generated");
        }

        [Test]
        public void FindPrimes_CorrectPrimesAreGenerated()
        {
            var expected = new List<ulong> { 2, 3, 5, 7, 11 };

            var result = _primeService.FindPrimes(5).ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i], "correct primes are generated");
            }
        }

        [Test]
        public void FindPrimes_1000th_PrimeNumber()
        {
            var expected = 7919;

            var result = _primeService.FindPrimes(1000).Skip(999).Take(1).ToList();

            Assert.AreEqual(expected, result[0]);
        }
    }
}
