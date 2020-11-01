using Iced.Intel;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DotNetCoreBenchmarking.StopwatchTesting
{
    public static class GCImpact
    {
        public static void RunCountTest()
        {
            for (int i = 0; i <= 100; i++)
            {
                var ticks = RunActionAndGetElapsedTicks(GetNumbersSum);
                if (i == 0)
                {
                    continue;
                }

                Console.WriteLine($"ElapsedTicks: {ticks}");
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            long RunActionAndGetElapsedTicks(Func<int> sumFunc)
            {
                var stopwatch = Stopwatch.StartNew();
                var sum = sumFunc();
                return stopwatch.ElapsedTicks;                
            }
        }

        private static int GetNumbersSum()
        {
            var numbers = Enumerable.Range(0, 1000).ToList();
            return numbers.Sum(n => n);
        }
    }
}
