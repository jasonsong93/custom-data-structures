namespace AlgorithmsAndDataStructures.DataStructures.Trees;

// Made it non-generic so it's a bit simpler
public class BinarySearchTree
{
    private BinarySearchTreeNode _root;

    public void Insert(int value)
    {
        _root = InsertRecursive(_root, value);
    }

    private BinarySearchTreeNode InsertRecursive(BinarySearchTreeNode current, int value)
    {
        // If the root node was null
        if (current == null)
        {
            return new BinarySearchTreeNode(value);
        }
        
        // Enforce BST invariant where L < R
        if (value < current.Value)
        {
            current.Left = InsertRecursive(current.Left, value);
        }
        else if (value > current.Value)
        {
            current.Right = InsertRecursive(current.Right, value);
        }

        return current;
    }

    public void PrintInOrder()
    {
        PrintInOrderHelper(_root);
    }

    private void PrintInOrderHelper(BinarySearchTreeNode node)
    {
        if (node == null)
        {
            return;
        }
        PrintInOrderHelper(node.Left);
        Console.WriteLine($"Node value is {node.Value}");
        PrintInOrderHelper(node.Right);
    }

    public void PrintPreOrder()
    {
        PrintPreOrderHelper(_root);
    }

    private void PrintPreOrderHelper(BinarySearchTreeNode node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine($"Node value is {node.Value}");
        PrintPreOrderHelper(node.Left);
        PrintPreOrderHelper(node.Right);
    }
    
    public void PrintPostOrder()
    {
        PrintPostOrderHelper(_root);
    }

    private void PrintPostOrderHelper(BinarySearchTreeNode node)
    {
        if (node == null)
        {
            return;
        }

        PrintPostOrderHelper(node.Left);
        PrintPostOrderHelper(node.Right);
        Console.WriteLine($"Node value is {node.Value}");
    }

    public void PrintLevelOrder()
    {
        PrintLevelOrderHelper(_root);
    }

    private void PrintLevelOrderHelper(BinarySearchTreeNode node)
    {
        if (node == null)
        {
            return;
        }

        var queue = new Queue<BinarySearchTreeNode>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.WriteLine($"Value: {current.Value}");

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }
}
public class BinarySearchTreeNode
{
    public int Value { get; set; }
    public BinarySearchTreeNode Left { get; set; }
    public BinarySearchTreeNode Right { get; set; }

    public BinarySearchTreeNode(int value)
    {
        Value = value;
    }
}