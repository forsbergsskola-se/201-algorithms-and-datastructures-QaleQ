namespace TurboCollections.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}

public static class MathsTests
{
    [Test]
    public static void SayHelloExists()
    {
        TurboCollections.TurboMaths.SayHello();
        Assert.Pass();
    }
}
