using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core
{
    public class BST
    {
        public static Node root;
        public int deepth;

        public BST()
        {

            root = null;
            deepth = 0;
        }
        public Node Root { get => root; set => root = value; }
        public int Deepth { get => deepth; set { if (Deepth < value) this.deepth = value; } }
        private Node SearchNode(int key)
        {
            Node currentNode = this.Root;
            while (currentNode == null || currentNode.key != key)
            {
                if (currentNode.key > key)
                    currentNode = currentNode.rightChild;
                else
                    currentNode = currentNode.leftChild;
            }
            return currentNode;
        }
        private Node CreateNode(int keyValue)
        {
            Node currentNode = root;
            Node oldNode = null;

            while (currentNode != null)
            {
                oldNode = currentNode;
                if (keyValue < currentNode.key)
                    currentNode = currentNode.leftChild;
                else
                    currentNode = currentNode.rightChild;
            }
            return AddNode(keyValue, oldNode);
        }
        private Node AddNode(int key, Node oldNode) // Реализация без использования информации о родителе
        {
            Node newNode = this.Root;
            if (oldNode == null)
                Root = newNode;
            else if (key > oldNode.key)
                oldNode.rightChild = newNode;
            else
                oldNode.leftChild = newNode;
            deepth = newNode.Deepth;
            return newNode;
        }
        private Node Remove(Node root, int key) // Рекурсивная реализация
        {
            if (root == null)
                return root;
            if (key < root.key)
                root.leftChild = Remove(root.leftChild, key);
            else if (key > root.key)
                root.rightChild = Remove(root.rightChild, key);
            else
            {
                if (root.leftChild != null)
                    root = root.leftChild;
                else if (root.rightChild != null)
                    root = root.rightChild;
                else
                    root = null;
            }
            return root;
        }
    }
}

    public class Node 
    {
        public int key;
        public Node parent;
        public Node leftChild;
        public Node rightChild;
        private readonly int deepth;
    public Node(Node parent, int keyValue)
    {
        this.parent = parent;
        this.key = keyValue;

        this.leftChild = null;
        this.rightChild = null;

        if (this.parent == null)
            this.deepth = 0;
        else
            this.deepth = this.parent.deepth + 1;
    }
    public Node Parrent => parent;
    public int KeyValue => key;
    public int Deepth => deepth;
    public Node LeftNode { get => leftChild; set => leftChild = value; }
    public Node RightNode { get => rightChild; set => rightChild = value; }

    public bool IsRoot() { return this.Parrent == null; }
}
