﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PageReplacementAlgorithms
{
    public class Opt
    {
        public int Simulate(List<int> items)
        {
            var requestsToTake = new Queue<int>(items);
            var frameBuffer = new List<int>();
            int pageFaults = 0;
            while (requestsToTake.Any())
            {
                int request = requestsToTake.Dequeue();
                if(frameBuffer.Contains(request)) continue;
                if (frameBuffer.Count == Program.FrameCount)
                {
                    List<int> notUsedLongestIndexCandidates = frameBuffer.Select(b => requestsToTake.ToList().IndexOf(b)).ToList();
                    int notUsedLongestNumber = notUsedLongestIndexCandidates.Any(i => i == -1)
                        ? frameBuffer.First(i => !requestsToTake.Contains(i))
                        : requestsToTake.ToList()[notUsedLongestIndexCandidates.Max()];
                    frameBuffer.Remove(notUsedLongestNumber);
                }
                frameBuffer.Add(request);
                ++pageFaults;
            }

            return pageFaults;

        }
    }
}