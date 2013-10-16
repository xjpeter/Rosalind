using System.Linq;

using NUnit.Framework;

namespace Rosalind
{
    [TestFixture]
    public class Finding_a_Motif_in_DNA
    {
//Problem

//Given two strings s and t, t is a substring of s if t is contained as a contiguous collection of symbols in s (as a result, t must be no longer than s).

//The position of a symbol in a string is the total number of symbols found to its left, including itself (e.g., the positions of all occurrences of 'U' in "AUGCUUCAGAAAGGUCUUACG" are 2, 5, 6, 15, 17, and 18). The symbol at position i of s is denoted by s[i].

//A substring of s can be represented as s[j:k], where j and k represent the starting and ending positions of the substring in s; for example, if s = "AUGCUUCAGAAAGGUCUUACG", then s[2:5] = "UGCU".

//The location of a substring s[j:k] is its beginning position j; note that t will have multiple locations in s if it occurs more than once as a substring of s (see the Sample below).

//Given: Two DNA strings s and t (each of length at most 1 kbp).

//Return: All locations of t as a substring of s.

//Sample Dataset

//GATATATGCATATACTT
//ATAT

//Sample Output

//2 4 10

        [Test]
        public void Problem1()
        {
            var result = Solution.Solve1("GATATATGCATATACTT", "ATAT");

            var expected = "2 4 10";

            Assert.That(result, Is.EqualTo(expected));
        }

        public static class Solution
        {
            public static string Solve1(string dna, string motif)
            {
                var results = from index in Enumerable.Range(0, dna.Count() - 1)
                              where index + motif.Length <= dna.Length
                              where dna.Substring(index, motif.Length) == motif
                              select index + 1;

                return results
                    .Select(x => x.ToString())
                    .Aggregate((current, next) => string.Format("{0} {1}", current, next));
            }
        }
    }
}