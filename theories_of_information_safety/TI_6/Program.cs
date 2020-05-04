using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_6
{
    class Node
    {
        private double frequence;
        private string letter;
        private Node leftChild;
        private Node rightChild;
        public Node(string letter, double frequence)
        {
            this.letter = letter;
            this.frequence = frequence;
        }
        
        public Node() { }
        public void AddChild(Node newNode)
        {
            if (leftChild == null)
                leftChild = newNode;
            else if (leftChild.GetFrequence() <= newNode.GetFrequence())
                rightChild = newNode;
            else
            {
                rightChild = leftChild;
                leftChild = newNode;
            }
            frequence += newNode.GetFrequence();
        }
        public Node GetLeftChild() { return leftChild; }
        public Node GetRightChild() { return rightChild; }
        public string GetLetter() { return letter; }
        public double GetFrequence() { return frequence; }
        public Boolean IsLeaf() { return leftChild == null && rightChild == null; }
    }
    class BinaryTree
    {
        private Node root;
        public BinaryTree()
        {
            root = new Node();
        }

        public BinaryTree(Node root) { this.root = root; }
        public double GetFrequence() { return root.GetFrequence(); }
        public Node GetRoot() { return root; }
    }
    class Queque
    {
        private List<BinaryTree> data;
        private int numOfElem;
        public Queque()
        {
            data = new List<BinaryTree>();
            numOfElem = 0;
        }
        public void Insert(BinaryTree newSubTree)
        {
            if (numOfElem != 0)
            {
                for (int i = 0; i < numOfElem; i++)
                {
                    if (data[i].GetFrequence() > newSubTree.GetFrequence())
                    {
                        data.Insert(i, newSubTree);
                        break;
                    }

                    if (i == numOfElem - 1) data.Add(newSubTree);
                }

            }
            else data.Add(newSubTree);
            numOfElem++;
        }

        public BinaryTree remove()
        {
            BinaryTree temp = data[0];
            data.RemoveAt(0);
            numOfElem--;
            return temp;
        }

    }
    class Huffman
    {
        public Dictionary<string, double> alphabet;
        private BinaryTree huffmamTree;
        public string[] encoding;
        public Huffman(Dictionary<string, double> alphabet)
        {
            this.alphabet = alphabet;
            this.encoding = new string[alphabet.Count];
            huffmamTree = GetHTree();
            EncodingArray(huffmamTree.GetRoot(), "", "");
            int count = 0;
            double K = 0;
            double Shan = 0;
            foreach (KeyValuePair<string, double> pair in alphabet)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} - {encoding[count]}");
                K += encoding[count].Length * alphabet[pair.Key];
                Shan += pair.Value * Math.Log(1 / pair.Value, 2);
                count++;
            }
            Console.WriteLine($"Ср. длина: {Math.Round(K, 3)}");
            Console.WriteLine($"Энтропия: {Math.Round(Shan, 3)}");
            Console.WriteLine($"Избыточность кода: {(K / Shan) - 1}");

        }
        private BinaryTree GetHTree()
        {
            Queque q = new Queque();
            foreach (KeyValuePair<string, double> pair in alphabet)
            {
                Node newNode = new Node(pair.Key, pair.Value);
                BinaryTree newTree = new BinaryTree(newNode);
                q.Insert(newTree);
            }
            while (true)
            {
                BinaryTree treeOne = q.remove();
                try
                {
                    BinaryTree treeSecond = q.remove();
                    Node newNode = new Node();
                    newNode.AddChild(treeOne.GetRoot());
                    newNode.AddChild(treeSecond.GetRoot());
                    q.Insert(new BinaryTree(newNode));
                }
                catch (ArgumentOutOfRangeException)
                {
                    return treeOne;
                }
            }
        }
        void EncodingArray(Node node, string before, string after)
        {
            if (node.IsLeaf())
            {
                int index = alphabet.Keys.ToList().IndexOf(node.GetLetter());
                encoding[index] = before + after;
            }
            else 
            {
                EncodingArray(node.GetLeftChild(), before + after, "0");
                EncodingArray(node.GetRightChild(), before + after, "1");
            }

        }
    }
    class Program
    {
        public static Dictionary<string, double> alphaBetRUS = new Dictionary<string, double> {
            {" ", 0.175}, { "О", 0.09 },
            { "Е", 0.048 }, { "Ё", 0.024 },
            { "А", 0.062 }, { "И", 0.062 },
            { "Т", 0.053 }, { "Н", 0.053 },
            { "С", 0.045 }, { "Р", 0.040 },
            { "В", 0.038 }, { "Л", 0.035 },
            { "К", 0.028 }, { "М", 0.026 },
            { "Д", 0.025 }, { "П", 0.023 },
            { "У", 0.021 }, { "Я", 0.018 },
            { "Ы", 0.016 }, { "З", 0.016 },
            { "Ъ", 0.014/2 }, { "Ь", 0.014 /2 },
            { "Б", 0.014 }, { "Г", 0.013 },
            { "Ч", 0.012 }, { "Й", 0.010 },
            { "Х", 0.009 }, { "Ж", 0.007 },
            { "Ю", 0.006 },{ "Ш", 0.006 },
            { "Ц", 0.004 },{ "Щ", 0.003 },
            { "Э", 0.003 },{ "Ф", 0.003 }
        };
        public static Dictionary<string, double> alphaBetENG = new Dictionary<string, double> {
            { " ", 0.2 }, { "E", 0.105 },
            { "T", 0.072 }, { "O", 0.065 },
            { "A", 0.063 }, { "N", 0.058 },
            { "I", 0.055 }, { "R", 0.052 },
            { "S", 0.052 }, { "H", 0.047 },
            { "D", 0.035 }, { "L", 0.028 },
            { "C", 0.023 }, { "F", 0.023 },
            { "U", 0.023 }, { "M", 0.021 },
            { "P", 0.018 }, { "Y", 0.012 },
            { "W", 0.012 }, { "G", 0.011 },
            { "B", 0.01 }, { "V", 0.008 },
            { "K", 0.003 }, { "X", 0.001 },
            { "J", 0.001 }, { "Q", 0.001 }, { "Z", 0.001 }};
        static Dictionary<string, double> homeWork = new Dictionary<string, double>
        {
            {"_", 0.3}, {"*", 0.2}, {"+", 0.2}, {"%", 0.15}, {"#", 0.1}, {"!", 0.05}
        };
        public static Dictionary<string, double> expFour = new Dictionary<string, double> {
            { "A", 0.2 }, { "B", 0.2 },
            { "C", 0.19 }, { "D", 0.12 },
            { "E", 0.11 }, { "F", 0.09 }, { "G", 0.11 }
        };
        public static Dictionary<string, double> alphaBetENG1 = new Dictionary<string, double>
        {
            { "А" , 5 },
            { "К" , 2 },
            { "Н" , 2 },
            { "C" , 2 },
            { "Д" , 1 },
            { "О" , 1 },
            { "В" , 1 },
            { "Т" , 1 },
            { "И" , 1 },
            { "Я" , 1 },
            { " ", 1},
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Задание № 1");
            new Huffman(alphaBetENG1);
            Console.WriteLine("___________");
            Console.WriteLine("Задание № 2");
            new Huffman(alphaBetENG);
            Console.WriteLine("___________");
            Console.WriteLine("Задание № 3");
            new Huffman(homeWork);
            Console.WriteLine("___________");
            Console.WriteLine("Задание № 4");
            new Huffman(expFour);
            Console.ReadLine();
        }
    }
}
