namespace AlgorithmsAndDataStructures.DataStructures.Hashing;

public class DictionarySeparateChaining<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>>[] _buckets;
    private int _count;

    public DictionarySeparateChaining(int initialCapacity = 16)
    {
        _buckets = new List<KeyValuePair<TKey, TValue>>[initialCapacity];
        for (var i = 0; i < initialCapacity; i++)
        {
            _buckets[i] = new List<KeyValuePair<TKey, TValue>>();
        }
        _count = 0;
    }

    public int Count => _count;

    private int GetBucketIndex(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var index = key.GetHashCode();
        return Math.Abs(index % _buckets.Length);
    }

    public void Add(TKey key, TValue value)
    {
        var index = GetBucketIndex(key);
        var bucket = _buckets[index];

        foreach (var kvp in bucket)
        {
            if (kvp.Key.Equals(key))
            {
                throw new ArgumentException("Key with same exists");
            }
        }

        bucket.Add(new KeyValuePair<TKey, TValue>(key, value));
        _count++;
    }

    public bool Remove(TKey key)
    {
        var index = GetBucketIndex(key);
        var bucket = _buckets[index];

        for (var i = 0; i < bucket.Count; i++)
        {
            if (bucket[i].Key.Equals(key))
            {
                bucket.RemoveAt(i);
                _count--;
                return true;
            }
        }

        return false;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var index = GetBucketIndex(key);
        var bucket = _buckets[index];

        foreach (var kvp in bucket)
        {
            if (kvp.Key.Equals(key))
            {
                value = kvp.Value;
                return true;
            }
        }

        value = default!;
        return false;
    }

    public bool ContainsKey(TKey key)
    {
        return TryGetValue(key, out _);
    }
}