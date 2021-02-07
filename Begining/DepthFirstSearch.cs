using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Begining
{
    class DepthFirstSearch
    {
        private static HashSet<Node> visited = new HashSet<Node>();
        private static Node Goal;

        public static bool DFS(Node start, Node goal)
        {
            Goal = goal;
            Console.Write($"{start.Data}");
            return Search(start);
        }

        private static bool Search(Node node)
        {     
            if (node == Goal)
            {
                return true;
            }

            visited.Add(node);

            foreach (Node neighbor in node.Neighbors.Where(x => !visited.Contains(x)))
            {
                Console.Write($"-> {neighbor.Data}");

                if (Search(neighbor))
                {
                   return true;
                }
            }

            return false;
        }
    }
}
