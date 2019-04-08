using System;
using System.Collections.Generic;
using System.Linq;

namespace PageReplacementAlgorithms
{
    public class ApproxLru
    {
        public int Simulate(List<int> items)
        {
            var requestsToTake = new Queue<int>(items);
            var lruList = new List<int>();
            var secondChanceSet = new HashSet<int>();
            var frameBuffer = new List<int>();
            int pageFaults = 0;
            while (requestsToTake.Any())
            {
                int request = requestsToTake.Dequeue();

                if (lruList.Contains(request)) lruList.Remove(request);
                lruList.Add(request);

                if (frameBuffer.Contains(request))
                {
                    secondChanceSet.Add(request);
                    continue;
                }
                if (frameBuffer.Count == Program.FrameCount)
                {
                    int? leastRecentlyUsed = null;
                    foreach (int i in lruList.FindAll(i => frameBuffer.Contains(i)))
                    {
                        if (secondChanceSet.Contains(i))
                        {
                            secondChanceSet.Remove(i);
                            continue;
                        }

                        leastRecentlyUsed = i;
                        break;
                    }

                    frameBuffer.Remove(leastRecentlyUsed ?? lruList.First(i => frameBuffer.Contains(i)));
                }
                frameBuffer.Add(request);
                ++pageFaults;
                //Console.WriteLine(string.Join(", ", frameBuffer).TrimEnd(',', ' '));
                //Console.WriteLine(string.Join(", ", secondChanceSet).TrimEnd(',', ' '));
            }

            return pageFaults;

        }
    }
}