# PriorityQueue.NET
Generic Priority Queue for the .NET Framework

Most class libraries include a Priority Queue class.  The C++ Standard Template Library (STL) has one; The Boost libraries also have one.  Java's library contains a Priority Queue class.  Python has a heapq.  Go's library contains one, as do the Standard PHP Library extension and Apple's Core Foundation framework.  But the .NET Framework does not have one.  This generic PriorityQueue class fills that gap.

A Priority Queue is a data structure like a queue, with the additional feature that each item in the queue 
has a priority and the highest priority item in the queue is dequeued first, then the next highest priority,
and so forth.  The top priority may be defined as the highest or the lowest value.

Many Priority Queues, including this one, are built on a Heap structure.  In so doing, the Priority Queue can 
be considered as a one-step-at-a-time Heap Sort.  Enqueuing the elements of an unsorted list and then repeatedly Dequeuing until the Priority Queue is empty yields a sorted list.

Starting with ideas and code from Dr. James McCaffrey in a *Visual Studio Magazine* 
[article](https://visualstudiomagazine.com/Articles/2012/11/01/Priority-Queues-with-C.aspx?Page=1 "Priority Queues with C#"), and finding that 
the sample code did not always dequeue in priority order, I consulted Donald Knuth's *Sorting and Searching* (Volume 3 of
*The Art of Computer Programming* series) for correct construction of Heap structures, Heap Sort, and Priority Queues.

Dr. McCaffrey's ideas for making the class generic work as expected.  His code for the Enqueue method was close; I reworked the Dequeue method entirely.

Departing from Dr. McCaffrey's code, I calculate parent-child relationships with ordinals rather than indices.  
Knuth defines a Heap structure as a file [or array] of keys, *K*<sub>1</sub>, *K*<sub>2</sub>, ..., *K*<sub>N</sub> 
if 

&emsp;&emsp;&emsp;&emsp;*K*<sub>[*j*/2]</sub> &le; *K*<sub>*j*</sub> for 1 &le; *j*/2 < *j* &le; N

where *j* is the 1-based ordinal key position in the file or array. 
To convert the 1-based ordinal key position to a 0-based array index, we simply subtract 1 from the ordinal.

The PriorityQueue<T> class implements the IPriorityQueue<T> interface.  It will create a PriorityQueue of any type T that 
implements the IComparable interface.  Fortunately, this includes native C# types such as int, double, and string.
  

&copy; 2020 Eugene C. Olsen

The use of this software is subject to the terms of the [Microsoft Public License (MS-PL)](https://opensource.org/licenses/MS-PL)
