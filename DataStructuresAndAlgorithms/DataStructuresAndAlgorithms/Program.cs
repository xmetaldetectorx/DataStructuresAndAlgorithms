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
            //MetalLinkedList<int> mll = new MetalLinkedList<int>();
            //WriteLine("Beginning LinkedList Test..");
            //mll.AddToBack(1);
            //mll.AddToBack(2);
            //mll.AddToBack(3);
            //mll.AddToBack(4);
            //mll.AddToBack(5);
            //mll.AddToBack(6);
            //mll.PrintAll();
            //WriteLine("The 0th to last is " + mll.NthToLast(0));

            int[] numbers = { 3, 8, 7, 5, 2, 1, 8, 6, 4 };
            int len = 9;

            Console.WriteLine("MergeSort By Recursive Method");
            //QuickSort_Recursive(numbers, 0, len - 1);
            //MetalSorts.MetalQuickSort(numbers, 0, len - 1);
            MetalSorts.MetalMergeSort(numbers, numbers.Length);
            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbers[i]);


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

            //WriteLine("Starting BST Test...");
            //MetalBST bst = new MetalBST(10);
            //bst.Add(5);
            //bst.Add(11);
            //bst.Add(15);
            //bst.Add(7);

            //WriteLine("In Order Traversal: ");
            //bst.PrintInOrder(bst.Root);
            //WriteLine("\n\rPre Order Traversal: ");
            //bst.PrintPreOrder(bst.Root);
            //WriteLine("\n\rPost Order Traversal: ");
            //bst.PrintPostOrder(bst.Root);

            //bst.displayTree();
            //WriteLine("The height of the tree is: " + bst.treeHeight(bst.Root));

            //bst.Root = bst.rotateRight();
            //bst.displayTree();
            //WriteLine("The height of the tree is: " + bst.treeHeight(bst.Root));
        }

        static void MergeSort()
        {

        }

        

        
    }
}
