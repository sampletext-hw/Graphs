using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class PrimaSearch : GraphSearch
    {
        public PrimaSearch(Graph graph) : base(graph)
        {
        }

        public override string Build()
        {
            StringBuilder builder = new StringBuilder();

            Random random = new Random(DateTime.Now.Millisecond);

            // текущее дерево графа
            List<Node> tree = new List<Node>();

            // выбираем случайный узел
            Node node = Graph.Nodes[random.Next(Graph.Nodes.Count)];
            tree.Add(node); // добавляем его в дерево

            builder.AppendLine($"Добавлен узел {node}");

            // пока дерево меньше чем граф
            while (tree.Count < Graph.Nodes.Count)
            {
                // выбираем такие рёбра, которые соединены с деревом, но не ещё не подключены к нему
                var connections =
                    Graph.Connections
                        .Where(c =>
                            tree.Contains(c.Node1) && !tree.Contains(c.Node2) ||
                            !tree.Contains(c.Node1) && tree.Contains(c.Node2)
                        ).ToList();

                builder.AppendLine($"{connections.Count} рёбер сейчас соединены с деревом");

                // сортируем рёбра по весу и выбираем первое
                var connection = connections.OrderBy(c => c.Length).First();
                builder.AppendLine($"Ребро с минимальным весом {{{connection}}}");

                // если дерево содержит 1 узел ребра, добавляем второе и наоборот
                if (tree.Contains(connection.Node1))
                {
                    tree.Add(connection.Node2);
                    builder.AppendLine($"Добавлен узел {connection.Node2}");
                }
                else
                {
                    tree.Add(connection.Node1);
                    builder.AppendLine($"Добавлен узел {connection.Node1}");
                }
            }

            return builder.ToString();
        }
    }
}