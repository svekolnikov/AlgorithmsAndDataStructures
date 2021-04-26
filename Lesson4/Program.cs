using BenchmarkDotNet.Running;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkClass bm = new BenchmarkClass();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
