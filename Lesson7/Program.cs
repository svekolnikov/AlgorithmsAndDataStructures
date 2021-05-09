using System;
using System.Collections.Generic;
using Xunit;

namespace Lesson7
{
    public class Program
    {
        [Theory]
        [MemberData(nameof(Test_Data_FindWay))]
        public void Test_FindWay(int a, int b, int expectedWaysNum, bool IsException)
        {
            //Arrange

            // 1  1  1  1
            // 1  2  2  4
            // 1  2  6 10
            // 1  4 10 20

            if (IsException)
            {
                //Act - Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => FindWay.WaysNumber(a, b));
            }
            else
            {
                //Act
                var ways = FindWay.WaysNumber(a, b);

                //Assert
                Assert.Equal(expectedWaysNum, ways);
            }
            
        }

        public static IEnumerable<object[]> Test_Data_FindWay()
        {
            yield return new object[] { -1, -2, 1, true };
            yield return new object[] { 0, 0, 1, true };

            yield return new object[] { 1, 1, 1, false };
            yield return new object[] { 2, 2, 2, false };
            yield return new object[] { 2, 4, 4, false };
            yield return new object[] { 3, 3, 6, false };
            yield return new object[] { 3, 4, 10, false };
            yield return new object[] { 4, 3, 10, false };
            yield return new object[] { 4, 4, 20, false };
        }
    }
}
