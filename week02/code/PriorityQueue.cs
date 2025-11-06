public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The item is always added to the back of the queue regardless of its priority.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes and returns the value with the highest priority.
    /// If multiple values have the same highest priority, the one that was enqueued first is removed.
    /// Throws an InvalidOperationException if the queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find highest priority
        var highestPriority = _queue.Max(item => item.Priority);

        // Find the first (oldest) item with that priority (FIFO among equals)
        var index = _queue.FindIndex(item => item.Priority == highestPriority);

        var value = _queue[index].Value;
        _queue.RemoveAt(index);

        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
