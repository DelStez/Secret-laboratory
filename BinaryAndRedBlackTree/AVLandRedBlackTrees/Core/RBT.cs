using System;
using System.Collections.Generic;
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
        public void leftRotation(RBTNode currentNode)
        {
            RBTNode parentThis = currentNode.right;
            currentNode.right = parentThis.left;
            if (parentThis.left != null)
                parentThis.left.parent = currentNode;
            if (parentThis != null)
                parentThis.parent = currentNode.parent; 
            if (currentNode.parent != null)
            {
                if (currentNode == currentNode.parent.left)
                    currentNode.parent.left = parentThis;
                else
                    currentNode.parent.right = parentThis;
            }
            else
            {
                    root = currentNode;
            }
            parentThis.left = currentNode;
            if (parentThis != null)
                currentNode.parent = currentNode;
        }
        public void rightRotation(RBTNode currentNode)
        {
            RBTNode parentThis = currentNode.left;
            currentNode.left = parentThis.right;
            if (parentThis.right != null)
                parentThis.right.parent = currentNode;
            if (parentThis != null)
                parentThis.parent = currentNode.parent;
            if (currentNode.parent != null)
            {
                if (currentNode == currentNode.parent.right)
                    currentNode.parent.right = parentThis;
                else
                    currentNode.parent.left = parentThis;
            }
            else
            {
                root = currentNode;
            }
            parentThis.right = currentNode;
            if (parentThis != null)
                currentNode.parent = currentNode;
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
        public void InsertFixUp(RBTNode item)
        {
            //проверка свойств КБ-дерева
            while (item != root && item.parent.colour == Colors.Red)
            {
                if (item.parent == item.parent.parent.left)
                {
                    RBTNode y = item.parent.parent.right;
                    if (y != null && y.colour == Colors.Red)// "дядя" - красный узел
                    {
                        item.parent.colour = Colors.Black;
                        y.colour = Colors.Black;
                        item.parent.parent.colour = Colors.Red;
                        item = item.parent.parent;
                    }
                    else  // "дядя" - черный узел
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            leftRotation(item);
                        }
                        item.parent.colour = Colors.Black;
                        item.parent.parent.colour = Colors.Red;
                        rightRotation(item.parent.parent);
                    }

                }
                else
                {
                    RBTNode y = item.parent.parent.left;
                    if (y != null && y.colour == Colors.Black)
                    {
                        item.parent.colour = Colors.Red;
                        y.colour = Colors.Red;
                        item.parent.parent.colour = Colors.Black;
                        item = item.parent.parent;
                    }
                    else
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            rightRotation(item);
                        }
                        item.parent.colour = Colors.Black;
                        item.parent.parent.colour = Colors.Red;
                        leftRotation(item.parent.parent);
                    }
                }
                root.colour = Colors.Black;
            }
        }
        public void Remove(int key)
        {
            RBTNode item = Find(key);
            RBTNode x = null; RBTNode y = null;
            if (item == null) return;
            if (item.left == null || item.right == null)
            {
                y = item;
            }
            else
            {
                y = TreeSuccessor(item);
                if (y.left != null)
                    x = y.left;
                else
                    x = y.right;
            }
            if (x != null) x.parent = y;
            if (y.parent != null)
            {
                
                if (y == y.parent.left)
                    y.parent.left = x;
                else
                    y.parent.right = x;
            }
            else
                root = x; 
            
            if (y != item)
                item.key = y.key;
            if (y.colour == Colors.Black)
                RemoveFixUp(x);
            
        }
        public void RemoveFixUp(RBTNode item)
        {
            while (item != null && item != root && item.colour ==Colors.Black )
            {
                if (item == item.parent)
                {
                    RBTNode w = item.parent.right;
                    if (w.colour == Colors.Red)
                    {
                        w.colour = Colors.Black;
                        item.parent.colour = Colors.Red;
                        leftRotation(item.parent);
                        w = item.parent.right;
                    }
                    if (w.left.colour == Colors.Black && w.right.colour == Colors.Black)
                    {
                        w.colour = Colors.Red;
                        item = item.parent;
                    }
                    else if (w.right.colour == Colors.Black)
                    {
                        w.left.colour = Colors.Black;
                        w.colour = Colors.Red;
                        rightRotation(w);
                        w = item.parent.right;
                    }
                    w.colour = item.parent.colour;
                    item.parent.colour = Colors.Black;
                    w.right.colour = Colors.Black;
                    leftRotation(item.parent);
                    item = root;
                }
                else
                {
                    RBTNode w = item.parent.left;
                    if (w.colour == Colors.Black)
                    {
                        w.colour = Colors.Red;
                        item.parent.colour = Colors.Black;
                        rightRotation(item.parent);
                        w = item.parent.left;
                    }
                    if (w.left.colour == Colors.Black && w.right.colour == Colors.Black)
                    {
                        w.colour = Colors.Black;
                        item = item.parent;
                    }
                    else if (w.left.colour == Colors.Black)
                    {
                        w.right.colour = Colors.Black;
                        w.colour = Colors.Red;
                        leftRotation(w);
                        w = item.parent.left;
                    }
                    w.colour = item.parent.colour;
                    item.parent.colour = Colors.Black;
                    w.left.colour = Colors.Black;
                    rightRotation(item.parent);
                    item = root;
                }
            }
            if (item != null)
                item.colour = Colors.Black;
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
