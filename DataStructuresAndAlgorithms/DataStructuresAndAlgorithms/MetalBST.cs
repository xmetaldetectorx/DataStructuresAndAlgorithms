using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class MetalBST
    {
        private Node<int> root;

        public Node<int> Root
        {
            get
            {
                return root;
            }

            set
            {
                root = value;
            }
        }

        public MetalBST()
        { }

        public MetalBST(int val)
        {
            Root = new Node<int>(val);
        }

        public void PrintPostOrder(Node<int> node)
        {
            if(node!= null)
            {
                PrintPostOrder(node.left);
                PrintPostOrder(node.right);
                Console.Write(node);
            }
        }

        public void PrintInOrder(Node<int> node)
        {
            if (node != null)
            {
                PrintInOrder(node.left);
                Console.Write(node);
                PrintInOrder(node.right);
            }
        }

        public void PrintPreOrder(Node<int> node)
        {
            if(node!=null)
            {
                Console.Write(node);
                PrintPreOrder(node.left);
                PrintPreOrder(node.right);
            }
        }

        public void Add(int val)
        {
            if(Root == null)
            {
                Root = new Node<int>(val);
            }
            else if(val >= Root.data && Root.right == null)
            {
                Root.right = new Node<int>(val);
            }
            else if(val < Root.data && Root.left == null)
            {
                Root.left = new Node<int>(val);
            }
            else if(val >= Root.data)
            {
                AddWork(Root.right, val);
            }
            else if(val < Root.data)
            {
                AddWork(Root.left, val);
            }
        }

        private void AddWork(Node<int> node, int val)
        {
            if (node == null)
            {
                node = new Node<int>(val);
            }
            else if (val >= node.data && node.right == null)
            {
                node.right = new Node<int>(val);
            }
            else if (val < node.data && node.left == null)
            {
                node.left = new Node<int>(val);
            }
            else if (val >= node.data)
            {
                AddWork(node.right, val);
            }
            else if (val < node.data)
            {
                AddWork(node.left, val);
            }
        }

        public bool Find(Node<int> root, int val)
        {
            if (root == null)
                return false;
            Node<int> curr = root;
            while(curr.data!=val)
            {
                if(val < curr.data)
                {
                    curr = curr.left;
                }
                else
                {
                    curr = curr.right;
                }
                if (curr == null)
                    return false;
            }
            return true;
        }

        public bool DFS(int val)
        {
            MetalStack<Node<int>> ms = new MetalStack<Node<int>>();
            Node<int> curr;
            ms.Push(Root);
            while(ms.Count() !=0)
            {
                curr = ms.Pop();
                if (curr.data == val)
                    return true;
                else
                { 
                    if (curr.right!=null)ms.Push(curr.right);
                    if (curr.left != null) ms.Push(curr.left);
                }
            }
            return false;
        }

        public bool BFS(int val)
        {
            MetalQueue<Node<int>> q = new MetalQueue<Node<int>>();
            q.Enqueue(root);
            while (q.Count() > 0)
            {
                Node<int> current = q.Dequeue();
                if (current == null)
                    continue;
                q.Enqueue(current.left);
                q.Enqueue(current.right);

                if (current.data == val)
                    return true;
            }
            return false;
        }

        public void displayTree()
        {
            MetalStack<Node<int>> globalStack = new MetalStack<Node<int>>();
            globalStack.Push(Root);
            int emptyLeaf = 32;
            bool isRowEmpty = false;
            Console.WriteLine("****......................................................****");
            while (isRowEmpty == false)
            {

                MetalStack<Node<int>> localStack = new MetalStack<Node<int>>();
                isRowEmpty = true;
                for (int j = 0; j < emptyLeaf; j++)
                    Console.Write(' ');
                while (globalStack.Count() > 0)
                {
                    Node<int> temp = globalStack.Pop();
                    if (temp != null)
                    {
                        Console.Write(temp);
                        localStack.Push(temp.left);
                        localStack.Push(temp.right);
                        if (temp.left != null || temp.right != null)
                            isRowEmpty = false;
                    }
                    else
                    {
                        Console.Write("--");
                        localStack.Push(null);
                        localStack.Push(null);
                    }
                    for (int j = 0; j < emptyLeaf * 2 - 2; j++)
                       Console.Write(' ');
                }
                Console.WriteLine();
                emptyLeaf /= 2;
                while (localStack.Count() > 0)
                    globalStack.Push(localStack.Pop());
            }
            Console.WriteLine("****......................................................****");
        }

        public int treeHeight(Node<int> n)
        {
            if (n == null) return 0;
            return 1 + Math.Max(treeHeight(n.left), treeHeight(n.right));
        }

        public Node<int> rotateRight()
        {
            Node<int> newRoot = Root.left;
            Root.left = newRoot.right;
            newRoot.right = Root;
            return newRoot;
        }

    }
}
