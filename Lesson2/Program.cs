using System;
using System.Collections.Generic;
using Xunit;

namespace Lesson2
{
    public class Program
    {
        [Theory]
        [MemberData(nameof(Test_Data_GetCount))]        
        public void Test_GetCount(int expectedCount, int[] array)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < array.Length; i++)
            {
                linkedList.AddNode(array[i]);
            }

            //Act
            int count = linkedList.GetCount();

            //Assert
            Assert.Equal(expectedCount, count);
            Node currentNode = linkedList.Head;
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public static IEnumerable<object[]> Test_Data_GetCount()
        {
            yield return new object[] { 5, new int[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { 0, new int[] { } };
        }

        [Theory]
        [MemberData(nameof(Test_Data_AddNode))]
        public void Test_AddNode(int valueToAdd, int expectedCount, int[] initArray, int[] expectedArray)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < initArray.Length; i++)
            {
                linkedList.AddNode(initArray[i]);
            }

            //Act            
            linkedList.AddNode(valueToAdd);

            //Assert
            Assert.Equal(valueToAdd, linkedList.Tail.Value);
            Assert.Equal(expectedCount, linkedList.GetCount());
            Node currentNode = linkedList.Head;
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.Equal(expectedArray[i], currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public static IEnumerable<object[]> Test_Data_AddNode()
        {
            yield return new object[] { 5, 5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 } };
        }

        [Theory]
        [MemberData(nameof(Test_Data_Test_AddNodeAfter))]
        public void Test_AddNodeAfter(int findValue,int newValue, int[] initArray, int[] expectedArray)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < initArray.Length; i++)
            {
                linkedList.AddNode(initArray[i]);
            }

            Node nodeBefore = linkedList.FindValue(findValue); // null if not found 

            //Act
            Action act = () => linkedList.AddNodeAfter(nodeBefore, newValue);

            //Assert
            if (!Array.Exists(initArray, x => x == findValue)) // if initArray not consist findValue => nodeBefore = null => ArgumentNullException
            {
                Assert.Throws<ArgumentNullException>(act);// Exception
            }
            else
            {
                act.Invoke();
            }
            Node currentNode = linkedList.Head;
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.Equal(expectedArray[i], currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public static IEnumerable<object[]> Test_Data_Test_AddNodeAfter()
        {
            yield return new object[] { 1, 7, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 7, 2, 3, 4, 5 } };
            yield return new object[] { 3, 7, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 7, 4, 5 } };
            yield return new object[] { 5, 7, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 7 } };
            yield return new object[] { 8, 7, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 } };
        }

        [Theory]
        [MemberData(nameof(Test_Data_Test_RemoveNode_index))]
        public void Test_RemoveNode_index(int indexToRemove, int[] initArray, int[] expectedArray)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < initArray.Length; i++)
            {
                linkedList.AddNode(initArray[i]);
            }

            //Act
            Action act = () => linkedList.RemoveNode(indexToRemove); 

            //Assert
            if(indexToRemove < 0 || indexToRemove > initArray.Length-1)
            {
                Assert.Throws<ArgumentOutOfRangeException>(act);// Exception
            }                
            else
            {
                act.Invoke();                
            }

            Node currentNode = linkedList.Head;
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.Equal(expectedArray[i], currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public static IEnumerable<object[]> Test_Data_Test_RemoveNode_index()
        {
            yield return new object[] { 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 } };
            yield return new object[] { 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 } };
            yield return new object[] { 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 } };
            yield return new object[] { 77, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 } };
        }

        [Theory]
        [MemberData(nameof(Test_Data_Test_RemoveNode_value))]
        public void Test_RemoveNode_value(int indexToRemove, int[] initArray, int[] expectedArray)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < initArray.Length; i++)
            {
                linkedList.AddNode(initArray[i]);
            }

            //Act
            Node node = linkedList.FindValue(indexToRemove); // not null
            Action act = () => linkedList.RemoveNode(node);

            //Assert
            if (indexToRemove < 0 || indexToRemove > initArray.Length)
            {
                Assert.Throws<ArgumentOutOfRangeException>(act);// Exception
            }
            else
            {
                act.Invoke();
            }

            Node currentNode = linkedList.Head;
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.Equal(expectedArray[i], currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public static IEnumerable<object[]> Test_Data_Test_RemoveNode_value()
        {
            yield return new object[] { 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 } };
            yield return new object[] { 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 } };
            yield return new object[] { 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 } };
            yield return new object[] { 77, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 } };
        }

        [Theory]
        [MemberData(nameof(Test_Data_FindValue))]
        public void Test_FindValue(object expectedValue, int searchValue, int[] array)
        {
            //Arrange
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < array.Length; i++)
            {
                linkedList.AddNode(array[i]);
            }

            //Act
            Node res = linkedList.FindValue(searchValue);

            //Assert;
            if (expectedValue == null)
            {
                Assert.Null(res);
            }
            else
            {
                Assert.Equal((int)expectedValue, res.Value);
            }
        }

        public static IEnumerable<object[]> Test_Data_FindValue()
        {
            yield return new object[] { 3, 3, new int[] { 0, 1, 2, 3, 4, 5 } };
            yield return new object[] { null, 77, new int[] { 0, 1, 2, 3, 4, 5 } };
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
