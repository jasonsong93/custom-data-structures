| Traversal Type | Order               | Use Cases                      |
| -------------- | ------------------- | ------------------------------ |
| Pre-order      | Node → Left → Right | Copying, prefix expressions    |
| In-order       | Left → Node → Right | Sorting BST, infix expressions |
| Post-order     | Left → Right → Node | Deleting, postfix expressions  |
| Level-order    | Level by level      | BFS, shortest path, printing   |

If you're writing your own tree class:

- Provide all 3 depth-first traversals unless you have a reason not to.
- For BSTs, in-order is often the most useful default.