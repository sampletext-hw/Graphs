using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Graphs
{
    public partial class Form1 : Form
    {
        private Graph Graph { get; set; }

        public List<Node> SelectedNodes { get; set; }

        private Bitmap _frameBitmap;
        private Graphics _frameGraphics;

        private bool _dragging;

        private int _dragStartX;
        private int _dragStartY;

        private int _dragEndX;
        private int _dragEndY;

        private Connection _creatingConnection;

        public Form1()
        {
            InitializeComponent();

            Graph = new Graph();
            SelectedNodes = new List<Node>();

            _frameBitmap = new Bitmap(pictureBoxFrame.Width, pictureBoxFrame.Height);
            _frameGraphics = Graphics.FromImage(_frameBitmap);
            Focus();
        }

        private void UpdateConnectionsListbox()
        {
            listBoxConnections.Items.Clear();
            Graph.Connections.ForEach(c=>listBoxConnections.Items.Add(c));
        }

        private void Draw()
        {
            _frameGraphics.Clear(Color.Transparent);

            SelectedNodes.ForEach(t => t.Draw(_frameGraphics));

            Graph.Draw(_frameGraphics);

            pictureBoxFrame.Refresh();
        }

        private void pictureBoxFrame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(_frameBitmap, 0, 0);
        }

        private void pictureBoxFrame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Graph.AddNode(new Node {X = e.X, Y = e.Y});
            }
            else if (e.Button == MouseButtons.Left)
            {
                var node = Graph.Nodes.FirstOrDefault(t => t.ContainsPoint(e.X, e.Y));
                var selectedNode = SelectedNodes.FirstOrDefault(t => t.ContainsPoint(e.X, e.Y));

                if (node != null)
                {
                    node.IsHighlighted = true;
                    Graph.Nodes.Remove(node);
                    SelectedNodes.Add(node);
                }
                else if (selectedNode != null)
                {
                    selectedNode.IsHighlighted = false;
                    Graph.Nodes.Add(selectedNode);
                    SelectedNodes.Remove(selectedNode);
                }
                else
                {
                    _dragging = true;
                    _dragStartX = e.X;
                    _dragStartY = e.Y;
                    _dragEndX = e.X;
                    _dragEndY = e.Y;
                }
            }

            Draw();
            UpdateConnectionsListbox();
        }

        private void pictureBoxFrame_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_dragging)
                {
                    _dragging = false;

                    _dragEndX = e.X;
                    _dragEndY = e.Y;

                    SelectedNodes.ForEach(n =>
                    {
                        n.X += _dragEndX - _dragStartX;
                        n.Y += _dragEndY - _dragStartY;
                    });
                }
            }

            Draw();
            UpdateConnectionsListbox();
        }

        private void pictureBoxFrame_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                _dragEndX = e.X;
                _dragEndY = e.Y;

                SelectedNodes.ForEach(n =>
                {
                    n.X += _dragEndX - _dragStartX;
                    n.Y += _dragEndY - _dragStartY;
                });

                _dragStartX = _dragEndX;
                _dragStartY = _dragEndY;
            }

            Draw();
            UpdateConnectionsListbox();
        }

        private void HandleInput(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F)
            {
                if (SelectedNodes.Count == 2)
                {
                    Graph.Connections.Add(Connection.FromNodes(SelectedNodes[0], SelectedNodes[1]));
                }
                else
                {
                    for (var i = 0; i < SelectedNodes.Count; i++)
                    {
                        for (var j = 0; j < SelectedNodes.Count; j++)
                        {
                            if (i != j)
                            {
                                Graph.Connections.Add(Connection.FromNodes(SelectedNodes[i], SelectedNodes[j]));
                            }
                        }
                    }
                }

                Graph.ReduceDuplicateConnections();

                SelectedNodes.ForEach(n => n.IsHighlighted = false);
                SelectedNodes.ForEach(n => Graph.Nodes.Add(n));
                SelectedNodes.Clear();

                Draw();
                UpdateConnectionsListbox();
            }
            else if (e.KeyCode == Keys.W)
            {
                var build = new WideSearch(Graph).Build();
                MessageBox.Show(build);
            }
            else if (e.KeyCode == Keys.D)
            {
                var build = new DeepSearch(Graph).Build();
                MessageBox.Show(build);
            }
            else if (e.KeyCode == Keys.K)
            {
                var build = new KraskalSearch(Graph).Build();
                MessageBox.Show(build);
            }
            else if (e.KeyCode == Keys.P)
            {
                var build = new PrimaSearch(Graph).Build();
                MessageBox.Show(build);
            }
            else if (e.KeyCode == Keys.S)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("graph.bin", FileMode.Create);
                bf.Serialize(fs, Graph);
                fs.Close();
            }
            else if (e.KeyCode == Keys.L)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("graph.bin", FileMode.Open);
                Graph = (Graph)bf.Deserialize(fs);
                fs.Close();
                Graph.ReduceDuplicateConnections();
                Draw();
                UpdateConnectionsListbox();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            HandleInput(e);
        }

        private void listBoxConnections_KeyDown(object sender, KeyEventArgs e)
        {
            HandleInput(e);
        }

        private void numericUpDownConnectionWeight_ValueChanged(object sender, System.EventArgs e)
        {
            Graph.Connections[listBoxConnections.SelectedIndex].Length = (float)numericUpDownConnectionWeight.Value;
            Draw();
        }

        private void listBoxConnections_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listBoxConnections.SelectedIndex != -1)
            {
                numericUpDownConnectionWeight.Value = (decimal)Graph.Connections[listBoxConnections.SelectedIndex].Length;
                numericUpDownConnectionWeight.Visible = true;
            }
            else
            {
                numericUpDownConnectionWeight.Visible = false;
            }
        }
    }
}