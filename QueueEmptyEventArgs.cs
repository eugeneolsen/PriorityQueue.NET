using System;

namespace EugeneOlsen.Collections.Generic
{
    public class QueueEmptyEventArgs : EventArgs
    {
        public QueueEmptyEventArgs(int comparisons, int swaps)
        {
            Compares = comparisons;
            Swaps = swaps;
        }

        public int Compares { get; private set; }
        public int Swaps { get; private set; }
    }
}