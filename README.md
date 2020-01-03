# PriorityQueue.NET
Generic Priority Queue for the .NET Framework

Starting with ideas and code from Dr. James McCaffrey in a *Visual Studio Magazine* 
[article](https://visualstudiomagazine.com/Articles/2012/11/01/Priority-Queues-with-C.aspx?Page=1 "Priority Queues with C#") 
(11/02/2012), and finding that 
the sample code did not always Dequeue in priority order, I consulted Donald Knuth's *Sorting and Searching* (Volume 3 of
*The Art of Computer Programming* series) for correct construction of Heap structures, Heap Sort, and Priority Queues.

Dr. McCaffrey's ideas for making the class generic work as expected.  His code for the Enqueue method was close, and I reqworked 
the Dequeue method entirely.

Departing from Dr. McCaffrey's original code, I calculate parent-child relationships with ordinals rather than indices.  
Knuth defines a Heap structure as a file [or array] of keys, *K*<sub>1</sub>, *K*<sub>2</sub>, ..., *K*<sub>N</sub> 
if *K*<sub>[*j*/2]</sub> &le; *K*<sub>*j*</sub> for 1 &le; *j*/2 < *j* &le; N, where *j* is the 1-based ordinal key position in the file or array. 
To convert the 1-based ordinal key position to a 0-based array index, we simply subtract 1 from the ordinal.

The PriorityQueue<T> class implements the IPriorityQueue<T> interface.  It will create a PriorityQueue of any type T that 
implements the IComparable interface.  Fortunately, this includes native C# types such as int, double, and string.
