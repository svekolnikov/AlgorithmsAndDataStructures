using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson4
{
    public class BenchmarkClass
    {
        private readonly int _countStrings = 10000;
        private readonly int _countTests = 5;

        public string[] RandomStrings { get; set; }         // здесь ищем строку по сравнению
        public HashSet<string> RandomHashes { get; set; }   // здесь ищем строку по hash

        public List<string> RandomStringsForTest { get; set; } 
        [ParamsSource(nameof(RandomStringsForTest))]
        public string StringToFind { get; set; }            

        public BenchmarkClass()
        {
            RandomStrings = new string[_countStrings];
            
            for (int i = 0; i < _countStrings; i++)
            {
                RandomStrings[i] = RandomString(20);
            }

            RandomHashes = new HashSet<string>(RandomStrings);

            RandomStringsForTest = new List<string>();
            for (int i = 0; i < _countTests; i++)
            {
                RandomStringsForTest.Add(RandomStrings[random.Next(0, RandomStrings.Length - 1)]);
            }            
        }

        [Benchmark]
        public int FindInArray()
        {
            int i = 0;
            for (; i < RandomStrings.Length; i++)
            {
                if (RandomStrings[i] == StringToFind)
                {
                    break;
                }
            }
            return i;
        }

        [Benchmark]
        public string FindInHashes()
        {
            RandomHashes.TryGetValue(StringToFind, out string result);
            return result;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
