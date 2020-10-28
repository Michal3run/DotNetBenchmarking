using BenchmarkDotNet.Running;
using DotNetCoreBenchmarking.Benchmarks;
using System;

namespace DotNetCoreBenchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CollectionsBenchmarks>();
        }
    }
}
