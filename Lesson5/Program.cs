using Lesson5.Tree;
using System;

namespace Lesson5
{
    public class Program
    {
        static void Main(string[] args)
        {
            BTree bTree = new BTree();
            bTree.AddItem(10);

            bTree.AddItem(5);
            bTree.AddItem(15);

            bTree.AddItem(2);
            bTree.AddItem(7);
            bTree.AddItem(12);
            bTree.AddItem(17);

            bTree.AddItem(1);
            bTree.AddItem(3);
            bTree.AddItem(6);
            bTree.AddItem(8);
            bTree.AddItem(11);
            bTree.AddItem(13);
            bTree.AddItem(16);
            bTree.AddItem(18);

            BTreePrinter.Print(bTree.GetRoot(), 0, 32); 
            
            var b = BTreeSearch.BFS(bTree.GetRoot(), 18);
            var d = BTreeSearch.DFS(bTree.GetRoot(), 18);
        }
    }
}
