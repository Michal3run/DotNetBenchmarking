using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DotNetCoreBenchmarking.Benchmarks
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]    
    [RankColumn]
    public class SingleContainsWithCollectionCreationBenchmarks
    {
        [Params(100, 10000, 1000000)]
        public int CollectionSize;

        private int _randomNumber;

        [GlobalSetup]
        public void Setup()
        {
            //THIS IS WRONG BENCHMARK: RANDOM NUMBER IS SET ONLY ONCE PER PARAM, SO IT COULD DRAW SOMETHING GOOD FOR ARRAY/LIST
            _randomNumber = new Random(42).Next();
        }

        [Benchmark(Baseline = true)]
        public void ListBenchmark()
        {
            var list = GetNumbers().ToList();
            list.Contains(_randomNumber);
        }

        [Benchmark]
        public void ArrayBenchmark()
        {
            var array = GetNumbers().ToArray();
            array.Contains(_randomNumber);
        }

        [Benchmark]
        public void HashsetBenchmark()
        {
            var hashset = new HashSet<int>(GetNumbers());
            hashset.Contains(_randomNumber);
        }

        [Benchmark]
        public void DictionaryBenchmark()
        {
            var dictionary = GetNumbers().ToDictionary(n => n, n => n);
            dictionary.ContainsKey(_randomNumber);
        }

        [Benchmark]
        public void LookupBenchmark()
        {
            var lookup = GetNumbers().ToLookup(n => n);
            lookup.Contains(_randomNumber);
        }

        private IEnumerable<int> GetNumbers() => Enumerable.Range(0, CollectionSize);
    }        
}
