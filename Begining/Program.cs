using System;

namespace Begining
{
    /* 
     Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. Дерево должно быть сбалансированным. 
    Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация. 
     */
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

            btr.Delete(16);
            btr.Print();

        }
    }
}
