using BenchmarkDotNet.Attributes;
using System;

namespace DotNetCoreBenchmarking.Benchmarks
{
    public class SimpleDateParsingBenchmark
    {
        private const string _dateTimeString = "2020-11-05T19:56:51.3802835+01:00";

        [Benchmark]
        public int GetYearFromDateTime()
        {
            var dateTime = DateTime.Parse(_dateTimeString);
            return dateTime.Year;
        }
    }
}
