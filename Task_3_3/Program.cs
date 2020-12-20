using System;

namespace Task_3_3
{
    /*
    Написать программу, выводящую введенную пользователем строку в обратном порядке (olleH вместо Hello).
   */
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();

            Console.WriteLine("Enter any string! ");

            string inputedString = Console.ReadLine();

            while (inputedString == null)
            {
                Console.Write("Enter any string! ");
            }

            char[] stringArr = inputedString.ToCharArray();
            Array.Reverse(stringArr);
            Console.Write("Reverted string: ");
            Console.WriteLine(new string(stringArr));
        }    
    }
}
