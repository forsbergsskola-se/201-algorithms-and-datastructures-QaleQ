namespace TurboCollections.Test;

public class TurboLinkedStackTests
{
    [Test]
    public void PopThrowsErrorWhenListIsEmpty()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        Assert.Throws<InvalidOperationException>(() => tls.Pop());
    }
    
    [Test]
    public void PeekThrowsErrorWhenListIsEmpty()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        Assert.Throws<InvalidOperationException>(() => tls.Peek());
    }

    [Test]
    public void CountIsZeroWhenListIsEmpty()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        Assert.That(tls.Count, Is.EqualTo(0));
    }
    
    [Test]
    [TestCase("pop", 12, true)]
    public void PushAndPopFollowsLifo(object firstValue, object secondValue, object thirdValue)
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(firstValue);
        tls.Push(secondValue);
        tls.Push(thirdValue);
        if (tls.Pop() != thirdValue) Assert.Fail();
        if (tls.Pop() != secondValue) Assert.Fail();
        if (tls.Pop() != firstValue) Assert.Fail();
    }

    [Test]
    [TestCase("pop", 12, true)]
    public void PeekReturnsValueOnTopOfStack(object firstValue, object secondValue, object thirdValue)
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(firstValue);
        Assert.That(tls.Peek(), Is.EqualTo(firstValue));
        tls.Push(secondValue);
        Assert.That(tls.Peek(), Is.EqualTo(secondValue));
        tls.Push(thirdValue);
        Assert.That(tls.Peek(), Is.EqualTo(thirdValue));
        tls.Pop();
        Assert.That(tls.Peek(), Is.EqualTo(secondValue));
        tls.Pop();
        Assert.That(tls.Peek(), Is.EqualTo(firstValue));
    }

    [Test]
    [TestCase(12)]
    [TestCase(12.4f)]
    [TestCase("bla")]
    [TestCase('a')]
    [TestCase(false)]
    public void CountIncreasesAndDecreasesWithPushAndPop(object a)
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        Assert.That(tls.Count, Is.EqualTo(0));
        tls.Push(a);
        Assert.That(tls.Count, Is.EqualTo(1));
        tls.Push(a);
        Assert.That(tls.Count, Is.EqualTo(2));
        tls.Pop();
        Assert.That(tls.Count, Is.EqualTo(1));
        tls.Pop();
        Assert.That(tls.Count, Is.EqualTo(0));
    }

    [Test]
    [TestCase(12)]
    [TestCase(12.4f)]
    [TestCase("bla")]
    [TestCase('a')]
    [TestCase(false)]
    public void CountGetsResetAfterClear(object a)
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(a);
        tls.Clear();
        Assert.That(tls.Count, Is.EqualTo(0));
    }

    [Test]
    public void TopOfStackIsNullAfterClear()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(12);
        tls.Clear();
        Assert.Throws<InvalidOperationException>(() => tls.Peek());
    }

    [Test]
    public void GetEnumeratorThrowsErrorOnEmptyList()
    {
        Assert.Throws<InvalidOperationException>(() => new TurboLinkedStack<object>().GetEnumerator());
    }
    
    [Test]
    public void MoveNextInitiallyReturnsTrueWhenListNotEmpty()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(12);
        var enumerator = tls.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
    }
    [Test]
    public void MoveNextReturnsFalseWhenAtEndOfList()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(12);
        var enumerator = tls.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(false));
    }

    [Test]
    public void CurrentPointerMovesWithMoveNext()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(12);
        tls.Push(100);
        var enumerator = tls.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
    }

    [Test]
    public void ResetRevertsCurrentPointerToTopOfStack()
    {
        TurboLinkedStack<object> tls = new TurboLinkedStack<object>();
        tls.Push(12);
        tls.Push(100);
        var enumerator = tls.GetEnumerator();
        enumerator.MoveNext();
        enumerator.Reset();
        enumerator.MoveNext();
        Assert.That(tls.Peek(), Is.EqualTo(100));
    }
    
}
