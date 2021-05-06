namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);

            //          (3)--7--(4)
            //           |       |       
            //           8       6       
            //           |       |       
            //  (1)--9--(2)--5--(5)--4--(6)
            //                   |        
            //                   3           
            //                   |        
            //                  (7)
            
            node1.Edges.Add(new Edge { Weight = 9, Node = node2 });
            node2.Edges.Add(new Edge { Weight = 9, Node = node1 });
            node2.Edges.Add(new Edge { Weight = 8, Node = node3 });
            node2.Edges.Add(new Edge { Weight = 5, Node = node5 });
            node3.Edges.Add(new Edge { Weight = 8, Node = node2 });
            node3.Edges.Add(new Edge { Weight = 7, Node = node4 });
            node4.Edges.Add(new Edge { Weight = 7, Node = node3 });
            node4.Edges.Add(new Edge { Weight = 6, Node = node5 });
            node5.Edges.Add(new Edge { Weight = 5, Node = node2 });
            node5.Edges.Add(new Edge { Weight = 6, Node = node4 });
            node5.Edges.Add(new Edge { Weight = 4, Node = node6 });
            node5.Edges.Add(new Edge { Weight = 3, Node = node7 });
            node6.Edges.Add(new Edge { Weight = 4, Node = node5 });
            node7.Edges.Add(new Edge { Weight = 3, Node = node5 });

            var resultBFS = GrafSearch.BFS(node1, 7);
            var resultDFS = GrafSearch.DFS(node1, 7);
        }
    }
}
