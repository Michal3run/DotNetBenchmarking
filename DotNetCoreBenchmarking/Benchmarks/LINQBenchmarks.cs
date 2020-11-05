using BenchmarkDotNet.Attributes;

namespace DotNetCoreBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LINQBenchmarks
    {

    }
}
