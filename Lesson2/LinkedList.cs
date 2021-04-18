using System;

namespace Lesson2
{
    public class LinkedList : ILinkedList
    {
        private int _count;

        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public int GetCount()
        {
            return _count;
        }

        public void AddNode(int value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode; 
            }
            else
            {
                Tail.NextNode = newNode;
                newNode.PrevNode = Tail;
            }

            Tail = newNode;
            _count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.NextNode == Tail)
            {
                AddNode(value);
                return;
            }                

            Node newNode = new Node(value) { PrevNode = node, NextNode = node.NextNode }; // 1 2 3

            node.NextNode = newNode; // 4

            node.NextNode.PrevNode = newNode; // 5
            
            _count++;
        }

        public Node FindValue(int searchValue)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }
            return null;
        }           

        public void RemoveNode(int index)
        {
            Node currentNode = Head;
            int i = 0;
            while (currentNode != null)
            {
                if(i == index)//Delete
                {                    
                    if (currentNode.NextNode != null)// not tail
                    {
                        currentNode.NextNode.PrevNode = currentNode.PrevNode;
                    }
                    else// tail
                    {
                        Tail = currentNode.PrevNode;
                    }

                    if(currentNode.PrevNode != null)// not head
                    {
                        currentNode.PrevNode.NextNode = currentNode.NextNode;
                    }
                    else// head
                    {
                        Head = currentNode.NextNode;
                    }

                    _count--;
                    return;
                }

                i++;
                currentNode = currentNode.NextNode;
            }

            //Not found
            throw new ArgumentOutOfRangeException();
        }

        public void RemoveNode(Node node)
        {
            Node currentNode = Head;
            while(currentNode != null)
            {

                currentNode = currentNode.NextNode;
            }
        }
    }
}
