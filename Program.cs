using System;
using System.Collections.Generic;
using System.Linq;

namespace PageReplacementAlgorithms
{
    internal static class Program
    {
        private const int TestSeries = 100;
        public const int PageCount = 100;
        public const int FrameCount = 10;
        public const int RequestCount = 2000;
        private static readonly Random Random = new Random();
        public static void Main()
        {
            var fcfsFaults = new List<int>();
            var optFaults = new List<int>();
            try
            {
                var fcfs = new Fifo();
                var opt = new Opt();
                for (int i = 0; i < TestSeries; ++i)
                {
                    List<int> requests = GenerateRequests(RequestCount);
                    fcfsFaults.Add(fcfs.Simulate(requests));
                    optFaults.Add(opt.Simulate(requests));
                }
                Console.WriteLine($"FCFS average faults: {fcfsFaults.Average()}");
                Console.WriteLine($"OPT average faults: {optFaults.Average()}");
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
