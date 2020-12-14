using System;

namespace Task_3
{
    class Program
    {
        private static int number;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Write("Hello! Enter any number:  ");

            bool isNumber = (int.TryParse(Console.ReadLine(), out number));

            if (!isNumber)
            {
                Console.WriteLine("Inccorect input!");
                return;
            }

            var remainder = number % 2;

            if (remainder == 0)
            {
                Console.Write($"The Number is even!");
            }
            else
            {
                Console.Write("The Number is odd!");
            }

            Console.WriteLine();
        }
    }
}
