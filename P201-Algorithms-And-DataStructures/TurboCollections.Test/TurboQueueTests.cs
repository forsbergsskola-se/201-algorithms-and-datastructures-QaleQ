namespace TurboCollections.Test;

public class TurboQueueTests
{
    [Test]
    public void DequeueThrowsErrorWhenListIsEmpty()
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        Assert.Throws<IndexOutOfRangeException>(() => tq.Dequeue());
    }
    
    [Test]
    public void PeekThrowsErrorWhenListIsEmpty()
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        Assert.Throws<IndexOutOfRangeException>(() => tq.Peek());
    }

    [Test]
    public void CountIsZeroWhenListIsEmpty()
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        Assert.That(tq.Count, Is.EqualTo(0));
    }
    
    [Test]
    [TestCase("pop", 12, true)]
    public void EnqueueAndDequeueFollowsFifo(object firstValue, object secondValue, object thirdValue)
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        tq.Enqueue(firstValue);
        tq.Enqueue(secondValue);
        tq.Enqueue(thirdValue);
        if (tq.Dequeue() != firstValue) Assert.Fail();
        if (tq.Dequeue() != secondValue) Assert.Fail();
        if (tq.Dequeue() != thirdValue) Assert.Fail();
    }

    [Test]
    [TestCase("pop", 12, true)]
    public void PeekReturnsValueOnTopOfStack(object firstValue, object secondValue, object thirdValue)
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        tq.Enqueue(firstValue);
        Assert.That(tq.Peek(), Is.EqualTo(firstValue));
        tq.Enqueue(secondValue);
        Assert.That(tq.Peek(), Is.EqualTo(firstValue));
        tq.Enqueue(thirdValue);
        Assert.That(tq.Peek(), Is.EqualTo(firstValue));
        tq.Dequeue();
        Assert.That(tq.Peek(), Is.EqualTo(12));
        tq.Dequeue();
        Assert.That(tq.Peek(), Is.EqualTo(true));
    }

    [Test]
    [TestCase(12)]
    [TestCase(12.4f)]
    [TestCase("bla")]
    [TestCase('a')]
    [TestCase(false)]
    public void CountIncreasesAndDecreasesWithEnqueueAndDequeue(object a)
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        Assert.That(tq.Count, Is.EqualTo(0));
        tq.Enqueue(a);
        Assert.That(tq.Count, Is.EqualTo(1));
        tq.Enqueue(a);
        Assert.That(tq.Count, Is.EqualTo(2));
        tq.Dequeue();
        Assert.That(tq.Count, Is.EqualTo(1));
        tq.Dequeue();
        Assert.That(tq.Count, Is.EqualTo(0));
    }

    [Test]
    [TestCase(12)]
    [TestCase(12.4f)]
    [TestCase("bla")]
    [TestCase('a')]
    [TestCase(false)]
    public void CountGetsResetAfterClear(object a)
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        tq.Enqueue(a);
        tq.Clear();
        Assert.That(tq.Count, Is.EqualTo(0));
    }

    [Test]
    public void TopOfStackIsNullAfterClear()
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        tq.Enqueue(12);
        tq.Clear();
        Assert.Throws<IndexOutOfRangeException>(() => tq.Peek());
    }

    [Test]
    public void GetEnumeratorThrowsErrorOnEmptyList()
    {
        Assert.Throws<InvalidOperationException>(() => new TurboQueue<object>().GetEnumerator());
    }
    
    [Test]
    public void MoveNextInitiallyReturnsTrueWhenListNotEmpty()
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        tq.Enqueue(12);
        var enumerator = tq.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
    }
    
    // [Test]
    // public void MoveNextReturnsFalseWhenAtEndOfList()
    // {
    //     TurboQueue<object> tq = new TurboQueue<object>();
    //     tq.Enqueue(12);
    //     var enumerator = tq.GetEnumerator();
    //     enumerator.MoveNext();
    //     Assert.That(enumerator.MoveNext(), Is.EqualTo(false));
    // }

    [Test]
    public void CurrentPointerMovesWithMoveNext()
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        tq.Enqueue(12);
        tq.Enqueue(100);
        var enumerator = tq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
    }

    [Test]
    public void ResetRevertsCurrentPointerToTopOfStack()
    {
        TurboQueue<object> tq = new TurboQueue<object>();
        tq.Enqueue(12);
        tq.Enqueue(100);
        var enumerator = tq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
        enumerator.Reset();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
    }
    
}