namespace AlgorithmsAndDataStructures.DataStructures.Graphs;

public class GraphAdjacencyList<T>
{
    private readonly Dictionary<T, List<T>> _adjacencyList = new Dictionary<T, List<T>>();

    // O(1)
    public void AddVertex(T vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
        {
            _adjacencyList.Add(vertex, new List<T>());
        }
    }

    // O(1)
    public void AddEdge(T from, T to)
    {
        AddVertex(from);
        AddVertex(to);
        
        _adjacencyList[from].Add(to);
    }

    // O(V + E), O(V * D) where D = E/V 
    public void RemoveVertex(T vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
        {
            return;
        }
        
        // We want to remove the vertex from every list
        foreach (var v in _adjacencyList.Values)
        {
            v.Remove(vertex);
        }

        _adjacencyList.Remove(vertex);
    }
    
}