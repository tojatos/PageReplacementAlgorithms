using System;
using System.Collections.Generic;
using System.Linq;

namespace PageReplacementAlgorithms
{
    internal static class Program
    {
        private const int TestSeries = 50;
        public const int PageCount = 20;
        public const int FrameCount = 10;
        public const int RequestCount = 2000;
        private static readonly Random Random = new Random();
        public static void Main()
        {
            var fcfsFaults = new List<int>();
            var optFaults = new List<int>();
            var lruFaults = new List<int>();
            var approxLruFaults = new List<int>();
            var randFaults = new List<int>();
            try
            {
                var fcfs = new Fifo();
                var opt = new Opt();
                var lru = new Lru();
                var approxLru = new ApproxLru();
                var rand = new Rand();
                for (int i = 0; i < TestSeries; ++i)
                {
                    List<int> requests = GenerateRequests(RequestCount);
                    fcfsFaults.Add(fcfs.Simulate(requests));
                    optFaults.Add(opt.Simulate(requests));
                    lruFaults.Add(lru.Simulate(requests));
                    approxLruFaults.Add(approxLru.Simulate(requests));
                    //approxLruFaults.Add(approxLru.Simulate(new List<int>{0, 4, 1, 4, 2, 4, 3, 4, 2, 4, 0, 4, 1, 4, 2, 4, 3, 4}));
                    randFaults.Add(rand.Simulate(requests));
                }
                Console.WriteLine($"FIFO average faults: {fcfsFaults.Average()}");
                Console.WriteLine($"OPT average faults: {optFaults.Average()}");
                Console.WriteLine($"LRU average faults: {lruFaults.Average()}");
                Console.WriteLine($"Approx LRU average faults: {approxLruFaults.Average()}");
                Console.WriteLine($"RAND average faults: {randFaults.Average()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static List<int> GenerateRequests(int numberOfRequests)
            => Enumerable.Range(0, numberOfRequests).Select(t => Random.Next(0, PageCount)).ToList();

    }
}
