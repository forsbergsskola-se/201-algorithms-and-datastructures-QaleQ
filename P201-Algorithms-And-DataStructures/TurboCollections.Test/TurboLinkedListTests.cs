namespace TurboCollections.Test;

public class TurboLinkedListTests
{
    [Test]
    [TestCase(1)]
    [TestCase("hi")]
    [TestCase(2.3f)]
    public void ContainsReturnsExpectedValues(object value)
    {
        TurboLinkedList<object> tlq = new TurboLinkedList<object> { value };
        Assert.That(tlq.Contains(value), Is.EqualTo(true));
        Assert.That(tlq.Contains(2), Is.EqualTo(false));
        Assert.That(tlq.Contains("pops"), Is.EqualTo(false));
    }
    
    [Test]
    public void CountIsZeroWhenListIsEmpty()
    {
        TurboLinkedList<object> tlq = new TurboLinkedList<object>();
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
        TurboLinkedList<object> tlq = new TurboLinkedList<object> { a };
        tlq.Clear();
        Assert.That(tlq.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void MoveNextInitiallyReturnsTrueWhenListNotEmpty()
    {
        TurboLinkedList<object> tlq = new TurboLinkedList<object> { 12 };
        var enumerator = tlq.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.EqualTo(true));
    }
    
    [Test]
    public void CurrentPointerMovesWithMoveNext()
    {
        TurboLinkedList<object> tlq = new TurboLinkedList<object> { 12, 100 };
        var enumerator = tlq.GetEnumerator();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(12));
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(100));
    }
    
    [Test]
    public void ResetRevertsCurrentPointerToTopOfStack()
    {
        TurboLinkedList<object> tlq = new TurboLinkedList<object> { 12, 100 };
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