using System;
using System.Collections.Generic;
using System.Linq;
using Lesson6;
using Xunit;

namespace Lesson6_Tests
{
    public class Program
    {
        [Theory]
        [MemberData(nameof(Test_Data_BFS))]
        public void Test_BFS(int[] expectedArr, int searchValue, bool IsException)
        {
            //Arrange
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);

            //          (3)--7--(4)
            //           |       |       
            //           8       6       
            //           |       |       
            //  (1)--9--(2)--5--(5)--4--(6)
            //                   |        
            //                   3           
            //                   |        
            //                  (7)

            node1.Edges.Add(new Edge { Weight = 9, Node = node2 });
            node2.Edges.Add(new Edge { Weight = 9, Node = node1 });
            node2.Edges.Add(new Edge { Weight = 8, Node = node3 });
            node2.Edges.Add(new Edge { Weight = 5, Node = node5 });
            node3.Edges.Add(new Edge { Weight = 8, Node = node2 });
            node3.Edges.Add(new Edge { Weight = 7, Node = node4 });
            node4.Edges.Add(new Edge { Weight = 7, Node = node3 });
            node4.Edges.Add(new Edge { Weight = 6, Node = node5 });
            node5.Edges.Add(new Edge { Weight = 5, Node = node2 });
            node5.Edges.Add(new Edge { Weight = 6, Node = node4 });
            node5.Edges.Add(new Edge { Weight = 4, Node = node6 });
            node5.Edges.Add(new Edge { Weight = 3, Node = node7 });
            node6.Edges.Add(new Edge { Weight = 4, Node = node5 });
            node7.Edges.Add(new Edge { Weight = 3, Node = node5 });

            //Act
            if (IsException)
            {
                //Assert
                Action act = () => GrafSearch.BFS(null, searchValue);
                Assert.Throws<ArgumentNullException>(act);
            }
            else
            {
                var resultBFS = GrafSearch.BFS(node1, searchValue);

                //Assert
                if (expectedArr == null)
                {
                    Assert.Null(resultBFS.FoundNode);
                }
                else
                {
                    for (int i = 0; i < expectedArr.Length; i++)
                    {
                        Assert.Equal(expectedArr[i], resultBFS.CheckedNodes[i].Value);
                    }
                }
            } 
        }

        public static IEnumerable<object[]> Test_Data_BFS()
        {
            yield return new object[] {new[] {1, 2, 3, 5, 4, 6, 7}, 7, false};
            yield return new object[] {new[] {1, 2, 3, 5, 4, 6, 7}, 7, true};
            yield return new object[] {null, 77, false};
        }

        [Theory]
        [MemberData(nameof(Test_Data_DFS))]
        public void Test_DFS(int[] expectedArr, int searchValue, bool IsException)
        {
            //Arrange
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);

            //          (3)--7--(4)
            //           |       |       
            //           8       6       
            //           |       |       
            //  (1)--9--(2)--5--(5)--4--(6)
            //                   |        
            //                   3           
            //                   |        
            //                  (7)

            node1.Edges.Add(new Edge { Weight = 9, Node = node2 });
            node2.Edges.Add(new Edge { Weight = 9, Node = node1 });
            node2.Edges.Add(new Edge { Weight = 8, Node = node3 });
            node2.Edges.Add(new Edge { Weight = 5, Node = node5 });
            node3.Edges.Add(new Edge { Weight = 8, Node = node2 });
            node3.Edges.Add(new Edge { Weight = 7, Node = node4 });
            node4.Edges.Add(new Edge { Weight = 7, Node = node3 });
            node4.Edges.Add(new Edge { Weight = 6, Node = node5 });
            node5.Edges.Add(new Edge { Weight = 5, Node = node2 });
            node5.Edges.Add(new Edge { Weight = 6, Node = node4 });
            node5.Edges.Add(new Edge { Weight = 4, Node = node6 });
            node5.Edges.Add(new Edge { Weight = 3, Node = node7 });
            node6.Edges.Add(new Edge { Weight = 4, Node = node5 });
            node7.Edges.Add(new Edge { Weight = 3, Node = node5 });

            //Act
            if (IsException)
            {
                //Assert
                Action act = () => GrafSearch.BFS(null, searchValue);
                Assert.Throws<ArgumentNullException>(act);
            }
            else
            {
                var resultDFS = GrafSearch.DFS(node1, searchValue);

                //Assert
                if (expectedArr == null)
                {
                    Assert.Null(resultDFS.FoundNode);
                }
                else
                {
                    for (int i = 0; i < expectedArr.Length; i++)
                    {
                        Assert.Equal(expectedArr[i], resultDFS.CheckedNodes[i].Value);
                    }
                }
            }
        }

        public static IEnumerable<object[]> Test_Data_DFS()
        {
            yield return new object[] { new[] { 1, 2, 5, 7 }, 7, false };
            yield return new object[] { new[] { 1, 2, 5, 7 }, 7, true };
            yield return new object[] { null, 77, false };
        }
    }
}
