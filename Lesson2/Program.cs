using Xunit;

namespace Lesson2
{
    public class Program
    {
        [Fact]
        public void Test_GetCount()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public void Test_AddNode()
        {
            //Arrange
            LinkedList linkedList = new LinkedList();

            //Act
            linkedList.AddNode(5);

            //Assert
            Assert.Equal(5, linkedList.Tail.Value);
            Assert.Equal(1, linkedList.GetCount());
        }

        [Fact]
        public void Test_AddNodeAfter()
        {
            //Arrange
            LinkedList linkedList = new LinkedList();

            //Act

            //Assert

        }

        [Fact]
        public void Test_RemoveNode_index()
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(1);
            linkedList.AddNode(2);
            linkedList.AddNode(3);

            //Act
            linkedList.RemoveNode(1); // value = 2

            //Assert

        }

        [Fact]
        public void Test_RemoveNode_value()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public void Test_FindValue()
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(-1);
            linkedList.AddNode(0);
            linkedList.AddNode(1);
            linkedList.AddNode(5);

            //Act
            var res1 = linkedList.FindValue(-1);
            var res2 = linkedList.FindValue(0);
            var res3 = linkedList.FindValue(1);
            var res4 = linkedList.FindValue(5);

            //Assert
            Assert.NotNull(res1);
            Assert.Equal(-1, res1.Value);

            Assert.NotNull(res2);
            Assert.Equal(0, res2.Value);

            Assert.NotNull(res3);
            Assert.Equal(1, res3.Value);

            Assert.NotNull(res4);
            Assert.Equal(5, res4.Value);
        }
    }
}
