using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core
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
}
