using System;
using System.Collections.Generic;
using System.Text;

namespace Begining
{
    public class Node
    {
        public int Data { get; }
        public List<Node> Neighbors { get; }

        public Node(int data)
        {
            Data = data;
            Neighbors = new List<Node>();
        }

        public Node AddNeigbors(Node node)
        {
            Neighbors.Add(node);
            return this;
        }
    }
}
