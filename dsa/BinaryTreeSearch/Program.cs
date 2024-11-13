class Program
{
    static void Main()
    {
        Tree bst = new Tree();

        bst.Insert(10);
        bst.Insert(1);
        bst.Insert(9);
        bst.Insert(4);
        bst.Insert(2);
        bst.Insert(5);
        bst.Insert(100);
        bst.Delete(1);
        Console.WriteLine(bst.Search(100));
        bst.DisplayDepthFirst(bst.Root);
        Console.WriteLine();
        bst.DisplayBreadthFirst(bst.Root);
    }
}