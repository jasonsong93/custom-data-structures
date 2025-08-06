namespace AlgorithmsAndDataStructures.DataStructures;

public class DoublyLinkedList<T>
{
    private DoublyLinkedListNode<T>? _head;
    private DoublyLinkedListNode<T>? _tail;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public void AddFirst(T value)
    {
        var newNode = new DoublyLinkedListNode<T>(value);
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }

        _count++;
    }

    public void AddLast(T value)
    {
        var newNode = new DoublyLinkedListNode<T>(value);
        if (_tail == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }

        _count++;
    }

    public bool Remove(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (Equals(current.Value, value))
            {
                RemoveNode(current);
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    private void RemoveNode(DoublyLinkedListNode<T> node)
    {
        if (node.Prev != null)
            node.Prev.Next = node.Next;
        else
            _head = node.Next;

        if (node.Next != null)
            node.Next.Prev = node.Prev;
        else
            _tail = node.Prev;

        _count--;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    private DoublyLinkedListNode<T>? Find(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (Equals(current.Value, value))
                return current;
            current = current.Next;
        }

        return null;
    }

    public void Clear()
    {
        _head = _tail = null;
        _count = 0;
    }

    public IEnumerable<T> Forward()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public IEnumerable<T> Backward()
    {
        var current = _tail;
        while (current != null)
        {
            yield return current.Value;
            current = current.Prev;
        }
    }
}

public class DoublyLinkedListNode<T>
{
    public T Value;
    public DoublyLinkedListNode<T> Prev;
    public DoublyLinkedListNode<T> Next;

    public DoublyLinkedListNode(T value)
    {
        Value = value;
    }
}