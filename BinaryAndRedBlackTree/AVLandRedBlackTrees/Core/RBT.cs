using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVLandRedBlackTrees.Core
{
    //None используется для новых вершин
    public enum NodeColor { None, Red, Black }
    public class RBT
    {
        public class RBTNode
        {
            public int key;
            public RBTNode left;
            public RBTNode right;
            public RBTNode parent;
            public NodeColor colour;
        }
        
        public RBTNode root;
        public RBTNode NullBlackNode{ get; set; }
       
        // инициализация дерева
        public RBT()
        {
            root = null;
        }
        protected RBTNode createNode(int newKey)
        {
            //инициализация новой вершины
            RBTNode newNode = new RBTNode { key = newKey, parent = null, left = null, right = null, colour = NodeColor.None };
            return newNode;
        }
        protected void ResetNullBlack()
        {
            // сброс вершины 
            NullBlackNode = new RBTNode { key = new int(), parent = null, left = null, right = null, colour = NodeColor.Black };
        }
        // создание корня дерева
        protected void MakeRoot(RBTNode node)
        {
            if (node == null)
            {
                root = null;
            }
            else
            {
                root = node;
                node.parent = null;
            }
        }
        protected void MakeLeftChild(RBTNode parent, RBTNode child)
        {
            parent.left = child;
            if (child != null)
            {
                child.parent = parent;
            }
        }
        protected void MakeRightChild(RBTNode parent, RBTNode child)
        {
            parent.right = child;
            if (child != null)
            {
                child.parent = parent;
            }
        }

        protected void ReplaceParentWithChild(RBTNode parent, RBTNode child)
        {
            

            bool parentHasNoChildren = (parent.left == null && parent.right == null);// 
            bool parentHasTwoChildren = (parent.left != null && parent.right!= null); // У родителя два ребёнка.
            bool parentHasOneChild = (!parentHasNoChildren && !parentHasTwoChildren); // У родителя один ребёнок.

            if (parentHasOneChild)
            {
                RBTNode grandparent = parent.parent;
                if (grandparent == null)
                {
                    // родитель - это корень
                    RemoveChildFromParent(child);
                    MakeRoot(child);
                }
                else
                {
                    bool parentIsLeftChildOfGrandParent = (grandparent.left == parent);
                    bool parentIsRightChildOfGrandParent = (grandparent.right == parent);
                    RemoveChildFromParent(parent);
                    RemoveChildFromParent(child);
                    if (parentIsLeftChildOfGrandParent)
                    {
                        MakeLeftChild(grandparent, child);
                    }
                    else if (parentIsRightChildOfGrandParent)
                    {
                        MakeRightChild(grandparent, child);
                    }
                    else
                    {
                        // у деда нет детей
                        throw new System.ArgumentException();
                    }
                }
            }
            else
            {
                throw new System.ArgumentException();
            }
        }
        protected RBTNode FindSuccessor(RBTNode node)
        {
            RBTNode successor;

            if (node == null)
            {
                successor = null;
            }
            else if (node.left != null)
            {
                successor = FindSuccessor(node.left);
            }
            else
            {
                successor = node;
            }

            return successor;
        }

        protected RBTNode Find(RBTNode node, int key)
        {
            bool nodeHasTargetValue = (node.key.CompareTo(key) == 0);
            if (nodeHasTargetValue)
            {
                return node;
            }

            RBTNode matchingnode;

            if (node.left != null)
            {
                matchingnode = Find(node.left, key);
                if (matchingnode != null)
                {
                    return matchingnode;
                }
            }

            if (node.right != null)
            {
                matchingnode = Find(node.right, key);
                if (matchingnode != null)
                {
                    return matchingnode;
                }
            }

            return null;
        }

        protected RBTNode Find(int key)
        {
            RBTNode node = Find(root, key);
            return node;
        }

        #region Rotate
        protected void RightRotate(RBTNode node)
        {

            RBTNode leftChild = node.left;
            RBTNode leftChildRightChild = leftChild?.right; 
            bool gotParent = (node.parent != null);
            if (gotParent)
            {
                bool isNodeParentLeftChild = (node.parent.left == node);
                bool isNodeParentRightChild = (node.parent.right == node);

                if (isNodeParentLeftChild)
                {
                    MakeLeftChild(node.parent, leftChild);
                }
                else if (isNodeParentRightChild)
                {
                    MakeRightChild(node.parent, leftChild);
                }
            }
            else
            {
                MakeRoot(leftChild);
            }

            node.parent = null;

            MakeRightChild(leftChild, node);

            MakeLeftChild(node, leftChildRightChild);
        }

        protected void LeftRotate(RBTNode node)
        {

            RBTNode rightChild = node.right;
            RBTNode rightChildLeftChild = rightChild?.left;

            bool gotParent = (node.parent != null);
            if (gotParent)
            {
                bool isNodeParentLeftChild = (node.parent.left == node);
                bool isNodeParentRightChild = (node.parent.right == node);

                if (isNodeParentLeftChild)
                {
                    MakeLeftChild(node.parent, rightChild);
                }
                else if (isNodeParentRightChild)
                {
                    MakeRightChild(node.parent, rightChild);
                }
            }
            else
            {
                MakeRoot(rightChild);
            }

            node.parent = null;
            MakeLeftChild(rightChild, node);
            MakeRightChild(node, rightChildLeftChild);
        }

        protected void LeftLeftTransform(RBTNode node)
        {
            RBTNode parent = node.parent;
            RBTNode grandParent = node.parent.parent;
            RightRotate(grandParent);
            NodeColor swap = parent.colour;
            parent.colour = grandParent.colour;
            grandParent.colour = swap;
        }

        protected void LeftRightTransform(RBTNode node)
        {
            RBTNode parent = node.parent;
            LeftRotate(parent);
            LeftLeftTransform(parent);
        }

        protected void RightRightTransform(RBTNode node)
        {
            RBTNode parent = node.parent;
            RBTNode grandParent = node.parent.parent;
            LeftRotate(grandParent);
            NodeColor swap = parent.colour;
            parent.colour = grandParent.colour;
            grandParent.colour = swap;
        }

        protected void RightLeftTransform(RBTNode node)
        {
            RBTNode parent = node.parent;
            RightRotate(parent);
            RightRightTransform(parent);
        }
        #endregion Rotate

        #region Insert
        protected void BalanceTreeAfterInsert(RBTNode newNode)
        {
            if (newNode.parent == null)
            {
                // Текущий узел N в корне дерева
                newNode.colour = NodeColor.Black;
                return;
            }
            if (newNode.parent != null && newNode.parent.colour == NodeColor.Black)
            {
                // Предок P текущего узла чёрный, то есть Свойство 4 (Оба потомка каждого красного узла — чёрные) не нарушается.
                // Свойство 5 (Все пути от любого данного узла до листовых узлов содержат одинаковое число чёрных узлов) не нарушается.
                return;
            }

            //Цвет null-узла считается черным

            bool gotGrandParent = (newNode.parent != null && newNode.parent.parent != null);
            if (gotGrandParent)
            {
                RBTNode parent = newNode.parent;
                RBTNode grandParent = newNode.parent.parent;

                // у текущего узла есть "дядя", котрый вызовет балансировку
                bool isNodeLeftChild = (parent.left == newNode);
                bool isNodeRightChild = (parent.right == newNode);

                bool isParentLeftChild = (grandParent != null && grandParent.left == parent);
                bool isParentRightChild = (grandParent != null && grandParent.right == parent);

                RBTNode rightUncle = (isParentLeftChild && grandParent.right != null ? grandParent.right : null);
                RBTNode leftUncle = (isParentRightChild && grandParent.left != null ? grandParent.left : null);

                // дядя == null
                RBTNode uncle = (isParentLeftChild ? rightUncle : leftUncle);

                bool gotRedUncle = (uncle != null && uncle.colour == NodeColor.Red);
                bool gotBlackUncle = (uncle == null || uncle.colour == NodeColor.Black);

                if (gotRedUncle) // дядя - красный
                {
                    // две смежные вершины не могут быть красными => красный дядя имеет чёрного родителя

                    // (i) Изменить цвет родителей и дяди на черный
                    newNode.parent.colour = NodeColor.Black;
                    uncle.colour = NodeColor.Black;

                    // (ii) цвет прародителя  красный
                    newNode.parent.parent.colour = NodeColor.Red;

                    // (iii) балансировка дерева
                    BalanceTreeAfterInsert(newNode.parent.parent);
                }
                else if (gotBlackUncle) //дядя - черный
                {

                    // (i)   текущий узел N — левый потомок P(родитель), и P — левый потомок G(предка).
                    if (isParentLeftChild && isNodeLeftChild)
                    {
                        LeftLeftTransform(newNode);
                    }

                    // (ii)  текущий узел N — правый потомок P, а P в свою очередь — левый потомок своего предка G
                    if (isParentLeftChild && isNodeRightChild)
                    {
                        LeftRightTransform(newNode);
                    }

                    // (iii) текущий узел N — правый потомок P, P в свою очередь  - правый потомок своего предка G
                    if (isParentRightChild && isNodeRightChild)
                    {
                        RightRightTransform(newNode);
                    }

                    // (iv) текущий узел N — левый потомок P,P в свою очередь  - правый потомок своего предка G 
                    if (isParentRightChild && isNodeLeftChild)
                    {
                        RightLeftTransform(newNode);
                    }
                }
            }
        }
        protected void UnbalancedInsert(RBTNode node, RBTNode newNode)
        {
            if (newNode.key.CompareTo(node.key) < 0)
            {
                // ключ новой вершины < ключ уже существующей вершины
                if (node.left == null)
                    MakeLeftChild(node, newNode);
                else
                    UnbalancedInsert(node.left, newNode);
            }
            else if (newNode.key.CompareTo(node.key) > 0)
            {
                // ключ новой вершины > ключ уже существующей вершины
                if (node.right == null)
                {
                    MakeRightChild(node, newNode);
                }
                else  
                {
                    UnbalancedInsert(node.right, newNode);
                }
            }
            else if (newNode.key.CompareTo(node.key) == 0)
            {
                // ключ новой вершины  == ключ уже существующей вершины
                // запрет на ввод дубликатов
                throw new System.InvalidOperationException();
            }
        }
        protected RBTNode UnbalancedInsert(int newValue)
        {
            RBTNode newNode = createNode(newValue);

            if (root == null)
                MakeRoot(newNode);
            else
                UnbalancedInsert(root, newNode);
            return newNode;
        }
        protected void UnbalancedDelete(RBTNode node, out RBTNode nodeDeleted, out RBTNode nodeReplacedDeleted)
        {
            bool nodeHasNoChildren = (node.left == null && node.right == null);
            bool nodeHasTwoChildren = (node.left != null && node.right != null);
            bool nodeHasOneChild = (!nodeHasNoChildren && !nodeHasTwoChildren);

            if (nodeHasNoChildren)
            {
                nodeDeleted = node;
                if (nodeDeleted.colour == NodeColor.Black)
                {
                    bool nodeIsRoot = (node == root);
                    bool nodeIsLeftChild = (!nodeIsRoot && node == node.parent.left);
                    bool nodeIsRightChild = (!nodeIsRoot && node == node.parent.right);
                    RBTNode parent = (node.parent ?? null);
                    nodeIsLeftChild = (node == node.parent?.left);
                    nodeIsRightChild = (node == node.parent?.right);

                    RemoveChildFromParent(node);

                    if (nodeIsLeftChild || nodeIsRightChild)
                    {
                        ResetNullBlack();
                        nodeReplacedDeleted = NullBlackNode;

                        if (nodeIsLeftChild)
                        {
                            MakeLeftChild(parent, NullBlackNode);
                        }
                        else if (nodeIsRightChild)
                        {
                            MakeRightChild(parent, NullBlackNode);
                        }
                    }
                    else
                    {
                        // вершина является корнем
                        nodeReplacedDeleted = null;
                    }
                }
                else
                {
                    RemoveChildFromParent(node);
                    nodeReplacedDeleted = null;
                }
            }
            else if (nodeHasOneChild)
            {
                RBTNode child = (node.left ?? node.right); 
                ReplaceParentWithChild(node, child);
                nodeDeleted = node;
                nodeReplacedDeleted = child;
            }
            else // if ( nodeHasTwoChildren )
            {
                RBTNode successor = FindSuccessor(node.right); // возвращает правого потомка

                int swap = node.key;
                node.key = successor.key;
                successor.key = swap;
                //двоичное дерево теперь сломанно, так как новый ключ вершины нарушает правила 
                // однако в дальнейшем будет исправленно

                nodeDeleted = successor;

                bool successorHasNoChildren = (successor.left == null && successor.right == null);
                bool successorHasRightChild = (successor.right != null);
                if (successorHasRightChild)
                {
                    RBTNode rightChild = successor.right;
                    ReplaceParentWithChild(successor, rightChild);

                    if (nodeDeleted.colour == NodeColor.Black)
                    {
                        nodeReplacedDeleted = rightChild;
                    }
                    else
                    {
                        nodeReplacedDeleted = null;
                    }
                }
                else if (successorHasNoChildren)
                {
                    if (nodeDeleted.colour == NodeColor.Black)
                    {
                        ResetNullBlack();
                        MakeLeftChild(successor, NullBlackNode);
                        ReplaceParentWithChild(successor, NullBlackNode);
                        nodeReplacedDeleted = NullBlackNode;
                    }
                    else
                    {
                        RemoveChildFromParent(successor);
                        nodeReplacedDeleted = null;
                    }
                }
                else
                {
                    throw new System.InvalidOperationException();
                }
            }
        }
        #endregion Insert


        protected int count { get; set; }
        public int Count { get { return count; } }

        protected bool isReadOnly { get; set; } 
        public bool IsReadOnly { get { return isReadOnly; } }

        public void Add(int item)
        {
            try
            {
                RBTNode newNode = UnbalancedInsert(item);
                newNode.colour = NodeColor.Red;
                BalanceTreeAfterInsert(newNode);
                count++;
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("дубликат");
            }
           
        }
        public void Clear()
        {
            root = null;
            count = 0;
            isReadOnly = false;
        }

        public bool Contains(int item)
        {
            return (Find(item) != null);
        }
        # region Remove
        /* При удалении вершины могут возникнуть три случая в зависимости от количества её детей:
        *      Если у вершины нет детей, то изменяем указатель на неё у родителя на null
        *      Если у неё только один ребёнок, то делаем у родителя ссылку на него вместо этой вершины.
        *      Если же имеются оба ребёнка, то находим вершину со следующим значением ключа. 
        * У такой вершины нет левого ребёнка (так как такая вершина находится в правом поддереве исходной вершины и она самая левая в нем, иначе бы мы взяли ее левого ребенка.
        * Иными словами сначала мы переходим в правое поддерево, а после спускаемся вниз в левое до тех пор, пока у вершины есть левый ребенок). 
        * Удаляем уже эту вершину описанным во втором пункте способом, скопировав её ключ в изначальную вершину.
        */
        public bool Remove(int item)
        {
            try
            {
                RBTNode node = Find(item);
                if (node == null)
                {
                    return false;
                }

                RBTNode nodeDeleted, nodeReplacedDeleted;
                UnbalancedDelete(node, out nodeDeleted, out nodeReplacedDeleted);

                bool blackNodeDeleted = (nodeDeleted.colour == NodeColor.Black);
                if (blackNodeDeleted)
                {
                    BalanceTreeAfterDelete(nodeReplacedDeleted);
                }

                count--;

                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            
        }
        /*Проверим балансировку дерева. Основные случаи:
         *      Если брат этого ребёнка красный
         *      Если брат текущей вершины был чёрным
         *              Оба ребёнка у брата чёрные.
         *              Если у брата правый ребёнок чёрный, а левый красный.
         *              Если у брата правый ребёнок красный.*/
        protected void BalanceTreeAfterDelete(RBTNode node)
        {
            if (root == null)
            {
                //корень был удален
                return;
            }

            bool leftChildOfRightSiblingIsBlack;
            bool rightChildOfRightSiblingIsBlack;
            bool leftChildOfLeftSiblingIsBlack;
            bool rightChildOfLeftSiblingIsBlack;

            while (node != root && node.colour == NodeColor.Black)
            {
                //  узел - это не корневой черный узел, имеющий неявный  черный узел

                bool isLeftChild = (node == node.parent.left);
                if (isLeftChild)
                {
                    // узел является левым потомком 

                    RBTNode rightSibling = node.parent.right;

                    if (rightSibling.colour == NodeColor.Red)
                    {

                        rightSibling.colour = NodeColor.Black;
                        node.parent.colour = NodeColor.Red;
                        LeftRotate(node.parent);
                        rightSibling = node.parent.right;
                    }

                    leftChildOfRightSiblingIsBlack =
                        (rightSibling.left == null || rightSibling.left.colour == NodeColor.Black);
                    rightChildOfRightSiblingIsBlack =
                        (rightSibling.right == null || rightSibling.right.colour == NodeColor.Black);

                    if (leftChildOfRightSiblingIsBlack && rightChildOfRightSiblingIsBlack)
                    {

                        rightSibling.colour = NodeColor.Red;

                        RBTNode parent = node.parent;
                        if (node == NullBlackNode)
                        {

                            RemoveChildFromParent(node);
                        }
                        node = parent;
                    }
                    else
                    {

                        rightChildOfRightSiblingIsBlack =
                            (rightSibling.right == null || rightSibling.right.colour == NodeColor.Black);

                        if (rightChildOfRightSiblingIsBlack)
                        {

                            rightSibling.left.colour = NodeColor.Black;
                            rightSibling.colour = NodeColor.Red;
                            RightRotate(rightSibling);
                            rightSibling = node.parent.right;
                        }

                        rightSibling.colour = node.parent.colour;
                        node.parent.colour = NodeColor.Black;
                        rightSibling.right.colour = NodeColor.Black;
                        LeftRotate(node.parent);

                        if (node == NullBlackNode)
                        {

                            RemoveChildFromParent(node);
                        }
                        node = root;
                    }
                }
                else
                {
                    // узел является правым потомком 

                    RBTNode leftSibling = node.parent.left;

                    if (leftSibling.colour == NodeColor.Red)
                    {

                        leftSibling.colour = NodeColor.Black;
                        node.parent.colour = NodeColor.Red;
                        RightRotate(node.parent);
                        leftSibling = node.parent.left;
                    }

                    leftChildOfLeftSiblingIsBlack =
                        (leftSibling.left == null || leftSibling.left.colour == NodeColor.Black);
                    rightChildOfLeftSiblingIsBlack =
                        (leftSibling.right == null || leftSibling.right.colour == NodeColor.Black);

                    if (leftChildOfLeftSiblingIsBlack && rightChildOfLeftSiblingIsBlack)
                    {
                        leftSibling.colour = NodeColor.Red;

                        RBTNode parent = node.parent;
                        if (node == NullBlackNode)
                        {

                            RemoveChildFromParent(node);
                        }
                        node = parent;
                    }
                    else
                    {
                        leftChildOfLeftSiblingIsBlack =
                            (leftSibling.left == null || leftSibling.left.colour == NodeColor.Black);

                        if (leftChildOfLeftSiblingIsBlack)
                        {

                            leftSibling.right.colour = NodeColor.Black;
                            leftSibling.colour = NodeColor.Red;
                            LeftRotate(leftSibling);
                            leftSibling = node.parent.left;
                        }

                        leftSibling.colour = node.parent.colour;
                        node.parent.colour = NodeColor.Black;
                        leftSibling.left.colour = NodeColor.Black;
                        RightRotate(node.parent);

                        if (node == NullBlackNode)
                        {
                            RemoveChildFromParent(node);
                        }
                        node = root;
                    }
                }
            }

            node.colour = NodeColor.Black;
        }

        protected void RemoveChildFromParent(RBTNode child)
        {
            RBTNode parent = child.parent;

            if (parent == null)
            {
                // если у вершины нет предка, то это корень дерева
                MakeRoot(null);
            }
            else//иначе
            {
                if (parent.left == child)// если данная вершина явлеятся левым листом
                {
                    RemoveLeft(parent);
                }
                else if (parent.right == child)//если данная вершина явлеятся правым листом
                {
                    RemoveRight(parent);
                }
                else// произошла ошибка ??
                {
                    throw new InvalidOperationException();
                }
            }
        }
        protected void RemoveLeft(RBTNode parent)
        {
            if (parent.left != null)
            {
                RBTNode leftChild = parent.left;
                parent.left = null;
                leftChild.parent = null;
            }
        }

        protected void RemoveRight(RBTNode parent)
        {
            if (parent.right != null)
            {
                RBTNode rightChild = parent.right;
                parent.right = null;
                rightChild.parent = null;
            }
        }
        #endregion Remove

    }
}
