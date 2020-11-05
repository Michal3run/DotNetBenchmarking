using BenchmarkDotNet.Attributes;
using System;

namespace DotNetCoreBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class OtherDateParsingBenchmark
    {
        private const string _dateTimeString = "2020-11-05T19:56:51.3802835+01:00";

        [Benchmark]
        public int GetYearFromSplit()
        {
            var splitted = _dateTimeString.Split('-');
            return int.Parse(splitted[0]);
        }


















        [Benchmark]
        public int GetYearFromSubstring()
        {
            var indexOfHyphen = _dateTimeString.IndexOf('-');
            return int.Parse(_dateTimeString.Substring(0, indexOfHyphen));
        }











        [Benchmark]
        public int GetYearFromSpan()
        {
            var dataTimeSpan = _dateTimeString.AsSpan(); //dotnet 2.2 (operates 
            var indexOfHyphen = dataTimeSpan.IndexOf('-');
            return int.Parse(dataTimeSpan.Slice(0, indexOfHyphen));
        }










        [Benchmark]
        public int GetYearFromSpanWithManualConversion()
        {
            var dataTimeSpan = _dateTimeString.AsSpan();
            var indexOfHyphen = dataTimeSpan.IndexOf('-');
            var yearAsSpan = dataTimeSpan.Slice(0, indexOfHyphen);

            var temp = 0;
            for (int i = 0; i < yearAsSpan.Length; ++i)
            {
                temp = temp * 10 + (yearAsSpan[i] - '0');
            }

            return temp;
        }
    }
}
