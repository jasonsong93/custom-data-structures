namespace AlgorithmsAndDataStructures.DataStructures;

public class LinkedList<T>
{
    private LinkedListNode<T> _head;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _count == 0;


    public void AddFirst(T value)
    {
        var newNode = new LinkedListNode<T>(value);
        newNode.Next = _head;
        _head = newNode;

        _count++;
    }

    public void AddLast(T value)
    {
        var newNode = new LinkedListNode<T>(value);

        if (_count == 0)
        {
            _head = newNode;
        }
        else
        {
            // 1. Iterate to end of list
            // 2. Set current.Next to newNode
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        _count++;
    }

    public bool Remove(T value)
    {
        if (_head == null)
        {
            return false;
        }
       
        // When you're removing the head, exception case
        if (value != null && value.Equals(_head.Value))
        {
            _head = _head.Next;
            _count--;
            return true;
        }

        var current = _head;

        // 1. Search for it
        // 2. Remove it
        // 3. Pointer updates for next
        while (current.Next != null && !current.Next.Value.Equals(value))
        {
            current = current.Next;
        }
        
        // Reached end of list, didn't find it
        if (current.Next == null)
        {
            return false;
        }
        
        // We found it - remove and return true
        current.Next = current.Next.Next;
        _count--;
        return true;
    }

    public bool Contains(T value)
    {
        var current = _head;
        while (current.Next != null)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }

            current = current.Next;
        }
        return false;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        var current = _head;
        for (var i = 0; i < index; i++)
        {
            current = current!.Next;
        }

        return current!.Value;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }
}

public class LinkedListNode<T>
{
    public T Value;
    public LinkedListNode<T>? Next;
    
    public LinkedListNode(T value)
    {
        Value = value;
        Next = null;
    }
}