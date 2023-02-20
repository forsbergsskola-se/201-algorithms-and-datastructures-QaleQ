namespace TurboCollections.Test;

public class HashSetTests
{
    [Test]
    public void AddingExistingValueReturnsFalse()
    {
        var set = new HashSet<int>();
        set.Add(5);
        Assert.That(set.Add(5), Is.False);
    }
    
    [Test]
    public void AddingExistingValueReturnsTrue()
    {
        var set = new HashSet<int>();
        Assert.That(set.Add(5), Is.True);
        Assert.That(set.Add(2), Is.True);
    }
}