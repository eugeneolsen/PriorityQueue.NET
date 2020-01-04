using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace EugeneOlsen.Collections.Generic
{
    public interface IPriorityQueue<T> : IBindingList where T : IComparable<T>
    {
        event EventHandler<QueueEmptyEventArgs> QueueEmptyEvent;

        void Enqueue(T item);

        T Peek();

        T Dequeue();

        bool IsEmpty { get; }

        IList<T> Items { get; }

        PriorityOrder PriorityOrder { get; }

        BindingList<T> SortedList { get; }

        new T this[int index] { get; }

        new void Clear();
    }
}