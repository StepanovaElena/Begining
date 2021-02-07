using System;

namespace Begining
{    
    public class BinaryTree
    {
        public Node Root
        {
            get;
            internal set;
        }

        public void Add(int val)
        {           

            if (Root == null)
            {
                Root = new Node(val, null, this);
            }
            else
            {
                InsertNode(Root, val);
            }
        }

        public void Delete(int val)
        {
            if (Root == null)
            {
                return;
            }
            
            var node = Search(val);

            if (node != null)
            {
                DeleteNode(node);
            }
            else
            {
                throw new Exception("No such element");
            }
        }

        public Node Search(int val)
        {
            return SearchNode(val, Root);
        }

        private void InsertNode(Node subtree, int val)
        {

            if (val < subtree.Data)
            {
                if (subtree.Left == null)
                {
                    subtree.Left = new Node(val, subtree, this);
                }
                else
                {
                    InsertNode(subtree.Left, val);
                }
            }                
            else if (subtree.Right == null)
             {
                 subtree.Right = new Node(val, subtree, this);
             }          
            else
            {
                InsertNode(subtree.Right, val);
            }

            subtree.Balance();
        }

        private Node SearchNode(int val, Node subtree)
        {
            if (subtree == null) return null;

            switch (val.CompareTo(subtree.Data))
            {
                case 1: return SearchNode(val, subtree.Right);
                case -1: return SearchNode(val, subtree.Left);
                case 0: return subtree;
                default: return null;
            }
        }

        private bool DeleteNode(Node node)
        {
            Node parentNode = node.Parent;  

            if (node.Right == null)
            {
                if (node.Parent == null)
                {
                    Root = node.Left; 

                    if (Root != null)
                    {
                        Root.Parent = null; 
                    }
                }
                else
                {
                    int result = node.Parent.Data.CompareTo(node.Data);

                    if (result > 0)
                    { 
                        node.Parent.Left = node.Left;
                    }
                    else if (result < 0)
                    {
                        node.Parent.Right = node.Left;
                    }
                }
            }
            else if (node.Right.Left == null) 
            {
                node.Right.Left = node.Left;

                if (node.Parent == null)
                {
                    Root = node.Right;

                    if (Root != null)
                    {
                        Root.Parent = null;
                    }
                }
                else
                {
                    int result = node.Parent.Data.CompareTo(node.Data);
                    if (result > 0)
                    {
                        node.Parent.Left = node.Right;
                    }
                    else if (result < 0)
                    {                      
                        node.Parent.Right = node.Right;
                    }
                }
            }
            else
            {
               Node leftmost = node.Right.Left;

                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                } 
                leftmost.Parent.Left = leftmost.Right;    
                leftmost.Left = node.Left;
                leftmost.Right = node.Right;

                if (node.Parent == null)
                {
                    Root = leftmost;

                    if (Root != null)
                    {
                        Root.Parent = null;
                    }
                }
                else
                {
                    int result = node.Parent.Data.CompareTo(node.Data);

                    if (result > 0)
                    {
                        node.Parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {                       
                        node.Parent.Right = leftmost;
                    }
                }
            }

            if (parentNode != null)
            {
                parentNode.Balance();
            }

            else
            {
                if (Root != null)
                {
                    Root.Balance();
                }
            }

            return true;
        }

        public void Print()
        {
            Print(Root, 4);
        }
        public void Print(Node node, int padding)
        {
            if (node != null)
            {
                if (node.Right != null)
                {
                    Print(node.Right, padding + 4);
                }

                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }

                if (node.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }

                Console.Write("(" + node.Data.ToString() + ")" + "\n ");
                if (node.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(node.Left, padding + 4);
                }
            }
        }        
    } 
}
