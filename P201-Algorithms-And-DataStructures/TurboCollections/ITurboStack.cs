namespace TurboCollections;

public interface ITurboStack<T> : IEnumerable<T>
{
    int Count { get; }
    void Push(T item);
    T Peek();
    T Pop();
    void Clear();
}