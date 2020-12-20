using System;

namespace Task_3_4
{
    /* Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца. На выходе — 
     * значение из перечисления (enum) — Winter, Spring, Summer, Autumn. Написать метод, принимающий на вход значение из этого перечисления и 
     * возвращающий название времени года (зима, весна, лето, осень). Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.
     * Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
     */
    enum Seasons
    {
        Winter = 1,
        Spring,
        Summer,
        Autumn
    }
    class Program    
    {                
        static void Main(string[] args)
        {
            int monthsInYear = 12;

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Write("Hello!");
            Console.WriteLine("Enter month number:  ");

            bool isNumber = (int.TryParse(Console.ReadLine(), out int month));

            if (isNumber && (1 <= month) && (month <= monthsInYear))
            {
                ShowSeason(month);
            }
            else
            {
                Console.Write($"Oh, no! There is no such month in year :( ");
            }

            Console.WriteLine();
        }

        private static void ShowSeason(int month)
        {
            switch(month)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine($"Season is \"{GetSeasonName(Seasons.Winter)}\"");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine($"Season is \"{GetSeasonName(Seasons.Spring)}\"");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine($"Season is \"{GetSeasonName(Seasons.Summer)}\"");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine($"Season is \"{GetSeasonName(Seasons.Autumn)}\"");
                    break;
            }
        }

        private static string GetSeasonName(Seasons season)
        {
            string seasonName = "";
            
            switch (season)
            {
                case Seasons.Winter:
                    seasonName = "зима";
                    break;
                case Seasons.Spring:               
                    seasonName = "весна";
                    break;
                case Seasons.Summer:               
                    seasonName = "лето";
                    break;
                case Seasons.Autumn:
                    seasonName = "осень";
                    break;
            }

            return seasonName;
        }
    }
}
