using System;

namespace Task_2
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

        public const int monthsInYear = 12;
        private static int month;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Write("Hello! Do you want to know the name of month? Enter its number:  ");

            bool isNumber = (int.TryParse(Console.ReadLine(), out month));

            if (isNumber && (1 <= month) && (month <= monthsInYear))
            {
                Console.Write($"The name of month is {(Months)month}");
            }
            else
            {
                Console.Write($"Oh, no! There is no such month in year :( ");
            }

            Console.WriteLine();
        }
    }
}
