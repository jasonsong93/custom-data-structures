namespace AlgorithmsAndDataStructures.DataStructures.Trees;

public class MaxHeap<T>
{
    private readonly List<T> _elements = new List<T>();
    private int _count = 0;

    public T GetMax()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("No elements in heap");
        }

        return _elements[0];
    }

    public void Insert(T value)
    {
        _elements.Add(value);
        HeapifyUp(_elements.Count - 1);
    }

    public T ExtractMax()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("Heal is empty");
        }

        T result = _elements[0];
        
        _elements[0] = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        
        HeapifyDown();
        
        return result;
    }
    
    private void HeapifyUp(int elementsCount)
    {
        throw new NotImplementedException();
    }

    private void HeapifyDown()
    {
        throw new NotImplementedException();
    }
}