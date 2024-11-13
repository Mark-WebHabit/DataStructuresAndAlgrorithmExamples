class Node
{
    public int Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public int Height { get; set; }

    public Node(int Data)
    {
        this.Data = Data;
        Height = 1;
    }
}