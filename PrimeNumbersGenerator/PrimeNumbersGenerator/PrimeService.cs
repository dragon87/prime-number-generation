using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbersGenerator
{
    public sealed class PrimeService
    {
        private readonly List<ulong> primeNumbers;
        private readonly object primeNumbersLock = new object();

        static PrimeService()
        {
        }

        private PrimeService()
        {
            primeNumbers = new List<ulong> { 2 };
        }

        public static PrimeService Instance { get; } = new PrimeService();

        public IEnumerable<ulong> FindPrimes(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{nameof(count)} should be at least 1");
            }

            lock (primeNumbersLock)
            {
                if (count < primeNumbers.Count)
                {
                    return primeNumbers.Take(count);
                }

                ulong nextPrimeNumberCandidate = primeNumbers[primeNumbers.Count - 1] + 1;

                while (primeNumbers.Count < count)
                {
                    if (IsPrime(nextPrimeNumberCandidate, primeNumbers))
                    {
                        primeNumbers.Add(nextPrimeNumberCandidate);
                    }

                    nextPrimeNumberCandidate++;
                }

                return primeNumbers;
            }
        }

        public bool IsPrime(ulong number, List<ulong> factors)
        {
            return !factors.Any(p => number % p == 0);
        }
    }
}