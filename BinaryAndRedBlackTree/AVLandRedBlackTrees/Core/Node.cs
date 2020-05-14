using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core
{
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
}
