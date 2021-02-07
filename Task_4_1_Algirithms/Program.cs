using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task_4_1_Algirithms
{
    /* 
     Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно сгенерировать.
     Потом выполните замер производительности проверки наличия строки в массиве и HashSet.
     Выложите код и результат замеров.
     */
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }

        public class BechmarkClass
        {
            public static int num_elements = 10000;

            public static HashSet<string> stringHash = new HashSet<string>();
            public static List<string> stringList = new List<string>();

            public BechmarkClass()
            {
               FillArrays();
            }

            public void FillArrays()
            {
                for (int i = 0; i < num_elements; i++)
                {
                    string insertedString = GetString();
                    stringList.Add(insertedString);
                    stringHash.Add(insertedString);
                }
            }

            public string GetString()
            {
                char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                Random rand = new Random();               
                int num_letters = rand.Next(3, 10);
                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }              

                return word;
            }

            [Benchmark]
            public void TestHashSearch()
            {
                if (stringHash.Contains("WORD"))
                {
                    Console.WriteLine(string.Format("Слово WORD содержится в массиве"));
                }
            }

            [Benchmark]
            public void TestListSearch()
            {
                if (stringList.Contains("WORD"))
                {
                    Console.WriteLine(string.Format("Слово WORD содержится в массиве"));
                }
            }            
        }
    }
}
