using System;

namespace Lesson7
{
    public static class FindWay
    {
        public static int WaysNumber(int a, int b)
        {
            if (a <= 0) throw new ArgumentOutOfRangeException(nameof(a));
            if (b <= 0) throw new ArgumentOutOfRangeException(nameof(b));

            if (a == 1 || b == 1)
            {
                return 1;
            }

            return WaysNumber(a, b - 1) + WaysNumber(a - 1, b);
        }
    }
}
