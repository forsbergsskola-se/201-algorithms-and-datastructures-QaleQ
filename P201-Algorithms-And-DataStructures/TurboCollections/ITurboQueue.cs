namespace TurboCollections;

public interface ITurboQueue<T> : IEnumerable<T> {
    int Count { get; }
    void Enqueue(T item);
    T Peek();
    T Dequeue();
    void Clear();
}