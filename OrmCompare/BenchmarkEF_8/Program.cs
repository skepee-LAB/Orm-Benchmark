using BenchmarkEF8;
using BenchmarkDotNet.Running;

Console.WriteLine("Starting Benchmark EF 8");
var res = BenchmarkRunner.Run<Benchmark>();
Console.WriteLine("Completed Benchmark EF 8");
