using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLandRedBlackTrees.Core
{
    public class AVL
    {
        public class AVLNode
        {
            public int key;
            public AVLNode left;
            public AVLNode right;
            public AVLNode(int key)
            {
                this.key = key;
            }
        }
        public AVLNode root;
        public AVL() { }
        public void Add(int key)
        {
            AVLNode newItem = new AVLNode(key);
            if (root == null)
                root = newItem;
            else
                root = RecursiveInsert(root, newItem);
        }
        private AVLNode RecursiveInsert(AVLNode current, AVLNode n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.key < current.key)
            {
                current.left = RecursiveInsert(current.left, n);
                current = BalanceTree(current);
            }
            else if (n.key > current.key)
            {
                current.right = RecursiveInsert(current.right, n);
                current = BalanceTree(current);
            }
            return current;
        }
        private AVLNode BalanceTree(AVLNode current)
        {
            int bFactor = BalanceFactor(current);
            if (bFactor > 1)
            {
                if (BalanceFactor(current.left) > 0)
                    current = RotateLL(current);
                else
                    current = RotateLR(current);
            }
            else if (bFactor < -1)
            {
                if (BalanceFactor(current.right) > 0)
                    current = RotateRL(current);
                else
                    current = RotateRR(current);
            }
            return current;
        }
        private int BalanceFactor(AVLNode current)
        {
            int l = GetHeight(current.left);
            int r = GetHeight(current.right);
            int bFactor = l - r;
            return bFactor;
        }
        public void Remove(int target)
        {
            root = Delete(root, target);
        }
        private AVLNode Delete(AVLNode current, int target)
        {
            AVLNode parent;
            if (current == null)
            { return null; }
            else
            {
                //левое поддерево
                if (target < current.key)
                {
                    current.left = Delete(current.left, target);
                    if (BalanceFactor(current) == -2)
                    {
                        if (BalanceFactor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //правое поддерево
                else if (target > current.key)
                {
                    current.right = Delete(current.right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.left) >= 0)
                            current = RotateLL(current);
                        else
                            current = RotateLR(current);
                    }
                }
                else
                {
                    if (current.right != null)
                    {
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.key = parent.key;
                        current.right = Delete(current.right, parent.key);
                        if (BalanceFactor(current) == 2)
                        {
                            if (BalanceFactor(current.left) >= 0)
                                current = RotateLL(current);
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                        return current.left;
                }
            }
            return current;
        }
        public void Find(int data)
        {
            if (Find(data, root) != null)
            {
                //Элемент найден
               // использовать листбоксы
            }
            else
            {
                // использовать листбоксы
                //Не был найден
            }

        }
        private AVLNode Find(int target, AVLNode current)
        {
            if (current != null)
            {
                if (target < current.key)
                {
                    if (target == current.key)
                    {
                        return current;
                    }
                    else
                        return Find(target, current.left);
                }
                else
                {
                    if (target == current.key)
                        return current;
                    else
                        return Find(target, current.right);
                }
            }
            else
                return null;
            
        }
        private int GetHeight(AVLNode current)
        {
            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.left);
                int r = GetHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private AVLNode RotateLL(AVLNode parent)
        {
            AVLNode pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private AVLNode RotateRR(AVLNode parent)
        {
            AVLNode pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private AVLNode RotateLR(AVLNode parent)
        {
            AVLNode pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private AVLNode RotateRL(AVLNode parent)
        {
            AVLNode pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}
