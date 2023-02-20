using System.Diagnostics;

namespace TurboCollections.Test;

public class SearchTests
{
    [Test]
    public void LinearSearchWorks()
    {
        var list = new TurboLinkedList<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        Assert.That(TurboSearch.LinearSearch(list, 10), Is.EqualTo(0));
        Assert.That(TurboSearch.LinearSearch(list, 11), Is.EqualTo(1));
        Assert.That(TurboSearch.LinearSearch(list, 12), Is.EqualTo(2));
        Assert.That(TurboSearch.LinearSearch(list, 13), Is.EqualTo(3));
        Assert.That(TurboSearch.LinearSearch(list, 2), Is.EqualTo(-1));
    }
    
    
    [Test]
    public void BinarySearchWorks()
    {
        var list = new TurboLinkedList<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        Assert.That(TurboSearch.BinarySearch(list, 10), Is.EqualTo(0));
        Assert.That(TurboSearch.BinarySearch(list, 11), Is.EqualTo(1));
        Assert.That(TurboSearch.BinarySearch(list, 12), Is.EqualTo(2));
        Assert.That(TurboSearch.BinarySearch(list, 13), Is.EqualTo(3));
        Assert.That(TurboSearch.BinarySearch(list, 2), Is.EqualTo(-1));
    }
    
    [Test]
    [TestCase(0)]
    [TestCase(50000)]
    [TestCase(75000)]
    [TestCase(99999)]
    public void BinaryVsLinearSearchComparison(int testCase)
    {
        var numberList = Enumerable.Range(0, 10000000);
        var list = new TurboLinkedList<int>();
        list.AddRange(numberList);
        var sw = new Stopwatch();

        sw.Start();
        Assert.That(TurboSearch.LinearSearch(list, testCase), Is.EqualTo(testCase));
        sw.Stop();
        long linearResult = sw.ElapsedMilliseconds;
        Console.WriteLine($"Linear Search value {testCase}: {sw.ElapsedMilliseconds} ms");
        sw.Reset();

        sw.Start();
        TurboSearch.BinarySearch(list, testCase);
        sw.Stop();
        long binaryResult = sw.ElapsedMilliseconds;
        Console.WriteLine($"Binary Search value {testCase}: {sw.ElapsedMilliseconds} ms");
        sw.Reset();
        
        string fasterMethod = (binaryResult < linearResult ? "Binary" : "Linear") + " search";
        long fasterTime = Math.Max(binaryResult, linearResult);
        long slower = Math.Min(binaryResult, linearResult);
        Console.WriteLine($"{fasterMethod} is faster by {fasterTime - slower} ms");
        numberList = null;
    }
}