public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // If the value is equal to current node's data, don't insert (no duplicates)
        if (value == Data)
            return;
        
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // If we found the value, return true
        if (value == Data)
            return true;
        
        // If value is less than current node, search left subtree
        if (value < Data)
        {
            // If left is null, value not found
            if (Left is null)
                return false;
            // Otherwise, search left subtree
            return Left.Contains(value);
        }
        // If value is greater than current node, search right subtree
        else
        {
            // If right is null, value not found
            if (Right is null)
                return false;
            // Otherwise, search right subtree
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Base case: if node is null, height is 0
        if (this is null)
            return 0;
        
        // Get height of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // Return 1 (for current node) plus the maximum height between left and right subtrees
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}