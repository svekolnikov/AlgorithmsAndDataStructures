using Lesson5;
using Lesson5.Tree;
using System;
using System.Collections.Generic;
using Xunit;

namespace Lesson5_Tests
{
    public class Program
    {
        [Theory]
        [MemberData(nameof(Test_Data_BFS))]
        public void Test_BFS(int[] arrInit, int valueToFind, int[] arrExpected, bool IsException)
        {
            //Arrange
            BTree tree = new BTree();
            for (int i = 0; i < arrInit.Length; i++)
            {
                tree.AddItem(arrInit[i]);
            }

            //Act

            //Assert
            if (IsException)
            {
                Action act = () => BTreeSearch.BFS(null, valueToFind);
                Assert.Throws<ArgumentNullException>(act);
            }
            else
            {
                var result = BTreeSearch.BFS(tree.GetRoot(), valueToFind);
                Assert.Equal(valueToFind, result.ResultValue.Data);
                for (int i = 0; i < arrExpected.Length; i++)
                {
                    Assert.Equal(arrExpected[i], result.TreeInLine[i].Node.Data);
                }
            }
        }

        public static IEnumerable<object[]> Test_Data_BFS()
        {
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 5, new int[] { 5 }, false };
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 8, new int[] { 5, 2, 7, 1, 3, 6, 8 }, false };
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 1, new int[] { 5, 2, 7, 1 }, false };
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 77, null, true };
        }

        [Theory]
        [MemberData(nameof(Test_Data_DFS))]
        public void Test_DFS(int[] arrInit, int valueToFind, int[] arrExpected, bool IsException)
        {
            //Arrange
            BTree tree = new BTree();
            for (int i = 0; i < arrInit.Length; i++)
            {
                tree.AddItem(arrInit[i]);
            }

            //Act

            //Assert
            if (IsException)
            {
                Action act = () => BTreeSearch.DFS(null, valueToFind);
                Assert.Throws<ArgumentNullException>(act);
            }
            else
            {
                var result = BTreeSearch.DFS(tree.GetRoot(), valueToFind);
                Assert.Equal(valueToFind, result.ResultValue.Data);
                for (int i = 0; i < arrExpected.Length; i++)
                {
                    Assert.Equal(arrExpected[i], result.TreeInLine[i].Node.Data);
                }
            }
        }

        public static IEnumerable<object[]> Test_Data_DFS()
        {
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 5, new int[] { 5 }, false };
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 8, new int[] { 5, 2, 1, 3, 7, 6, 8 }, false };
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 1, new int[] { 5, 2, 1 }, false };
            yield return new object[] { new int[] { 5, 2, 7, 1, 3, 6, 8 }, 77, null, true };
        }
    }
}
