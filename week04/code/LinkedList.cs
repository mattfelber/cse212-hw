using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create a new node
        Node newNode = new(value);

        // If the list is empty, set both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode; // Connect current tail to new node
            newNode.Prev = _tail; // Connect new node back to current tail
            _tail = newNode; // Update tail to the new node
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list. This condition will also
        // cover an empty list. It's okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head = _head.Next; // Update the head to point to the second node
            if (_head != null)
            {
                _head.Prev = null; // Disconnect the second node from the first node
            }
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If the list is empty, do nothing
        if (_tail is null)
        {
            return;
        }

        // If there is only one node, set both head and tail to null
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If there are multiple nodes, update the tail and remove the last node
        else
        {
            _tail = _tail.Prev; // Move tail back one node
            if (_tail != null)
            {
                _tail.Next = null; // Disconnect the last node from the list
            }
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // Start searching from the head
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If it's the head node, use RemoveHead()
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If it's the tail node, use RemoveTail()
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // If it's a middle node, update its neighbors and remove it
                else
                {
                    curr.Prev!.Next = curr.Next; // Bridge previous node to the next
                    curr.Next!.Prev = curr.Prev; // Bridge next node to the previous
                }
                
                return; // Exit after removing the first occurrence
            }

            curr = curr.Next; // Move forward in the list
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // Start searching from the head
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue; // Replace value
            }

            curr = curr.Next; // Move forward in the list
        }
    }

    /// <summary>
    /// Yields all values in the linked list.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Move forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        // Start from the tail since we are iterating backward
        var curr = _tail;

        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // Move backward in the linked list
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
