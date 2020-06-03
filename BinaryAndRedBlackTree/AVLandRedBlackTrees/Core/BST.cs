using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackBSTs.Core
{
    public class BST
    {
        public BSTNode root;
        public int deepth;

        public BST()
        {
            root = null;
            deepth = 0;
        }

        public BSTNode Root { get => root; set => root = value; }
        public int Deepth
        {
            get => deepth;

            set
            {
                if (Deepth < value)
                {
                    this.deepth = value;
                }
            }
        }

        private BSTNode SearchBSTNode(int keyValue)
        {
            BSTNode currentBSTNode = this.Root;

            while (currentBSTNode != null && currentBSTNode.KeyValue != keyValue)
            {
                int key = currentBSTNode.KeyValue;
                if (keyValue > key)
                {
                    currentBSTNode = currentBSTNode.RightBSTNode;
                }
                else
                {
                    currentBSTNode = currentBSTNode.LeftBSTNode;
                }
            }

            return currentBSTNode;
        }

        private BSTNode CreateBSTNode(int keyValue)
        {
            BSTNode currentBSTNode = root;
            BSTNode oldBSTNode = null;

            while (currentBSTNode != null)
            {
                oldBSTNode = currentBSTNode;
                if (keyValue < currentBSTNode.KeyValue)
                {
                    currentBSTNode = currentBSTNode.LeftBSTNode;
                }
                else
                {
                    currentBSTNode = currentBSTNode.RightBSTNode;
                }
            }
            return AddBSTNode(keyValue, oldBSTNode);
        }

        private BSTNode AddBSTNode(int keyValue, BSTNode oldBSTNode)
        {
            BSTNode newBSTNode = new BSTNode(oldBSTNode, keyValue);
            if (oldBSTNode == null)
            {
                Root = newBSTNode;
            }
            else if (keyValue > oldBSTNode.KeyValue)
            {
                oldBSTNode.RightBSTNode = newBSTNode;
            }
            else
            {
                oldBSTNode.LeftBSTNode = newBSTNode;
            }
            Deepth = newBSTNode.Deepth;
            return newBSTNode;
        }

        private bool Exists(int keyValue, out BSTNode foundBSTNode)
        {
            foundBSTNode = SearchBSTNode(keyValue);
            return foundBSTNode != null;
        }

        public bool Exists(int keyValue)
        {
            return Exists(keyValue, out BSTNode FoundBSTNode);
        }

        public BSTNode Add(int keyValue)
        {
            BSTNode newBSTNode;
            if (Exists(keyValue, out newBSTNode) == false)
            {
                newBSTNode = CreateBSTNode(keyValue);
            }
            return newBSTNode;
        }

        public class BSTNode
        {
            public BSTNode parrent;
            int X;
            int Y;
            public BSTNode leftBSTNode;
            public BSTNode rightBSTNode;
            public int key;
            public readonly int deepth;

            public BSTNode(BSTNode parrent, int keyValue)
            {
                this.parrent = parrent;
                this.key = keyValue;

                this.LeftBSTNode = null;
                this.RightBSTNode = null;

                if (this.Parrent == null)
                {
                    this.deepth = 0;
                }
                else
                {
                    this.deepth = this.Parrent.Deepth + 1;
                }
            }

            public BSTNode Parrent => parrent;
            public int KeyValue => key;
            public int Deepth => deepth;
            public BSTNode LeftBSTNode { get => leftBSTNode; set => leftBSTNode = value; }
            public BSTNode RightBSTNode { get => rightBSTNode; set => rightBSTNode = value; }

            public bool IsRoot()
            {
                return this.Parrent == null;
            }

        }
    }
   
}
