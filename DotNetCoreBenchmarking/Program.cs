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

            //GCImpact.RunEvenNumbersCountTest();
            //GCImpact.RunEvenNumbersCountTestWithGCCollect();

            //BenchmarkRunner.Run<Md5VsSha256>();

            BenchmarkRunner.Run<MultipleContainsWithoutCollectionCreationBenchmarks>();            
            //BenchmarkRunner.Run<MultipleContainsBenchmarks>();            
            //BenchmarkRunner.Run<CountBenchmarks>();       

        }
    }
}
