using System;
using System.Drawing;

namespace Graphs
{
    [Serializable]
    public class Connection
    {
        public Node Node1 { get; set; }
        public Node Node2 { get; set; }

        public float Length { get; set; }

        public Connection(Node node1, Node node2)
        {
            Node1 = node1;
            Node2 = node2;
            Length = 0f;
        }

        public static Connection FromNodes(Node n1, Node n2)
        {
            return new Connection(n1, n2);
        }

        public void Draw(Graphics graphics)
        {
            var font = new Font(FontFamily.GenericMonospace, 14);
            var sizeF = graphics.MeasureString(Length.ToString(), font);
            graphics.DrawString(Length.ToString(), font, Brushes.Black, (Node1.X + Node2.X) / 2f - sizeF.Width / 2, (Node1.Y + Node2.Y) / 2f - sizeF.Height / 2);
            graphics.DrawLine(Pens.Black, Node1.X, Node1.Y, Node2.X, Node2.Y);
        }

        public Node GetPairedNode(Node n)
        {
            if (Node1.Id == n.Id)
            {
                return Node2;
            }
            else if(Node2.Id == n.Id)
            {
                return Node1;
            }
            else
            {
                return null;
            }
        }

        public Connection Clone()
        {
            return new Connection(Node1, Node2);
        }

        public override string ToString()
        {
            return $"{Node1} - {Node2} [{Length}]";
        }
    }
}