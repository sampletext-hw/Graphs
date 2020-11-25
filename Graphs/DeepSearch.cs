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
            Stack<Node> stack = new Stack<Node>(); // стек узлов к обработке
            stack.Push(Graph.Nodes[0]); // добавляем первый узел

            builder.AppendLine($"Добавлен узел {Graph.Nodes[0].Id}; " +
                               $"Стек {string.Join("-", stack)}");

            // пока очередь не пуста
            while (stack.Count > 0)
            {
                Node node = stack.Pop(); // достаём последний узел
                visitedNodes.Add(node); // считаем его обработанным
                // выводим сообщение
                builder.AppendLine($"\nОбрабатываем узел {node.Id}; " +
                                   $"Стек {string.Join("-", stack)}");

                // ищем все такие узлы, который соединены с текущим
                foreach (var n in Graph.Connections.Select(t => t.GetPairedNode(node)).Where(n => n != null).OrderBy(n => n.Id))
                {
                    // если узел ещё не посещён и ещё не в стэке
                    if (!visitedNodes.Contains(n) && !stack.Contains(n))
                    {
                        node.Children.Add(n); // добавляем дочерний узел
                        n.Parent = node; // устанавливаем родительский узел
                        stack.Push(n); // добавляем узел в стек обработки
                        // выводим сообщение
                        builder.AppendLine($"Добавлен узел {n.Id}; " +
                                           $"Стек {string.Join("-", stack)}");
                    }
                    else
                    {
                        // выводим сообщение
                        if (visitedNodes.Contains(n))
                        {
                            builder.AppendLine($"Узел {n.Id} уже обработан;");
                        }
                        else if (stack.Contains(n))
                        {
                            builder.AppendLine($"Узел {n.Id} уже в стеке;");
                        }
                    }
                }
            }

            return builder.ToString();
        }
    }
}