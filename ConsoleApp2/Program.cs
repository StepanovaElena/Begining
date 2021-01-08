using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                Console.WriteLine("Enter your name:");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.Profession))
            {
                Console.WriteLine("Enter your proffesion:");
                Properties.Settings.Default.Profession = Console.ReadLine();
                Properties.Settings.Default.Save();
            }

            string userName = Properties.Settings.Default.UserName;
            string greeting = Properties.Settings.Default.Greeting;
            string profession = Properties.Settings.Default.Profession;
            Console.WriteLine($"{greeting}, {userName}, {profession}!");
            Console.ReadLine();
        }
    }
}
