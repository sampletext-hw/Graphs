using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class KraskalSearch : GraphSearch
    {
        public KraskalSearch(Graph graph) : base(graph)
        {
        }

        public override string Build()
        {
            StringBuilder builder = new StringBuilder();

            Graph graph = new Graph(); // создаём временный граф
            graph.Nodes.AddRange(Graph.Nodes); // копируем в него все узлы

            // сортируем рёбра по весам
            var connections = Graph.Connections.OrderBy(c => c.Length).ToList();

            // обрабатываем рёбра
            for (var i = 0; i < connections.Count - 1; i++)
            {
                builder.AppendLine($"Обрабатываем ребро {connections[i]}");

                // добавляем ребро в граф
                graph.Connections.Add(connections[i]); 

                // если в графе появился цикл
                if (graph.HasLoop())
                {
                    builder.AppendLine($"Ребро {connections[i]} создало цикл!");

                    // удяляем это ребро
                    graph.Connections.Remove(connections[i]);
                }
                else
                {
                    builder.AppendLine($"Добавлено ребро {connections[i]}");
                }
            }

            return builder.ToString();
        }
    }
}