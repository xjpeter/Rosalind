using System.Linq;

using NUnit.Framework;

namespace Rosalind
{
    [TestFixture]
    public class Transcribing_DNA_into_RNA
    {
//An RNA string is a string formed from the alphabet containing 'A', 'C', 'G', and 'U'.

//Given a DNA string t corresponding to a coding strand, its transcribed RNA string u is formed by replacing all occurrences of 'T' in t with 'U' in u.

//Given: A DNA string t having length at most 1000 nt.

//Return: The transcribed RNA string of t.

//Sample Dataset

//GATGGAACTTGACTACGTAAATT

//Sample Output

//GAUGGAACUUGACUACGUAAAUU

        [Test]
        public void Problem1()
        {
            var result = Solution.Solve1("GATGGAACTTGACTACGTAAATT");

            var expected = "GAUGGAACUUGACUACGUAAAUU";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Problem2()
        {
            var result = Solution.Solve2("GATGGAACTTGACTACGTAAATT");

            var expected = "GAUGGAACUUGACUACGUAAAUU";

            Assert.That(result, Is.EqualTo(expected));
        }

        public static class Solution
        {
            public static string Solve1(string dataSet)
            {
                return dataSet.Replace("T", "U");
            }

            public static string Solve2(string dataSet)
            {
                return dataSet
                    .Select(x => x == 'T' ? 'U' : x)
                    .Aggregate(string.Empty, (current, next) => string.Format("{0}{1}", current, next));
            }
        }
    }
}