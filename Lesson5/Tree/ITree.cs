namespace Lesson5.Tree
{
    public interface ITree
    {
        public TreeNode GetRoot();
        public void AddItem(int value);             // добавить узел
        public void RemoveItem(int value);          // удалить узел по значению
        public TreeNode GetNodeByValue(int value);  // получить узел дерева по значению
        public void PrintTree();                    // вывести дерево в консоль
    }
}
