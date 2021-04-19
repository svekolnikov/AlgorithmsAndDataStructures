using System;
using System.Collections.Generic;
using Xunit;

namespace Lesson2
{
    public class Program
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void Test_GetCount(int expected, int addToList)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < addToList; i++)
            {
                linkedList.AddNode(1);
            }

            //Act
            int count = linkedList.GetCount();

            //Assert
            Assert.Equal(expected, count);
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
            linkedList.AddNode(0);
            linkedList.AddNode(1);
            linkedList.AddNode(2);
            linkedList.AddNode(3);

            Node nodeBefore1 = linkedList.FindValue(2);
            Node nodeBefore2 = linkedList.FindValue(100);

            //Act
            linkedList.AddNodeAfter(nodeBefore1, 4);
            int res = nodeBefore1.NextNode.Value;

            Action act = () => linkedList.AddNodeAfter(nodeBefore2, 5);            

            //Assert
            Assert.Equal(4, res);
            Assert.Throws<ArgumentNullException>(act);
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
            Node res1 = linkedList.FindValue(2); // not null
            linkedList.RemoveNode(1); // value = 2
            Node res2 = linkedList.FindValue(2); // null

            Action act = () => linkedList.RemoveNode(100); // Exception

            //Assert
            Assert.NotNull(res1);
            Assert.Null(res2);
            Assert.Equal(2, linkedList.GetCount());
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void Test_RemoveNode_value()
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(1);
            linkedList.AddNode(2);
            linkedList.AddNode(3);

            //Act
            Node res1 = linkedList.FindValue(2); // not null
            linkedList.RemoveNode(res1); // value = 2
            Node res2 = linkedList.FindValue(2); // null

            Action act = () => linkedList.RemoveNode(100); // Exception

            //Assert
            Assert.NotNull(res1);
            Assert.Null(res2);
            Assert.Equal(2, linkedList.GetCount());
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void Test_FindValue(int expected, int searchValue)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(searchValue);

            //Act
            var res = linkedList.FindValue(searchValue);

            //Assert
            Assert.NotNull(res);
            Assert.Equal(expected, res.Value);
        }

        [Theory]
        [MemberData(nameof(Test_Data_BinarySearchInArray))]
        public static void Test_BinarySearchInArray(int expectedIndex, int searchValue, int[] array)
        {
            //Act
            int index = BinarySearch.BinarySearchInArray(array, searchValue);
            //Assert
            Assert.Equal(expectedIndex, index);
        }

        public static IEnumerable<object[]> Test_Data_BinarySearchInArray()
        {
            // expected index
            // search value
            // array
            yield return new object[] { 4, 5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 } };
            yield return new object[] { -1, 77, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 } };
        }
    }
}
