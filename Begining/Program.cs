using System;

namespace Begining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("Hello! Do you want to know the average daily temperature?");
            Console.Write("Press [Y] to continue / [N] to escape:  ");

            ConsoleKeyInfo ck = Console.ReadKey();

            while (!(ck.Key == ConsoleKey.Y || ck.Key == ConsoleKey.N))
            {
                Console.WriteLine();
                Console.Write("Press [Y] to continue / [N] to escape:  ");
                ck = Console.ReadKey();
            }

            Console.Clear();

            if (ck.Key == ConsoleKey.Y)
            {
                Console.Write("Enter max temperature:  ");
                var minTemp = int.Parse(Console.ReadLine());

                Console.Write("Enter min temperature:  ");
                var maxTemp = int.Parse(Console.ReadLine());

                var avrgTemp = (maxTemp + minTemp) / 2;

                Console.Write($"The average daily temperature is ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{avrgTemp }");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            if (ck.Key == ConsoleKey.N)
            {
                Console.WriteLine("Bye-Bue!");
            }

        }
    }
}
