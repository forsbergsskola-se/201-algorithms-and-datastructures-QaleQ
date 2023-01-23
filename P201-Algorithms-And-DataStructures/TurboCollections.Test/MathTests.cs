namespace TurboCollections.Test;

public class MathsTests
{
    [Test]
    public void SayHelloExists()
    {
        TurboMaths.SayHello();
        Assert.Pass();
    }

    [Test]
    public void AverageReturnsAverageOfArray()
    {
        float[] testCase = { 1.5f, 2.1f, 3.0f };
        Assert.That(TurboMaths.Average(testCase), Is.EqualTo(2.2f));
        testCase = new float[] { 1, 2, 3, 4, 5 };
        Assert.That(TurboMaths.Average(testCase), Is.EqualTo(3f));
        
    }
}

public class IteratorTests
{
    [Test]
    [TestCase(12)]
    [TestCase(15)]
    [TestCase(-1)]
    [TestCase(0)]
    public void GetEvenNumbersListTest(int maxNumber)
    {
        List<int> testList = TurboMaths.GetEvenNumbersList(maxNumber);
        
        if (testList.Count > maxNumber / 2 + 1) Assert.Fail();
        
        foreach (int num in testList)
            if (num % 2 != 0 || num < 0 || num > maxNumber) Assert.Fail();
    }
    
    [Test]
    [TestCase(12)]
    [TestCase(15)]
    [TestCase(-1)]
    [TestCase(0)]
    public void GetEvenNumbersTest(int maxNumber)
    {
        List<int> testList = new();
        foreach (int number in TurboMaths.GetEvenNumbers(maxNumber))
            testList.Add(number);
        
        
        if (testList.Count > maxNumber / 2 + 1) Assert.Fail();
        if (maxNumber < 0 && testList.Count > 0) Assert.Fail();
        
        foreach (int num in testList)
            if (num % 2 != 0 || num < 0 || num > maxNumber) Assert.Fail();
    }
}