using System;

namespace Begining
{   /*
    Написать программу, выводящую элементы двухмерного массива по диагонали.
   */
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();

            Console.Write("Enter the dimension of the matrix: ");

            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            Console.WriteLine("Current matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Main diagonal: ");
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(matrix[i, i] + " ");
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Side diagonal: ");
            Console.ForegroundColor = ConsoleColor.Black;

            for (int j = matrix.GetLength(0) - 1, i = 0; j >= 0; i++, j--)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}
