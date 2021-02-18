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
        private int lastLocation;
        private static Bitmap nodeSize = new Bitmap(30, 25);
        private static Size freeSpace = new Size(nodeSize.Width / 8, (int)(nodeSize.Height * 1.3f));
        private static readonly float Coef = nodeSize.Width / 40f;
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
            this.root = new TreeDrawNode(tree.root.key, NodeColor.None);
            if (tree.root.right != null)
                this.root.right = GetChild(tree.root.right, this.root.right);
            if (tree.root.left != null)
                this.root.left = GetChild(tree.root.left, this.root.left);
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
        public Image Draw()
        {
            GC.Collect();
            int temp;
            return Draw(this.root, out temp);
        }
        public List<PointF> GetListPoint(float x1, float x2, float y1, float y2, float w, float h)
        {
            return new List<PointF>
                                  {
                                      new PointF(x1, y1),
                                      new PointF(x1 - w/6, y1 + h/3.5f),
                                      new PointF(x2 + w/6, y2 - h/3.5f),
                                      new PointF(x2, y2),
                                  };
        }
        public Image Draw(TreeDrawNode current, out int center)
        {
            var centerLeft = 0;
            var rCenter = 0;
            Image lNodeImg = null, rNodeImg = null;
            if (current.left != null)    
                lNodeImg = Draw(current.left, out centerLeft);
            if (current.right != null)   
                rNodeImg = Draw(current.right, out rCenter);
            var lSize = new Size();
            var rSize = new Size();
            var under = (lNodeImg != null) || (rNodeImg != null);
            if (lNodeImg != null)
                lSize = lNodeImg.Size;
            if (rNodeImg != null)
                rSize = rNodeImg.Size;

            var maxHeight = lSize.Height;
            if (maxHeight < rSize.Height)
                maxHeight = rSize.Height;

            if (lSize.Width <= 0)
                lSize.Width = (nodeSize.Width - freeSpace.Width) / 2;
            if (rSize.Width <= 0)
                rSize.Width = (nodeSize.Width - freeSpace.Width) / 2;

            var resSize = new Size
            {
                Width = lSize.Width + rSize.Width + freeSpace.Width,
                Height = nodeSize.Size.Height + (under ? maxHeight + freeSpace.Height : 0)
            };

            var result = new Bitmap(resSize.Width, resSize.Height);
            var g = Graphics.FromImage(result);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), resSize));
            g.DrawImage(nodeSize, lSize.Width - nodeSize.Width / 2 + freeSpace.Width / 2, 0);
            var str = current.key.ToString();
            Brush brush = Brushes.Black;
            if (current.color == NodeColor.Red)
                brush = Brushes.Red;
            g.DrawString(str, font, brush, lSize.Width - nodeSize.Width / 2 + 
                                    freeSpace.Width / 2 + (2 + (str.Length == 1 ? 10 : str.Length == 2 ? 5 : 0))
                                    * Coef, nodeSize.Height / 2f - 12 * Coef);

            center = lSize.Width + freeSpace.Width / 2;
            var pen = new Pen(Brushes.Black, 1.2f * Coef)
            {
                EndCap = LineCap.ArrowAnchor,
                StartCap = LineCap.Round
            };

            float x1 = center;
            float y1 = nodeSize.Height;
            float y2 = nodeSize.Height + freeSpace.Height;
            float x2 = centerLeft;
            var h = Math.Abs(y2 - y1);
            var w = Math.Abs(x2 - x1);
            if (lNodeImg != null)
            {
                g.DrawImage(lNodeImg, 0, nodeSize.Size.Height + freeSpace.Height);
                var points1 = GetListPoint(x1, x2, y1, y2, w, h);
                g.DrawCurve(pen, points1.ToArray(), 0.5f);
            }
            if (rNodeImg != null)
            {
                g.DrawImage(rNodeImg, lSize.Width + freeSpace.Width, nodeSize.Size.Height + freeSpace.Height);
                x2 = rCenter + lSize.Width + freeSpace.Width;
                w = Math.Abs(x2 - x1);
                var points = GetListPoint(x1, x2, y1, y2, w, h);
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            if (rNodeImg != null)
            {
                g.DrawImage(rNodeImg, lSize.Width + freeSpace.Width, nodeSize.Size.Height + freeSpace.Height);
                x2 = rCenter + lSize.Width + freeSpace.Width;
                w = Math.Abs(x2 - x1);
                var points = GetListPoint(x1, x2, y1, y2, w, h);
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            lastLocation = center;
            return result;
        }
       
    }
}
