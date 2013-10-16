using System;
using System.Linq;

using NUnit.Framework;

namespace Rosalind
{
    [TestFixture]
    public class Computing_GC_Content
    {
//Given: At most 10 DNA strings in FASTA format (of length at most 1 kbp each).

//Return: The ID of the string having the highest GC-content, followed by the GC-content of that string. Rosalind allows for a default error of 0.001 in all decimal answers unless otherwise stated; please see the note on absolute error below.

//Sample Dataset

//>Rosalind_6404
//CCTGCGGAAGATCGGCACTAGAATAGCCAGAACCGTTTCTCTGAGGCTTCCGGCCTTCCC
//TCCCACTAATAATTCTGAGG
//>Rosalind_5959
//CCATCGGTAGCGCATCCTTAGTCCAATTAAGTCCCTATCCAGGCGCTCCGCCGAAGGTCT
//ATATCCATTTGTCAGCAGACACGC
//>Rosalind_0808
//CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCCGGAC
//TGGGAACCTGCGGGCAGTAGGTGGAAT

//Sample Output

//Rosalind_0808
//60.919540

        [Test]
        public void Problem1()
        {
            var result = Solution.Solve1(@">Rosalind_6404
CCTGCGGAAGATCGGCACTAGAATAGCCAGAACCGTTTCTCTGAGGCTTCCGGCCTTCCC
TCCCACTAATAATTCTGAGG
>Rosalind_5959
CCATCGGTAGCGCATCCTTAGTCCAATTAAGTCCCTATCCAGGCGCTCCGCCGAAGGTCT
ATATCCATTTGTCAGCAGACACGC
>Rosalind_0808
CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCCGGAC
TGGGAACCTGCGGGCAGTAGGTGGAAT");

            var expected = @"Rosalind_0808
60.919540";

            Assert.That(result.Id + "\n" + Math.Round(result.GC_Content,6), Is.EqualTo(expected));
        }

        public static class Solution
        {
            public static Fasta Solve1(string dataSet)
            {
                // Stage 1 of processing FASTA format - break up into seperate FASTA chunks
                var fastas = dataSet.Split('>').Skip(1);

                var items = fastas
                    .Select(x =>
                    {
                        // Stage 2 of processing FASTA format - break up the chunk into it's constituents
                        var data = x.Split('\n');

                        var id = data[0];

                        var dna = data
                            .Skip(1)
                            .Take(data.Count() - 1)
                            .Aggregate(string.Empty,
                                       (current, next) => string.Format("{0}{1}", current, next.Split('\r')[0]));

                        // Calculate the GC Content
                        decimal numberOfCorG = dna.Count(y => y == 'G' || y == 'C');
                        var gcContent = numberOfCorG/dna.Count()*100;

                        return new Fasta
                        {
                            Id = id,
                            Dna = dna,
                            GC_Content = gcContent
                        };
                    })
                    .ToList();

                return items.OrderByDescending(x => x.GC_Content).First();
            }

            public class Fasta
            {
                public string Id { get; set; }

                public string Dna { get; set; }

                public decimal GC_Content { get; set; }
            }
        }
    }
}
