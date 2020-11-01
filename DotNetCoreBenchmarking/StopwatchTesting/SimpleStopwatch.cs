using System;
using System.Diagnostics;

namespace DotNetCoreBenchmarking.StopwatchTesting
{
    public class SimpleStopwatch
    {
        public static void CountLoopTest()
        {
            var stopwatch = Stopwatch.StartNew();
            var count = 0;
            for (int i = 0; i < 100; i++)
            {
                count++;
            }
            stopwatch.Stop();
            Console.WriteLine($"ElapsedTicks: {stopwatch.ElapsedTicks}");
            Console.WriteLine($"Frequency: {Stopwatch.Frequency} (ticks per second)");
            Console.WriteLine($"ms: {1000.0 * stopwatch.ElapsedTicks / Stopwatch.Frequency}");
        }

        public static void CountLoopTestInFunc()
        {
            RunActionAndLogElapsed(CountLoop);

            void CountLoop()
            {
                var count = 0;
                for (int i = 0; i < 100; i++)
                {
                    count++;
                }
            }

            void RunActionAndLogElapsed(Action action)
            {
                var stopwatch = Stopwatch.StartNew();
                action();
                Console.WriteLine($"ElapsedTicks: {stopwatch.ElapsedTicks}");
                Console.WriteLine($"Frequency: {Stopwatch.Frequency} (ticks per second)");
            }
        }
    }
}
