// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using BenchmarkEF7;

Console.WriteLine("Starting Benchmark EF 7");
var res = BenchmarkRunner.Run<Benchmark>();
Console.WriteLine("Completed Benchmark EF 7");
