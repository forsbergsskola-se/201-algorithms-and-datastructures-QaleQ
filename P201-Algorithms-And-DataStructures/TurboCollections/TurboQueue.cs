using System.Collections;

namespace TurboCollections;

public class TurboQueue<T> : ITurboQueue<T>
{
    T[] _array = Array.Empty<T>();

    public int Count { get; set; }

    public void Enqueue(T item)
    {
        // Resize the array if not big enough
        if (Count == _array.Length)
        {
            var newArray = new T[Math.Max(_array.Length * 2, 1)];
            for (var i = 0; i < _array.Length; i++) newArray[i] = _array[i];
            _array = newArray;
        }
        _array[Count] = item;
        Count++;
    }

    public T Dequeue()
    {
        T firstValue = _array[0];
        Count--;
        for (int i = 0; i < Count; i++) _array[i] = _array[i + 1];
        return firstValue;
    }

    public T Peek() => _array[0];
    public void Clear()
    {
        _array = Array.Empty<T>();
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(_array);
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