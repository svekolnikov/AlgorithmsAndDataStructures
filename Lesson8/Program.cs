using System;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrNotSort = new int[] {98, 92, 87, 85, 77, 71, 69, 63, 55, 56, 42, 43, 38, 30, 20, 21, 13, 17, 4, 7};
            var result = Sort.MergeSort(arrNotSort);
            foreach (var i in result)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }
    }
}
