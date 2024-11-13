using System.Security.Cryptography.X509Certificates;

class AVLTree
{
    public Node? Root { get; set; }

    int GetHeight(Node? n)
    {
        return n == null ? 0 : n.Height;
    }

    int GetBalance(Node? n)
    {
        return n == null ? 0 : GetHeight(n?.Left) - GetHeight(n?.Right);
    }

    Node? LeftRotate(Node? x)
    {
        Node? y = x?.Right;
        Node? T2 = y?.Left;

        if (x == null || y == null)
        {
            Console.WriteLine("Null reference on RotateLeft Method");
            return null;
        }

        y.Left = x;
        x.Right = T2;

        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        return y;
    }

    Node? RightRotate(Node? y)
    {
        Node? x = y?.Left;
        Node? T2 = x?.Right;

        if (x == null || y == null)
        {
            Console.WriteLine("Null reference on RotateLeft Method");
            return null;
        }

        x.Right = y;
        y.Left = T2;


        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    public void Delete(int data)
    {
        Root = DeleteHelper(Root, data);
    }

    private Node? DeleteHelper(Node? root, int data)
    {
        if (root == null)
        {
            return null;
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
                return root.Right;
            else if (root.Right == null)
                return root.Left;
            else
            {
                Node? successor = GetSuccessor(root);
                root.Data = successor?.Data ?? root.Data;
                root.Right = DeleteHelper(root.Right, successor?.Data ?? root.Data);
            }
        }

        root.Height = 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
        int balance = GetBalance(root);

        // Left left case
        if (balance > 1 && GetBalance(root.Left) >= 0)
        {
            return RightRotate(root);
        }

        // Left Right case
        if (balance > 1 && GetBalance(root.Left) < 0)
        {
            root.Left = LeftRotate(root.Left);
            return RightRotate(root);
        }

        // Right Rigth case
        if (balance < -1 && GetBalance(root.Right) <= 0)
        {
            return LeftRotate(root);
        }

        if (balance < -1 && GetBalance(root.Right) > 0)
        {
            root.Right = RightRotate(root.Right);
            return LeftRotate(root);
        }

        return root;
    }

    private Node? GetSuccessor(Node? root)
    {
        if (root == null)
        {
            Console.WriteLine("Null reference in GetSUccessor Method");
            return null;
        }
        Node? current = root.Right;
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
            return root;
        }

        root.Height = 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
        int balance = GetBalance(root);


        // Left left case
        if (balance > 1 && GetBalance(root.Left) >= 0)
        {
            return RightRotate(root);
        }

        // Left Right case
        if (balance > 1 && GetBalance(root.Left) < 0)
        {
            root.Left = LeftRotate(root.Left);
            return RightRotate(root);
        }

        // Right Rigth case
        if (balance < -1 && GetBalance(root.Right) <= 0)
        {
            return LeftRotate(root);
        }

        if (balance < -1 && GetBalance(root.Right) > 0)
        {
            root.Right = RightRotate(root.Right);
            return LeftRotate(root);
        }
        return root;
    }

    public bool Search(int Data)
    {
        return SearchHelper(Root, Data) == null ? false : true;
    }

    private Node? SearchHelper(Node? root, int Data)
    {
        if (root == null)
        {
            return null;
        }

        if (root.Data == Data)
        {
            return root;
        }

        if (root.Data > Data)
        {
            return SearchHelper(root.Left, Data);
        }
        else
        {
            return SearchHelper(root.Right, Data);
        }
    }


    // inorder traversal
    public void DisplayDepthFirst(Node? root)
    {
        if (root == null) return;

        DisplayDepthFirst(root.Left);
        Console.Write(root.Data + " ");
        DisplayDepthFirst(root.Right);
    }

    // level order traversal
    public void DisplayBreadthFirst(Node? root)
    {

        if (root == null)
        {
            return;
        }
        Queue<Node> nodes = new Queue<Node>();

        nodes.Enqueue(root);

        while (nodes.Count != 0)
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