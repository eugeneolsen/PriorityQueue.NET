using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace EugeneOlsen.Collections.Generic
{
    public interface IPriorityQueue<T> : IBindingList where T : IComparable<T>
    {
        event EventHandler<QueueEmptyEventArgs> QueueEmpty;    // Fires when Dequeue empties the queue.

        void Enqueue(T item);   // Enqueues an item of class T onto the Priority Queue.

        T Peek();   // Returns the highest priority item in the Priority Queue and leaves it on the queue.

        T Dequeue();    // Returns the highest priority item in the Priority Queue and removes it from the queue.

        bool IsEmpty { get; }   // Returns true if the queue is empty, otherwise, false.

        Diagnostics Diagnostics { get; set; }   // If on, validates the underlying heap after each Enqueue and Dequeue.

        IList<T> Items { get; }     // Returns a list of items in the BindingList.  Used by DataGridView and other clients.

        PriorityOrder PriorityOrder { get; }    // Tells if the priority order is ascending or descending.

        BindingList<T> SortedList { get; }  // Returns a list of enqueued items in priority order without disturbing the queue.

        new T this[int index] { get; }  // Provides direct access to queue items by index.

        new void Clear();   // Empties the Priority Queue.
    }
}