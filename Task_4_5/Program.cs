using System;
using System.IO;
using System.Collections.Generic;

namespace Task_4_5
{
    /*
     * Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.          
     */

    class Program
    {
        private static string prefix = "";
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.Write("Enter path to Dir:  ");
            string pathToDir = Console.ReadLine();

            bool dirExist = Directory.Exists(pathToDir);
           
            if (String.IsNullOrWhiteSpace(pathToDir) || !dirExist )
            {
                Console.WriteLine("Incorrect data!");
                return;
            }

            File.WriteAllText("dirs.txt", "");
            File.WriteAllText("dirsRec.txt", $"{new DirectoryInfo(pathToDir).Name}" + Environment.NewLine);

            Tree(pathToDir);
            RecursiveTree(pathToDir);
        }
        public static void Tree(string pathToDir)
        {

            Stack<string> dirs = new Stack<string>(20);
            string pref = "";
            DirectoryInfo nextDirInfo = null;

            if (!Directory.Exists(pathToDir))
            {
                throw new ArgumentException();
            }

            dirs.Push(pathToDir);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();

                if(dirs.Count > 0)
                {
                    string nextDir = dirs.Peek();
                    nextDirInfo = new DirectoryInfo(nextDir);
                }                

                DirectoryInfo currentDirInfo = new DirectoryInfo(currentDir);
                
                File.AppendAllText("dirs.txt", pref + $"|--{currentDirInfo.Name}" + Environment.NewLine);

                pref += "|   ";

                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                foreach (string file in files)
                {
                    try
                    {                        
                        File.AppendAllText("dirs.txt", pref + $"|---{new FileInfo(file).Name}" + Environment.NewLine);
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
               
                foreach (string str in subDirs)
                {
                    dirs.Push(str); 
                }                

                if (subDirs.Length == 0)
                {
                    pref = pref.Remove(pref.Length - 4, 4);
                }

                if ((subDirs.Length == 0) && (nextDirInfo != null) && (nextDirInfo.Parent.ToString() != currentDirInfo.Parent.ToString()))
                {
                    pref = pref.Remove(pref.Length - 4, 4);
                }

                if ((subDirs.Length == 0) && (nextDirInfo != null) && (nextDirInfo.Parent.ToString() == pathToDir))
                {
                    pref = "|   ";
                }
            }
        }

        private static void RecursiveTree(string pathToDir)
        {
            prefix += "|   ";

            string[] files;
            try
            {
                files = Directory.GetFiles(pathToDir);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            foreach (string file in files)
            {
                try
                {                    
                    File.AppendAllText("dirsRec.txt", prefix + $"|---{new FileInfo(file).Name}" + Environment.NewLine);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string[] subDirs;
            try
            {
                subDirs = Directory.GetDirectories(pathToDir);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            foreach (string dirInfo in subDirs)
            {
                File.AppendAllText("dirsRec.txt", prefix + $"|---{new DirectoryInfo(dirInfo).Name}" + Environment.NewLine);
                RecursiveTree(dirInfo);
                prefix = prefix.Remove(prefix.Length - 4, 4);
            }
        }        
    } 
}