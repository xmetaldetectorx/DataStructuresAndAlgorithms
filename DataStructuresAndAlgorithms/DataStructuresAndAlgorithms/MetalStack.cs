using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class MetalStack<T>
    {
        Node<T> head;
        public MetalStack()
        {
        }

        public MetalStack(T val)
        {
            head = new Node<T>(val);
        }

        public void Push(T val)
        {
            if (head == null)
            { 
                head = new Node<T>(val);
                return;
            }
            Node<T> newNode = new Node<T>(val);
            newNode.next = head;
            head = newNode;
        }

        public T Pop()
        {
            if (head == null)
                return default(T);
            Node<T> curr = head;
            head = head.next;
            return curr.data;
        }

        public void PrintAll()
        {
            Node<T> curr = head;
            do
            {
                Console.WriteLine(curr.data);
                curr = curr.next;
            } while (curr != null);
        }

        public int Count()
        {
            int count = 0;
            if (head == null)
                return count;
            else
            {

                Node<T> cur = head;
                while (cur != null)
                {
                    count++;
                    cur = cur.next;
                }
                return count;
            }
        }
    }
}
