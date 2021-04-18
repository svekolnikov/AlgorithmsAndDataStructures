namespace Lesson2
{
    public static class BinarySearch
    {
        public static int FindIndexByValue(int[] inputArray, int value)
        {
            int min = 0; // O(1)
            int max = inputArray.Length - 1;// O(1)
            while (min <= max)
            {
                int mid = (min + max) / 2;// O(1)
                if (value == inputArray[mid])
                {
                    return mid;
                }
                else if(value < inputArray[mid])
                {
                    max = mid - 1;// O(1)
                }
                else
                {
                    min = mid + 1;// O(1)
                }
            }
            return -1;// O(1)
        }
    }
}
