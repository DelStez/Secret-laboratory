using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVLandRedBlackBSTs.Core;


namespace AVLandRedBlackTrees.Core
{
    public class TreeDraw
    {
        public class TreeDrawNode
        {
            public TreeDrawNode left;
            public TreeDrawNode right;
            public int key;
            public NodeColor color;
            public TreeDrawNode(int key, NodeColor tColor)
            {
                this.key = key;
                this.color = tColor;
            }
        }
        public TreeDrawNode root;
        private int _lastImageLocationOfStarterNode;
        private static Bitmap _nodeBg = new Bitmap(30, 25);
        private static Size _freeSpace = new Size(_nodeBg.Width / 8, (int)(_nodeBg.Height * 1.3f));
        private static readonly float Coef = _nodeBg.Width / 40f;
        private static Font font = new Font("Arial", 14f * Coef);
        
        public TreeDraw(RBT tree)
        {
            this.root = new TreeDrawNode(tree.root.key, tree.root.colour);
            if (tree.root.right != null)
                this.root.right = GetChild(tree.root.right, this.root.right);
            if (tree.root.left != null)
                this.root.left = GetChild(tree.root.left, this.root.left);
        }
        public TreeDraw(AVL tree)
        {
            this.root = new TreeDrawNode(tree.root.key, NodeColor.None);
            if (tree.root.right != null)
                this.root.right = GetChild(tree.root.right, this.root.right);
            if (tree.root.left != null)
                this.root.left = GetChild(tree.root.left, this.root.left);
        }
        public TreeDraw(BST tree)
        {
            //this.root = new TreeDrawNode(tree.root.key, NodeColor.None);
            //if (tree.root.right != null)
            //    this.root.right = GetChild(tree.root.right, this.root.right);
            //if (tree.root.left != null)
            //    this.root.left = GetChild(tree.root.left, this.root.left);
        }
        public TreeDrawNode GetChild(RBT.RBTNode node, TreeDrawNode currentnode)
        {
            currentnode = new TreeDrawNode(node.key, node.colour);
            if (node.left != null)
            {
                currentnode.left = GetChild(node.left, currentnode.left);
            }
            if (node.right != null)
            {
                currentnode.right = GetChild(node.right, currentnode.right);
            }
            return currentnode;
        }

        public TreeDrawNode GetChild(AVL.AVLNode node, TreeDrawNode currentnode)
        {
            currentnode = new TreeDrawNode(node.key, NodeColor.None);
            if (node.left != null)
            {
                currentnode.left = GetChild(node.left, currentnode.left);
            }
            if (node.right != null)
            {
                currentnode.right = GetChild(node.right, currentnode.right);
            }
            return currentnode;
        }
        public TreeDrawNode GetChild(BST.BSTNode node, TreeDrawNode currentnode)
        {
            currentnode = new TreeDrawNode(node.key, NodeColor.None);
            //if (node.left != null)
            //{
            //    currentnode.left = GetChild(node.left, currentnode.left);
            //}
            //if (node.right != null)
            //{
            //    currentnode.right = GetChild(node.right, currentnode.right);
            //}
            return currentnode;
        }
        public Image Draw()
        {
            GC.Collect();// collects the unreffered locations on the memory
            int temp;
            return Draw(this.root, out temp);
        }
        public Image Draw(TreeDrawNode current, out int center)
        {
            var lCenter = 0;
            var rCenter = 0;
            Image lNodeImg = null, rNodeImg = null;
            if (current.left != null)       // draw left node's image
                lNodeImg = Draw(current.left, out lCenter);
            if (current.right != null)      // draw right node's image
                rNodeImg = Draw(current.right, out rCenter);
            var lSize = new Size();
            var rSize = new Size();
            var under = (lNodeImg != null) || (rNodeImg != null);// if true the current node has childs
            if (lNodeImg != null)
                lSize = lNodeImg.Size;
            if (rNodeImg != null)
                rSize = rNodeImg.Size;

            var maxHeight = lSize.Height;
            if (maxHeight < rSize.Height)
                maxHeight = rSize.Height;

            if (lSize.Width <= 0)
                lSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;
            if (rSize.Width <= 0)
                rSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;

            var resSize = new Size
            {
                Width = lSize.Width + rSize.Width + _freeSpace.Width,
                Height = _nodeBg.Size.Height + (under ? maxHeight + _freeSpace.Height : 0)
            };

            var result = new Bitmap(resSize.Width, resSize.Height);
            var g = Graphics.FromImage(result);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), resSize));
            g.DrawImage(_nodeBg, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2, 0);
            var str = current.key.ToString();
            Brush brush = Brushes.Black;
            if (current.color == NodeColor.Red)
                brush = Brushes.Red;
            g.DrawString(str, font, brush, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2 + (2 + (str.Length == 1 ? 10 : str.Length == 2 ? 5 : 0)) * Coef, _nodeBg.Height / 2f - 12 * Coef);

            center = lSize.Width + _freeSpace.Width / 2;
            var pen = new Pen(Brushes.Black, 1.2f * Coef)
            {
                EndCap = LineCap.ArrowAnchor,
                StartCap = LineCap.Round
            };

            float x1 = center;
            float y1 = _nodeBg.Height;
            float y2 = _nodeBg.Height + _freeSpace.Height;
            float x2 = lCenter;
            var h = Math.Abs(y2 - y1);
            var w = Math.Abs(x2 - x1);
            if (lNodeImg != null)
            {
                g.DrawImage(lNodeImg, 0, _nodeBg.Size.Height + _freeSpace.Height);
                var points1 = new List<PointF>
                                  {
                                      new PointF(x1, y1),
                                      new PointF(x1 - w/6, y1 + h/3.5f),
                                      new PointF(x2 + w/6, y2 - h/3.5f),
                                      new PointF(x2, y2),
                                  };
                g.DrawCurve(pen, points1.ToArray(), 0.5f);
            }
            if (rNodeImg != null)
            {
                g.DrawImage(rNodeImg, lSize.Width + _freeSpace.Width, _nodeBg.Size.Height + _freeSpace.Height);
                x2 = rCenter + lSize.Width + _freeSpace.Width;
                w = Math.Abs(x2 - x1);
                var points = new List<PointF>
                                 {
                                     new PointF(x1, y1),
                                     new PointF(x1 + w/6, y1 + h/3.5f),
                                     new PointF(x2 - w/6, y2 - h/3.5f),
                                     new PointF(x2, y2)
                                 };
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            if (rNodeImg != null)
            {
                g.DrawImage(rNodeImg, lSize.Width + _freeSpace.Width, _nodeBg.Size.Height + _freeSpace.Height);
                x2 = rCenter + lSize.Width + _freeSpace.Width;
                w = Math.Abs(x2 - x1);
                var points = new List<PointF>
                                 {
                                     new PointF(x1, y1),
                                     new PointF(x1 + w/6, y1 + h/3.5f),
                                     new PointF(x2 - w/6, y2 - h/3.5f),
                                     new PointF(x2, y2)
                                 };
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            _lastImageLocationOfStarterNode = center;
            return result;
        }
       
    }
}
