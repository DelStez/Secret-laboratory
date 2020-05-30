using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core
{
    public class BST
    {
        public class BSTNode
        {
            public int key;
            public BSTNode parent;
            public BSTNode leftChild;
            public BSTNode rightChild;
            private readonly int deepth;

            public BSTNode(BSTNode parent, int keyValue)
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
            public BSTNode Parrent => parent;
            public int KeyValue => key;
            public int Deepth => deepth;
            public BSTNode LeftBSTNode { get => leftChild; set => leftChild = value; }
            public BSTNode RightBSTNode { get => rightChild; set => rightChild = value; }

            public bool IsRoot() { return this.Parrent == null; }
        }
        public static BSTNode root;
        public int deepth;

        public BST()
        {
            root = null;
            deepth = 0;
        }
        public BSTNode Root { get => root; set => root = value; }
        public int Deepth { get => deepth; set { if (Deepth < value) this.deepth = value; } }
        public BSTNode SearchBSTNode(int key)
        {
            BSTNode currentBSTNode = this.Root;
            while (currentBSTNode == null || currentBSTNode.key != key)
            {
                if (currentBSTNode.key > key)
                    currentBSTNode = currentBSTNode.rightChild;
                else
                    currentBSTNode = currentBSTNode.leftChild;
            }
            return currentBSTNode;
        }
        public BSTNode CreateBSTNode(int keyValue)
        {
            BSTNode currentBSTNode = root;
            BSTNode oldBSTNode = null;

            while (currentBSTNode != null)
            {
                oldBSTNode = currentBSTNode;
                if (keyValue < currentBSTNode.key)
                    currentBSTNode = currentBSTNode.leftChild;
                else
                    currentBSTNode = currentBSTNode.rightChild;
            }
            return AddBSTNode(keyValue, oldBSTNode);
        }
        public BSTNode AddBSTNode(int key, BSTNode oldBSTNode) // Реализация без использования информации о родителе
        {
            BSTNode newBSTNode = this.Root;
            if (oldBSTNode == null)
                Root = newBSTNode;
            else if (key > oldBSTNode.key)
                oldBSTNode.rightChild = newBSTNode;
            else
                oldBSTNode.leftChild = newBSTNode;
            deepth = newBSTNode.Deepth;
            return newBSTNode;
        }
        public BSTNode Remove(BSTNode root, int key) // Рекурсивная реализация
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
