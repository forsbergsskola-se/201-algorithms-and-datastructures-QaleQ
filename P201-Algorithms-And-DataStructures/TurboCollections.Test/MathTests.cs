namespace TurboCollections.Test;

public static class MathsTests
{
    [Test]
    public static void SayHelloExists()
    {
        TurboMaths.SayHello();
        Assert.Pass();
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