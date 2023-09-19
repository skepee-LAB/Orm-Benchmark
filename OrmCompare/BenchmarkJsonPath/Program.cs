
using BenchmarkDotNet.Running;
using BenchmarkJsonPath;

Console.WriteLine("Starting Benchmark Json Path");
var res = BenchmarkRunner.Run<Benchmark>();
Console.WriteLine("Completed Benchmark Json Path");
