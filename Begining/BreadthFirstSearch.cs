using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Begining
{
    public class BreadthFirstSearch
    {
        private static Queue<Node> queue = new Queue<Node>();
        private static HashSet<Node> visited = new HashSet<Node>();
        private static Node Goal;

        public static bool BFS(Node start, Node goal)
        {
            Goal = goal;
            return Search(start);
        }
        private static bool Search(Node startNode)
        {
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.Write($"{node.Data} -> ");

                if (node == Goal)
                {
                    return true;
                }

                visited.Add(node);

                foreach (var neighbor in node.Neighbors.Where(n => !visited.Contains(n)))
                {                    
                    queue.Enqueue(neighbor);                    
                }
            }

            return false;
        }
    }
}
