using System;

namespace Lesson5.Tree
{
    public class BTree : ITree
    {
        private TreeNode _root;
        private int _count;

        public TreeNode GetRoot() => _root;

        public int GetCount() => _count;

        public void AddItem(int value)
        {
            if (_root == null)
            {
                _root = GetFreeNode(value, null);
            }
            else
            {
                Insert(_root, value);
            }
        }

        public TreeNode Insert(TreeNode head, int value)
        {
            if (head == null)
            {
                head = GetFreeNode(value, null);
                return head;
            }

            TreeNode tmp = head;
            while (tmp != null)
            {
                if (value > tmp.Data)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                    else
                    {
                        tmp.RightChild = GetFreeNode(value, tmp);
                        return head;
                    }
                }
                else if(value < tmp.Data)
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;
                    }
                    else
                    {
                        tmp.LeftChild = GetFreeNode(value, tmp);
                        return head;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");
                }
            }

            return head;
        }

        public TreeNode GetNodeByValue(int value)
        {
            if (_root == null)
            {
                return null;
            }

            TreeNode head = _root;
            while (head != null)
            {
                if (value > head.Data)
                {
                    if (head.RightChild != null)
                    {
                        if (head.RightChild.Data == value)
                        {
                            return head.RightChild;
                        }
                        head = head.RightChild;
                        continue;
                    }
                    else // not found
                    {
                        return null;
                    }
                }
                else if (value < head.Data)
                {
                    if (head.LeftChild != null)
                    {
                        if (head.LeftChild.Data == value)
                        {
                            return head.LeftChild;
                        }
                        head = head.LeftChild;
                        continue;
                    }
                    else // not found
                    {
                        return null;
                    }
                }
                else if(value == head.Data)
                {
                    return head;
                }
                else
                {
                    throw new Exception("Wrong tree state");
                }
            }

            return null;
        }              
              
        public void RemoveItem(int value)
        {
            //Find node to remove
            TreeNode currentNode = GetNodeByValue(value);            
            if (currentNode != null)
            {
                //Case: LeftChild and RightChild are null
                if (currentNode.LeftChild == null && currentNode.RightChild == null)
                {
                    // Current is Leaf
                    var parent = currentNode.Parent;

                    if (parent.LeftChild != null)
                    {
                        if (parent.LeftChild.Equals(currentNode))
                            parent.LeftChild = null;
                    }
                    else if (parent.RightChild != null)
                    {
                        if (parent.RightChild.Equals(currentNode))
                            parent.RightChild = null;
                    }
                }
                //Case: One child is null
                else if(currentNode.LeftChild == null || currentNode.RightChild == null)
                {
                    //get this not null child
                    var child = currentNode.LeftChild ?? currentNode.RightChild;
                    var parent = currentNode.Parent;
                    if (parent.LeftChild.Equals(currentNode))
                        parent.LeftChild = child;
                    else
                        parent.RightChild = child;
                }
                //Case: LeftChild and RightChild are not null
                else if (currentNode.LeftChild != null && currentNode.RightChild != null)
                {
                    //Find minimal node in right branch
                    TreeNode minNode = GetMin(currentNode.RightChild);
                    //Case: minNode is leaf
                    if (minNode.LeftChild == null && minNode.RightChild == null)
                    {
                        //Remove this leaf
                        var parent = minNode.Parent;
                        if (parent.LeftChild.Equals(minNode))
                            parent.LeftChild = null;
                        else
                            parent.RightChild = null;

                        //Replace data from removing node with date from minNode
                        currentNode.Data = minNode.Data;
                    }
                    //Case: minNode with one right child
                    else if (minNode.LeftChild == null && minNode.RightChild != null)
                    {
                        //Replace data from removing node with date from minNode
                        currentNode.Data = minNode.Data;

                        //Replace minNode with right child
                        minNode.Parent.RightChild = minNode.RightChild;
                    }
                }

                _count--;
            }
        }

        public TreeNode GetMin(TreeNode head)
        {
            if (head is null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            TreeNode node = head;
            while (true)
            {
                if (node.LeftChild == null)
                    break;
                node = node.LeftChild;
            }
            return node;
        }

        public void PrintTree()
        {
            BTreePrinter.Print(_root, 0, 32);
        }

        private TreeNode GetFreeNode(int value, TreeNode parent)
        {
            _count++;
            return new TreeNode
            {
                Parent = parent,                
                Data = value
            };
        }
    }
}
