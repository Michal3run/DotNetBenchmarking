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
    public class MultipleContainsWithoutCollectionCreationBenchmarks
    {
        [Params(1, 100, 10000)]
        public int CollectionSize;

        private IEnumerable<int> _numbersToCheck;

        private List<int> _list;
        private int[] _array;
        private HashSet<int> _hashset;
        private Dictionary<int, int> _dictionary;
        private ILookup<int, int> _lookup;

        [GlobalSetup]
        public void Setup()
        {
            _numbersToCheck = GetNumbers().ToArray();

            _array = GetNumbers().ToArray();
            _list = _array.ToList();
            _hashset = new HashSet<int>(_array);
            _dictionary = _array.ToDictionary(n => n, n => n);
            _lookup = _array.ToLookup(n => n);
        }
                

        [Benchmark(Baseline = true)]
        public bool ListBenchmark()
        {
            bool result = default;
            TestCollection(number => result ^= _list.Contains(number));
            return result;
        }

        [Benchmark]
        public bool ArrayBenchmark()
        {
            bool result = default;
            TestCollection(number => result ^= _array.Contains(number));
            return result;
        }

        [Benchmark]
        public bool HashsetBenchmark()
        {
            bool result = default;
            TestCollection(number => result ^= _hashset.Contains(number));
            return result;
        }

        [Benchmark]
        public bool DictionaryBenchmark()
        {
            bool result = default;
            TestCollection(number => result ^= _dictionary.ContainsKey(number));
            return result;
        }

        [Benchmark]
        public bool LookupBenchmark()
        {
            bool result = default;
            TestCollection(number => _lookup.Contains(number));
            return result;
        }

        private void TestCollection(Func<int, bool> contains)
        {
            foreach (var number in _numbersToCheck)
            {
                contains(number);
            }
        }

        private IEnumerable<int> GetNumbers() => Enumerable.Range(0, CollectionSize);
    }        
}
