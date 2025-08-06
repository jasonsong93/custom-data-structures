namespace AlgorithmsAndDataStructures.DataStructures.Trees;

public class BinaryTree<T>
{
    private TreeNode<T> _root;

    public void Insert(T item)
    {
        var newNode = new TreeNode<T>(item);

        if (_root == null)
        {
            _root = newNode;

            return;
        }
        
        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Left == null)
            {
                current.Left = newNode;
                return;
            }
            else
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right == null)
            {
                current.Right = newNode;
                return;
            }
            else
            {
                queue.Enqueue(current.Right);
            }
        }
    }
    
    // Let's implement all 3 traversal types
    // Preorder, Inorder, Postorder, Level-
    // Just return a list of the nodes to the user
    
    public List<T> PreOrderTraversal()
    {
        var result = new List<T>();
        PreOrderHelper(_root, result);
        return result;
    }

    private void PreOrderHelper(TreeNode<T> node, List<T> result)
    {
        if (node == null)
        {
            return;
        }
        
        result.Add(node.Value);
        PreOrderHelper(node.Left, result);
        PreOrderHelper(node.Right, result);
    }

    public List<T> InOrderTraversal()
    {
        var result = new List<T>();
        InOrderTraversalHelper(_root, result);
        return result;
    }

    private void InOrderTraversalHelper(TreeNode<T> node, List<T> result)
    {
        if (node == null)
        {
            return;
        }
        
        InOrderTraversalHelper(node.Left, result);
        result.Add(node.Value);
        InOrderTraversalHelper(node.Right, result);
    }
    
    public List<T> PostOrderTraversal()
    {
        var result = new List<T>();
        PostOrderHelper(_root, result);
        return result;
    }

    private void PostOrderHelper(TreeNode<T> node, List<T> result)
    {
        if (node == null)
        {
            return;
        }
        PostOrderHelper(node.Left, result);
        PostOrderHelper(node.Right, result);
        result.Add(node.Value);
    }
}

public class TreeNode<T>
{
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }
    public T Value { get; }

    public TreeNode(T value)
    {
        Value = value;
    }
}