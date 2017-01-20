using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node<T> left;
        public Node<T> right;
        public Node(T val)
        {
            data = val;
            next = left = right = null;
        }

        public override string ToString()
        {
            return $"[{data}]";
        }
    }
}
