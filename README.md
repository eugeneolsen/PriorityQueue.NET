# PriorityQueue.NET
Generic Priority Queue for the .NET Framework

Starting with ideas and code from Dr. James McCaffrey in Visual Studio Magazine (11/02/2012), and finding that 
the sample code did not always Dequeue in priority order, I consulted Donald Knuth's Sorting and Searching (Volume 3 of
The Art of Computer Programming series) for correct construction of Heap structures, Heap Sort, and Priority Queues.

Dr. McCaffrey's ideas for making the class generic worked well.  His code for the Enqueue method was close, and I reqworked 
the Dequeue method entirely.

Departing from Dr. McCaffrey's original code, I calculate parent-child relationships with ordinals rather than indices.  
Knuth defines a Heap structure as a file [or array] of keys, K1, K2, ..., KN if K[j/2] <= Kj for 1 <= j/2 < j <= N, where j is
the 1-based ordinal record number in the file or array.
