using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            MetalLinkedList<string> ll = new MetalLinkedList<string>();
            ll.AddToFront("test1");
            ll.AddToFront("test22");
            ll.AddToFront("This is the front");
            ll.AddToBack("This is the end");
            ll.PrintAll();
        }
    }
}
