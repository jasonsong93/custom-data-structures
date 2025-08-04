namespace AlgorithmsAndDataStructures.ADT.Linear;

public class DequeCircularArray<T>
{
    private int _count;
    private int _head;
    private T[] _items;
    private int _tail;

    public DequeCircularArray(int capacity = 4)
    {
        _items = new T[capacity];
        _count = 0;
        _head = 0;
        _tail = 0;
    }

    public void AddFront(T item)
    {
        if (_count == _items.Length) Resize();

        // Add to front of queue
        // If head is at the start of the array, use % to send to back
        // Head value needs to decrement and wrap
        _head = (_head - 1 + _items.Length) % _items.Length;
        _items[_head] = item;
        _count++;
    }

    public void AddBack(T item)
    {
        if (_count == _items.Length) Resize();

        // We want to add to tail (empty slot)
        // If the incremented tail is out of bounds (items.Length
        // [3, x] -> items.Length = 2, tail would point to index 1
        // When Addback is called, we just place into tail and increment tail with wrapping
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    public T RemoveFront()
    {
        // Get the front value (head points to this)
        // Remove value, increment header using wrap
        if (_count == 0) throw new InvalidOperationException();

        var result = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        _count--;

        return result;
    }

    public T RemoveBack()
    {
        if (_count == 0) throw new InvalidOperationException();

        _tail = (_tail - 1 + _items.Length) % _items.Length;

        var result = _items[_tail];
        _items[_tail] = default!;
        _count--;
        return result;
    }

    public T PeekFront()
    {
        if (_count == 0) throw new InvalidOperationException();

        return _items[_head];
    }

    public T PeekBack()
    {
        if (_count == 0) throw new InvalidOperationException();

        return _items[(_tail - 1 + _items.Length) % _items.Length];
    }

    private void Resize()
    {
        var newCapacity = _items.Length * 2;
        var tempArray = new T[newCapacity];

        // Copy across
        for (var i = 0; i < _count; i++) tempArray[i] = _items[(_head + i) % _items.Length];
        // Update head and tail
        _head = 0;
        _tail = _count;

        _items = tempArray;
    }
}