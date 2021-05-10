using Lesson8;
using System;
using System.Collections.Generic;
using Xunit;

namespace Lesson8_Tests
{
    public class Program
    {
        [Theory]
        [MemberData(nameof(Test_Data_BucketSort))]
        public void Test_BucketSort(int[] unsorted, List<int> sortedExpected, bool IsException)
        {
            
            if (IsException)
            {
                //Act and Assert
                Assert.Throws<ArgumentNullException>(() => Sort.BucketSort(null));
            }
            else
            {
                //Act
                var sorted = Sort.BucketSort(unsorted);

                //Assert
                for (int i = 0; i < unsorted.Length; i++)
                {
                    Assert.Equal(sortedExpected[i], sorted[i]);
                }
            }
        }

        public static IEnumerable<object[]> Test_Data_BucketSort()
        {
            Random rnd = new Random();

            var unsorted1 = new int[100];
            var sorted1 = new List<int>();

            var unsorted2 = new int[10000];
            var sorted2 = new List<int>();

            var unsorted3 = new int[100000000];
            var sorted3 = new List<int>();

            for (int i = 0; i < unsorted1.Length; i++)
            {
                unsorted1[i] = rnd.Next(0, 1000);
                sorted1.Add(unsorted1[i]);
            }

            for (int i = 0; i < unsorted2.Length; i++)
            {
                unsorted2[i] = rnd.Next(0, 1000);
                sorted2.Add(unsorted2[i]);
            }

            for (int i = 0; i < unsorted3.Length; i++)
            {
                unsorted3[i] = rnd.Next(0, 1000);
                sorted3.Add(unsorted3[i]);
            }

            sorted1.Sort();
            sorted2.Sort();
            sorted3.Sort();

            yield return new object[] {unsorted1, sorted1, true};

            yield return new object[] {unsorted1, sorted1, false};
            yield return new object[] {unsorted2, sorted2, false};
            yield return new object[] {unsorted3, sorted3, false};
        }
    }
}
