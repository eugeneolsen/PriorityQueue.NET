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

Two examples follow.  The first demonstrates basic usage of the PriorityQueue&lt;T&gt; class.  The second shows a more practical application: quickly and efficiently merging sorted arrays.

Examples were created with Visual Studio 2019 targeting the .NET Framework 4.8.  

### Basic Usage
In this example, the higher customer number has the higher priority.  The PriorityQueue constructor specifies a priority queue with PriorityOrder.Descending.
```csharp

using System;
using System.ComponentModel;

using EugeneOlsen.Collections.Generic;

namespace PriorityQueueExample
{
    class Program
    {
        private static void OnQueueEmpty(object sender, QueueEmptyEventArgs e)
        {
            Console.WriteLine($"\nPriority queue is empty. Compares: {e.Compares}, swaps: {e.Swaps}\n");
        }

        static void Main(string[] args)
        {
            IPriorityQueue<Customer> customerQueue = new PriorityQueue<Customer>(PriorityOrder.Descending);

            customerQueue.QueueEmpty += OnQueueEmpty;

            customerQueue.Enqueue(new Customer(401, "Wang", "Judy"));
            customerQueue.Enqueue(new Customer(3, "Singh", "Babaji"));
            customerQueue.Enqueue(new Customer(56, "Fernandez", "Guadalupe"));
            customerQueue.Enqueue(new Customer(42, "Adams", "Douglas"));
            customerQueue.Enqueue(new Customer(101, "de Vil", "Cruella"));
            customerQueue.Enqueue(new Customer(9, "van Beethoven", "Ludwig"));
            customerQueue.Enqueue(new Customer(256, "Cratchit", "Robert"));

            BindingList<Customer> customerList = customerQueue.SortedList;

            Console.WriteLine("Sorted list of customers:\n");

            foreach(var customer in customerList)
            {
                Console.WriteLine(customer.ToString());
            }

            Console.WriteLine("\n\nList of Dequeued customers:\n");

            while (!customerQueue.IsEmpty)
            {
                Console.WriteLine(customerQueue.Peek().ToString());

                _ = customerQueue.Dequeue();
            }

            Console.WriteLine("\n  Press any key to continue...");
            _ = Console.ReadKey();
        }
    }

    /// <summary>
    /// Very minimal Customer class
    /// </summary>
    class Customer : IComparable<Customer>
    {
        public Customer(int id, string lastName, string firstName)
        {
            ID = id;
            LastName = lastName;
            FirstName = firstName;
        }

        int ID { get; }
        string LastName { get; }
        string FirstName { get; }

        public int CompareTo(Customer other)
        {
            if (this.ID > other.ID) return 1;

            if (this.ID < other.ID) return -1;

            return 0;
        }

        public new string ToString()
        {
            return $"Customer {ID}: {LastName}, {FirstName}";
        }
    }
}
```

### Merge Sorted Arrays
```csharp
using System;
using System.ComponentModel;

using EugeneOlsen.Collections.Generic;

namespace MergeSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray =
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 0, 2, 4, 6, 8, 10, 12 },
                new int[] { 11, 22, 33, 44, 55},
                new int[] { 3, 6, 9, 12, 15, 18, 21, 24},
                new int[] { 7, 14, 21, 28, 35, 42}
            };

            IPriorityQueue<int> intQueue = new PriorityQueue<int>(PriorityOrder.Ascending);

            int maxLength = 0;

            foreach (var intArray in jaggedArray)
            {
                if (intArray.Length > maxLength) maxLength = intArray.Length;
            }

            for (int i = 0;  i < maxLength; i++)
            {
                for (int j = 0; j < jaggedArray.Length; j++)
                {
                    if (i < jaggedArray[j].Length)
                    {
                        intQueue.Enqueue(jaggedArray[j][i]);
                    }
                }
            }

            BindingList<int> list = intQueue.SortedList;

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            intQueue.Clear();

            Console.WriteLine("\n  Press any key to continue...");
            _ = Console.ReadKey();
        }
    }
}
```

# Properties

Property | Description
---|---
T this[int index] | Returns the item in the list that underlies the priority queue at the specified zero-based index.
int Count | Returns the number of items in the priority queue.  (Inherited from IList&lt;T&gt;.)
Diagnostics Diagnostics | Gets or sets whether the heap structure that underlies the priority queue is validated after each Enqueue and Dequeue operation.  Diagnostics = Diagnostics.On adds over 100% performance degradation and should be used only for debugging.  It is a good practice to set the Diagnostics property to Diagnostics.On in Debug builds and Diagnostics.Off in Release builds in the constructor of concrete classes that inherit the IPriorityQueue&lt;T&gt; interface.
bool IsEmpty | Returns true if the priority queue is empty, otherwise false.
PriorityOrder&nbsp;PriorityOrder | Gets the order of the priority queue, either PriorityOrder.Ascending or PriorityOrder.Descending.  This priority order should be passed to the constructor of concrete classes that inherit the IPriorityQueue&lt;T&gt; interface.  The default is PriorityOrder.Ascending.
BindingList&lt;T&gt; SortedList | Returns a list of all priority queue items sorted in priority order and leaves the priority queue undisturbed.


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
