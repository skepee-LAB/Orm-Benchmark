using BenchmarkDotNet.Running;
using System;

namespace BenchmarkEF_3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Benchmark EF 3.1");
            var res = BenchmarkRunner.Run<Benchmark>();
            Console.WriteLine("Completed Benchmark EF 3.1");
        }
    }
}
