using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Begining
{
    
    /*
    Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет 
    завершить указанный процесс. Предусмотреть возможность завершения процессов с помощью указания его ID или 
    имени процесса. В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.
     */   
    class Program
    {
        private static Process[] processesList;
        private static Paginator paginator;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            StartUp();

            Console.WriteLine();
        }

        private static void StartUp()
        {
            processesList = Process.GetProcesses();
            paginator = new Paginator(processesList.Length);

            Prosessing();           
        }

        private static void Prosessing()
        {            
            CreateList();

            Console.WriteLine();
            Console.WriteLine($"Next page - [N]   Previous page - [P]    Filter process - [F]   Cancel Filter - [C]");
            Console.WriteLine($"Cancel process - [K]   To escape - [E]: ");

            ConsoleKeyInfo ckey = Console.ReadKey();            

            if (ckey.Key == ConsoleKey.N && paginator.CurrentPage != paginator.TotalPages)
            {
                paginator = new Paginator(processesList.Length, paginator.CurrentPage + 1);
            }

            if (ckey.Key == ConsoleKey.P && paginator.CurrentPage > 0)
            {
                paginator = new Paginator(processesList.Length, paginator.CurrentPage - 1);
            }

            if (ckey.Key == ConsoleKey.F)
            {
                Filtering();
            }

            if (ckey.Key == ConsoleKey.C)
            {
                Update();
            }

            if (ckey.Key == ConsoleKey.K)
            {
                Cancel();
                Update();
            }

            if (ckey.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("-- Task Manager --");
                Console.WriteLine("Bye-bye!");
                return;
            }

            Prosessing();
        }

        private static void Cancel()
        {
            Console.WriteLine();
            Console.Write("Enter process ID or name to cancel: ");
            string inputValue = Console.ReadLine();
            bool isNumber = (int.TryParse(inputValue, out int id));

            if (!isNumber)
            {                
                CancelProcessByName(inputValue);
            }
            else
            {
                CancelProcessById(id);
            }            
        }

        private static void CancelProcessById(int id)
        {
            Process process = GetProcessById(id);
            process.Kill();
        }

        private static void CancelProcessByName(string name)
        {
            Process[] processes = GetProcessByName(name);
            foreach (Process process in processes)
            {
                process.Kill();
            }            
        }

        private static void CreateList()
        {
            Console.Clear();
            Console.WriteLine("-- Task Manager --");
            Console.WriteLine("{0, 8}   {1, 50}   {2, 20}", "ID", "Name", "Memory Size MB");
            Console.WriteLine(String.Empty.PadLeft(100, '='));

            for (int i = paginator.StartIndex; i <= paginator.EndIndex; i++)
            {
                var memorySize = string.Format("{0:0.00}", Convert.ToDouble(processesList[i].VirtualMemorySize64 / Math.Pow(1024, 2)));
                Console.WriteLine("{0, 8}   {1, 50}   {2, 20}", processesList[i].Id, processesList[i].ProcessName, memorySize);
            }

            Console.WriteLine();
            Console.WriteLine(String.Empty.PadLeft(100, '='));
            Console.WriteLine($"Page {paginator.CurrentPage} from {paginator.TotalPages}");
            Console.WriteLine($"Number of Rows on page {paginator.PageSize}");
        }

        private static void Filtering()
        {
            Console.WriteLine();
            Console.Write("Enter name: ");

            string name = Console.ReadLine();
            processesList = GetProcessByName(name);

            if (processesList.Length == 0)
            {
                Console.WriteLine($"There are no processes with name {name}");
                Console.ReadLine();
                processesList = Process.GetProcesses();
            }

            paginator = new Paginator(processesList.Length);
        }

        private static Process GetProcessById(int id)
        {
            return Process.GetProcessById(id);
        }

        private static Process[] GetProcessByName(string name)
        {
            return Process.GetProcessesByName(name);
        }

        private static void Update()
        {
            processesList = Process.GetProcesses();
            paginator = new Paginator(processesList.Length);
        }
    }
}
