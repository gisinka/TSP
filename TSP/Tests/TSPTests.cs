using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TSP.Core;

namespace TSP.Tests
{
    [TestFixture]
    internal static class TSPTests
    {
        private static readonly Dictionary<string, int[,]> MatricesStorage = new Dictionary<string, int[,]>
        {
            {
                "dataset1", new[,]
                {
                    {0, 2, 4, 7},
                    {2, 0, 3, 1},
                    {4, 2, 0, 1},
                    {3, 5, 2, 0}
                }
            },
            {
                "dataset2", new[,]
                {
                    {0, 23, 25, 19},
                    {19, 0, 16, 18},
                    {25, 10, 0, 10},
                    {9, 4, 13, 0}
                }
            },
            {
                "dataset3", new[,]
                {
                    {0, 4, 5, 7, 5},
                    {8, 0, 5, 6, 6},
                    {3, 5, 0, 9, 6},
                    {3, 5, 6, 0, 2},
                    {6, 2, 3, 8, 0}
                }
            },
            {
                "dataset4", new[,]
                {
                    {0, 90, 80, 40, 100},
                    {60, 0, 40, 50, 70},
                    {50, 30, 0, 60, 20},
                    {10, 70, 20, 0, 50},
                    {20, 40, 50, 20, 0}
                }
            },
            {
                "dataset5", new[,]
                {
                    {0, 10, 5, 9, 16, 8},
                    {6, 0, 11, 8, 18, 19},
                    {7, 13, 0, 3, 4, 14},
                    {5, 9, 6, 0, 12, 17},
                    {5, 4, 11, 6, 0, 14},
                    {17, 7, 12, 13, 16, 0}
                }
            }
        };

        [TestCase("dataset1", 9)]
        [TestCase("dataset2", 58)]
        [TestCase("dataset3", 18)]
        [TestCase("dataset4", 180)]
        [TestCase("dataset5", 38)]
        public static void PathPriceTest(string dataset, int expectedPrice)
        {
            var matrix = MatricesStorage[dataset];
            var (path, calculatedPrice) = TSPSolver.Solve(matrix);
            Assert.AreEqual(expectedPrice, calculatedPrice);
            Assert.AreEqual(expectedPrice, path.Select((t, i) => matrix[t, path[(i + 1) % path.Length]]).Sum());
        }

        [TestCase("dataset1")]
        [TestCase("dataset2")]
        [TestCase("dataset3")]
        [TestCase("dataset4")]
        [TestCase("dataset5")]
        public static void PathLengthTest(string dataset)
        {
            var matrix = MatricesStorage[dataset];
            Assert.AreEqual(matrix.GetLength(0), TSPSolver.Solve(matrix).Item1.GetLength(0));
        }

        [TestCase("dataset1")]
        [TestCase("dataset2")]
        [TestCase("dataset3")]
        [TestCase("dataset4")]
        [TestCase("dataset5")]
        public static void PathElementsUniqueTest(string dataset)
        {
            var matrix = MatricesStorage[dataset];
            var path = TSPSolver.Solve(matrix).Item1;
            Assert.AreEqual(path.Distinct().Count(), path.Length);
        }
    }
}