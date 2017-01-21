using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //MetalStack<string> ms = new MetalStack<string>();
            //WriteLine("Beginning Stack Test..");
            //ms.Push("Plate 1");
            //ms.Push("Plate 2");
            //ms.Push("Plate 3");
            //WriteLine("First Pop: " + ms.Pop());
            //WriteLine("Second Pop: " + ms.Pop());
            //WriteLine("Third Pop: " + ms.Pop());

            //WriteLine(Environment.NewLine+"Beginning a Queue Test..");
            //MetalQueue<string> mq = new MetalQueue<string>();
            //mq.Enqueue("First guy in line");
            //mq.Enqueue("Second guy in line");
            //mq.Enqueue("Third guy in line");
            //WriteLine("First Dequeue: " + mq.Dequeue());
            //WriteLine("Second Dequeue: " + mq.Dequeue());
            //WriteLine("Third Dequeue: " + mq.Dequeue());

            WriteLine("Starting BST Test...");
            MetalBST bst = new MetalBST(10);
            bst.Add(5);
            bst.Add(11);
            bst.Add(15);
            bst.Add(7);

            WriteLine("In Order Traversal: ");
            bst.PrintInOrder(bst.Root);
            WriteLine("\n\rPre Order Traversal: ");
            bst.PrintPreOrder(bst.Root);
            WriteLine("\n\rPost Order Traversal: ");
            bst.PrintPostOrder(bst.Root);

            if(bst.Find(bst.Root, 13))
            {
                WriteLine("15 found!");
            }
            else
            {
                WriteLine("13 not found..");
            }
            bst.displayTree();
            if (bst.BFS(5))
            {
                WriteLine("5 found using BFS!");
            }
            else
                WriteLine("not found!"); 
        }
    }
}
