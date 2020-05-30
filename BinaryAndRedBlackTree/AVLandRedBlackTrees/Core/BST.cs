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
            public BSTNode left;
            public BSTNode right;
            public BSTNode(int key)
            {
                this.key = key;
            }
            
        }
        public static BSTNode root;

        public BST()
        {
            root = null;
        }
       
        public void Insert(int key)
        {
            BSTNode newBSTNode = new BSTNode(key);
            if (root == null)
                root = newBSTNode;
            else
            {
                BSTNode current = root;
                BSTNode parent = null;
                while (current != null)
                {
                    parent = current;
                    if (key < current.key)
                    {
                        current = current.left;
                        if (current == null)
                            parent.left = newBSTNode;
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                            parent.right = newBSTNode;
                    }
                }
            }
        }
        public void Remove(int key)
        {
            if (root == null || find(key) == false)
            {
                return;
            }
            else
            {
                Private_Remove(key);
                return;
            }
        }
        public bool find(int target)
        {
            if (root != null && regular_find(target) != false)
            {
                return true;
            }
            else
            { return false; }
        }
        private bool regular_find(int target)
        {
            bool isFound = false;
            BSTNode current = root;
            while (current != null && isFound == false)
            {
                if (current.key == target)
                {
                    isFound = true;
                }
                if (target < current.key)
                {
                    if (current.left == null)
                    {
                        break;
                    }
                    else
                    {
                        current = current.left;
                    }
                }
                if (target > current.key)
                {
                    if (current.right == null)
                    {
                        break;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
            }
            if (isFound == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int Private_Remove(int target)
        {
            int temp;
            BSTNode targetNode = GoToTarget(target);
            if (targetNode == root)
            {
                if (targetNode.left == null && targetNode.right == null)
                {
                    temp = root.key;
                    root = null;
                    return temp;
                }
                if (targetNode.left != null)
                {
                    BSTNode current = root.left;

                    temp = root.key;
                    if (root.left.right == null)
                    { root.key = root.left.key; }
                    else
                    {
                        while (current != null)
                        { 
                            if (current.right.right == null)
                            { root.key = current.right.key; break; }
                            current = current.right;
                        }
                        if (current.right != null) { current.right = current.right.right; }
                        else { current.right = null; }
                        return temp;
                    }

                    if (root.left.left == null)
                    {
                        root.left = null;
                    }
                    else { root.left = root.left.left; }
                    return temp;
                }
                if (targetNode.right != null)
                {
                    temp = root.key;
                    root.key = root.right.key;
                    if (root.right.right == null)
                    {
                        root.right = null;
                    }
                    else { root.right = root.right.right; }
                    return temp;
                }
            }
            if (targetNode.left == null && targetNode.right == null)
            {
                if (ParentOfTarget(targetNode).left == targetNode)
                {
                    temp = targetNode.key;
                    ParentOfTarget(targetNode).left = null;
                }
                else
                {
                    temp = targetNode.key;
                    ParentOfTarget(targetNode).right = null;
                }
                return temp;
            }
            if (targetNode.left != null && targetNode.right == null)
            {
                temp = targetNode.key;
                ParentOfTarget(targetNode).right = targetNode.left;
                return temp;

            }
            if (targetNode.right != null && targetNode.left == null)
            {
                temp = targetNode.key;
                if (ParentOfTarget(targetNode) == root)
                {
                    ParentOfTarget(targetNode).left = targetNode.right;
                }
                else
                    ParentOfTarget(targetNode).right = targetNode.right;

                return temp;

            }
            if (targetNode.left != null && targetNode.right != null)
            {
                if (ParentOfTarget(targetNode).left == targetNode)
                {
                    temp = targetNode.key;
                    targetNode.key = targetNode.left.key;
                    targetNode.left = null;
                    return temp;
                }
                else
                {
                    temp = targetNode.key;
                    targetNode.key = targetNode.left.key;
                    if (targetNode.left.left != null)
                    {
                        targetNode.left = targetNode.left.left;
                    }
                    else
                        targetNode.left = null;
                    return temp;
                }

            }
            return Int32.MinValue;
        }
        private BSTNode ParentOfTarget(BSTNode target)
        {
            BSTNode current = root;
            BSTNode parent = null;
            while (current != null)
            {
                if (current.left == target || current.right == target)
                {
                    parent = current;
                    break;
                }
                if (target.key < current.key && current.left != target)
                    current = current.left;
                if (target.key > current.key && current.right != target)
                    current = current.right;
            }
            return parent;
        }
        private BSTNode GoToTarget(int target)
        {
            BSTNode c = root;
            BSTNode returnThis = null;
            while (c != null)
            {
                if (target < c.key)
                {
                    c = c.left;
                }
                if (target == c.key)
                {
                    returnThis = c;
                    break;
                }
                if (target > c.key)
                {
                    c = c.right;
                }
            }
            return returnThis;
        }
    }
}
