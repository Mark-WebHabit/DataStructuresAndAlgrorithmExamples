class Program
{

    static void Main()
    {
        AVLTree tree = new AVLTree();
        tree.Insert(4);
        tree.Insert(7);
        tree.Insert(2);
        tree.Insert(9);
        tree.Insert(5);
        tree.Insert(1);
        tree.Insert(3);
        tree.Insert(10);
        tree.Insert(8);
        tree.Insert(6);

        // tree.Delete(5);
        // Console.WriteLine(tree.Search(10));

        tree.DisplayBreadthFirst(tree.Root);
    }
}