using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Rosalind
{
    [TestFixture]
    public class Translating_RNA_into_Protein
    {
//Problem
//The 20 commonly occurring amino acids are abbreviated by using 20 letters from the English alphabet (all letters except for B, J, O, U, X, and Z). Protein strings are constructed from these 20 symbols. Henceforth, the term genetic string will incorporate protein strings along with DNA strings and RNA strings.

//The RNA codon table dictates the details regarding the encoding of specific codons into the amino acid alphabet.

//Given: An RNA string s corresponding to a strand of mRNA (of length at most 10 kbp).

//Return: The protein string encoded by s.

//Sample Dataset

//AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA

//Sample Output

//MAMAPRTEINSTRING

        [Test]
        public void Problem1()
        {
            var result = Solution.Solve1("AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA");

            var expected = "MAMAPRTEINSTRING";

            Assert.That(result, Is.EqualTo(expected));
        }

        public static class Solution
        {
            private static readonly Dictionary<string, string> _rnaCodonMappings = new Dictionary<string, string>();

            const string STOP = "Stop";

            static Solution()
            {
                _rnaCodonMappings.Add("UUU", "F");
                _rnaCodonMappings.Add("UUC", "F");
                _rnaCodonMappings.Add("UUA", "L");
                _rnaCodonMappings.Add("UUG", "L");
                _rnaCodonMappings.Add("UCU", "S");
                _rnaCodonMappings.Add("UCC", "S");
                _rnaCodonMappings.Add("UCA", "S");
                _rnaCodonMappings.Add("UCG", "S");
                _rnaCodonMappings.Add("UAU", "Y");
                _rnaCodonMappings.Add("UAC", "Y");
                _rnaCodonMappings.Add("UAA", STOP);
                _rnaCodonMappings.Add("UAG", STOP);
                _rnaCodonMappings.Add("UGU", "C");
                _rnaCodonMappings.Add("UGC", "C");
                _rnaCodonMappings.Add("UGA", STOP);
                _rnaCodonMappings.Add("UGG", "W");
                _rnaCodonMappings.Add("CUU", "L");
                _rnaCodonMappings.Add("CUC", "L");
                _rnaCodonMappings.Add("CUA", "L");
                _rnaCodonMappings.Add("CUG", "L");
                _rnaCodonMappings.Add("CCU", "P");
                _rnaCodonMappings.Add("CCC", "P");
                _rnaCodonMappings.Add("CCA", "P");
                _rnaCodonMappings.Add("CCG", "P");
                _rnaCodonMappings.Add("CAU", "H");
                _rnaCodonMappings.Add("CAC", "H");
                _rnaCodonMappings.Add("CAA", "Q");
                _rnaCodonMappings.Add("CAG", "Q");
                _rnaCodonMappings.Add("CGU", "R");
                _rnaCodonMappings.Add("CGC", "R");
                _rnaCodonMappings.Add("CGA", "R");
                _rnaCodonMappings.Add("CGG", "R");
                _rnaCodonMappings.Add("AUU", "I");
                _rnaCodonMappings.Add("AUC", "I");
                _rnaCodonMappings.Add("AUA", "I");
                _rnaCodonMappings.Add("AUG", "M");
                _rnaCodonMappings.Add("ACU", "T");
                _rnaCodonMappings.Add("ACC", "T");
                _rnaCodonMappings.Add("ACA", "T");
                _rnaCodonMappings.Add("ACG", "T");
                _rnaCodonMappings.Add("AAU", "N");
                _rnaCodonMappings.Add("AAC", "N");
                _rnaCodonMappings.Add("AAA", "K");
                _rnaCodonMappings.Add("AAG", "K");
                _rnaCodonMappings.Add("AGU", "S");
                _rnaCodonMappings.Add("AGC", "S");
                _rnaCodonMappings.Add("AGA", "R");
                _rnaCodonMappings.Add("AGG", "R");
                _rnaCodonMappings.Add("GUU", "V");
                _rnaCodonMappings.Add("GUC", "V");
                _rnaCodonMappings.Add("GUA", "V");
                _rnaCodonMappings.Add("GUG", "V");
                _rnaCodonMappings.Add("GCU", "A");
                _rnaCodonMappings.Add("GCC", "A");
                _rnaCodonMappings.Add("GCA", "A");
                _rnaCodonMappings.Add("GCG", "A");
                _rnaCodonMappings.Add("GAU", "D");
                _rnaCodonMappings.Add("GAC", "D");
                _rnaCodonMappings.Add("GAA", "E");
                _rnaCodonMappings.Add("GAG", "E");
                _rnaCodonMappings.Add("GGU", "G");
                _rnaCodonMappings.Add("GGC", "G");
                _rnaCodonMappings.Add("GGA", "G");
                _rnaCodonMappings.Add("GGG", "G");
            }

            public static string Solve1(string dataSet)
            {
                var result = dataSet
                    .Split(3)
                    .Select(x => _rnaCodonMappings[x])
                    .Aggregate((current, next) => string.Format("{0}{1}", current, next));

                var indexOfStop = result.IndexOf(STOP);
                if (indexOfStop > 0)
                {
                    result = result.Substring(0, indexOfStop);
                }

                return result;
            }
        }
    }

    public static class StringExtensions
    {
        public static IEnumerable<string> Split(this string source, int chunkSize)
        {
            return Enumerable.Range(0, source.Length / chunkSize)
                .Select(i => source.Substring(i * chunkSize, chunkSize));
        }
    }
}