namespace AlgorithmsAndDataStructures.Linear;

public class List<T>
{
    private T[] _items;

    public List(int capacity = 4)
    {
        _items = new T[capacity];
        Count = 0;
    }

    public int Count { get; private set; }

    public void Add(T item)
    {
        if (_items.Length == Count) Resize();

        _items[Count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
        return _items[index];
    }

    public void Set(int index, T value)
    {
        if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

        _items[index] = value;
    }

    private void Resize()
    {
        var newSize = _items.Length * 2;
        var newArray = new T[newSize];

        Array.Copy(_items, newArray, _items.Length);

        _items = newArray;
    }
}