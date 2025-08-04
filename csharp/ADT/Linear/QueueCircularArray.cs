namespace AlgorithmsAndDataStructures.ADT.Linear;

// This will be a circular queue - faster than regular array without pointers for dequeueing esp
public class QueueCircularArray<T>
{
    private int _count;
    private int _head;
    private T[] _items;
    private int _tail;


    public QueueCircularArray(int capacity = 4)
    {
        _items = new T[capacity];
        _count = 0;
        _head = 0;
        _tail = 0;
    }

    public void Enqueue(T item)
    {
        if (_count == _items.Length) Resize();

        _items[_tail] = item;
        _count++;
        // Increment by 1
        // modulo by the length of the array so it's now at the "start" OR just the value itself
        // a % b = a  IF a < b
        // a % b => remainder IF a >= b
        _tail = (_tail + 1) % _items.Length;
    }

    public T Dequeue()
    {
        if (_count == 0) throw new InvalidOperationException();

        var item = _items[_head];
        _items[_head] = default!;
        _count--;
        _head = (_head + 1) % _items.Length;

        return item;
    }

    public T Peek()
    {
        return _items[_head];
    }

    private void Resize()
    {
        var newCapacity = _items.Length * 2;
        var newArray = new T[newCapacity];

        for (var i = 0; i < _count; i++)
            // resize here - note circular dependency
            // [x, x, x, 3, 4, 5] -> [3, 4, 5, x, x, x, x...]
            newArray[i] = _items[(_head + i) % _items.Length];

        _head = 0;
        _tail = _count;

        _items = newArray;
    }
}