using System.Collections;

namespace TurboCollections;

public class TurboLinkedStack<T> : ITurboStack<T> {
    class Node {
        public readonly T Value;
        public readonly Node? Previous;
        public Node(T value, Node? lastNode) {
            Value = value;
            Previous = lastNode;
        }
    }
    
    Node? _lastNode;

    public void Push(T item)
    {
        _lastNode = new Node(item, _lastNode);
        Count++;
    }

    public T Peek() => _lastNode != null ? _lastNode.Value : throw new NullReferenceException();

    public T Pop()
    {
        if (_lastNode == null) throw new NullReferenceException();
        T storedValue = _lastNode.Value;
        _lastNode = _lastNode.Previous;
        Count--;
        return storedValue;
    }

    public void Clear()
    {
        _lastNode = null;
        Count = 0;
    }

    public int Count { get; private set; }

    public IEnumerator<T> GetEnumerator() => new Enumerator(_lastNode);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    class Enumerator : IEnumerator<T> {
        Node? _currentNode;
        readonly Node? _firstNode;

        public Enumerator(Node? firstNode) => _firstNode = firstNode;

        public bool MoveNext()
        {
            _currentNode = _currentNode == null ? _firstNode : _currentNode.Previous;
            return _currentNode != null;
        }

        public T Current => _currentNode!.Value;

        object IEnumerator.Current => Current!;

        public void Reset() => _currentNode = null;

        public void Dispose() {}
    }
}