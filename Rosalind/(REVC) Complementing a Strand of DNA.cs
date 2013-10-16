using System;
using System.Linq;

using NUnit.Framework;

namespace Rosalind
{
    [TestFixture]
    public class Complementing_a_Strand_of_DNA
    {
//Problem

//In DNA strings, symbols 'A' and 'T' are complements of each other, as are 'C' and 'G'.

//The reverse complement of a DNA string s is the string sc formed by reversing the symbols of s, then taking the complement of each symbol (e.g., the reverse complement of "GTCA" is "TGAC").

//Given: A DNA string s of length at most 1000 bp.

//Return: The reverse complement sc of s.

//Sample Dataset

//AAAACCCGGT

//Sample Output

//ACCGGGTTTT

        [Test]
        public void Problem1()
        {
            var result = Solution.Solve1("AAAACCCGGT");

            var expected = "ACCGGGTTTT";

            Assert.That(result, Is.EqualTo(expected));
        }

        public static class Solution
        {
            public static string Solve1(string dataSet)
            {
                return dataSet
                    .Select(x =>
                    {
                        switch (x)
                        {
                            case 'A':
                                return 'T';
                            case 'T':
                                return 'A';
                            case 'C':
                                return 'G';
                            case 'G':
                                return 'C';
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    })
                    .Reverse()
                    .Aggregate(string.Empty, (current, next) => string.Format("{0}{1}", current, next));
            }
        }
    }
}