using System;
using System.Collections.Generic;

namespace Lesson6
{
    public static class GrafSearch
    {
        public static SearchResult BFS(Node startNode, int searchValue)
        {
            Console.WriteLine("Поиск BFS.");
            Console.WriteLine(new string('-', 80));
            if (startNode == null) throw new ArgumentNullException(nameof(startNode));

            var step = 1;
            var buffer = new Queue<Node>();
            startNode.Visited = true;
            buffer.Enqueue(startNode);
            var grafArray = new List<Node>();
            while (buffer.Count != 0)
            {
                var node = buffer.Dequeue();
                node.Visited = true;
                grafArray.Add(node);
                PrintInfo(step, searchValue, node.Value, node.Edges);

                if (node.Value == searchValue)
                {
                    Console.WriteLine($"Найдено: {node.Value}\n");
                    grafArray.ForEach(x => x.Visited = false);
                    return new SearchResult{CheckedNodes = grafArray, FoundNode = node};
                }

                step++;

                foreach (var edge in node.Edges)
                {
                    if (!edge.Node.Visited)
                    {
                        edge.Node.Visited = true;
                        buffer.Enqueue(edge.Node);
                    }
                }
            }                

            Console.WriteLine("Значение не найдено.\n");
            grafArray.ForEach(x => x.Visited = false);
            return new SearchResult();
        }

        public static SearchResult DFS(Node startNode, int searchValue)
        {
            Console.WriteLine("Поиск DFS.");
            Console.WriteLine(new string('-',80));
            if (startNode == null) throw new ArgumentNullException(nameof(startNode));

            var step = 1;
            var buffer = new Stack<Node>();
            buffer.Push(startNode);
            var grafArray = new List<Node>();
            while (buffer.Count != 0)
            {
                var node = buffer.Pop();
                node.Visited = true;
                grafArray.Add(node);
                PrintInfo(step, searchValue, node.Value, node.Edges);

                if (node.Value == searchValue)
                {
                    Console.WriteLine($"Найдено: {node.Value}\n");
                    grafArray.ForEach(x => x.Visited = false);
                    return new SearchResult { CheckedNodes = grafArray, FoundNode = node };
                }

                step++;

                foreach (var edge in node.Edges)
                {
                    if (!edge.Node.Visited)
                    {
                        edge.Node.Visited = true;
                        buffer.Push(edge.Node);
                    }
                }
            }

            Console.WriteLine("Значение не найдено.\n");
            grafArray.ForEach(x => x.Visited = false);
            return new SearchResult();
        }

        private static void PrintInfo(int step, int searchValue, int nodeValue, List<Edge> edges)
        {
            var str = $"Step: {step:D2} Search: {searchValue} Node value: {nodeValue}";
            Console.WriteLine(str);
            foreach (var edge in edges)
            {
                
                Console.WriteLine($"{new string(' ',str.Length)}--{edge.Weight}--({edge.Node.Value}) Visited: {edge.Node.Visited}");
            }
        }
    }
}
