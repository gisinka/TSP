using System.Collections.Generic;
using NUnit.Framework;
using TSP.Core;

namespace TSP.Tests
{
    [TestFixture]
    internal static class PermutationTests
    {
        private static readonly Dictionary<string, int[]> ArrayStorage = new Dictionary<string, int[]>
        {
            {"dataset1", new int[0]},
            {"dataset2", new int[1]},
            {"dataset3", new int[2]},
            {"dataset4", new int[3]},
            {"dataset5", new int[4]}
        };

        private static readonly Dictionary<string, List<int[]>> PermutationsStorage =
            new Dictionary<string, List<int[]>>
            {
                {"permutations1", new List<int[]> {new int[0]}},
                {"permutations2", new List<int[]> {new[] {0}}},
                {"permutations3", new List<int[]> {new[] {0, 1}, new[] {1, 0}}},
                {"permutations4", new List<int[]> {new[] {0, 1, 2}, new[] {0, 2, 1}, new[] {1, 0, 2}, new[] {1, 2, 0}, new[] {2, 0, 1}, new[] {2, 1, 0}}},
                {
                    "permutations5",
                    new List<int[]>
                    {
                        new[] {0, 1, 2, 3}, new[] {0, 1, 3, 2}, new[] {0, 2, 1, 3}, new[] {0, 2, 3, 1},
                        new[] {0, 3, 1, 2}, new[] {0, 3, 2, 1}, new[] {1, 0, 2, 3}, new[] {1, 0, 3, 2},
                        new[] {1, 2, 0, 3}, new[] {1, 2, 3, 0}, new[] {1, 3, 0, 2}, new[] {1, 3, 2, 0},
                        new[] {2, 0, 1, 3}, new[] {2, 0, 3, 1}, new[] {2, 1, 0, 3}, new[] {2, 1, 3, 0},
                        new[] {2, 3, 0, 1}, new[] {2, 3, 1, 0}, new[] {3, 0, 1, 2}, new[] {3, 0, 2, 1},
                        new[] {3, 1, 0, 2}, new[] {3, 1, 2, 0}, new[] {3, 2, 0, 1}, new[] {3, 2, 1, 0}
                    }
                }
            };

        [TestCase("dataset1", "permutations1")]
        [TestCase("dataset2", "permutations2")]
        [TestCase("dataset3", "permutations3")]
        [TestCase("dataset4", "permutations4")]
        [TestCase("dataset5", "permutations5")]
        public static void PermutationTest(string dataset, string permutations)
        {
            Assert.AreEqual(PermutationsStorage[permutations], Permutator.GetPermutations(ArrayStorage[dataset]));
        }
    }
}