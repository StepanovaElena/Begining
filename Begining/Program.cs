using System;

namespace Begining
{
    /*Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль. */
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree btr = new BinaryTree();
            btr.Add(6);
            btr.Add(2);
            btr.Add(3);
            btr.Add(35);
            btr.Add(16);
            btr.Add(21);
            btr.Print();

            Console.WriteLine($"BFS Search - 6");
            btr.BFSSearch(6);
            Console.WriteLine($"BFS Search - 21");
            btr.BFSSearch(21);

            Console.WriteLine($"DFS Search - 6");
            btr.DFSSearch(6);

            Console.WriteLine($"DFS Search - 21");
            btr.DFSSearch(21);
        }
    }
}
