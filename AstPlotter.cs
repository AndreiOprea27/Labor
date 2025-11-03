using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Labor
{
    public static class AstPlotter
    {
        public static void PlotAst(AstNode root, string filePath)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            int width = 800;
            int height = 600;

            using (var bitmap = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                // Start drawing from the top center
                DrawNode(graphics, root, width / 2, 20, width / 4);

                bitmap.Save(filePath, ImageFormat.Png);
            }
        }

        private static void DrawNode(Graphics g, AstNode node, int x, int y, int xOffset)
        {
            if (node == null)
                return;

            // Node size and style
            int nodeRadius = 20;
            var nodeBrush = Brushes.LightBlue;
            var textBrush = Brushes.Black;
            var font = new Font("Arial", 10);
            var pen = Pens.Black;

            // Draw the node circle
            g.FillEllipse(nodeBrush, x - nodeRadius, y - nodeRadius, 2 * nodeRadius, 2 * nodeRadius);
            g.DrawEllipse(pen, x - nodeRadius, y - nodeRadius, 2 * nodeRadius, 2 * nodeRadius);

            // Draw the node text
            var textSize = g.MeasureString(node.Value, font);
            g.DrawString(node.Value, font, textBrush, x - textSize.Width / 2, y - textSize.Height / 2);

            // Draw left child
            if (node.Left != null)
            {
                int childX = x - xOffset;
                int childY = y + 60;
                g.DrawLine(pen, x, y + nodeRadius, childX, childY - nodeRadius);
                DrawNode(g, node.Left, childX, childY, xOffset / 2);
            }

            // Draw right child
            if (node.Right != null)
            {
                int childX = x + xOffset;
                int childY = y + 60;
                g.DrawLine(pen, x, y + nodeRadius, childX, childY - nodeRadius);
                DrawNode(g, node.Right, childX, childY, xOffset / 2);
            }
        }
    }
}
