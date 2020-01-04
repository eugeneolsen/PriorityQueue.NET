using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EugeneOlsen.Collections.Generic
{
    public interface IPriorityQueue<T> : IBindingList where T : IComparable<T>
    {
        event EventHandler<QueueEmptyEventArgs> QueueEmptyEvent;

        void Enqueue(T item);

        T Peek();

        T Dequeue();

        IList<T> Items { get; }

        HeapOrder HeapOrder { get; }

        BindingList<T> SortedList { get; }

        new T this[int index] { get; }

        new void Clear();
    }
}