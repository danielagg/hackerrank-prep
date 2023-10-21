namespace HackerRankPrep;

public class MyNode<T>
{
    public T Val { get; }
    public MyNode<T>? Next { get; }

    public MyNode(T val, MyNode<T>? next)
    {
        Val = val;
        Next = next;
    }
}
