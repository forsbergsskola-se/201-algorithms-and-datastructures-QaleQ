using System.Collections;

namespace TurboCollections;

public class TurboQueue<T> : ITurboQueue<T>
{
    T[] _array = Array.Empty<T>();

    public int Count => _array.Length;

    public void Enqueue(T item)
    {
        var newArray = new T[_array.Length + 1];
        for (var i = 0; i < _array.Length; i++) newArray[i] = _array[i];
        newArray[^1] = item;
        _array = newArray;
    }

    public T Dequeue()
    {
        T firstValue = _array[0];
        T[] newArray = new T[_array.Length - 1];
        for (var i = 1; i < _array.Length; i++)
            newArray[i - 1] = _array[i];
        _array = newArray;
        return firstValue;
    }

    public T Peek() => _array[0];
    public void Clear() => _array = Array.Empty<T>();

    public IEnumerator<T> GetEnumerator() =>
        _array.Length > 0 ? new Enumerator(_array) : throw new InvalidOperationException();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    class Enumerator : IEnumerator<T>
    {
        private int _currentIndex = -1;
        private readonly T[] _array;

        public Enumerator(T[] array) => _array = array;

        public bool MoveNext() => _currentIndex++ != _array.Length;
        public void Reset() => _currentIndex = -1;
        public T Current => _array[_currentIndex];
        object IEnumerator.Current => Current;
        public void Dispose() {}
    }
}