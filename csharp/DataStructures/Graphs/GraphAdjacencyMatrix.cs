namespace AlgorithmsAndDataStructures.DataStructures.Graphs;

public class GraphAdjacencyMatrix<T>
{
    private readonly List<T> _vertices = new();
    private readonly Dictionary<T, int> _vertexToIndex = new();
    private int[,] _matrix;

    public GraphAdjacencyMatrix(int initialCapacity = 4)
    {
        _matrix = new int[initialCapacity, initialCapacity];
    }

    public void AddVertex(T vertex)
    {
        // Check if vertex exists
        if (_vertexToIndex.ContainsKey(vertex))
        {
            return;
        }

        // Adding a new entry to the dictionary,
        // where the key (K) is the vertex,
        // and the value (V) is the row/column index
        _vertexToIndex[vertex] = _vertices.Count;
        _vertices.Add(vertex);

        if (_vertices.Count > _matrix.GetLength(0))
            ResizeMatrix(_vertices.Count);
    }

    public void AddEdge(T source, T destination)
    {
        AddVertex(source);
        AddVertex(destination);

        var i = _vertexToIndex[source];
        var j = _vertexToIndex[destination];

        _matrix[i, j] = 1;
    }

    public void RemoveEdge(T source, T destination)
    {
        if (!HasVertex(source) || !HasVertex(destination))
        {
            return;
        }

        var i = _vertexToIndex[source];
        var j = _vertexToIndex[destination];

        _matrix[i, j] = 0;
    }
    
    private bool HasVertex(T vertex)
    {
        return _vertexToIndex.ContainsKey(vertex);
    }

    private void ResizeMatrix(int size)
    {
        var newMatrix = new int[size, size];
        
        for (var i = 0; i < _matrix.GetLength(0); ++i)
        {
            for (var j = 0; j < _matrix.GetLength(0); ++j)
            {
                newMatrix[i, j] = _matrix[i, j];
            }
        }

        _matrix = newMatrix;
    }
}