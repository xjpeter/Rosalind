using System.Linq;

using NUnit.Framework;

namespace Rosalind
{

    [TestFixture]
    public class Counting_Point_Mutations
    {
//Problem

//Figure 2. The Hamming distance between these two strings is 7. Mismatched symbols are colored red.
//Given two strings s and t of equal length, the Hamming distance between s and t, denoted dH(s,t), is the number of corresponding symbols that differ in s and t. See Figure 2.

//Given: Two DNA strings s and t of equal length (not exceeding 1 kbp).

//Return: The Hamming distance dH(s,t).

//Sample Dataset

//GAGCCTACTAACGGGAT
//CATCGTAATGACGGCCT

//Sample Output

//7

        [Test]
        public void Problem1()
        {
            var result = Solution.Solve1("GAGCCTACTAACGGGAT", "CATCGTAATGACGGCCT");

            var expected = 7;

            Assert.That(result, Is.EqualTo(expected));
        }

        public static class Solution
        {
            public static int Solve1(string dataSet1, string dataSet2)
            {
                return dataSet1
                    .Zip(dataSet2, (x, y) => new {Left = x, Right = y})
                    .Count(x => x.Left != x.Right);
            }
        }
    }
}