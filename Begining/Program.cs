using System;

namespace Begining
{
    class Program
    {
        static void Main(string[] args)
        {
            //                                       7
            //                                      /  \
            //                                 1    |   8            
            //                                / \   |     \            
            //                               2   3 <-      9            
            //                               \    \        /            
            //                                 5<- 4 -> 10
            //                                     | 
            //                                     V
            //                                     11
            //                                   /    \
            //                                 12  -  13
            //
            
            var n01 = new Node(1);
            var n02 = new Node(2);
            var n03 = new Node(3);
            var n04 = new Node(4);
            var n05 = new Node(5);
            var n06 = new Node(6);
            var n07 = new Node(7);
            var n08 = new Node(8);
            var n09 = new Node(9);
            var n10 = new Node(10);
            var n11 = new Node(11);
            var n12 = new Node(12);
            var n13 = new Node(13);

            n01.AddNeigbors(n02).AddNeigbors(n03);
            n02.AddNeigbors(n05);
            n03.AddNeigbors(n04);
            n04.AddNeigbors(n05).AddNeigbors(n10).AddNeigbors(n11);
            n06.AddNeigbors(n01);
            n07.AddNeigbors(n03).AddNeigbors(n08);
            n09.AddNeigbors(n08).AddNeigbors(n10);
            n11.AddNeigbors(n12).AddNeigbors(n13);
            n12.AddNeigbors(n13);

            DepthFirstSearch.DFS(n01, n13);
            Console.WriteLine();
            BreadthFirstSearch.BFS(n01, n13);
        }
    }
}
