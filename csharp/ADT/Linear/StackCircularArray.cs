namespace AlgorithmsAndDataStructures.ADT.Linear;

public class StackCircularArray<T>
{
    private T[] _items;

    public StackCircularArray(int capacity = 4)
    {
        _items = new T[capacity];
        Count = 0;
    }

    public int Count { get; private set; }

    public void Push(T item)
    {
        // Resize if full
        if (_items.Length == Count) Resize();

        _items[Count++] = item;
    }

    public T Pop()
    {
        if (Count == 0) throw new InvalidOperationException("Stack is empty");

        Count--;
        var item = _items[Count];
        _items[Count] = default!;
        return item;
    }


    private void Resize()
    {
        var newCapacity = _items.Length * 2;
        var newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _items.Length);
        _items = newArray;
    }
}