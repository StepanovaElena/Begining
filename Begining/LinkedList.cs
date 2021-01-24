using System;
using System.Collections.Generic;
using System.Text;

namespace Begining
{
    public class LinkedList : ILinkedList
    {
        Node firstNode;
        Node lastNode;
        int count;  

        public void AddNode(int value)
        {
            Node node = new Node
            {
                Value = value
            };

            if (firstNode == null)
            {
                firstNode = node;
            }                
            else
            {
                lastNode.NextNode = node;
                node.PrevNode = lastNode;
            }

            lastNode = node;
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node
            {
                Value = value
            };

            newNode.PrevNode = node;
            newNode.NextNode = node.NextNode;

            if(node.Value.Equals(lastNode.Value))
            {
                lastNode = newNode;
            }

            node.NextNode = newNode;
            count++;
        }

        public Node FindNode(int searchValue)
        {
            Node current = firstNode;
            while (current != null)
            {
                if (current.Value.Equals(searchValue))
                {
                    break;
                }
                current = current.NextNode;
            }

            return current;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            Node node;
            int i;
            
            if (index < count / 2)
            {
                for (i = 0, node = firstNode; i != index; i++)
                {
                    node = node.NextNode;
                }
            }
            else
            {
                for (i = count - 1, node = lastNode; i != index; i--)
                {
                    node = node.PrevNode;
                }

            }               

            RemoveNode(node);
        }

        public void RemoveNode(Node node)
        {          
            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }
            else
            {                
                lastNode = node.PrevNode;
            }
           
            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }
            else
            {
                firstNode = node.NextNode;
            }

            count--;
        }
    }
}
