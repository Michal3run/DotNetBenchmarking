using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DotNetCoreBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class CollectionsBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void ListBenchmark()
        {
            var list = GetNumbers().ToList();
            TestCollection(number => list.Contains(number));
        }

        [Benchmark]
        public void ArrayBenchmark()
        {
            var array = GetNumbers().ToArray();
            TestCollection(number => array.Contains(number));
        }

        [Benchmark]
        public void ArraySimpleBenchmark()
        {
            var array = GetNumbers().ToArray();
            foreach (var number in GetNumbers())
            {
                array.Contains(number);
            }
        }

        [Benchmark]
        public void HashsetBenchmark()
        {
            var hashset = new HashSet<int>(GetNumbers());
            TestCollection(number => hashset.Contains(number));
        }

        [Benchmark]
        public void DictionaryBenchmark()
        {
            var dictionary = GetNumbers().ToDictionary(n => n, n => n);
            TestCollection(number => dictionary.ContainsKey(number));
        }

        [Benchmark]
        public void LookupBenchmark()
        {
            var lookup = GetNumbers().ToLookup(n => n);
            TestCollection(number => lookup.Contains(number));
        }

        //private void TestIEnumerable(IEnumerable<int> collectionToTest)
        //{
        //    TestCollection(number => collectionToTest.Contains(number));
        //}

        private void TestCollection(Func<int, bool> contains)
        {
            foreach (var number in GetNumbers())
            {
                contains(number);
            }
        }

        private IEnumerable<int> GetNumbers(int count = 1000) => Enumerable.Range(0, count);
    }        
}
