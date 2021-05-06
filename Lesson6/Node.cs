using System.Collections.Generic;

namespace Lesson6
{
    public class Node
    {
        public int Value { get; set; }
        public bool Visited { get; set; }
        public List<Edge> Edges { get; }

        public Node(int value)
        {
            Value = value;
            Edges = new List<Edge>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Node node))
            {
                return false;
            }

            return node.Value == Value;
        }
    }
}
