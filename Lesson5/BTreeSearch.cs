using Lesson5.Tree;
using System;
using System.Collections.Generic;

namespace Lesson5
{
    public static class BTreeSearch
    {
        public static SearchResult BFS(TreeNode root, int searchValue)
        {
            Console.WriteLine("BFS поиск:");
            if (root is null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            
            var step = 1;
            var buffer = new Queue<NodeInfo>();
            var treeArray = new List<NodeInfo>();
            buffer.Enqueue(new NodeInfo { Node = root});

            while (buffer.Count != 0)
            {
                var nodeInfo = buffer.Dequeue();
                treeArray.Add(nodeInfo);

                var depth = nodeInfo.Depth;

                PrintInfo(step, depth, searchValue, nodeInfo.Node.Data);
                if (nodeInfo.Node.Data == searchValue)
                {
                    Console.WriteLine($"Найдено: {nodeInfo.Node.Data}");
                    return new SearchResult { ResultValue = nodeInfo.Node, TreeInLine = treeArray }; 
                }

                depth = nodeInfo.Depth + 1;
                step++;

                if (nodeInfo.Node.LeftChild != null)
                {
                    var leftChild = new NodeInfo
                    {
                        Node = nodeInfo.Node.LeftChild,
                        Depth = depth
                    };
                    buffer.Enqueue(leftChild);
                }
                if (nodeInfo.Node.RightChild != null)
                {
                    var rightChild = new NodeInfo
                    {
                        Node = nodeInfo.Node.RightChild,
                        Depth = depth
                    };
                    buffer.Enqueue(rightChild);
                }
            }

            Console.WriteLine($"Значение не найдено.");
            return null;  
        }

        public static SearchResult DFS(TreeNode root, int searchValue)
        {
            Console.WriteLine("DFS поиск:");
            if (root is null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var step = 1;
            var treeArray = new List<NodeInfo>();
            var buffer = new Stack<NodeInfo>();
            buffer.Push(new NodeInfo { Node = root , Depth = 0});

            while(buffer.Count != 0)
            {
                var nodeInfo = buffer.Pop();
                treeArray.Add(nodeInfo);

                PrintInfo(step, 0, searchValue, nodeInfo.Node.Data);
                if (nodeInfo.Node.Data == searchValue)
                {
                    Console.WriteLine($"Найдено: {nodeInfo.Node.Data}");
                    return new SearchResult { ResultValue = nodeInfo.Node, TreeInLine = treeArray };
                }
                step++;

                if (nodeInfo.Node.RightChild != null)
                {
                    var rightChild = new NodeInfo
                    {
                        Node = nodeInfo.Node.RightChild                      
                    };
                    buffer.Push(rightChild);
                }
                if (nodeInfo.Node.LeftChild != null)
                {
                    var leftChild = new NodeInfo
                    {
                        Node = nodeInfo.Node.LeftChild
                    };
                    buffer.Push(leftChild);
                }               
            }

            Console.WriteLine($"Значение не найдено.");
            return null;
        }

        private static void PrintInfo(int step, int level, int searchValue, int nodeValue)
        {
            Console.WriteLine($"Step: {step:D2} Level: {level} Search: {searchValue} NodeData: {nodeValue}");
        }
    }
}
