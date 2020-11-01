using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    //[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MinColumn, Q1Column, Q3Column, MaxColumn]
    [SimpleJob(launchCount: 1, warmupCount: 10, targetCount: 20)]
    public class CountBenchmarks
    {
        private static readonly List<int> List = GetNumbers().ToList();
        private static readonly IEnumerable<int> ListAsIEnumerable = GetNumbers().ToList();
        private static readonly IEnumerable<int> IEnumerable = GetNumbers();

        //private static IEnumerable<int> GetNumbers() => Enumerable.Range(0, 10000);
        private static IEnumerable<int> GetNumbers()
        {
            for (int i = 0; i < 1000; i++)
            {
                yield return i;
            }
        }

        [Benchmark(Baseline = true)]        
        public bool TestListCountProperty()
        {
            return List.Count > 0;
        }

        [Benchmark]
        public bool TestListCountMethod()
        {
            return List.Count() > 0;
        }

        [Benchmark]
        public bool TestListAsIEnumerableAny()
        {
            return ListAsIEnumerable.Count() > 0;
        }

        [Benchmark]
        public bool TestIEnumerableAny()
        {
            return IEnumerable.Count() > 0;
        }
    }
}
