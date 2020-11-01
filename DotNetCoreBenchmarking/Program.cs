using BenchmarkDotNet.Running;
using DotNetCoreBenchmarking.Benchmarks;
using DotNetCoreBenchmarking.StopwatchTesting;
using System;

namespace DotNetCoreBenchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleStopwatch.CountLoopTest();            

            //StopwatchJITImpact.RunCountTest();
            //StopwatchJITImpact.RunEvenTest();

            GCImpact.RunCountTest();

            //BenchmarkRunner.Run<CollectionsBenchmarks>();            
            //BenchmarkRunner.Run<CountBenchmarks>();       
        }
    }
}
