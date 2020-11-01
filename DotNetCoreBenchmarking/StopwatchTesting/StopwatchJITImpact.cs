using System;
using System.Diagnostics;

namespace DotNetCoreBenchmarking.StopwatchTesting
{
    public static class StopwatchJITImpact
    {
        public static void RunCountTest()
        {
            RunTest(CountLoopTest);
        }

        public static void RunEvenTest()
        {
            RunTest(IsEvenLoopTest);
        }

        private static void RunTest(Func<long> methodToRun)
        {
            Console.WriteLine($"First run ticks: {methodToRun()}");
            Console.WriteLine($"Second run ticks: {methodToRun()}");
            Console.WriteLine($"Third run ticks: {methodToRun()}");
            Console.WriteLine($"Fourth run ticks: {methodToRun()}");
        }

        private static long CountLoopTest()
        {
            var stopwatch = Stopwatch.StartNew();
            var count = 0;
            for (int i = 0; i < 100; i++)
            {                
                count++;
            }
            return stopwatch.ElapsedTicks;
        }

        private static long IsEvenLoopTest()
        {
            var stopwatch = Stopwatch.StartNew();            
            for (int i = 0; i < 100; i++)
            {
                IsEven(i);
            }
            return stopwatch.ElapsedTicks;
        }

        private static long IsEven(int number)
        {
            return number % 2;
        }
    }
}
