# ProrityQueue&lt;T&gt; Class

Namespace: EugeneOlsen.Collections.Generic<br>
Assemblies: EugeneOlsen.Collections.Generic.PriorityQueue.dll

<br>Creates and manages a priority queue of objects of any class that implements IComparable.

```csharp

public class PriorityQueue<T> : BindingList<T>, IPriorityQueue<T> where T : IComparable<T>

```
#### Type Parameters
#### &emsp; T

The type of the elements in the priority queue.

# Examples

```

Example code coming soon!

```


# Remarks

Use the properties, methods, and events of the IPriorityQueue&lt;T&gt; interface.

The PriorityQueue&lt;T&gt; class inherits from BindingList&lt;T&gt; in order to automatically update DataGridView and similar bound clients.
