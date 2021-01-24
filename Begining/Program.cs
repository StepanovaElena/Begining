using System;

namespace Begining
{
    /*
     * Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом.
    */
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            
            linkedList.AddNode(34);
            linkedList.AddNode(45);
            linkedList.AddNode(56);
            linkedList.AddNodeAfter(linkedList.FindNode(45), 4);
            linkedList.RemoveNode(2);
        }
    }
}
