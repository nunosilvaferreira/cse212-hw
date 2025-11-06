using System;
using System.Collections.Generic;

public class SimpleQueueSolution
{
    private readonly List<int> _queue = new();

    private void Enqueue(int value)
    {
        _queue.Add(value); // Corrected: add to end of queue
    }

    private int Dequeue()
    {
        if (_queue.Count == 0)
            throw new IndexOutOfRangeException("Queue is empty");

        var value = _queue[0]; // Corrected: remove from front
        _queue.RemoveAt(0);
        return value;
    }

    public static void Run()
    {
        Console.WriteLine("=== Simple Queue Solution ===");

        // Test 1
        var queue = new SimpleQueueSolution();
        queue.Enqueue(100);
        Console.WriteLine(queue.Dequeue());

        // Test 2
        queue = new SimpleQueueSolution();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());

        // Test 3
        queue = new SimpleQueueSolution();
        try
        {
            queue.Dequeue();
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Caught expected exception.");
        }
    }
}
