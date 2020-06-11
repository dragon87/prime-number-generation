using System;
using System.Collections.Generic;

namespace PrimeNumbersGenerator
{
    public static class MultiplicationTable
    {
        public static ulong[,] GetGrid(List<ulong> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException($"{nameof(elements)} argument should not be null");
            }

            var multiplicationTable = new ulong[elements.Count + 1, elements.Count + 1];

            // Top-left element of the multplication table represents the number rows and columns
            multiplicationTable[0, 0] = (ulong)elements.Count;

            // Create multiplication matrix left and top borders
            for (int i = 0; i < elements.Count; i++)
            {
                multiplicationTable[0, i + 1] = elements[i];
                multiplicationTable[i + 1, 0] = elements[i];
            }

            // Create multplication matrix content
            for (int i = 0; i < elements.Count; i++)
            {
                for (int j = 0; j < elements.Count; j++)
                {
                    multiplicationTable[i + 1, j + 1] = elements[i] * elements[j];
                }
            }

            return multiplicationTable;
        }
    }
}
