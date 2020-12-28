using System;
using System.IO;
using System.Text;

namespace Task_3_5
{
    /*
     * Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
     */
    class Program
    {
        private static readonly string[] exceptions = { ";", "_", "|", ",", ":", "?" };
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("Enter numbers from 0 to 255 divided by whitespace: ");
            string numbers = Console.ReadLine();

            bool emptyData = String.IsNullOrWhiteSpace(numbers);
            bool hasExceptions = HasExceptions(numbers);
            bool hasLetters = HasLetters(numbers);

            if (emptyData || hasExceptions || hasLetters)
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect string!");
                return;
            }

            string[] strArr = numbers.Trim().Split(' ');


            File.WriteAllBytes("bytes.bin", ConvertedString(strArr));            
        }

        private static bool HasExceptions(string inputStr)
        {
            foreach (string exp in exceptions)
            {
                if (inputStr.Contains(exp))
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

        private static byte[] ConvertedString(string[] strArr)
        {
            byte[] doubleArr = new byte[strArr.Length];

            for (int i = 0; i < strArr.Length; i++)
            {
                try
                {
                    doubleArr[i] = Convert.ToByte(strArr[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }                
            }

            return doubleArr;
        }
    
    }
}
