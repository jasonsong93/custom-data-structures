namespace AlgorithmsAndDataStructures.ADT.Hashing;

public class DictionarySeparateChaining<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>>[] _buckets;
    private int _count;

    public DictionarySeparateChaining(int initialCapacity = 16)
    {
        _buckets = new List<KeyValuePair<TKey, TValue>>[initialCapacity];
        for (int i = 0; i < initialCapacity; i++)
        {
            _buckets[i] = new List<KeyValuePair<TKey, TValue>>();
        }
        _count = 0;
    }

    private int GetBucketIndex(TKey key)
    {
        int index = key.GetHashCode();

        return Math.Abs(index % _buckets.Length);
    }

    
}