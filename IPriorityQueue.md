# IPriorityQueue&lt;T&gt; Interface
Namespace: EugeneOlsen.Collections.Generic<br>
Assemblies: EugeneOlsen.Collections.Generic.PriorityQueue.dll

<br>Represents a priority queue of objects of any class that implements IComparable.


```csharp

public interface IPriorityQueue<T> : IBindingList where T : IComparable<T>

```
#### Type Parameters
#### &emsp; T

The type of the elements in the priority queue.

# Examples

```csharp

Example code coming soon!

```

# Properties

T this[int index]

int Count

Diagnostics Diagnostics

bool IsEmpty

BindingList&lt;T&gt; SortedList


# Methods

void Clear

T Dequeue

void Enqueue(T item)

T Peek


# Events

QueueEmpty(QueueEmptyEventArgs)
