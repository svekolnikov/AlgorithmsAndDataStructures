using System;
using System.Collections.Generic;
using Xunit;

namespace Lesson4_BTree
{
    public class Program
    {
        [Fact]
        public void Test_GetRoot()
        {
            //Arrange
            BTree bTree = new BTree();
            bTree.AddItem(10);
            bTree.AddItem(5);
            bTree.AddItem(15);

            //Act
            TreeNode root = bTree.GetRoot();

            //Assert
            Assert.Equal(10, root.Data);
            Assert.Null(root.Parent);
            Assert.Equal(5, root.LeftChild.Data);
            Assert.Equal(15, root.RightChild.Data);
        }

        [Fact]
        public void Test_GetCount()
        {
            //Arrange
            BTree bTree = new BTree();
            bTree.AddItem(1);
            bTree.AddItem(2);
            bTree.AddItem(3);

            var count = bTree.GetCount();

            //Assert
            Assert.Equal(3, count);

            //Act
            bTree.AddItem(4);

            count = bTree.GetCount();

            //Assert
            Assert.Equal(4, count);
        }

        [Theory]
        [MemberData(nameof(Test_Data_AddItem))]
        public void Test_AddItem(int[] arrInit, int[] arrToAdd, int[] arrExpected, object expextedRootData, object expectedRootLeftChild, object expectedRootRightChild)
        {
            //Arrange
            BTree bTree = new BTree();

            if (arrInit != null)
            {
                for (int i = 0; i < arrInit.Length; i++)
                {
                    bTree.AddItem(arrInit[i]);
                }
            }

            for (int i = 0; i < arrToAdd.Length; i++)
            {
                bTree.AddItem(arrToAdd[i]);
            }

            var treeArray = TreeHelper.GetTreeInLine(bTree);

            //Act
            var root = bTree.GetRoot();
            object rootData = null;
            object rootLeftChildData = null;
            object rootRightChildData = null;
            if (root != null)
            {
                rootData = root.Data;

                if (root.LeftChild != null)
                    rootLeftChildData = root.LeftChild.Data;

                if (root.RightChild != null)
                    rootRightChildData = root.RightChild.Data;
            }    

            //Assert
            Assert.Equal(expextedRootData, rootData);
            Assert.Equal(expectedRootLeftChild, rootLeftChildData);
            Assert.Equal(expectedRootRightChild, rootRightChildData);
            for (int i = 0; i < treeArray.Length; i++)
            {
                Assert.Equal(arrExpected[i], treeArray[i].Node.Data);
            }
        }

        public static IEnumerable<object[]> Test_Data_AddItem()
        {
            yield return new object[] { new[] { 10, 5, 15, 7, 12 }, new[] { 2, 17 }, new[] { 10, 5, 15, 2, 7, 12, 17 }, 10, 5, 15 };
            yield return new object[] { null, new[] { 10, 5 }, new[] { 10, 5 }, 10, 5, null };
            yield return new object[] { null, new[] { 10, 15 }, new[] { 10, 15 }, 10, null, 15 };
            yield return new object[] { null, new[] { 10}, new[] { 10}, 10, null, null };
        }
        
        [Theory]
        [MemberData(nameof(Tast_Data_Insert))]
        public void Test_Insert(int[] arrInit, int headData, int insertData, int[] arrExpected, bool expectException)
        {
            //Arrange
            BTree bTree = new BTree();
            for (int i = 0; i < arrInit.Length; i++)
            {
                bTree.AddItem(arrInit[i]);
            }

            TreeNode head = bTree.GetNodeByValue(headData);

            //Act
            Action act = () => bTree.Insert(head, insertData);

            if (expectException)
            {
                Assert.Throws<Exception>(act);
            }
            else
            {
                act.Invoke();

                var treeArray = TreeHelper.GetTreeInLine(bTree);

                for (int i = 0; i < treeArray.Length; i++)
                {
                    Assert.Equal(arrExpected[i], treeArray[i].Node.Data);
                }
            }
        }

        public static IEnumerable<object[]> Tast_Data_Insert()
        {
            yield return new object[] { new int[] { 5, 10, 1, 20 }, 1, 3, new int[] { 5, 1, 10, 3, 20 }, false};
            yield return new object[] { new int[] { 5, 10, 1, 20 }, 77, 3, new int[] { 5, 1, 10, 20 }, false };
            yield return new object[] { new int[] { 5, 10, 1, 20 }, 5, 15, new int[] { 5, 1, 10, 20, 15 }, false };
            yield return new object[] { new int[] { 5, 10, 1, 20 }, 5, 10, new int[] { 5, 1, 10, 20, 15 }, true };
        }

        [Theory]
        [MemberData(nameof(Tast_Data_GetNodeByValue))]
        public void Test_GetNodeByValue(int[] arrInit, int valueToFind, int? valueInNode, int? parentValue, int? leftChildValue, int? rightChildValue)
        {
            //Arrange
            BTree bTree = new BTree();
            for (int i = 0; i < arrInit.Length; i++)
            {
                bTree.AddItem(arrInit[i]);
            }

            //Act
            TreeNode node = bTree.GetNodeByValue(valueToFind);

            //Assert
            //Если ожидаемое значение внутри узла null, то проверяем на null
            if (valueInNode == null)
            {
                Assert.Null(node);
            }
            //иначе если не null
            else
            {
                //Если ожидаемое значение родителя узла не null, то проверяем на NotNull и проверяем знаечние внутри
                if (parentValue != null)
                {
                    Assert.NotNull(node.Parent);
                    Assert.Equal(parentValue, node.Parent.Data);
                }
                else
                {
                    Assert.Null(node.Parent);
                }

                if (leftChildValue != null)
                {
                    Assert.NotNull(node.LeftChild);
                    Assert.Equal(leftChildValue, node.LeftChild.Data);
                }
                else
                {
                    Assert.Null(node.LeftChild);
                }

                if (rightChildValue != null)
                {
                    Assert.NotNull(node.RightChild);
                    Assert.Equal(rightChildValue, node.RightChild.Data);
                }
                else
                {
                    Assert.Null(node.RightChild);
                }
            }            
        }

        public static IEnumerable<object[]> Tast_Data_GetNodeByValue()
        {
            yield return new object[] { new int[] { 5 }, 5, 5, null, null, null };
            yield return new object[] { new int[] { 5 , 1, 10, 3, 7, 20}, 10, 10, 5, 7, 20 };
            yield return new object[] { new int[] { 5 , 1, 10, 3, 7, 20}, 1, 1, 5, null, 3 };
            yield return new object[] { new int[] { 5 , 1, 10, 3, 7, 20}, 3, 3, 1, null, null };
            yield return new object[] { new int[] { 5 , 1, 10, 3, 7, 20}, 77, null, null, null, null };
        }

        [Theory]
        [MemberData(nameof(Test_Data_GetMin))]
        public void Test_GetMin(int[] arrInit, int? expectedMin)
        {
            //Arrange
            BTree bTree = new BTree();
            for (int i = 0; i < arrInit.Length; i++)
            {
                bTree.AddItem(arrInit[i]);
            }

            //Act
            var root = bTree.GetRoot();

            //Assert
            if (expectedMin != null)
            {
                var value = bTree.GetMin(root);
                Assert.Equal(expectedMin, value.Data);
            }
            else
            {
                Action act = () => bTree.GetMin(null);
                Assert.Throws<ArgumentNullException>(act);
            }
            
        }

        public static IEnumerable<object[]> Test_Data_GetMin()
        {
            yield return new object[] { new int[] { 5, 1, 10, 3, 7 }, 1 };
            yield return new object[] { new int[] { 7 }, 7 };
            yield return new object[] { new int[] { }, null};
        }

        [Theory]
        [MemberData(nameof(Test_Data_RemoveItem))]
        public void Test_RemoveItem(int[] arrInit, int valueToRemove, int[] arrExpected)
        {
            //Arrange
            BTree bTree = new BTree();
            for (int i = 0; i < arrInit.Length; i++)
            {
                bTree.AddItem(arrInit[i]);
            }

            //Act
            bTree.RemoveItem(valueToRemove);

            var treeArray = TreeHelper.GetTreeInLine(bTree);

            //Assert
            for (int i = 0; i < treeArray.Length; i++)
            {
                Assert.Equal(arrExpected[i], treeArray[i].Node.Data);
            }
        }

        public static IEnumerable<object[]> Test_Data_RemoveItem()
        {
            yield return new object[] { new int[] { 5, 1, 10, 3, 7 }, 3, new int[] { 5, 1, 10, 7 } }; //Case: Leaf - LeftChild and RightChild are null
            yield return new object[] { new int[] { 5, 1, 10, 3, 7 }, 1, new int[] { 5, 3, 10, 7 } }; //Case: One child is null

            //Case: LeftChild and RightChild are not null
            yield return new object[] { new int[] { 5, 1, 10, 7, 15, 6, 9, 11, 16 }, 10, new int[] { 5, 1, 11, 7, 15, 6, 9, 16 } }; //Case: minNode is leaf
            yield return new object[] { new int[] { 5, 1, 10, 7, 15, 6, 9, 16 }, 10, new int[] { 5, 1, 15, 7, 16, 6, 9 } }; //Case: minNode with one right child

            //Case: root
            yield return new object[] { new int[] { 5, 2, 10, 1, 3, 7, 12 }, 5, new int[] { 7, 2, 10, 1, 3, 12 } }; 

        }
    }
}
