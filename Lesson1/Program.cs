using System;
using Xunit;

namespace Lesson1
{
    public class Program
    {
        private static bool IsPrime(int n)
        {
            var d = 0;
            var i = 2;
            while (i < n)
            {
                if (n % i == 0)
                    d++;

                i++;
            }

            return d == 0;
        }

        // асимптотическая сложность = O(2) + O(N*N*N*2) + O(N*N*(N-1)*1).
        // Пренебрегая константами получим O(N^3), где  N = inputArray.Length
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1) 
            for (int i = 0; i < inputArray.Length; i++) // N 
            {
                for (int j = 0; j < inputArray.Length; j++) // N 
                {
                    for (int k = 0; k < inputArray.Length; k++) // N 
                    {
                        int y = 0;    // O(1) 
                        if (j != 0)   // N*N*(N-1)  
                        {
                            y = k / j;  // O(1) 
                        }
                        sum += inputArray[i] + i + k + j + y; // O(1) 
                    }
                }
            }
            return sum; // O(1) 
        }

        public static int FibonacciReqursive(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));

            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return FibonacciReqursive(n - 1) + FibonacciReqursive(n - 2);
        }

        public static int Fibonacci(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));

            int f2 = 0;
            int f1= 1;

            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            int f = 0;
            int i = 2;
            while (i++ <= n)
            {
                f = f1 + f2;
                f2 = f1;
                f1 = f;
            }

            return f;
        }


        [Fact]
        public static void Test_IsPrime()
        {
            //Arrange

            //Act
            bool res1 = IsPrime(5);
            bool res2 = IsPrime(17);
            bool res3 = IsPrime(47);
            bool res4 = IsPrime(10);
            bool res5 = IsPrime(20);

            //Assert
            Assert.True(res1);
            Assert.True(res2);
            Assert.True(res3);
            Assert.True(!res4);
            Assert.True(!res5);
        }

        [Fact]
        public static void Test_FibonacciReqursive()
        {
            //Arrange

            //Act
            int res1 = FibonacciReqursive(1);
            int res2 = FibonacciReqursive(2);
            int res3 = FibonacciReqursive(3);
            int res4 = FibonacciReqursive(4);
            int res5 = FibonacciReqursive(5);
            int res6 = FibonacciReqursive(10);

            Action act = () => FibonacciReqursive(-1);

            //Assert
            Assert.Equal(1, res1);
            Assert.Equal(1, res2);
            Assert.Equal(2, res3);
            Assert.Equal(3, res4);
            Assert.Equal(5, res5);
            Assert.Equal(55, res6);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public static void Test_Fibonacci()
        {
            //Arrange

            //Act
            int res1 = Fibonacci(1);
            int res2 = Fibonacci(2);
            int res3 = Fibonacci(3);
            int res4 = Fibonacci(4);
            int res5 = Fibonacci(5);
            int res6 = Fibonacci(10);

            Action act = () => FibonacciReqursive(-1);

            //Assert
            Assert.Equal(1, res1);
            Assert.Equal(1, res2);
            Assert.Equal(2, res3);
            Assert.Equal(3, res4);
            Assert.Equal(5, res5);
            Assert.Equal(55, res6);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }
    }
}
