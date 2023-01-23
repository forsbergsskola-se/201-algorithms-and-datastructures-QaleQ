using System.Collections;

namespace TurboCollections;

public class TurboLinkedListMarc<T> : IEnumerable<T> // ICollection
{
    private class Node {
        public T Value;
        public Node? Next;

        public Node(T value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }
    
    public int Count { get; private set; }

    private Node? _firstNode;
    private Node? _lastNode;

    public void Add(T item)
    {
        if (_lastNode == null) _firstNode = _lastNode = new Node(item, null);
        else _lastNode = _lastNode.Next = new Node(item, null);

        Count++;
    }

    public T Get(int index)
    {
        if (index < 0) throw new IndexOutOfRangeException();
        if (index >= Count) throw new IndexOutOfRangeException();
        Node current = _firstNode!; // validated through index checks above
        for (int i = 0; i < index; i++) current = current.Next!; // validated through index checks above

        return current.Value;
    }
    
    public void Set(int index, T value)
    {
        if (index >= Count) throw new IndexOutOfRangeException();
        Node current = _firstNode!;
        for (int i = 0; i < index; i++) current = current.Next!;
        current.Value = value;
    }
    
    public void Remove(int index)
    {
        if (index >= Count) throw new IndexOutOfRangeException();
        Node current = _firstNode!;
        Node? previous = null;
        for (int i = 0; i < index; i++)
        {
            previous = current;
            current = current.Next!;
        }
        if (previous != null) previous.Next = current.Next;
        if (_firstNode == current) _firstNode = current.Next;
        if (_lastNode == current) _lastNode = previous;
        Count--;
    }

    public void Clear()
    {
        _firstNode = _lastNode = null;
        Count = 0;
    }
    
    public IEnumerator<T> GetEnumerator() => new Enumerator(_firstNode);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    class Enumerator : IEnumerator<T>
    {
        private readonly Node? _firstNode;
        private Node? _currentNode;

        public Enumerator(Node? firstNode) => _firstNode = firstNode;

        public bool MoveNext()
        {
            _currentNode = _currentNode == null ? _firstNode : _currentNode.Next;
            return _currentNode != null;
        }

        public void Reset() => _currentNode = null;

        public T Current
        {
            get
            {
                if (_currentNode == null) throw new InvalidOperationException();
                return _currentNode.Value;
            }
        }

        object? IEnumerator.Current => Current;

        public void Dispose() { }
    }
    
    public T this[int index]
    {
        get => Get(index);
        set => Set(index, value);
    }
}
