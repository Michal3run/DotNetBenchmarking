using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DotNetCoreBenchmarking.StopwatchTesting
{
    public static class GCImpact
    {
        private static int _testLaunchCount = 100;

        public static void RunEvenNumbersCountTest()
        {
            RunEvenNumbersCountTest(forceGC: false);
        }

        public static void RunEvenNumbersCountTestWithGCCollect()
        {
            RunEvenNumbersCountTest(forceGC: true);
        }

        private static void RunEvenNumbersCountTest(bool forceGC)
        {
            var ticksList = new List<long>(_testLaunchCount);

            for (int i = 0; i < _testLaunchCount; i++)
            {
                if (forceGC)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                var stopwatch = Stopwatch.StartNew();

                var evenNumberCount = GetEvenNumbersCount();

                var elapsedTicks = stopwatch.ElapsedTicks;

                Console.WriteLine($"ElapsedTicks: {elapsedTicks}");
                if (i > 1)
                {
                    ticksList.Add(elapsedTicks);
                }
            }

            Console.WriteLine($"ElapsedTicks with{(forceGC ? "" : "out")} GC.Collect(). " +
                $"Avg: {Math.Round(ticksList.Average(), 1)}");                       
        }

        private static long GetEvenNumbersCount()
        {            
            var numbers = Enumerable.Range(0, 10000).Select(GetNumber).ToArray();
            var evenNumbers = numbers.Where(n => n.IsEven).ToArray();
            var evenNumbersCount = evenNumbers.Length;

            return evenNumbersCount;

            Number GetNumber(int i) => new Number(i);
        }

        private class Number
        {
            private readonly int _number;

            public Number(int number)
            {
                _number = number;
            }

            public bool IsEven => _number % 2 == 0;
        }
    }
}
