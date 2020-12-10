using System;

namespace Begining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("What is your name? ");

            var name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}, today is {DateTime.Now}!");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Bye-Bye!");
        }
    }
}
