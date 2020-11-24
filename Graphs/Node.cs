using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graphs
{
    [Serializable]
    public class Node
    {
        public const int Size = 30;

        private static Pen DefaultPen = new Pen(Color.Black, 1f);
        private static Pen HighlightPen = new Pen(Color.Red, 2f);

        private static int _idAuto = 1;

        public int Id { get; set; }

        public Node Parent { get; set; }

        public List<Node> Children { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsHighlighted { get; set; }

        public void Draw(Graphics graphics)
        {
            var font = new Font(FontFamily.GenericMonospace, 14);
            var sizeF = graphics.MeasureString(Id.ToString(), font);
            graphics.DrawString(Id.ToString(), font, Brushes.Black, X - sizeF.Width / 2, Y - sizeF.Height / 2);
            graphics.DrawEllipse(IsHighlighted ? HighlightPen : DefaultPen, X - Size / 2, Y - Size / 2, Size, Size);
        }

        public bool ContainsPoint(int x, int y)
        {
            return ((x - X) * (x - X) + (y - Y) * (y - Y)) <= Size * Size / 4;
        }

        public Node()
        {
            Parent = null;
            Children = new List<Node>();
            Id = _idAuto++;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}