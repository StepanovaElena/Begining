using System;
using System.Text.RegularExpressions;

namespace Task_2_3
{
    /*
    Написать программу — телефонный справочник — создать двумерный массив 5*2, хранящий список телефонных контактов: 
    первый элемент хранит имя контакта, второй — номер телефона/e-mail.
   */
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();
            string[,] matrix = new string[5, 2];

            string pattern = @"\(\d{3}\)[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                        
            if (matrix[0,0] == null)
            {
                Console.WriteLine("Phone directory is empty!");
                Console.Write("Add contacts!");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.Write("Enter Name: ");
                    matrix[i, 0] = Console.ReadLine();

                    Console.Write("Enter Telephone Number in format (000)0000000: ");
                    var phoneNumber = Console.ReadLine();
                    var matching = regex.Match(phoneNumber);

                    while (!matching.Success)
                    {
                        Console.Write("Incorrect Number!");
                        Console.Write("Enter Telephone Number in format +7(000)0000000");
                        phoneNumber = Console.ReadLine();
                        matching = regex.Match(phoneNumber);
                    }

                    matrix[i, 1] = $"+7{phoneNumber}";
                }
                
            }

            Console.WriteLine("Phone directory:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(matrix[i, 0] + " : ");
                Console.WriteLine(matrix[i, 1]);
            }
        }
    }
}
