using System;

namespace Begining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Как Ваше имя? ");

            var name = Console.ReadLine();

            Console.WriteLine($"Привет, {name}, сегодня {DateTime.Now}!");
            Console.ReadLine();

        }
    }
}
