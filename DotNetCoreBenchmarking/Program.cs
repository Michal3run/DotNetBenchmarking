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

            //BenchmarkRunner.Run<SimpleDateParsingBenchmark>();
            //BenchmarkRunner.Run<OtherDateParsingBenchmark>();

            //BenchmarkRunner.Run<Md5VsSha256>();

            //BenchmarkRunner.Run<AnyBenchmarks>();
            //BenchmarkRunner.Run<CountBenchmarks>();

            //BenchmarkRunner.Run<MultipleContainsWithoutCollectionCreationBenchmarks>();            
            //BenchmarkRunner.Run<MultipleContainsBenchmarks>();            

            BenchmarkRunner.Run<LINQBenchmarks>();

            //var LBenchmark = new LINQBenchmarks();
            //LBenchmark.RealRankingYears = 19;
            //LBenchmark.RankingRowsCount = 200;
            //LBenchmark.Setup();
            //LBenchmark.LINQTestWithHashsetInWhere();
        }
    }
}
