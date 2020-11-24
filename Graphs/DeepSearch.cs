using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class DeepSearch : GraphSearch
    {
        public DeepSearch(Graph graph) : base(graph)
        {
        }

        public override string Build()
        {
            StringBuilder builder = new StringBuilder();
            Graph.Nodes = Graph.Nodes.OrderBy(n => n.Id).ToList();

            List<Node> visitedNodes = new List<Node>(); // посещённый узлы
            Stack<Node> stack = new Stack<Node>(); // стэк узлов к обработке
            stack.Push(Graph.Nodes[0]); // добавляем первый узел

            // пока очередь не пуста
            while (stack.Count > 0)
            {
                Node node = stack.Pop(); // достаём последний узел
                visitedNodes.Add(node); // считаем его обработанным
                // выводим сообщение
                builder.AppendLine($"Обрабатываем узел {node.Id}; " +
                                   $"Стэк {string.Join("-", stack)}");

                // ищем все такие узлы, который соединены с текущим
                foreach (var n in Graph.Connections.Select(t => t.GetPairedNode(node)).Where(n => n != null))
                {
                    // если узел ещё не посещён и ещё не в стэке
                    if (!visitedNodes.Contains(n) && !stack.Contains(n))
                    {
                        node.Children.Add(n); // добавляем дочерний узел
                        n.Parent = node; // устанавливаем родительский узел
                        stack.Push(n); // добавляем узел в стэк обработки
                        // выводим сообщение
                        builder.AppendLine($"Добавлен узел {n.Id}; " +
                                           $"Стэк {string.Join("-", stack)}");
                    }
                    else
                    {
                        // выводим сообщение
                        builder.AppendLine($"Узел {n.Id} уже обработан; " +
                                           $"Стэк {string.Join("-", stack)}");
                    }
                }
            }

            return builder.ToString();
        }
    }
}