using System;
using System.IO;

namespace Begining
{
    /* 
     * Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "text.txt";

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            string age = Console.ReadLine();

            File.WriteAllText(filename, $"Name: {name}");
            File.AppendAllText(filename, Environment.NewLine); 
            File.AppendAllText(filename, $"Age: {age}");

            Console.WriteLine();

            string[] fileLines = File.ReadAllLines(filename);

            foreach (string line in fileLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
