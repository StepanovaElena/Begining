using System;
using System.IO;

namespace Task_2_5
{
    /*
     * Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
     */
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "startup.txt";
            File.WriteAllText(filename, $"Текущие дата и время (локальное): {DateTime.UtcNow.ToLocalTime()}");

            string fileString = File.ReadAllText(filename);            
            Console.WriteLine(fileString);            
        }
    }
}
