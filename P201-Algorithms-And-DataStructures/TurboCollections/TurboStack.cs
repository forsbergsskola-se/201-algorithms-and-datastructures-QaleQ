using System.Collections;

namespace TurboCollections;

public class TurboStack<T> : ITurboStack<T>
{
    T[] _array = Array.Empty<T>();
    public int Count { get; private set; }
    public void Push(T item)
    {
        if (_array.Length == Count)
        {
            T[] newArray = new T[Math.Max(1, _array.Length * 2)];
            for (var i = 0; i < _array.Length; i++) newArray[i] = _array[i];
            _array = newArray;
        }
        _array[Count++] = item;
    }
    public T Peek() => _array[Count - 1];
    public T Pop() => _array[Count--];
    public void Clear() => _array = Array.Empty<T>();
    public IEnumerator<T> GetEnumerator() => new Enumerator(this);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    class Enumerator : IEnumerator<T>
    {
        readonly TurboStack<T>? _turboStack;
        int _currentIndex = 0;
        public Enumerator(TurboStack<T> turboStack)
        {
            _turboStack = turboStack;
            _currentIndex = turboStack.Count;
        }
        public bool MoveNext() => --_currentIndex != 0;
        public void Reset()
        {
            _currentIndex = _turboStack.Count;
        }

        public T Current => _turboStack.Peek();
        object IEnumerator.Current => Current;
        public void Dispose() {}
    }
}
