using System.Collections;

namespace TurboCollections;

public class TurboLinkedQueue<T> : ITurboQueue<T> {
    class Node {
        public readonly T Value;
        public Node? Next;
        public Node(T value) => Value = value;
    }
    Node? _firstNode;
    Node? _lastNode;

    public int Count { get; private set; }

    public void Enqueue(T value)
    {
        Node newNode = new Node(value);
        if (_firstNode == null) _firstNode = newNode;
        else _lastNode!.Next = newNode;
        _lastNode = newNode;
        Count++;
    }

    public T Peek() => _firstNode != null ? _firstNode.Value : throw new NullReferenceException();

    public T Dequeue()
    {
        if (_firstNode == null) throw new NullReferenceException();
        
        Node returnValue = _firstNode;
        _firstNode = _firstNode.Next;
        Count--;
        return returnValue.Value;
    }
    
    public void Clear()
    {
        _firstNode = null;
        Count--;
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(_firstNode);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    class Enumerator : IEnumerator<T>
    {
        Node? _currentNode;
        readonly Node? _firstNode;
        
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
