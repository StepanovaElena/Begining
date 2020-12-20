using System;

namespace Task_2_4
{
    /*
     Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке. 
     Ввести данные с клавиатуры и вывести результат на экран.
     */
    class Program
    {
        private static readonly string[] exceptions = { ";", "_", "|", ",", ":", "?"};
        static void Main(string[] args)
        {            
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("Enter numbers spleted by whitespace: ");
            string numbers = Console.ReadLine();

            bool emptyData = String.IsNullOrWhiteSpace(numbers);
            bool hasExceptions = HasExceptions(numbers);
            bool hasLetters = HasLetters(numbers);

            if(emptyData || hasExceptions || hasLetters)
            {
                Console.WriteLine("Incorrect string!");
                return;
            }

            string[] strArr = numbers.Trim().Split(" ");
            double summ = 0;

            foreach (string chr in strArr)
            {
                summ += Math.Round(Convert.ToDouble(chr), 2);
            }

            Console.WriteLine($"Summ: {summ}");
        }

        private static bool HasExceptions(string inputStr)
        {
            foreach(string exp in exceptions)
            {
                if(inputStr.Contains(exp))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasLetters(string inputStr)
        {
            char[] charArr = inputStr.ToCharArray();
            
            foreach (char chr in charArr)
            {
                if (Char.IsLetter(chr))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
