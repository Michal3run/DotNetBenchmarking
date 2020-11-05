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
            SimpleStopwatch.CountLoopTest();







            //StopwatchJITImpact.RunCountTest();
            //StopwatchJITImpact.RunEvenTest();







            //GCImpact.RunEvenNumbersCountTest();
            //GCImpact.RunEvenNumbersCountTestWithGCCollect();







            //BenchmarkRunner.Run<CollectionsBenchmarks>();            
            //BenchmarkRunner.Run<CountBenchmarks>();       


            //BenchmarkRunner.Run<SimpleDateParsingBenchmark>();
            BenchmarkRunner.Run<OtherDateParsingBenchmark>();
            //new OtherDateParsingBenchmark().GetYearFromSpanWithManualConversion();
        }
    }
}
