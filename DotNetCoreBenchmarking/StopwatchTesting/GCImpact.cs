using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DotNetCoreBenchmarking.StopwatchTesting
{
    public static class GCImpact
    {
        private static int _testLaunchCount = 100;

        public static void RunCountTestWithoutGCCollect()
        {
            RunCountTest(forceGC: false);
        }

        public static void RunCountTestWithGCCollect()
        {
            RunCountTest(forceGC: true);
        }

        private static void RunCountTest(bool forceGC)
        {
            var ticksList = new List<long>(_testLaunchCount);

            for (int i = 0; i < _testLaunchCount; i++)
            {
                if (forceGC)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                var (_, elapsedTicks) = GetCountAndElapsedTicks();
                Console.WriteLine($"ElapsedTicks: {elapsedTicks}");
                if (i > 1)
                {
                    ticksList.Add(elapsedTicks);
                }
            }

            Console.WriteLine($"ElapsedTicks with{(forceGC ? "" : "out")} GC.Collect(). " +
                $"Avg: {Math.Round(ticksList.Average(), 1)}");                       
        }

        private static (int count, long elapsedTicks) GetCountAndElapsedTicks()
        {
            var stopwatch = Stopwatch.StartNew();
            var numberArrays = Enumerable.Range(0, 10).ToArray();

            var count = numberArrays.Count();

            return (count, stopwatch.ElapsedTicks);
        }
    }
}
