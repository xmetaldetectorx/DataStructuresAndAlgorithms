using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class MetalLinkedList<T> 
    {
        Node<T> head;
        Node<T> end;
        public MetalLinkedList()
        { }            
        public MetalLinkedList(T val)
        {
            head = new Node<T>(val);
            end = head;
        }

        public void AddToFront(T val)
        {
            if(head == null)
            {
                head = new Node<T>(val);
                end = head;
                return;
            }
            Node<T> newNode = new Node<T>(val);
            newNode.next = head;
            head = newNode;   
        }

        public void AddToBack(T val)
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
                while(cur != null)
                {
                    count++;
                    cur = cur.next;
                }
                return count;
            }
        }

        public bool DeleteMiddle(Node<T> n)
        {
            
            if (n == null || n.next == null)
                return false;
            Node<T> next = n.next;
            n.data = next.data;
            n.next = next.next;
            return true;
        }

        public bool InsertAfter(T val)
        {
            return false;
        }

        public T NthToLast(int n)
        {
            if (n == 0)
            {
                return end.data;
            }
            Node<T> curPos = head;
            Node<T> nth = null;
            for (int i =0; i < n; i++)
            {
                if (curPos.next!=null)
                    curPos = curPos.next;
                else
                    return default(T);
            }

            nth = head;
            while(curPos.next!=null)
            {
                curPos = curPos.next;
                nth = nth.next;
            }
            
            return nth.data;
        }
    }

    
}
