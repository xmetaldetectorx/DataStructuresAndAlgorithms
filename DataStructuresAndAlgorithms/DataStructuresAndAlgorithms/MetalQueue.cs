using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class MetalQueue<T> 
    {
        Node<T> head;
        Node<T> end;

        public MetalQueue()
        {

        }
        public MetalQueue(T val)
        {
            head = new Node<T>(val);
            end = head;
        }
        public void Enqueue(T val)
        {
            if(head == null)
            {
                head = new Node<T>(val);
                end = head;
                return;
            }
            Node<T> newNode = new Node<T>(val);
            end.next = newNode;
            end = newNode;
        }
        public T Dequeue()
        {
            if(head ==null)
            {
                return default(T);
            }
            Node<T> toDequeue = head;
            head = head.next;
            return toDequeue.data;
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
