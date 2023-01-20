namespace TurboCollections.Test;

public class TurboLinkedQueueTests
{
    [Test]
    public void DequeueThrowsErrorWhenListIsEmpty()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        Assert.Throws<InvalidOperationException>(() => tlq.Dequeue());
    }
    
    [Test]
    public void PeekThrowsErrorWhenListIsEmpty()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        Assert.Throws<InvalidOperationException>(() => tlq.Peek());
    }

    [Test]
    public void CountIsZeroWhenListIsEmpty()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        Assert.That(tlq.Count, Is.EqualTo(0));
    }
    
    [Test]
    [TestCase("pop", 12, true)]
    public void EnqueueAndDequeueFollowsFifo(object firstValue, object secondValue, object thirdValue)
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(firstValue);
        tlq.Enqueue(secondValue);
        tlq.Enqueue(thirdValue);
        if (tlq.Dequeue() != firstValue) Assert.Fail();
        if (tlq.Dequeue() != secondValue) Assert.Fail();
        if (tlq.Dequeue() != thirdValue) Assert.Fail();
    }

    [Test]
    [TestCase("pop", 12, true)]
    public void PeekReturnsValueOnTopOfStack(object firstValue, object secondValue, object thirdValue)
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(firstValue);
        Assert.That(tlq.Peek(), Is.EqualTo(firstValue));
        tlq.Enqueue(secondValue);
        Assert.That(tlq.Peek(), Is.EqualTo(firstValue));
        tlq.Enqueue(thirdValue);
        Assert.That(tlq.Peek(), Is.EqualTo(firstValue));
        tlq.Dequeue();
        Assert.That(tlq.Peek(), Is.EqualTo(12));
        tlq.Dequeue();
        Assert.That(tlq.Peek(), Is.EqualTo(true));
    }

    [Test]
    [TestCase(12)]
    [TestCase(12.4f)]
    [TestCase("bla")]
    [TestCase('a')]
    [TestCase(false)]
    public void CountIncreasesAndDecreasesWithEnqueueAndDequeue(object a)
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        Assert.That(tlq.Count, Is.EqualTo(0));
        tlq.Enqueue(a);
        Assert.That(tlq.Count, Is.EqualTo(1));
        tlq.Enqueue(a);
        Assert.That(tlq.Count, Is.EqualTo(2));
        tlq.Dequeue();
        Assert.That(tlq.Count, Is.EqualTo(1));
        tlq.Dequeue();
        Assert.That(tlq.Count, Is.EqualTo(0));
    }

    [Test]
    [TestCase(12)]
    [TestCase(12.4f)]
    [TestCase("bla")]
    [TestCase('a')]
    [TestCase(false)]
    public void CountGetsResetAfterClear(object a)
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(a);
        tlq.Clear();
        Assert.That(tlq.Count, Is.EqualTo(0));
    }

    [Test]
    public void TopOfStackIsNullAfterClear()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(12);
        tlq.Clear();
        Assert.Throws<InvalidOperationException>(() => tlq.Peek());
    }

    [Test]
    public void GetEnumeratorThrowsErrorOnEmptyList()
    {
        Assert.Throws<InvalidOperationException>(() => new TurboLinkedQueue<object>().GetEnumerator());
    }
    
    [Test]
    public void MoveNextInitiallyReturnsTrueWhenListNotEmpty()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(12);
        var enumerator = tlq.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
    }
    
    // [Test]
    // public void MoveNextReturnsFalseWhenAtEndOfList()
    // {
    //     TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
    //     tlq.Enqueue(12);
    //     var enumerator = tlq.GetEnumerator();
    //     enumerator.MoveNext();
    //     Assert.That(enumerator.MoveNext(), Is.EqualTo(false));
    // }

    [Test]
    public void CurrentPointerMovesWithMoveNext()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(12);
        tlq.Enqueue(100);
        var enumerator = tlq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
    }

    [Test]
    public void ResetRevertsCurrentPointerToTopOfStack()
    {
        TurboLinkedQueue<object> tlq = new TurboLinkedQueue<object>();
        tlq.Enqueue(12);
        tlq.Enqueue(100);
        var enumerator = tlq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
        enumerator.Reset();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
    }
    
}