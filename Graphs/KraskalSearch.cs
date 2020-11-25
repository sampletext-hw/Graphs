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

            float sum = 0f;

            // сортируем рёбра по весам
            var connections = Graph.Connections.OrderBy(c => c.ToString()).GroupBy(c=>c.Length).SelectMany(g=>g).ToList();

            builder.AppendLine("Рёбра, отсортированные по весам:");
            builder.AppendLine(string.Join(", ", connections.Select(c=>c.Node1 + " - " + c.Node2)));
            builder.AppendLine(string.Join(", ", connections.Select(c=>$"  [{c.Length}]  ")));

            // обрабатываем рёбра
            for (var i = 0; i < connections.Count - 1; i++)
            {
                builder.AppendLine($"\nОбрабатываем ребро {{{connections[i].Node1} - {connections[i].Node2}}}");

                // добавляем ребро в граф
                graph.Connections.Add(connections[i]); 

                // если в графе появился цикл
                if (graph.HasLoop())
                {
                    builder.AppendLine($"Ребро {{{connections[i].Node1} - {connections[i].Node2}}} создало цикл!");

                    // удяляем это ребро
                    graph.Connections.Remove(connections[i]);
                }
                else
                {
                    sum += connections[i].Length;
                    builder.AppendLine($"Добавлено ребро {{{connections[i].Node1} - {connections[i].Node2}}}");
                }
            }

            builder.AppendLine($"\nОбработано {connections.Count - 1} рёбер\n");
            builder.AppendLine($"\nСуммарный вес дерева - {sum}");

            return builder.ToString();
        }
    }
}