using System.Collections;

namespace TurboCollections;

public class TurboLinkedList<T> : ITurboList<T> {
    class Node {
        public Node(T v) => Value = v;
        public T Value;
        public Node? Next;
    }
    Node? _firstNode;
    Node? _lastNode;

    public int Count { get; private set; }
    
    public T this[int i]
    {
        get => Get(i);
        set => Set(i, value);
    }

    public void Add(T value){
        Node newNode = new Node(value);
        if (_firstNode == null) _firstNode = _lastNode = newNode;
        else _lastNode = _lastNode!.Next = newNode;
        Count++;
    }

    public T Get(int index)
    {
        if (index >= Count || index < 0) throw new IndexOutOfRangeException();

        Node currentNode = _firstNode!;
        for (int i = 0; i < index; i++) currentNode = currentNode.Next!; 
        return currentNode.Value;
    }

    public void Set(int index, T value)
    {
        if (index >= Count || index < 0) throw new IndexOutOfRangeException();

        Node currentNode = _firstNode!;
        for (int i = 0; i < index; i++) currentNode = currentNode.Next!;
        currentNode.Value = value;
    }

    public void Clear()
    {
        _firstNode = _lastNode = null;
        Count = 0;
    }

    public void RemoveAt(int index)
    {
        if (index >= Count || index < 0) throw new IndexOutOfRangeException();

        Node currentNode = _firstNode!;
        Node? previousNode = null;

        for (int i = 0; i < index; i++)
        {
            previousNode = currentNode;
            currentNode = currentNode.Next!;
        }
        if (previousNode != null) previousNode.Next = currentNode.Next;
        if (currentNode == _firstNode) _firstNode = _firstNode!.Next;
        if (currentNode == _lastNode) _lastNode = previousNode;
        Count--;
    }

    public bool Contains(T item)
    {
        foreach (T i in this)
            if (EqualityComparer<T>.Default.Equals(i, item))
                return true;
        return false;
    }

    public int IndexOf(T item)
    {
        int currentIndex = 0;
        foreach (T i in this)
        {
            if (EqualityComparer<T>.Default.Equals(i, item)) return currentIndex;
            currentIndex++;
        }
        return -1;
    }

    public void Remove(T item)
    {
        int currentIndex = 0;
        foreach (T i in this)
        {
            if (EqualityComparer<T>.Default.Equals(i, item))
            {
                RemoveAt(currentIndex);
                return;
            }
            currentIndex++;
        }
    }

    public void AddRange(IEnumerable<T> items) { foreach (T item in items) Add(item); }
    
    public IEnumerator<T> GetEnumerator() => new Enumerator(_firstNode);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    class Enumerator : IEnumerator<T>
    {
        private Node? _currentNode;
        private readonly Node? _firstNode;
        
        public Enumerator(Node? firstNode) => _firstNode = firstNode;

        public bool MoveNext()
        {
            _currentNode = _currentNode == null ? _firstNode : _currentNode.Next;
            return _currentNode != null;
        }

        public void Reset() => _currentNode = null;
        
        public T Current => _currentNode!.Value;
        object IEnumerator.Current => Current!;

        public void Dispose() {}
    }
}