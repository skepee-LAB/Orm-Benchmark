
using BenchmarkDapper;
using BenchmarkDotNet.Running;

Console.WriteLine("Starting Benchmark Dapper");
var res = BenchmarkRunner.Run<Benchmark>();
Console.WriteLine("Completed Benchmark Dapper");
