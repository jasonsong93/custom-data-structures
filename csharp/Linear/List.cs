namespace AlgorithmsAndDataStructures.Linear;

public class List<T>
{
    private T[] _items;
    private int _count;

    public List(int capacity = 4)
    {
        _items = new T[capacity];
        _count = 0;
    }
    
    public int Count => _count;

    public void Add(T item)
    {
        if (_items.Length == _count)
        {
            Resize();
        }

        _items[_count++] = item;
    }

    public T Get(int index)
    {
        if (index <= 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }
        return _items[index];
    }

    public void Set(int index, T value)
    {
        if (index <= 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        _items[index] = value;
    }

    private void Resize()
    {
        var newSize = _items.Length * 2;
        var newArray = new T[newSize];

        for (int i = 0; i < newSize; i++)
        {
            newArray[i] = _items[i];
        }

        _items = newArray;
    }
}