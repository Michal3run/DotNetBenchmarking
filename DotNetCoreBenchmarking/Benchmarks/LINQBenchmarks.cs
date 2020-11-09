using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace DotNetCoreBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    //[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LINQBenchmarks
    {
        public int RankingRowsCount = 200;

        [Params(1, 19)]
        public int RealRankingYears;

        private const int DbStartingYear = 2000;
        private const int DbPeriodsCount = 20;
        private int DbCurrentYear = DbStartingYear + DbPeriodsCount;

        private List<PeriodDto> _periods;
        private List<RankingRow> _rankingRows;


        [GlobalSetup]
        public void Setup()
        {
            _periods = GetPeriods();
            _rankingRows = GetRankingRows();
        }

        [Benchmark]
        public List<PeriodDto> LINQTestWithLotOfTemporaryArrayResultsNoDistinct()
        {
            var periodData = _rankingRows.SelectMany(r => r.RowPeriods).ToArray();
            var rowPeriodIds = periodData.Select(p => p.PeriodId).ToArray();

            return _periods.Where(p => rowPeriodIds.Contains(p.Id)).ToList();
        }

        [Benchmark]
        public List<PeriodDto> LINQTestWithLotOfTemporaryArrayResults()
        {
            var periodData = _rankingRows.SelectMany(r => r.RowPeriods).ToArray();
            var rowPeriodIds = periodData.Select(p => p.PeriodId).ToArray();
            var distinctRowPeriodIds = rowPeriodIds.Distinct().ToArray();

            return _periods.Where(p => distinctRowPeriodIds.Contains(p.Id)).ToList();
        }

        [Benchmark]
        public List<PeriodDto> LINQTestWithLotOfTemporaryListResults()
        {
            var periodData = _rankingRows.SelectMany(r => r.RowPeriods).ToList();
            var rowPeriodIds = periodData.Select(p => p.PeriodId).ToList();
            var distinctRowPeriodIds = rowPeriodIds.Distinct().ToList();

            return _periods.Where(p => distinctRowPeriodIds.Contains(p.Id)).ToList();
        }
        
        [Benchmark]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public List<PeriodDto> LINQTestWithLotOfTemporaryResultsDistinctInWhereNoInlining()
        {
            var periodData = _rankingRows.SelectMany(r => r.RowPeriods).ToList();
            var rowPeriodIds = periodData.Select(p => p.PeriodId).ToList();
            var distinctRowPeriodIds = rowPeriodIds.Distinct();

            return _periods.Where(p => distinctRowPeriodIds.Contains(p.Id)).ToList();
        }

        [Benchmark]
        public List<PeriodDto> LINQTestWithLotOfTemporaryResultsDistinctInWhere()
        {
            var periodData = _rankingRows.SelectMany(r => r.RowPeriods).ToList();
            var rowPeriodIds = periodData.Select(p => p.PeriodId).ToList();
            var distinctRowPeriodIds = rowPeriodIds.Distinct();

            return _periods.Where(p => distinctRowPeriodIds.Contains(p.Id)).ToList();
        }

        [Benchmark]
        public List<PeriodDto> LINQTestWithSomeTemporaryResults()
        {
            var distinctRowPeriodIds = _rankingRows.SelectMany(r => r.RowPeriods)
                .Select(p => p.PeriodId)
                .Distinct()
                .ToList();

            return _periods.Where(p => distinctRowPeriodIds.Contains(p.Id)).ToList();
        }

        [Benchmark]
        public List<PeriodDto> LINQTestWithSomeTemporaryResultsAndHashset()
        {
            var distinctRowPeriodIds = new HashSet<string>(_rankingRows.SelectMany(r => r.RowPeriods)
                .Select(p => p.PeriodId));

            return _periods.Where(p => distinctRowPeriodIds.Contains(p.Id)).ToList();
        }

        [Benchmark]
        public List<PeriodDto> LINQTestWithHashsetInWhere()
        {

            return _periods.Where(p => new HashSet<string>(_rankingRows.SelectMany(r => r.RowPeriods)
                .Select(r => r.PeriodId)).Contains(p.Id)).ToList();
        }


        private List<PeriodDto> GetPeriods()
        {
            return Enumerable.Range(DbStartingYear, DbPeriodsCount).Select(i => new PeriodDto {Id = i.ToString()}).ToList();
        }

        private List<RankingRow> GetRankingRows()
        {
            return Enumerable.Range(0, RankingRowsCount).Select(i => new RankingRow
            {
                RowPeriods = GetRankingPeriodData()
            }).ToList();

            List<RankingPeriodDataDto> GetRankingPeriodData()
            {
                return Enumerable.Range(DbCurrentYear - RealRankingYears, RealRankingYears)
                    .Select(r => new RankingPeriodDataDto {PeriodId = r.ToString(), Value = 10}).ToList();
            }

    }

        public class PeriodDto
        {
            public string Id { get; set; }
        }

        public class RankingRow
        {
            public List<RankingPeriodDataDto> RowPeriods { get; set; }
        }

        public class RankingPeriodDataDto
        {
            public string PeriodId { get; set; }
            public decimal Value { get; set; }
        }
    }
}
