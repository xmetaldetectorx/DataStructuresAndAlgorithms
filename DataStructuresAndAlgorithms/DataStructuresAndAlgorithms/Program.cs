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

            BST myBST = new BST();
            myBST.Add(15);
            myBST.Add(10);
            myBST.Add(20);
            myBST.Add(11);
            myBST.Add(9);
            myBST.Add(16);
            myBST.Add(21);
            myBST.displayTree();

            WriteLine("LCA of 16 and 21 is : " + myBST.FindLCA(myBST.root, 16, 21).data);

            WriteLine("Is the tree balanced? " + myBST.IsBalanced(myBST.root));

            //myBST.InvertTree(myBST.root);
            //myBST.displayTree();

            WriteLine("The distance between 21 and 16 is : " + myBST.DistanceBetweenNodes(16, 21));

            //myBST.PrintPath(myBST.root, 21);

            myBST.root = myBST.SortedArrayToBST(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 5);
            myBST.displayTree();
            
        }

        public static bool OneEditReplace(String s1, String s2)
        {
            //cracking the coding interview 1.5
            //need to check if two strings have only 1 edit in between them
            //get longer string
            if (s1.Length != s2.Length && s1.Length + 1 == s2.Length)
            {
                string temp = s1;
                s1 = s2;
                s2 = temp;
            }
            else if (s1.Length != s2.Length && s1.Length != s2.Length + 1)
            {
                return false;
            }
            bool foundDifference = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDifference)
                    {
                        //if 2 differences are found, return false
                        return false;
                    }

                    foundDifference = true;
                }
            }
            return true;
        }

        public static bool IsPalindrome(string str)
        {
            if (str.Length <= 0)
                return false;
            string input = str.ToLower();
            int start = 0;
            int end = input.Length - 1;

            while (start <= end)
            {
                //move pointers until each one is pointing at a character
                //compare characters and keep moving
                if (!('a' <= input[start] && input[start] <= 'z'))
                {
                    start++;
                }
                else if (!('a' <= input[end] && input[end] <= 'z'))
                {
                    end--;
                }
                else
                {
                    if (input[start] != input[end])
                        return false;
                    start++;
                    end--;
                }
            }

            return true;
        }


        static int totalScore(string[] blocks, int n)
        {
            //amazon interview question
            if (n == 0 || blocks.Length == 0)
                return 0;
            int finalScore = 0;
            int lastScore = 0;
            int secondToLastScore = 0;
            int curScore;
            for (int i = 0; i < n; i++)
            {
                if (int.TryParse(blocks[i], out curScore))
                {
                    //current block is a number
                    finalScore += curScore;
                    if (i >= 1)
                        secondToLastScore = lastScore;
                    lastScore = curScore;

                }
                else
                {
                    switch (blocks[i])
                    {
                        case "X":
                            curScore = lastScore * 2;
                            finalScore += curScore;
                            if (i >= 1)
                                secondToLastScore = lastScore;
                            lastScore = curScore;
                            break;
                        case "+":
                            curScore = lastScore + secondToLastScore;
                            finalScore += curScore;
                            if (i >= 1)
                                secondToLastScore = lastScore;
                            lastScore = curScore;
                            break;
                        case "Z":
                            finalScore -= lastScore;
                            lastScore = secondToLastScore;
                            break;
                    }
                }
            }
            return finalScore;
        }

        static string FullURL(string input)
        {
            //microsoft interview question
            StringBuilder sb = new StringBuilder();
            input = input.Trim().ToLower();
            if (input.Length > 0)
            {
                if (!input.StartsWith("http://") || !input.StartsWith("https://"))
                    sb.Append("http://");
                sb.Append(input);
                if (!input.EndsWith(".com") && !input.EndsWith(".net") && !input.EndsWith(".org"))
                    sb.Append(".com");
            }
            return sb.ToString();
        }

        static int CountWords(string text)
        {
            int wordCount = 0, index = 0;
            text = text.Trim();
            while (index < text.Length)
            {
                // check if current char is part of a word
                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                    index++;

                wordCount++;

                // skip whitespace until next word
                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
            }
            return wordCount;
        }

        static public bool IsPermutation(string str1, string str2)
        {
            //Cracking the Coding Interview 1.2
            //Check if strings are permutations of each other
            if (str1 == null || str2 == null) return false;
            if (str1.Length != str2.Length) return false;

            int[] chars = new int[128];

            foreach (char c in str1)
            {
                chars[c]++;
            }

            foreach (char c in str2)
            {
                chars[c]--;
                if (chars[c] < 0)
                    return false;
            }

            return true;
        }
        static public bool IsPermutationBITWISE(String str1, String str2)
        {
            //Cracking the Coding Interview 1.2
            //Check if strings are permutations of each other

            if (str1 == null || str2 == null) return false;
            if (str1.Length != str2.Length) return false;

            int result = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                int str1Val = (int)str1.ToCharArray()[i];
                int str2Val = (int)str2.ToCharArray()[i];

                //Binary XOR Operator copies the bit if it is set in one operand but not both.
                //in permutation, the values should be same regardless of order, so XOR both strings should return 0
                result = result ^ str1Val;
                result = result ^ str2Val;
            }

            return result == 0;//if XOR both strings returned 0, then it was a valid permutation, so return true
        } // end permutation

        static public int DotProduct(int[,] v1, int[,] v2)
        {
            int result = 0;
            Dictionary<int, int> dV1 = new Dictionary<int, int>();
            //add all elements from first vector to dictionary
            for (int i = 0; i < v1.GetLength(0); i++)
            {
                dV1.Add(v1[i, 0], v1[i, 1]);
            }
            //start adding second 
            for (int i = 0; i < v2.GetLength(0); i++)
            {
                if (dV1.ContainsKey(v2[i, 0]))
                {
                    result += dV1[v2[i, 0]] * v2[i, 1];
                }
                else
                {
                    dV1.Add(v2[i, 0], v2[i, 1]);
                }
            }

            return result;
        }

        static public bool HasUniqueChars(string input)
        {
            //Cracking the Coding Interview 1.1
            //Check if input has all unique characters
            input = input.ToLower();
            bool[] chars = new bool[128];
            for (int i = 0; i < input.Length; i++)
            {

                //valid char
                if (chars[input[i]])
                    return false;
                else
                    chars[input[i]] = true;

            }

            return true;
        }
    }

    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }

    public class BST
    {
        public Node root;

        public BST()
        {
            root = null;
        }

        public void Add(int val)
        {
            if (root == null)
                root = new Node(val);
            else if (val >= root.data && root.right == null)
                root.right = new Node(val);
            else if (val <= root.data && root.left == null)
                root.left = new Node(val);
            else if (val >= root.data)
                Add(root.right, val);
            else if (val <= root.data)
                Add(root.left, val);

        }

        void Add(Node node, int val)
        {
            if (node == null)
                node = new Node(val);
            else if (val >= node.data && node.right == null)
                node.right = new Node(val);
            else if (val <= node.data && node.left == null)
                node.left = new Node(val);
            else if (val >= node.data)
                Add(node.right, val);
            else if (val <= node.data)
                Add(node.left, val);
        }

        public Node FindLCA(Node root, int n1, int n2)
        {
            if (root == null)
                return null;
            if (root.data == n1 || root.data == n2)
                return root;
            Node left = FindLCA(root.left, n1, n2);
            Node right = FindLCA(root.right, n1, n2);
            if (left != null && right != null)
                return root;
            if (left == null && right == null)
                return null;

            return left != null ? left : right;
        }

        public Node InvertTree(Node root)
        {
            if (root == null)
                return null;
            Node left = InvertTree(root.left);
            Node right = InvertTree(root.right);
            root.left = right;
            root.right = left;
            return root;
        }

        public bool IsBalanced(Node root)
        {
            return checkHeight(root) != Int32.MinValue;
        }

        int checkHeight(Node n)
        {
            if (n == null)
                return -1;
            int leftHeight = checkHeight(n.left);
            if (leftHeight == Int32.MinValue)
                return Int32.MinValue;

            int rightHeight = checkHeight(n.right);
            if (rightHeight == Int32.MinValue)
                return Int32.MinValue;

            int heightDiff = leftHeight - rightHeight;

            if (Math.Abs(heightDiff) > 1)
                return Int32.MinValue;
            else
                return Math.Max(leftHeight, rightHeight) + 1;
        }

        public int DistanceBetweenNodes(int n1, int n2)
        {

            Node LCA = FindLCA(root, n1, n2);

            if(LCA!=null)
            {
                int dlca = DistanceFromRoot(root, LCA.data)-1;
                int d1 = DistanceFromRoot(root, n1)-1;
                int d2 = DistanceFromRoot(root, n2)-1;

                return d1 + d2 - (dlca*2);
            }

            return 0;
        }

        public Node SortedArrayToBST(int[] array, int start, int end)
        {
            if (start > end)
                return null;
            int mid = (start+end) / 2;
            Node nroot = new Node(array[mid]);
            nroot.left = SortedArrayToBST(array, start, mid - 1);
            nroot.right = SortedArrayToBST(array, mid + 1, end);
            return nroot;
        }

        //public int DistanceFromRoot(Node n1)
        //{
        //    if (root == n1 || n1==null)
        //        return 0;

        //}

        public int DistanceFromRoot(Node root, int n1)
        {
            if (root != null)
            {
                int x = 0;
                if ((root.data == n1) || (x = DistanceFromRoot(root.left, n1)) > 0
                        || (x = DistanceFromRoot(root.right, n1)) > 0)
                {
                    return x + 1;

                }
                return 0;
            }
            return 0;
        }

        public Boolean PrintPath(Node root, int dest)
        {
            if (root == null) return false;
            if (root.data == dest || PrintPath(root.left, dest) || PrintPath(root.right, dest))
            {
                Console.Write("  " + root.data);
                //path.add(root.data);
                return true;
            }
            return false;
        }

        public void displayTree()
        {
            Stack<Node> globalStack = new Stack<Node>();
            globalStack.Push(root);
            int emptyLeaf = 32;
            bool isRowEmpty = false;
            Console.WriteLine("****......................................................****");
            while (isRowEmpty == false)
            {

                Stack<Node> localStack = new Stack<Node>();
                isRowEmpty = true;
                for (int j = 0; j < emptyLeaf; j++)
                    Console.Write(' ');
                while (globalStack.Count() > 0)
                {
                    Node temp = globalStack.Pop();
                    if (temp != null)
                    {
                        Console.Write(temp.data);
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
    }

}
