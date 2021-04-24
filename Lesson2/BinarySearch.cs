namespace Lesson2
{
    public static class BinarySearch
    {
        //Асимптотическая сложность = O(log(N)), где N = inputArray.Length
        public static int BinarySearchInArray(int[] inputArray, int value)
        {
            int min = 0; 
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2; // 1 = N / 2^x => x = Log(N)
                if (value == inputArray[mid])
                {
                    return mid;
                }
                else if(value < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
