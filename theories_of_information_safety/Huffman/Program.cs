using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
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
        public Huffman(Dictionary<string, double> alphabet, bool Show)
        {
            this.alphabet = alphabet;
            this.encoding = new string[alphabet.Count];
            huffmamTree = GetHTree();
            Program.alphaBetNewCode.Clear();
            EncodingArray(huffmamTree.GetRoot(), "", "");
            int count = 0;
            double firstSize = 0;
            double secondSize = 0;
            foreach (KeyValuePair<string, double> pair in alphabet)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} - {encoding[count]}");
                Program.alphaBetNewCode.Add(pair.Key, encoding[count]);
                firstSize += alphabet[pair.Key] * 16;
                secondSize += alphabet[pair.Key] * encoding[count].Length;
                count++;
            }
            if (Show)
            {
                Console.WriteLine($"Первоначальный размер файла: {Math.Round(firstSize / 8)} байт");
                Console.WriteLine($"Размер сжатого файла: {Math.Round(secondSize / 8)} байт");
                Console.WriteLine($"Сжатие : {Math.Round(secondSize / (firstSize / 100))} %");
            }

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
        public static Dictionary<string, double> alphaBetNew = new Dictionary<string, double>();
        public static Dictionary<string, string> alphaBetNewCode = new Dictionary<string, string>();
        public static Dictionary<string, double> alphaBetNewZ = new Dictionary<string, double>()
            {{"Z1", 0.22},{"Z2", 0.20 },{"Z3", 0.16},{"Z4", 0.16 },
            {"Z5", 0.10 },{"Z6", 0.10 },{"Z7", 0.04 },{"Z8", 0.02 }};

        public static void CreateDictonary(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {

                int count = (message.Split(new string[] { message[i].ToString() }, StringSplitOptions.None).Count() - 1);
                KeyValuePair<string, double> keyValuePair = new KeyValuePair<string, double>($"{message[i].ToString()}", count);
                if (!alphaBetNew.Contains(keyValuePair))
                {
                    alphaBetNew.Add($"{message[i].ToString()}", count);
                }
               
            }
            var n = alphaBetNew.OrderByDescending(key => key.Value);
            alphaBetNew = new Dictionary<string, double>(n.ToDictionary(x => x.Key, x => x.Value));

        }
        public static string t;
        public static void Encrypt(string message, Dictionary<string, string> alphaBet)
        {
            string output = String.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                output += alphaBetNewCode[message[i].ToString()];
            }
            t = output;
            Console.WriteLine(output);
        }
        
        public static void Decrypt(string message, Dictionary<string, string> alphaBet)
        {
            string output = String.Empty;
            int count = 0;
            while (count != message.Length)
            {
                string t = String.Empty; 
                for (int i = count; i < message.Length; i++)
                {
                    t += message[i];
                    if (alphaBet.ContainsValue(t))
                    {
                        output += alphaBet.Where(x => x.Value == t).FirstOrDefault().Key;
                        break;
                    }
                }
                count += t.Length;
            }

            Console.WriteLine(output);
        }
        static void Main(string[] args)
        {

            //Добавленно 3 задание:
            //Console.WriteLine("Задание № 3");
            string message = "Дружелюбный город посреди пустыни, где солнце горячо, луна прекрасна, а таинственные огни проплывают у нас над головами, пока мы все притворяемся, что спим. " +
                "Добро пожаловать в Найт-Вейл. Приветствую вас, слушатели. Для начала меня попросили прочитать одно короткое объявление:" +
                " Городской cовет объявляет об открытии нового Парка для собак на углу Эрл и Сомерсет рядом с супермаркетом «Ральф'с». " +
                "Они напоминают всем, что с собаками вход в Парк для собак запрещён.Без собак вход в Парк для собак тоже запрещён.Возможно, в Парке для собак вы увидите Фигуры в Капюшонах. " +
                "Не приближайтесь к ним. Не приближайтесь к Парку для собак. " +
                "Ограда парка находится под напряжением, и это очень опасно. Постарайтесь не смотреть на Парк для собак, и особенно — ни на мгновение не задерживайте взгляд на Фигурах в Капюшонах. Парк для собак не причинит вам вреда.";
            CreateDictonary(message);
            new Huffman(alphaBetNew, true);
            Console.WriteLine("Сжатое сообщение: ");
            Encrypt(message, Program.alphaBetNewCode);
            Console.WriteLine("Получим обратное: ");
            Decrypt(t, Program.alphaBetNewCode);
            new Huffman(alphaBetNewZ, true);
            Console.ReadLine();
        }
    }
}
