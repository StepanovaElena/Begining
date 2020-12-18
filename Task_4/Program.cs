using System;

namespace Task_4
{
    class Program
    {
        enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        private const int monthsInYear = 12;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            int minTemp;
            int maxTemp;
            int month;
            
            Console.Write("Enter min temperature:  ");
            bool isMinTempInt = int.TryParse(Console.ReadLine(), out minTemp);
            if(!isMinTempInt)
            {
                Console.Write("Incorrect temperature!");
                return;
            }

            Console.Write("Enter max temperature:  ");
            bool isMaxTempInt = int.TryParse(Console.ReadLine(), out maxTemp);
            if (!isMaxTempInt)
            {
                Console.Write("Incorrect temperature!");
                return;
            }

            if (maxTemp < minTemp)
            {
                Console.Write("Incorrect max temperature!");
                return;
            }

            var avrgTemp = (maxTemp + minTemp) / 2;            

            Console.Write("Enter month number:  ");
            bool isMonthNumberInt = (int.TryParse(Console.ReadLine(), out month));

            if (!isMonthNumberInt || !(1 <= month && month <= monthsInYear))
            {
                Console.Write("Incorrect month!");
                return;
            }

            Console.Write($"The average daily temperature is ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{avrgTemp }");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.Write($"The name of month is ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{(Months)month}");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            if ((month == 12 || month <= 2) && avrgTemp > 0)
            {
                Console.Write($"Rainy winter");
            }
        }
    }
}
