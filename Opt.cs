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
                    int notUsedLongestIndex = frameBuffer.Select(b => requestsToTake.ToList().IndexOf(b)).Max();
                    if(notUsedLongestIndex != -1)frameBuffer.Remove(requestsToTake.ToList()[notUsedLongestIndex]);
                    else frameBuffer.RemoveAt(0);
                }
                frameBuffer.Add(request);
                ++pageFaults;
            }

            return pageFaults;

        }
    }
}