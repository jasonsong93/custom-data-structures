namespace AlgorithmsAndDataStructures.DataStructures.Hashing;

public class HashSetSeparateChaining<T>
{
    private List<T>[] _buckets;
    private int _count;
    
    public HashSetSeparateChaining(int initialCapacity = 16)
    {
        _buckets = new List<T>[initialCapacity];
        
        for (var i = 0; i < initialCapacity; i++)
        {
            _buckets[i] = new List<T>();
        }

        _count = 0;
    }

    private int GetBucketIndex(T item)
    {
        if (item == null) return 0;
        var hash = item.GetHashCode();
        return Math.Abs(hash % _buckets.Length);
    }

    public bool Add(T item)
    {
        // do the hash thing
        // place into the array with that hash value (int)
        // if there's a collision, add to next element of the list

        var index = GetBucketIndex(item);
        
        // We have the index, now we want to add it to the list of items
        if (_buckets[index].Contains(item))
        {
            return false;
        }

        _buckets[index].Add(item);
        _count++;

        return true;
    }

    public bool Contains(T item)
    {
        var index = GetBucketIndex(item);
        
        return _buckets[index].Contains(item);
    }

    public bool Remove(T item)
    {
        var index = GetBucketIndex(item);

        // Remove the item from the list if it exists - note you can't clear the list
        // because of hash collision, you might need to store it
        // We need to check if it exists in the list to remove
        if (_buckets[index].Contains(item))
        {
            // We remove it only if it exists
            _buckets[index].Remove(item);
            _count--;

            return true;
        }

        return false;
    }

    public int Count => _count;
} 