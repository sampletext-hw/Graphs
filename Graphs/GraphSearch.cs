using System.Linq;

namespace Graphs
{
    public abstract class GraphSearch
    {
        protected Graph Graph { get; set; }

        public GraphSearch(Graph graph)
        {
            Graph = graph;
        }

        public abstract string Build();
    }
}
