using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graphs
{
    [Serializable]
    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<Connection> Connections { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
            Connections = new List<Connection>();
        }

        public void AddNode(Node n)
        {
            Nodes.Add(n);
        }

        public void AddConnection(Connection c)
        {
            Connections.Add(c);
        }

        public void Draw(Graphics graphics)
        {
            Connections.ForEach(c => c.Draw(graphics));
            Nodes.ForEach(t => t.Draw(graphics));
        }

        public bool HasLoop()
        {
            HashSet<Node> visitedNodes = new HashSet<Node>();
            visitedNodes.Add(Connections[0].Node1);
            visitedNodes.Add(Connections[0].Node2);
            for (var i = 1; i < Connections.Count; i++)
            {
                if (!visitedNodes.Add(Connections[i].Node1) && !visitedNodes.Add(Connections[i].Node2))
                {
                    return true;
                }
            }

            return false;
        }

        public void ReduceDuplicateConnections()
        {
            outer:
            for (var i = 0; i < Connections.Count; i++)
            {
                for (var j = 0; j < Connections.Count; j++)
                {
                    if (i != j)
                    {
                        if (Connections[i].Node1 == Connections[j].Node1 &&
                            Connections[i].Node2 == Connections[j].Node2)
                        {
                            // Full duplicate
                            Connections.RemoveAt(j);
                            goto outer;
                        }
                        else if (Connections[i].Node1 == Connections[j].Node2 &&
                                 Connections[i].Node2 == Connections[j].Node1)
                        {
                            // Reverse duplicate
                            Connections.RemoveAt(j);
                            goto outer;
                        }
                    }
                }
            }
        }
    }
}