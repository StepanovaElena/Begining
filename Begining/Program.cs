using System;

namespace Begining
{
    /*
     Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах 
     и возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            string[,] peopleData = new string[3, 3];

            Console.WriteLine("Enter some data about three people you want to invite!");

            for (int i = 0; i < peopleData.GetLength(0); i++)
            {
                Console.Write("Enter first name:  ");
                string firstName = Console.ReadLine();
                Console.Write("Enter last name:  ");
                string lastName = Console.ReadLine();
                Console.Write("Enter middle name:  ");
                string middleName = Console.ReadLine();

                bool incorrectData = String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(middleName);

                while (incorrectData)
                {
                    Console.WriteLine("Enter correct data! Parametr can't be empty!");
                    Console.Write("Enter first name:  ");
                    firstName = Console.ReadLine();
                    Console.Write("Enter last name:  ");
                    lastName = Console.ReadLine();
                    Console.Write("Enter middle name:  ");
                    middleName = Console.ReadLine();
                    incorrectData = String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(middleName);
                    Console.WriteLine();
                }

                peopleData[i, 0] = firstName;
                peopleData[i, 1] = lastName;
                peopleData[i, 2] = middleName;
            }

            Console.WriteLine("You want to invite:  ");

            for (int i = 0; i < peopleData.GetLength(0); i++)
            {
                int numberInList = i + 1;
                Console.WriteLine($"{numberInList}. {GetFullName(peopleData[i, 0], peopleData[i, 1], peopleData[i, 2])}");
            } 
        }
        private static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} {patronymic} {lastName}";
        }

    }
}
