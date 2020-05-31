using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core
{
    public enum Colors { Red, Black }
    public class RBT
    {
        public class RBTNode
        {
            public int key;
            public RBTNode left;
            public RBTNode right;
            public RBTNode parent;
            public Colors colour;

            public RBTNode(int key) { this.key = key; }
            public RBTNode(Colors colour) { this.colour = colour; }
            public RBTNode(int key, Colors colour) { this.key = key; this.colour = colour; }
        }
        
        public RBTNode root;
        public RBT() { }
        public RBTNode Find(int key)
        {
            bool isFound = false;
            RBTNode temp = root;
            RBTNode item = null;
            while (!isFound)
            {
                if (temp == null)
                    break;
                else
                {
                    if (key < temp.key)
                        temp = temp.left;
                    else if (key > temp.key)
                        temp = temp.right;
                    else if (key == temp.key)
                    {
                        isFound = true;
                        item = temp;
                    }
                }
            }
            if (isFound)//если найден
                return temp;
            else // иначе
                return null;
        }
        public void leftRotation(RBTNode x)
        {
            RBTNode y = x.right;

            x.right = y.left;
            if (y.left != null)
                y.left.parent = x;
            y.parent = x.parent;

            if (x == root)
                root = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;
            y.left = x;
            x.parent = y;
        }
        public void rightRotation(RBTNode x)
        {
            RBTNode y = x.left;

            x.left = y.right;
            if (y.right != null)
                y.right.parent = x;
            y.parent = x.parent;

            if (x == root)
                root = y;
            else if (x == x.parent.right)
                x.parent.right = y;
            else
                x.parent.left = y;
            y.right = x;
            x.parent = y;
        }

        public void Insert(int item)
        {
            RBTNode newItem = new RBTNode(item);
            if (root == null)
            {
                root = newItem;
                root.colour = Colors.Black;
                return;
            }
            RBTNode Y = null;
            RBTNode X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.key < X.key)
                    X = X.left;
                else
                    X = X.right;
            }
            newItem.parent = Y;
            if (Y == null)
                root = newItem;
            else if (newItem.key < Y.key)
                Y.left = newItem;
            else
                Y.right = newItem;

            newItem.left = null;
            newItem.right = null;
            newItem.colour = Colors.Red;
            InsertFixUp(newItem);
        }
        public void InsertFixUp(RBTNode x)
        {
            //проверка свойств КБ-дерева
            x.colour = Colors.Red;
            while (x != root && x.parent.colour == Colors.Red)
            {
                if (x.parent == x.parent.parent.left)
                {
                    RBTNode y = x.parent.parent.right;
                    if (y != null && y.colour == Colors.Red)
                    {
                        x.parent.colour = Colors.Black;
                        y.colour = Colors.Black;
                        x.parent.parent.colour = Colors.Red;
                        x = x.parent.parent;
                    }
                    else
                    {
                        if (x == x.parent.right)
                        {
                            x = x.parent;
                            leftRotation(x);
                        }
                        x.parent.colour = Colors.Black;
                        x.parent.parent.colour = Colors.Red;
                        rightRotation(x.parent.parent);
                    }
                }
                else
                {
                    RBTNode y = x.parent.parent.left;
                    if (y != null && y.colour == Colors.Red)
                    {
                        x.parent.colour = Colors.Black;
                        y.colour = Colors.Black;
                        x.parent.parent.colour = Colors.Red;
                        x = x.parent.parent;
                    }
                    else
                    {
                        if (x == x.parent.left)
                        {
                            x = x.parent;
                            rightRotation(x);
                        }
                        x.parent.colour = Colors.Black;
                        x.parent.parent.colour = Colors.Red;
                        leftRotation(x.parent.parent);
                    }
                }
            }
            root.colour = Colors.Black;
        }

        public void Remove(int key)
        {
            RBTNode item = Find(key);
            RBTNode X = null;
            RBTNode Y = null;

            if (item == null)
            {
                // ничего не удаленно
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.key = Y.key;
            }
            if (Y.colour == Colors.Black)
            {
                RemoveFixUp(X);
            }

        }
        public void RemoveFixUp(RBTNode X)
        {
            while (X != null && X != root && X.colour == Colors.Black)
            {
                if (X == X.parent.left)
                {
                    RBTNode W = X.parent.right;
                    if (W.colour == Colors.Red)
                    {
                        W.colour = Colors.Black;
                        X.parent.colour = Colors.Red;
                        leftRotation(X.parent);
                        W = X.parent.right;
                    }
                    if (W.left.colour == Colors.Black && W.right.colour == Colors.Black)
                    {
                        W.colour = Colors.Red;
                        X = X.parent;
                    }
                    else if (W.right.colour == Colors.Black)
                    {
                        W.left.colour = Colors.Black;
                        W.colour = Colors.Red;
                        rightRotation(W);
                        W = X.parent.right;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = Colors.Black;
                    W.right.colour = Colors.Black;
                    leftRotation(X.parent);
                    X = root;
                }
                else
                {
                    RBTNode W = X.parent.left;
                    if (W.colour == Colors.Red)
                    {
                        W.colour = Colors.Black;
                        X.parent.colour = Colors.Red;
                        rightRotation(X.parent);
                        W = X.parent.left;
                    }
                    if (W.right.colour == Colors.Black && W.left.colour == Colors.Black)
                    {
                        W.colour = Colors.Black;
                        X = X.parent;
                    }
                    else if (W.left.colour == Colors.Black)
                    {
                        W.right.colour = Colors.Black;
                        W.colour = Colors.Red;
                        leftRotation(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = Colors.Black;
                    W.left.colour = Colors.Black;
                    rightRotation(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = Colors.Black;
        }
        private RBTNode Maximum(RBTNode X)
        {
            while(X.right.right != null)
                X = X.right;

            if (X.right.left != null)
                X = X.right.left;
            return X;
        }
        private RBTNode Minimum(RBTNode X)
        {
            while (X.left.left != null)
                X = X.left;
            
            if (X.left.right != null)
                X = X.left.right;
            return X;
        }
        private RBTNode TreeSuccessor(RBTNode current)
        {
            if (current.left == null)
            {
                RBTNode Y = current.parent;
                while (Y != null && current == Y.right)
                {
                    current = Y;
                    Y = Y.parent;
                }
                return Y;
            }
            else
                return Minimum(current);
        }
    }
}
