
// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchmarkEF6;

Console.WriteLine("Starting Benchmark EF 6");
var res = BenchmarkRunner.Run<Benchmark>();
Console.WriteLine("Completed Benchmark EF 6");
