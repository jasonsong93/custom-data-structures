namespace AlgorithmsAndDataStructures.Linear;

public class Array<T>
{
    private readonly T[] _items;

    public Array(int size)
    {
        _items = new T[size];
    }

    public int Length => _items.Length;

    public T Get(int index)
    {
        if (index < 0 || index >= _items.Length)
            throw new IndexOutOfRangeException();
        return _items[index];
    }

    public void Set(int index, T value)
    {
        if (index < 0 || index >= _items.Length)
            throw new IndexOutOfRangeException();
        _items[index] = value;
    }
}