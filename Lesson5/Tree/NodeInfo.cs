namespace Lesson5.Tree
{
    public class NodeInfo
    {
        public TreeNode Node { get; set; }
        public string Text { get; set; }
        public int Size { get { return Text.Length; } }
        public int StartPos { get; set; }
        public int EndPos 
        {
            get
            {
                return StartPos + Size;
            }
            set
            {
                StartPos = value - Size;
            } 
        }
        public int Depth { get; set; }
    }
}
