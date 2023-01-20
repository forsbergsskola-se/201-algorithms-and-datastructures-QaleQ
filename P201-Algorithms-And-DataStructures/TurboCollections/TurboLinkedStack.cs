using System.Collections;
using TurboCollections;

public class TurboLinkedStack<T> : IEnumerable<T> {
    class Node {
        public T? Value;
        public Node? Previous;
    }
    
    Node? _lastNode;

    public void Push(T item) {
        _lastNode = new Node {
            Value = item,
            Previous = _lastNode
        };
    }

    public T Peek()
    {
        if (_lastNode == null) throw new InvalidOperationException();
        return _lastNode.Value;
    }

    public T Pop()
    {
        if (_lastNode == null) throw new InvalidOperationException();
        T storedValue = _lastNode.Value;
        _lastNode = _lastNode.Previous;
        return storedValue;
    }

    public void Clear() => _lastNode = null;

    public int Count {
        get {
            int count = 0;
            Node currentNode = _lastNode;
            while(currentNode != null) {
                count++;
                currentNode = currentNode.Previous;
            }
            return count;
        }
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(_lastNode ?? throw new InvalidOperationException());
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    class Enumerator : IEnumerator<T> {
        Node? _currentNode;
        readonly Node _firstNode;

        public Enumerator(Node firstNode) => _firstNode = firstNode;

        public bool MoveNext()
        {
            if (_firstNode == null) throw new InvalidOperationException();
            
            _currentNode = _currentNode == null ? _firstNode : _currentNode.Previous;
            return _currentNode != null;
        }

        public T Current => _currentNode.Value;

        object IEnumerator.Current => Current;

        public void Reset() => _currentNode = null;

        public void Dispose() {}
    }
}
