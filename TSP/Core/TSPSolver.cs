using System.Linq;

namespace TSP.Core
{
    internal static class TSPSolver
    {
        public static (int[], int) Solve(int[,] weights)
        {
            return Evaluate(weights);
        }

        private static (int[], int) Evaluate(int[,] weights)
        {
            var minPrice = int.MaxValue;
            var result = new int[0];

            var permutations = Permutator.GetPermutations(new int[weights.GetLength(0)]);

            foreach (var permutation in permutations)
            {
                var price = permutation.Select((t, i) => weights[t, permutation[(i + 1) % permutation.Length]]).Sum();
                if (price >= minPrice) continue;
                minPrice = price;
                result = permutation;
            }

            return (result, minPrice);
        }
    }
}