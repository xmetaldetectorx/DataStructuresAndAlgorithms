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
    }

    class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T val)
        {
            data = val;
            next = null;
        }
    }
}
