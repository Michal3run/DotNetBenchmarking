using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class AnyBenchmarks
    {
        private static readonly List<int> List = GetNumbers().ToList();
        private static readonly IEnumerable<int> ListAsIEnumerable = GetNumbers().ToList();
        private static readonly IEnumerable<int> IEnumerable = GetNumbers();

        private static IEnumerable<int> GetNumbers()
        {
            for (int i = 0; i < 10000; i++)
            {
                yield return i;
            }
        }

        [Benchmark]
        public void TestListAny()
        {
            List.Any();
        }

        [Benchmark]
        public void TestListAsIEnumerableAny()
        {
            ListAsIEnumerable.Any();
        }

        [Benchmark]
        public void TestIEnumerableAny()
        {
            IEnumerable.Any();
        }
    }
}
