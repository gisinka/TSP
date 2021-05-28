using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP.Core
{
    public static class Permutator
    {
        public static List<int[]> GetPermutations(int[] permutation)
        {
            return MakePermutations(permutation, new List<int[]>());
        }

        private static List<int[]> MakePermutations(int[] permutation, List<int[]> permutations, int position = 0)
        {
            if (position == permutation.Length)
            {
                permutations.Add(permutation.ToArray());
                return permutations;
            }

            for (var i = 0; i < permutation.Length; i++)
            {
                var index = Array.IndexOf(permutation, i, 0, position);
                if (index != -1)
                    continue;
                permutation[position] = i;
                MakePermutations(permutation, permutations, position + 1);
            }

            return permutations;
        }
    }
}