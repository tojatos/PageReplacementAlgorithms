using System;
using System.Collections.Generic;
using System.Linq;

namespace PageReplacementAlgorithms
{
    public class Lru
    {
        public int Simulate(List<int> items)
        {
            var requestsToTake = new Queue<int>(items);
            var lruList = new List<int>();
            var frameBuffer = new List<int>();
            int pageFaults = 0;
            while (requestsToTake.Any())
            {
                int request = requestsToTake.Dequeue();

                if (lruList.Contains(request)) lruList.Remove(request);
                lruList.Add(request);
                
                if(frameBuffer.Contains(request)) continue;
                if (frameBuffer.Count == Program.FrameCount)
                {
                    int leastRecentlyUsed = lruList.First(i => frameBuffer.Contains(i));
                    frameBuffer.Remove(leastRecentlyUsed);
                }
                frameBuffer.Add(request);
                ++pageFaults;
                //Console.WriteLine(string.Join(", ", frameBuffer).TrimEnd(',', ' '));
            }

            return pageFaults;

        }
    }
}