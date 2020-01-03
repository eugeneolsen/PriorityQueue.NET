using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace EugeneOlsen.Collections.Generic
{
    public enum HeapOrder
    {
        MinHeap = 0,
        MaxHeap = 1
    }

    /// <summary>
    /// PriorityQueue
    /// 
    /// Generic Priority Queue
    /// <para>A priority queue is a heap structure.  Donald Knuth defines a heap structure as a tree, which can be implemented as an
    /// array of keys (and optionally associated records) in which K[j/2] &lt;= K[j] for an ascending or "min heap" or
    /// K[j/2] &gt;= K[j] for a descending or "max heap", for 1 &lt;= [j/2] &lt; j &;lt= N</para>
    /// <example>
    /// Where:
    /// <code>
    /// K is a key
    /// j is an ordinal position in the array
    /// N is the size of the array
    /// </code>
    /// </example>
    /// <para>Note that Knuth's definition is 1-based, and array indices in C# are 0-based.   Therefore, we do the heap calculations with the 1-based ordinal number of the array
    /// position (the root of the tree is at ordinal position 1, index 0 of the array). We subtract 1 from the ordinal for the array index, as you will see in the code below.</para>
    /// </summary>
    /// <typeparam name="T">Creates a priority queue of any class T that implements IComparable.CompareTo</typeparam>
    public class PriorityQueue<T> : BindingList<T>, IPriorityQueue<T> where T : IComparable<T>
    {
        public PriorityQueue(HeapOrder order = HeapOrder.MinHeap)
        {
            _heapOrder = order;

            base.RaiseListChangedEvents = false;       // We will raise these events manually when Enqueue and Dequeue are complete.
        }

        IList<T> IPriorityQueue<T>.Items => base.Items;

        // Performance metrics
        private int _swaps;             // Counter for number of swaps in all Enqueue and Dequeue operations
        private int _comparisons;       // Counter for number of comparisions in all Enqueue and Dequeue operations

        // Min Heap or Max Heap
        private HeapOrder _heapOrder;

        public HeapOrder HeapOrder => _heapOrder;

        /// <summary>
        /// Enqueue
        /// 
        /// Enqueues a priority item of type T onto the priority queue
        /// </summary>
        /// <param name="item">The priority item of type T</param>
        public void Enqueue(T item)
        {
            base.Add(item);

            int childOrdinal = base.Count;

            while (childOrdinal > 1)
            {
                int parentOrdinal = childOrdinal / 2;

                T parentNode = base[parentOrdinal - 1];
                T childNode = base[childOrdinal - 1];

                if (!HeapOrderCompare(parentNode.CompareTo(childNode)))
                {
                    break;  // If it's already in priority order, we have no work left to do.
                }

                Swap(parentOrdinal - 1, childOrdinal - 1);

                childOrdinal = parentOrdinal;   // Make the parent the new child
            }

            if (IsHeap())
            {
                base.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
            else
            {
                Debug.Assert(false, "Enqueue did not result in a properly formed Heap structure.");
                // TODO: Create class HeapException
                // TODO: Raise heap exception in release builds
            }
        }

        public T Peek()
        {
            if (0 == base.Count)
            {
                return default(T);
            }

            return base[0];
        }

        public T Dequeue()
        {
            if (0 == base.Count)
            {
                return default(T);
            }

            int lastIndex = base.Count - 1;

            int rootIndex = 0;
            int rootOrdinal = 1;

            T topItem = base[rootIndex];

            Debug.WriteLine($"\nDequeuing Priority Item: {topItem.ToString()}");
            Debug.WriteLine($"Moving {base[lastIndex].ToString()} to root");

            base[rootIndex] = base[lastIndex];

            base.RemoveAt(lastIndex);

            Traverse(rootOrdinal);

            if (IsHeap())
            {
                base.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
            else
            {
                Debug.Assert(false, "Dequeue did not result in a properly formed Heap structure.");
            }

            if (base.Count == 0)
            {
                // TODO: Raise a PriorityQueueEmpty event with PriorityQueueEmptyEventArgs including the swap count and comparison count

                _swaps = 0;
                _comparisons = 0;
            }

            return topItem;
        }

        private bool IsHeap()
        {
            // Check the List and make sure it's a Heap
            int childOrdinal = this.Count;

            int parentOrdinal = childOrdinal / 2;

            int rootOrdinal = 1;

            while (childOrdinal > rootOrdinal && parentOrdinal > 0)
            {
                if (HeapOrderCompare(base[parentOrdinal - 1].CompareTo(base[childOrdinal - 1])))
                {
                    return false;
                }

                childOrdinal--;
                parentOrdinal = childOrdinal / 2;
            }

            return true;
        }

        public new void Clear()
        {
            base.Clear();

            _swaps = 0;
            _comparisons = 0;

            base.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }


        private void Traverse(int ordinal)
        {
            int leftChild = ordinal * 2;

            if (leftChild > base.Count) return;

            int parentIndex = ordinal - 1;
            int leftChildIndex = leftChild - 1;

            T parentNode = base[parentIndex];       // This makes debugging easier
            T leftChildNode = base[leftChildIndex];

            if (HeapOrderCompare(parentNode.CompareTo(leftChildNode)))
            {
                Debug.WriteLine($"Swapping parent {parentNode.ToString()} with left child {leftChildNode.ToString()}");
                Swap(parentIndex, leftChildIndex);

                Traverse(leftChild);
            }

            parentNode = base[parentIndex];     // Update parent node

            int rightChild = leftChild + 1;

            if (rightChild > base.Count) return;

            int rightChildIndex = rightChild - 1;       // This makes debugging easier
            T rightChildNode = base[rightChildIndex];

            if (HeapOrderCompare(parentNode.CompareTo(rightChildNode)))
            {
                Debug.WriteLine($"Swapping parent {parentNode.ToString()} with right child {rightChildNode.ToString()}");
                Swap(parentIndex, rightChildIndex);

                Traverse(rightChild);
            }
        }

        private bool HeapOrderCompare(int compareResult)
        {
            _comparisons++;

            if (_heapOrder == HeapOrder.MinHeap)
            {
                return compareResult > 0;
            }
            else
            {
                return compareResult < 0;
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = base[index1];
            base[index1] = base[index2];
            base[index2] = temp;

            _swaps++;
        }
    }

    // TODO: Add Unit Tests
}