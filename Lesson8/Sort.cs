using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lesson8
{
    public static class Sort
    {
        public static List<int> BucketSort(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));

            List<int> sortedArr = new List<int>();

            //Buckets
            var numBuckets = (int)Math.Ceiling(arr.Max() / 10.0f);
            List<int>[] buckets = new List<int>[numBuckets];

            for (int i = 0; i < numBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            //Add to buckets
            for (var i = 0; i < arr.Length; i++)
            {
                var numBucket = arr[i] / numBuckets;
                buckets[numBucket].Add(arr[i]);
            }

            //Sort and merge
            for (int i = 0; i < numBuckets; i++)
            {
                int[] temp = buckets[i].ToArray();
                if (temp.Length > 0)
                {
                    QuickSort(temp, 0, temp.Length - 1);
                    sortedArr.AddRange(temp);
                }
                
            }

            return sortedArr;
        }
        
        public static void QuickSort(int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];

            do
            {
                while (array[i] < x)
                    i++;

                while (array[j] > x)
                    j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }

                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
            {
                QuickSort(array, i, last);
            }

            if (first < j)
            {
                QuickSort(array, first, j);
            }
        }

        public static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;

                for (int i = left; i <= middleIndex; i++)
                {
                    tempArray[index] = array[i];
                    index++;
                }

                for (int i = right; i <= highIndex; i++)
                {
                    tempArray[index] = array[i];
                    index++;
                }

                for (int i = 0; i < tempArray.Length; i++)
                {
                    array[lowIndex + i] = tempArray[i];
                }
            }
        }

        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                if (highIndex - lowIndex == 1)
                {
                    if (array[highIndex] < array[lowIndex])
                    {
                        var t = array[lowIndex];
                        array[lowIndex] = array[highIndex];
                        array[highIndex] = t;
                    }
                }
                else
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }
            }

            return array;
        }
        
    }
}
