using System.Collections;

namespace TurboCollections;

public class TurboLinkedQueue<T> : ITurboQueue<T> {
    class Node {
        public T? Value;
        public Node? Next;
    }
    Node? _firstNode;
    Node? _lastNode;

    public int Count { get; set; }

    public void Enqueue(T value)
    {
        if (_firstNode == null)
        {
            _firstNode = new Node { Value = value };
            _lastNode = _firstNode;
        }
        else
        {
            _lastNode!.Next = new Node { Value = value };
            _lastNode = _lastNode.Next;
        }
        Count++;
    }

    public T Peek()
    {
        if (_firstNode == null) throw new InvalidOperationException();
        return _firstNode.Value;
    }

    public T Dequeue()
    {
        if (_firstNode == null) throw new InvalidOperationException();
        
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

    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(_firstNode ?? throw new InvalidOperationException());
        return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    class Enumerator : IEnumerator<T>
    {
        private Node? _currentNode;
        private readonly Node? _firstNode;
        
        public Enumerator(Node firstNode) => _firstNode = firstNode;

        public bool MoveNext()
        {
            if (_firstNode == null) throw new InvalidOperationException();
            
            _currentNode = _currentNode == null ? _firstNode : _currentNode.Next;
            return _currentNode != null;
        }

        public void Reset() => _currentNode = null;
        
        public T Current => _currentNode.Value;
        object IEnumerator.Current => Current;

        public void Dispose() {}
    }
}
