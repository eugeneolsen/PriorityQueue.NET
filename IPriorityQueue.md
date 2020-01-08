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

Property | Description
---|---
T this[int index] | Returns the item in the list that underlies the priority queue at the specified index.
int Count | Returns the number of items in the priority queue.
Diagnostics Diagnostics | Gets or sets whether the heap that underlies the priority queue is validated after each Enqueue and Dequeue operation.  Diagnostics = Diagnostics.On adds over 100% performance degradation and should be used only for debugging.
bool IsEmpty | Returns true if the priority queue is empty, otherwise false.
PriorityOrder&nbsp;PriorityOrder | Gets or sets the order of the priority queue to PriorityOrder.Ascending or PriorityOrder.Descending.  If not specified, the default is PriorityOrder.Ascending.
BindingList&lt;T&gt; SortedList | Returns a list sorted in priority order and leaves the priority queue undisturbed.


# Methods

Method | Description
---|---
void Clear | Empties the priority queue.
T Dequeue | Returns the top item in the priority queue and removes it from the queue.
void Enqueue(T item) | Adds an item to the priority queue and reorders the underlying heap.
T Peek | Returns the top item from the priority queue


# Events

Event | Description
---|---
QueueEmpty(QueueEmptyEventArgs) | Occurs when Dequeue empties the priority queue. QueueEmptyEventArgs returns the number of compares made and the number of times queue members were swapped since the queue was last cleared.
