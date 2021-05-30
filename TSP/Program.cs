using System;
using TSP.Core;

namespace TSP
{
    internal class Program
    {
        private static void Main()
        {
            var (route, price) = TSPSolver.Solve(ReadMatrix());

            Console.WriteLine("Порядок посещения городов (нумерация с нуля): ");

            foreach (var item in route) Console.Write(item + " ");

            Console.WriteLine();
            Console.WriteLine($"Стоимость маршрута {price}");

            Console.WriteLine("Нажмите любую клавишу, чтобы закрыть утилиту...");
            Console.ReadKey();
        }

        private static int[,] ReadMatrix()
        {
            Console.WriteLine("Введите количество городов, которые должен обойти коммивояжер");
            var dimension = int.Parse(Console.ReadLine() ?? "0");
            var weights = new int[dimension, dimension];
            for (var i = 0; i < dimension; i++)
            {
                Console.Write($"Введите веса {i + 1}-ой строки матрицы через пробел: ");
                var row = Console.ReadLine()?.Split();
                for (var j = 0; j < dimension; j++)
                    if (row != null)
                        weights[i, j] = int.Parse(row[j] ?? "0");
                Console.WriteLine();
            }

            return weights;
        }
    }
}