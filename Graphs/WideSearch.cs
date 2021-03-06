﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class WideSearch : GraphSearch
    {
        public WideSearch(Graph graph) : base(graph)
        {
        }

        public override string Build()
        {
            StringBuilder builder = new StringBuilder();
            Graph.Nodes = Graph.Nodes.OrderBy(n => n.Id).ToList();

            List<Node> visitedNodes = new List<Node>(); // посещённый узлы
            Queue<Node> queue = new Queue<Node>(); // очередь узлов к обработке
            queue.Enqueue(Graph.Nodes[0]); // добавляем первый узел

            builder.AppendLine($"Добавлен узел {Graph.Nodes[0].Id}; " +
                               $"Очередь {string.Join("-", queue)}");

            // пока очередь не пуста
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue(); // достаём первый узел
                visitedNodes.Add(node); // считаем его обработанным
                // выводим сообщение
                builder.AppendLine($"\nОбрабатываем узел {node.Id}; " +
                                   $"Очередь {string.Join("-",queue)}"); 

                // ищем все такие узлы, который соединены с текущим
                foreach (var n in Graph.Connections.Select(t => t.GetPairedNode(node)).Where(n => n != null).OrderBy(n=>n.Id))
                {
                    // если узел ещё не посещён и ещё не в очереди
                    if (!visitedNodes.Contains(n) && !queue.Contains(n))
                    {
                        node.Children.Add(n); // добавляем дочерний узел
                        n.Parent = node; // устанавливаем родительский узел
                        queue.Enqueue(n); // добавляем узел в очередь обработки
                        // выводим сообщение
                        builder.AppendLine($"Добавлен узел {n.Id}; " +
                                           $"Очередь {string.Join("-", queue)}"); 
                    }
                    else
                    {
                        // выводим сообщение
                        if (visitedNodes.Contains(n))
                        {
                            builder.AppendLine($"Узел {n.Id} уже обработан;");
                        }
                        else if (queue.Contains(n))
                        {
                            builder.AppendLine($"Узел {n.Id} уже в очереди;");
                        }
                    }
                }
            }

            return builder.ToString();
        }
    }
}
