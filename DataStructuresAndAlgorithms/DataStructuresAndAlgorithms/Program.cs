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

            Console.WriteLine(IsPermutation("goed", "doog"));
            //int[,] x = new int[3,2] { { 1, 1}, { 2, 2 }, { 4, 1 } };
            //int[,] y = new int[4,2] { { 1, 1 }, { 2, 2 }, { 3, 1 }, { 4, 1 } };
            //Console.WriteLine(DotProduct(x, y).ToString());
            //string[][] pairs =
            //{
            //    new string[]{"apple", "papel"},
            //    new string[]{"carrot", "tarroc"},
            //    new string[]{"hello", "llloh"}
            //};

            //foreach (var pair in pairs)
            //{
            //    var word1 = pair[0];
            //    var word2 = pair[1];
            //    var result1 = IsPermutation(word1, word2);
            //    var result2 = IsPermutation(word1, word2);
            //    Console.WriteLine("{0}, {1}: {2} / {3}", word1, word2, result1, result2);
            //}

            //int[] values = new int[] { 5,6,3,1,2,4};
            //int node1 = 2, node2 = 4;
            //int n = 6;
            //BST myBST = new BST();
            //Node n1, n2;
            //n1 = n2 = null;
            //for (int i = 0; i < n; i++)
            //{
            //    myBST.Add(myBST.root, values[i]);
            //    if (values[i] == node1)
            //        n1 = new Node(node1);
            //    if (values[i] == node2)
            //        n2 = new Node(node2);
            //}
            //Node LCA = myBST.FindLCA(myBST.root, node1, node2);
            //Console.Write("The LCA of node1 and node2 is " + LCA.data);
        }

        public static bool OneEditReplace(String s1, String s2)
        {
            //cracking the coding interview 1.5
            //need to check if two strings have only 1 edit in between them
            //get longer string
            if (s1.Length != s2.Length && s1.Length+1 == s2.Length)
            {
                string temp = s1;
                s1 = s2;
                s2 = temp;
            }
            else if(s1.Length != s2.Length && s1.Length!=s2.Length+1)
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
            int end = input.Length-1;

            while(start <= end)
            {
                //move pointers until each one is pointing at a character
                //compare characters and keep moving
                if(!('a'<= input[start] && input[start] <= 'z'))
                {
                    start++;
                }
                else if(!('a' <= input[end] && input[end] <= 'z'))
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

        public static int bstDistance(int[] values, int n, int node1, int node2)
        {
            // WRITE YOUR CODE HERE
            BST myBST = new BST();
            //Node n1, n2;
            //n1 = n2 = null;
            for (int i = 0; i < n; i++)
            {
                myBST.Add(myBST.root, values[i]);
                //if (values[i] == node1)
                //    n1 = new Node(node1);
                //if (values[i] == node2)
                //    n2 = new Node(node2);
            }
            //find lowest common ancestor of nodes
            //if (n1 != null && n2 != null)
            //{
                Node LCA = myBST.FindLCA(myBST.root, node1, node2);
                Console.Write("The LCA of node1 and node2 is " + LCA.data);
                return LCA.data;
            //}
            return 0;
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
            for(int i=0; i<n; i++)
            {
                if(int.TryParse(blocks[i], out curScore))
                {
                    //current block is a number
                    finalScore += curScore;
                    if (i >= 1)
                        secondToLastScore = lastScore;
                    lastScore = curScore;
                    
                }
                else
                {
                    switch(blocks[i])
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
            if(input.Length > 0)
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

            foreach(char c in str1)
            {
                chars[c]++;
            }

            foreach(char c in str2)
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
                if(dV1.ContainsKey(v2[i,0]))
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
            for(int i = 0; i < input.Length; i++)
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

    class Node
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

    class BST
    {
        public Node root;

        public BST()
        {
            root = null;
        }

        public void Add(Node node, int val)
        {
            if (root == null)
                root = new Node(val);
            else if (node == null)
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
    }

}
