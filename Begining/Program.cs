using System;

namespace Begining
{
    /*
     Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
     Написать консольное приложение.
     Алгоритм реализовать отдельно в функции согласно блок-схеме.
     Написать проверочный код в main функции .
     Код выложить на GitHub.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
           
            Console.Write("Введите число:  ");

            bool isNumber = (int.TryParse(Console.ReadLine(), out int number));
            
            if (isNumber)
            {
                Console.Write(DetermineNumber(number));
            }
            else
            {
                Console.Write($"Введенное значение имеет неверный формат!");
            }
        }

        private static string DetermineNumber(int number)
        {
            int d = 0;
            int i = 2;
            string result;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                result = "Число просто";
            }
            else
            {
                result ="Число не простое";
            }

            return result;
        }
    }
}
