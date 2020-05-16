using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core.RBTree
{
    public enum Color { Red, Black }
    public class RBTNode
    {
        public int key;
        public RBTNode left;
        public RBTNode right;
        public RBTNode parent;
        public Color colour;

        public RBTNode(int key) { this.key = key; }
        public RBTNode(Color colour) { this.colour = colour; }
        public RBTNode(int key, Color colour) { this.key = key; this.colour = colour;}
    }
}
