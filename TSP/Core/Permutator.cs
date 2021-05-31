using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP.Core
{
    public static class Permutator<T>
    {
        public static List<int[]> GetIndexPermutations(int length)
        {
            return MakePermutations(new int[length], new List<int[]>());
        }

        public static List<T[]> GetPermutations(T[] array)
        {
            var indexPermutations = MakePermutations(new int[array.Length], new List<int[]>());
            return indexPermutations
                .Select(x => x.Select(y => array[y]).ToArray())
                .ToList();
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