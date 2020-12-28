using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;



namespace Task_5_5
{
    /*     
     * Список задач (ToDo-list):
        написать приложение для ввода списка задач;
        задачу описать классом ToDo с полями Title и IsDone;
        на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
        если задача выполнена, вывести перед её названием строку «[x]»;
        вывести порядковый номер для каждой задачи;
        при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
        записать актуальный массив задач в файл tasks.json/xml/bin.
     */
    class Program
    {       
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();           
           
            StartUp();

            Console.WriteLine();

            Prosessing();
        }

        private static void StartUp()
        {
            Console.WriteLine("-- ToDo List --");

            if (!File.Exists("ToDoList.json")) {
                Console.WriteLine("You don't have ToDo list!");
                Console.ReadLine();
                AddTask();
            }

            Console.WriteLine();
            Console.WriteLine("To see tasks list press -[S] \nTo add new task press   -[A] \nTo done task press      -[D]");
            ConsoleKeyInfo ck = Console.ReadKey();

            while (!(ck.Key == ConsoleKey.A || ck.Key == ConsoleKey.S || ck.Key == ConsoleKey.D))
            {
                Console.WriteLine();
                Console.Write("To see tasks list press -[S] \n To add new task press  -[A] \nTo mark a task as Done press   -[D]");
                ck = Console.ReadKey();
            }

            switch (ck.Key)
            {
                case ConsoleKey.A:
                    AddTask();
                    break;
                case ConsoleKey.S:
                    InputTasksList();
                    break;
                case ConsoleKey.D:                    
                    MarkedTaskAsDone();                    
                    break;
            }
        } 
        
        private static void Prosessing()
        {
            Console.Write("Press [Y] to continue / [N] to escape:  ");

            ConsoleKeyInfo ckey = Console.ReadKey();

            while (!(ckey.Key == ConsoleKey.Y || ckey.Key == ConsoleKey.N))
            {
                Console.WriteLine();
                Console.Write("Press [Y] to continue / [N] to escape:  ");
                ckey = Console.ReadKey();
            }

            if (ckey.Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                StartUp();
                Prosessing();
            }

            if (ckey.Key == ConsoleKey.N)
            {
                Console.WriteLine();
                Console.WriteLine("Bye-Bue!");
            }
        }

        private static void AddTask()
        {
            Console.Clear();
            Console.WriteLine("-- Task adding --");

            List<ToDo> tasks = GetAllTasks();

            Console.Write("Enter Title:  ");
            string title = Console.ReadLine(); 

            if (String.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Incorrect data!");
                return;
            }
            
            ToDo task = new ToDo();
            task.Title = title;
            task.IsDone = false;
            
            tasks.Add(task);
            
            string json = JsonSerializer.Serialize(tasks.ToArray());
            File.WriteAllText("ToDoList.json", json);

            InputTasksList();
        }

        private static List<ToDo> GetAllTasks()
        {            
            List<ToDo> list = new List<ToDo>();

            if (!File.Exists("ToDoList.json"))
            {
                return new List<ToDo>();
            }

            string json = File.ReadAllText("ToDoList.json");

            if(String.IsNullOrWhiteSpace(json))
            {
                return new List<ToDo>();
            }

            return JsonSerializer.Deserialize<List<ToDo>>(json);
        }       

        private static void InputTasksList()
        {
            Console.Clear();
            Console.WriteLine(" -- ToDo List --");

            List<ToDo> tasks = GetAllTasks();            

            Console.WriteLine($"Number Done Task");

            for (int i = 0; i < tasks.Count; i++)
            {                
                if (tasks[i].IsDone)
                {
                    Console.WriteLine($"{i + 1}.     [X]   {tasks[i].Title}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}.     [ ]   {tasks[i].Title}");
                }
            }           
        } 

        private static void MarkedTaskAsDone()
        {
            List<ToDo> tasks = GetAllTasks();

            ToDo notDoneTask = tasks.Find(t => t.IsDone == false);

            if (notDoneTask == null)
            {
                Console.WriteLine($"All Tasks were done!!!");
                return;
            }

            InputTasksList();

            Console.Write("Enter Task number to mark as DONE :  ");
            int number = Convert.ToInt32(Console.ReadLine()) - 1;

            if (tasks[number].IsDone == true)
            {
                Console.WriteLine($"This Task had been done!!!");
                return;
            }

            tasks[number].IsDone = true;
        
            string json = JsonSerializer.Serialize(tasks.ToArray());
            File.WriteAllText("ToDoList.json", json);

            InputTasksList();
        }    
       
    }
}
