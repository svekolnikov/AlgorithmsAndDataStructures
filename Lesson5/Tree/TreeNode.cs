namespace Lesson5.Tree
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TreeNode node))
                return false;
            return node.Data == Data;
        }
    }
}
  