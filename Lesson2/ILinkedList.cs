namespace Lesson2
{
    public interface ILinkedList
    {
        public int GetCount();
        public void AddNode(int value);
        public void AddNodeAfter(Node node, int value);
        public void RemoveNode(int index);
        public void RemoveNode(Node node);
        public Node FindValue(int searchValue);
    }
}
