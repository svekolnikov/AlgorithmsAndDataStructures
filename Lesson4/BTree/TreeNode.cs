﻿namespace Lesson4.BTree
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            if (node == null)
                return false;
            return node.Data == Data;
        }
    }
}
  