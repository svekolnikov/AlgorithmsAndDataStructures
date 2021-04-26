using System;

namespace Lesson4.BTree
{
    public class BTree : ITree
    {
        public TreeNode Tree(int n)
        {
            TreeNode newNode = null;
            if (n == 0)
            {
                return null;
            }
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new TreeNode();
                newNode.Data = 1;
                newNode.LeftChild = Tree(nl);
                newNode.RightChild = Tree(nr);
            }

            return newNode;
        }

        public void AddItem(int value)
        {
            throw new NotImplementedException();
        }

        public TreeNode GetNodeByValue(int value)
        {
            throw new NotImplementedException();
        }

        public TreeNode GetRoot()
        {
            throw new NotImplementedException();
        }

        public TreeNode Insert(TreeNode head, int value)
        {
            TreeNode tmp = null;
            if (head == null)
            {
                head = GetFreeNode(value, null);
                return head;
            }

            tmp = head;
            while(tmp != null)
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
                    if (tmp != null)
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

        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int value)
        {
            throw new NotImplementedException();
        }



        private TreeNode GetFreeNode(int value, TreeNode parent)
        {
            return new TreeNode
            {
                Data = value
            };
        }
    }
}
