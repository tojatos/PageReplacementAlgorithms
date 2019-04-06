using System.Collections.Generic;
using System.Linq;

namespace PageReplacementAlgorithms
{
    public class Fifo
    {
        public int Simulate(List<int> items)
        {
            var requestsToTake = new Queue<int>(items);
            var frameBuffer = new Queue<int>();
            int pageFaults = 0;
            while (requestsToTake.Any())
            {
                int request = requestsToTake.Dequeue();
                if(frameBuffer.Contains(request)) continue;
                if (frameBuffer.Count == Program.FrameCount)
                    frameBuffer.Dequeue();
                frameBuffer.Enqueue(request);
                ++pageFaults;
            }

            return pageFaults;

        }
    }
}