using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PageReplacementAlgorithms
{
    public class Rand
    {
        public int Simulate(List<int> items)
        {
            var requestsToTake = new Queue<int>(items);
            var frameBuffer = new List<int>();
            var rng = new Random();
            int pageFaults = 0;
            while (requestsToTake.Any())
            {
                int request = requestsToTake.Dequeue();
                
                if(frameBuffer.Contains(request)) continue;
                if (frameBuffer.Count == Program.FrameCount)
                    frameBuffer.RemoveAt(rng.Next(0, Program.FrameCount));
                frameBuffer.Add(request);
                ++pageFaults;
            }

            return pageFaults;

        }
    }
}