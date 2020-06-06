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
        public class BSTNode
        {
            public int key;
            public BSTNode left;
            public BSTNode right;

            public BSTNode(int value)
            {
                this.key = value;
            }
        }
        public BST()
        {
            root = null;
        }
        public BSTNode Find(int val)
        {
            BSTNode current = root;
            while (current!= null)
            {
                if (current.key == val)
                    return current;
                if (current.key > val)
                    current= current.left;
                else
                    current= current.right;
            }
            return null;
        }
        public string Insert(int i)
        {
            if (Find(i) == null)
            {
                if (root == null) root = new BSTNode(i);
                else
                {

                    BSTNode cur = root;
                    BSTNode pre = cur;
                    while (cur != null)
                    {
                        pre = cur;
                        if (cur.key < i)
                        {
                            cur = cur.right;
                        }
                        else
                        {
                            cur = cur.left;
                        }
                    }

                    if (i < pre.key)
                        pre.left = new BSTNode(i);
                    else if (i > pre.key)
                        pre.right = new BSTNode(i);
                }
                return "";
            }
            else
                return "Дубликат не был добавлен: " + i.ToString();

        }
        public void Remove(int key)
        {
           BSTNode current = root;
           BSTNode parent = root;
            bool isLeftChild = false;

            if (current == null)
            {
                return;
            }

            while (current != null && current.key != key)
            {
                parent = current;

                if (key < current.key)
                {

                    current = current.left;
                    isLeftChild = true;
                }
                else
                {
                    current = current.right;
                    isLeftChild = false;
                }
            }

            if (current == null)
            {
                return;
            }

            if (current.left == null && current.right == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }

                }
            }
            else if (current.right == null)
            {
                if (current == root)
                    root = current.left;
                else
                {
                    if (isLeftChild)
                    {
                        parent.left = current.left;
                    }
                    else
                    {
                        parent.right = current.right;
                    }
                }
            }
            else
            {
               BSTNode successor = GetSuccessor(current);

                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.left = successor;
                }
                else
                {
                    parent.right = successor;
                }
            }
        }
        private BSTNode GetSuccessor(BSTNode node)
        {
            BSTNode parentOfSuccessor = node;
            BSTNode successor = node;
            BSTNode current = node.right;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.left;
            }

            if (successor != node.right)
            {
                parentOfSuccessor.left = successor.right;

                successor.right = node.right;
            }

            successor.left = node.left;

            return successor;
        }

    }

}
