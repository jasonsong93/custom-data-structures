When to use what type of tree:

Unbalanced BST: Use only if you want simple code and data is small or random.

AVL Tree: Use when fast searches matter more than insertion speed (e.g., databases, caches).

Red-Black Tree: Use for general-purpose, balanced performance with frequent updates (e.g., language std libs).

| Structure                    | When to Use                               | Pros                                                              | Cons                                                    | Strictly Better For                                                            |
| ---------------------------- | ----------------------------------------- | ----------------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------------------------------ |
| **Unbalanced BST**           | Simple, small datasets; quick prototyping | Easy to implement; minimal overhead                               | Poor worst-case (O(n)); unbalanced easily               | Very small or random data where balancing overhead isn’t worth it              |
| **Balanced BST** (idealized) | Theoretical baseline                      | Logarithmic ops if balanced                                       | Hard to maintain balance manually                       | N/A (used mainly as conceptual ideal)                                          |
| **AVL Tree**                 | Read-heavy apps; fast lookups needed      | Tighter balance → faster search                                   | More rotations on insert/delete; complex implementation | Fast search with fewer reads/writes, strict balance needed                     |
| **Red-Black Tree**           | General-purpose balanced tree; std libs   | Good balance of insert/delete/search performance; fewer rotations | Slightly slower searches than AVL; more complex logic   | Frequent inserts/deletes with acceptable search speed (e.g., std library maps) |
