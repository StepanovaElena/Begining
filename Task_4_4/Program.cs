using System;

namespace Task_4_4
{
    /* 
     * Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Write("Enter integer number: ");
            bool number = int.TryParse(Console.ReadLine(), out int res);

            if(number && res > 0)
            {
                for (int i = 0; i < res; i++)
                    Console.Write($"{Fib(i)} ");
            }
            else
            {
                Console.Write("Enter correct number!");
            }
        }

        private static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
