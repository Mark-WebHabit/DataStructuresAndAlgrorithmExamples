class Tree
{
    public Node? Root { get; set; }

    public void Delete(int data)
    {
        Root = DeleteHelper(Root, data);
    }

    private Node? DeleteHelper(Node? root, int data)
    {

        if (root == null)
        {
            return root;
        }

        if (root.Data > data)
        {
            root.Left = DeleteHelper(root.Left, data);
        }
        else if (root.Data < data)
        {
            root.Right = DeleteHelper(root.Right, data);
        }
        else
        {

            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }
            else
            {

                Node? successor = GetSuccessor(root);
                root.Data = successor?.Data ?? root.Data;
                root.Right = DeleteHelper(root.Right, successor?.Data ?? root.Data);

            }


        }
        return root;
    }

    public Node? GetSuccessor(Node? root)
    {
        Node? current = root?.Right;
        while (current != null && current.Left != null)
        {
            current = current.Left;
        }


        return current;
    }

    public void Insert(int data)
    {
        Root = InsertHelper(Root, data);
    }
    private Node? InsertHelper(Node? root, int data)
    {

        if (root == null)
        {
            return new Node(data);
        }

        if (root.Data > data)
        {
            root.Left = InsertHelper(root.Left, data);
        }
        else if (root.Data < data)
        {
            root.Right = InsertHelper(root.Right, data);
        }
        else
        {
            return root; // do not allow duplicates so return the root if data is already existing
        }

        return root;
    }

    public bool Search(int data)
    {
        Node? result = SeachHelper(Root, data);

        if (result != null) return true;
        return false;
    }

    static private Node? SeachHelper(Node? root, int data)
    {
        if (root == null)
        {
            return null;
        }

        if (root.Data == data)
        {
            return root;
        }

        if (root.Data > data)
        {
            return root.Left = SeachHelper(root.Left, data);
        }
        else
        {
            return root.Right = SeachHelper(root.Right, data);
        }
    }

    // inorder traversal 
    public void DisplayDepthFirst(Node? root)
    {
        if (root == null)
        {
            return;
        }

        DisplayDepthFirst(root.Left);
        Console.Write(root.Data + " ");
        DisplayDepthFirst(root.Right);
    }

    // level order taversal
    public void DisplayBreadthFirst(Node? root)
    {

        if (root == null)
        {
            return;
        }

        Queue<Node> nodes = new Queue<Node>();
        nodes.Enqueue(root);

        while (nodes.Count > 0)
        {
            Node? current = nodes.Dequeue();
            Console.Write(current.Data + " ");

            if (current.Left != null)
            {
                nodes.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                nodes.Enqueue(current.Right);
            }
        }
    }
}