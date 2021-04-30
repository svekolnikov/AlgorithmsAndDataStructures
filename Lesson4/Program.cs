using BenchmarkDotNet.Running;

namespace Lesson4_Search 
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
