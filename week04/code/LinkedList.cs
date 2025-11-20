using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
            return;
        }

        if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_tail is null)
        {
            return;
        }

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
            return;
        }

        var prev = _tail.Prev!;
        prev.Next = null;
        _tail = prev;
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        if (_head is null)
        {
            return;
        }

        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // only node
                if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                    return;
                }

                // removing head
                if (curr == _head)
                {
                    _head = _head.Next;
                    if (_head is not null)
                        _head.Prev = null;
                    return;
                }

                // removing tail
                if (curr == _tail)
                {
                    _tail = _tail.Prev;
                    if (_tail is not null)
                        _tail.Next = null;
                    return;
                }

                // middle
                var prev = curr.Prev!;
                var next = curr.Next!;
                prev.Next = next;
                next.Prev = prev;
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Replace all occurrences of oldValue with newValue.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list (forward).
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // For tests or debugging
    public bool HeadAndTailAreNull() => _head is null && _tail is null;
    public bool HeadAndTailAreNotNull() => _head is not null && _tail is not null;
}

/// <summary>
/// Node class used by LinkedList.
/// </summary>
public class Node
{
    public int Data;
    public Node? Next;
    public Node? Prev;

    public Node(int data)
    {
        Data = data;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
