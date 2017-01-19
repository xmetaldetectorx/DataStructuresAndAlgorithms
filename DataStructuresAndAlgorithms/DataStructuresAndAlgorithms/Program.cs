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
            MetalStack<string> ms = new MetalStack<string>();
            WriteLine("Beginning Stack Test..");
            ms.Push("Plate 1");
            ms.Push("Plate 2");
            ms.Push("Plate 3");
            WriteLine("First Pop: " + ms.Pop());
            WriteLine("Second Pop: " + ms.Pop());
            WriteLine("Third Pop: " + ms.Pop());
        }
    }
}
