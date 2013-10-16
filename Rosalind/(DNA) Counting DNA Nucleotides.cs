using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Rosalind
{
    [TestFixture]
    public class Counting_DNA_Nucleotides
    {
//Problem

//A string is simply an ordered collection of symbols selected from some alphabet and formed into a word; the length of a string is the number of symbols that it contains.

//An example of a length 21 DNA string (whose alphabet contains the symbols 'A', 'C', 'G', and 'T') is "ATGCTTCAGAAAGGTCTTACG."

//Given: A DNA string s of length at most 1000 nt.

//Return: Four integers (separated by spaces) counting the respective number of times that the symbols 'A', 'C', 'G', and 'T' occur in s.

//Sample Dataset

//AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC

//Sample Output

//20 12 17 21

        [Test]
        public void Problem1()
        {
            var result = Solution.Solve1("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");

            var expected = "20 12 17 21";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Problem2()
        {
            var result = Solution.Solve2("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");

            var expected = "20 12 17 21";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Problem3()
        {
            var result = Solution.Solve3("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");

            var expected = "20 12 17 21";

            Assert.That(result, Is.EqualTo(expected));
        }

        public static class Solution
        {
            public static string Solve1(string dataSet)
            {
                var a = 0;
                var c = 0;
                var g = 0;
                var t = 0;

                foreach (var symbol in dataSet.AsEnumerable())
                {
                    switch (symbol)
                    {
                        case 'A':
                            a++;
                            break;
                        case 'C':
                            c++;
                            break;
                        case 'G':
                            g++;
                            break;
                        case 'T':
                            t++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                return string.Format("{0} {1} {2} {3}", a, c, g, t);
            }

            public static string Solve2(string dataSet)
            {
                var results = new Dictionary<string, int>();

                foreach (var symbol in dataSet.AsEnumerable().Distinct().OrderBy(x => x))
                {
                    var numberOfInstances = dataSet.AsEnumerable().Count(x => x.Equals(symbol));
                    results.Add(symbol.ToString(), numberOfInstances);
                }

                return string.Join(" ", results.Select(x => x.Value.ToString()));
            }

            public static string Solve3(string dataSet)
            {
                return dataSet
                    .GroupBy(x => x)
                    .OrderBy(x => x.Key)
                    .Select(x => x.Count())
                    .Select(x => x.ToString())
                    .Aggregate((current, next) => string.Format("{0} {1}", current, next));
            }
        }
    }
}