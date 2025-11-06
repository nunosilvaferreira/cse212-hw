using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - PriorityQueue
// Write and run test cases. Record any defects found above each test method.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three elements with different priorities.
    // Expected Result: Highest priority item should be dequeued first.
    // Defect(s) Found: The loop in Dequeue() ignored the last element and didn't remove items.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("Medium", 5);
        queue.Enqueue("High", 10);

        var result = queue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple elements with the same priority.
    // Expected Result: Dequeue should return them in FIFO order.
    // Defect(s) Found: Needed to ensure FIFO order among same-priority items.
    public void TestPriorityQueue_EqualPrioritiesFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("First", 5);
        queue.Enqueue("Second", 5);
        queue.Enqueue("Third", 5);

        Assert.AreEqual("First", queue.Dequeue());
        Assert.AreEqual("Second", queue.Dequeue());
        Assert.AreEqual("Third", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue alternately, mixing priorities.
    // Expected Result: Always returns highest priority available at each step.
    // Defect(s) Found: Dequeue previously ignored correct ordering of mixed priority and order.
    public void TestPriorityQueue_MixedOperations()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 4);
        Assert.AreEqual("B", queue.Dequeue());

        queue.Enqueue("C", 10);
        queue.Enqueue("D", 3);
        Assert.AreEqual("C", queue.Dequeue());
        Assert.AreEqual("D", queue.Dequeue());
        Assert.AreEqual("A", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException("The queue is empty.").
    // Defect(s) Found: Exception message and type fixed to match test requirements.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var queue = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Check ToString() output for visual verification.
    // Expected Result: String should contain items in proper [value (Pri:x)] format.
    // Defect(s) Found: None. ToString() method works as intended.
    public void TestPriorityQueue_ToStringFormat()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Alice", 1);
        queue.Enqueue("Bob", 2);
        queue.Enqueue("Carol", 3);

        var s = queue.ToString();
        StringAssert.Contains(s, "Alice (Pri:1)");
        StringAssert.Contains(s, "Bob (Pri:2)");
        StringAssert.Contains(s, "Carol (Pri:3)");
    }
}
