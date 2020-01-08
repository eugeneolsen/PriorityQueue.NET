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
T this[int index] | Returns the item in the list that underlies the priority queue at the specified zero-based index.
int Count | Returns the number of items in the priority queue.  (Inherited from IList&lt;T&gt;.)
Diagnostics Diagnostics | Gets or sets whether the heap structure that underlies the priority queue is validated after each Enqueue and Dequeue operation.  Diagnostics = Diagnostics.On adds over 100% performance degradation and should be used only for debugging.  It is a good practice to set the Diagnostics property to Diagnostics.On in debug builds in the constructor of concrete classes that inherit the IPriorityQueue&lt;T&gt; interface.
bool IsEmpty | Returns true if the priority queue is empty, otherwise false.
PriorityOrder&nbsp;PriorityOrder | Gets the order of the priority queue, either PriorityOrder.Ascending or PriorityOrder.Descending.  This priority order should be set in the constructor of concrete classes that inherit the IPriorityQueue&lt;T&gt; interface.
BindingList&lt;T&gt; SortedList | Returns a list sorted in priority order and leaves the priority queue undisturbed.


# Methods

Method | Description
---|---
void Clear | Empties the priority queue.
T Dequeue | Returns the highest priority item in the priority queue and removes it from the queue.
void Enqueue(T item) | Adds an item to the priority queue and reorders the underlying heap structure.
T Peek | Returns the highest priority item from the priority queue and leaves the queue undisturbed.


# Events

Event | Description
---|---
QueueEmpty(QueueEmptyEventArgs) | Occurs when Dequeue empties the priority queue. QueueEmptyEventArgs returns the number of compares made and the number of times queue members were swapped since the queue was last cleared.
