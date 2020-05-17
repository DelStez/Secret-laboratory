using AVLandRedBlackTrees.Core.RBTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core
{
    public class RBT
    {
        public RBTNode root;
        //private int deepth;

        public RBTNode Find(int key)
        {
            bool isFound = false;
            RBTNode temp = root;
            RBTNode item = null;
            while (!isFound)
            {
                if (temp == null)
                    break;
                if (key < temp.key)
                    temp = temp.left;
                if (key > temp.key)
                    temp = temp.right;
                if (key == temp.key)
                {
                    isFound = true;
                    item = temp;
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
            if (currentNode.parent == null)
                root = currentNode;
            if (currentNode == currentNode.parent.left)
                currentNode.parent.left = parentThis;
            else
                currentNode.parent.left = parentThis;
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
            if (currentNode.parent == null)
                root = currentNode;
            if (currentNode == currentNode.parent.right)
                currentNode.parent.right = parentThis;
            else
                currentNode.parent.right = parentThis;
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
                root.colour = Color.Black;
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
            newItem.colour = Color.Red;
            InsertFixUp(newItem);
        }
        public void InsertFixUp(RBTNode item)
        {
            //проверка свойств КБ-дерева
            while (item != root && item.parent.colour == Color.Red)
            {
                if (item.parent == item.parent.parent.left)
                {
                    RBTNode y = item.parent.parent.right;
                    if (y != null && y.colour == Color.Red)// "дядя" - красный узел
                    {
                        item.parent.colour = Color.Black;
                        y.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        item = item.parent.parent;
                    }
                    else  // "дядя" - черный узел
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            leftRotation(item);
                        }
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        rightRotation(item.parent.parent);
                    }

                }
                else
                {
                    RBTNode y = item.parent.parent.left;
                    if (y != null && y.colour == Color.Black)
                    {
                        item.parent.colour = Color.Red;
                        y.colour = Color.Red;
                        item.parent.parent.colour = Color.Black;
                        item = item.parent.parent;
                    }
                    else
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            rightRotation(item);
                        }
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        leftRotation(item.parent.parent);
                    }
                }
                root.colour = Color.Black;
            }
        }
        public void Remove(int key)
        {
            RBTNode item = Find(key);
            RBTNode x = null; RBTNode y = null;
            if (item == null) return;
            if (item.left == null || item.right == null) y = item;
            else y = TreeSuccessor(item);//!!!!!!!!
            if (y.left != null) x = y.left;
            else x = y.right;
            if (x != null) x.parent = y;
            if (y.parent != null) root = x;
            else if (y == y.parent.left) y.parent.left = x;
            else y.parent.left = x;
            if (y != item) item.key = y.key;
            if (y.colour == Color.Black) RemoveFixUp(x);
            
        }
        public void RemoveFixUp(RBTNode item)
        {
            while (item != null && item != root && item.colour ==Color.Black )
            {
                if (item == item.parent)
                {
                    RBTNode w = item.parent.right;
                    if (w.colour == Color.Red)
                    {
                        w.colour = Color.Black;
                        item.parent.colour = Color.Red;
                        leftRotation(item.parent);
                        w = item.parent.right;
                    }
                    if (w.left.colour == Color.Black && w.right.colour == Color.Black)
                    {
                        w.colour = Color.Red;
                        item = item.parent;
                    }
                    else if (w.right.colour == Color.Black)
                    {
                        w.left.colour = Color.Black;
                        w.colour = Color.Red;
                        rightRotation(w);
                        w = item.parent.right;
                    }
                    w.colour = item.parent.colour;
                    item.parent.colour = Color.Black;
                    w.right.colour = Color.Black;
                    leftRotation(item.parent);
                    item = root;
                }
                else
                {
                    RBTNode w = item.parent.left;
                    if (w.colour == Color.Black)
                    {
                        w.colour = Color.Red;
                        item.parent.colour = Color.Black;
                        rightRotation(item.parent);
                        w = item.parent.left;
                    }
                    if (w.left.colour == Color.Black && w.right.colour == Color.Black)
                    {
                        w.colour = Color.Black;
                        item = item.parent;
                    }
                    else if (w.left.colour == Color.Black)
                    {
                        w.right.colour = Color.Black;
                        w.colour = Color.Red;
                        leftRotation(w);
                        w = item.parent.left;
                    }
                    w.colour = item.parent.colour;
                    item.parent.colour = Color.Black;
                    w.left.colour = Color.Black;
                    rightRotation(item.parent);
                    item = root;
                }
            }
            if (item != null)
                item.colour = Color.Black;
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
