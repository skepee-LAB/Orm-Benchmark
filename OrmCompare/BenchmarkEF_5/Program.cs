using BenchmarkDotNet.Running;
using System;

namespace BenchmarkEF5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Benchmark EF 5");
            var res = BenchmarkRunner.Run<Benchmark>();
            Console.WriteLine("Completed Benchmark EF 5");
        }
    }
}
