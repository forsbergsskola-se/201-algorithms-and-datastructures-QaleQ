using System.Diagnostics;

namespace TurboCollections.Test;

public class TurboSortTests
{
    [Test]
    public void SelectionSortSortedTest()
    {
        var numberRange = Enumerable.Range(1, 1000);
        var sortedList = new TurboLinkedList<int>();
        foreach (var i in numberRange) sortedList.Add(i);
        var sw = new Stopwatch();
        
        sw.Start();
        TurboSort.SelectionSort(sortedList);
        sw.Stop();
        
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Assert.That(sortedList, Is.EquivalentTo(numberRange));
        Assert.That(sortedList, Is.Ordered);
    }
    
    [Test]
    public void BubbleSortSortedTest()
    {
        var numberRange = Enumerable.Range(1, 1000);
        var sortedList = new TurboLinkedList<int>();
        foreach (var i in numberRange) sortedList.Add(i);
        var sw = new Stopwatch();
        
        sw.Start();
        TurboSort.BubbleSort(sortedList);
        sw.Stop();
        
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Assert.That(sortedList, Is.EquivalentTo(numberRange));
        Assert.That(sortedList, Is.Ordered);
    }

    
    [Test]
    public void SelectionSortInvertedTest()
    {
        var numberRange = Enumerable.Range(1, 1000).Reverse();
        var invertedList = new TurboLinkedList<int>();
        foreach (var i in numberRange) invertedList.Add(i);
        var sw = new Stopwatch();
        
        sw.Start();
        TurboSort.SelectionSort(invertedList);
        sw.Stop();
        
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Assert.That(invertedList, Is.EquivalentTo(numberRange));
        Assert.That(invertedList, Is.Ordered);
    }
    
    [Test]
    public void BubbleSortInvertedTest()
    {
        var numberRange = Enumerable.Range(1, 1000).Reverse();
        var invertedList = new TurboLinkedList<int>();
        foreach (var i in numberRange) invertedList.Add(i);
        var sw = new Stopwatch();
        
        sw.Start();
        TurboSort.BubbleSort(invertedList);
        sw.Stop();
        
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Assert.That(invertedList, Is.EquivalentTo(numberRange));
        Assert.That(invertedList, Is.Ordered);
    }
    
    [Test]
    public void SelectionSortAlmostSorted()
    {
        var numberRange = Enumerable.Range(1, 1000);
        var almostSortedList = new TurboLinkedList<int>();
        foreach (var i in numberRange) almostSortedList.Add(i);
        (almostSortedList[0], almostSortedList[^1]) = (almostSortedList[^1], almostSortedList[0]);
        var sw = new Stopwatch();
        
        sw.Start();
        TurboSort.SelectionSort(almostSortedList);
        sw.Stop();
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Assert.That(almostSortedList, Is.EquivalentTo(numberRange));
        Assert.That(almostSortedList, Is.Ordered);
    }
    
    [Test]
    public void BubbleSortAlmostSorted()
    {
        var numberRange = Enumerable.Range(1, 1000);
        var almostSortedList = new TurboLinkedList<int>();
        foreach (var i in numberRange) almostSortedList.Add(i);
        (almostSortedList[0], almostSortedList[^1]) = (almostSortedList[^1], almostSortedList[0]);
        var sw = new Stopwatch();
        
        sw.Start();
        TurboSort.BubbleSort(almostSortedList);
        sw.Stop();
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        Assert.That(almostSortedList, Is.EquivalentTo(numberRange));
        Assert.That(almostSortedList, Is.Ordered);
    }
    
    [Test]
    public void SelectionSortRandomList()
    {
        var numberRange = Enumerable.Range(1,1000);
        var randomList = new TurboLinkedList<int>();
        foreach (var item in numberRange) randomList.Add(item);
        for (int i = 0; i < randomList.Count - 1; i++)
        {
            var r = Random.Shared.Next(i + 1, randomList.Count);
            (randomList[i], randomList[r]) = (randomList[r], randomList [i]);
        }
        
        var sw = new Stopwatch();
        sw.Start();
        TurboSort.SelectionSort(randomList);
        sw.Stop();
        TimeSpan timeTaken = sw.Elapsed;
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        
        Assert.That(randomList, Is.EquivalentTo(numberRange));
        Assert.That(randomList, Is.Ordered);
    }
    
    [Test]
    public void BubbleSortRandomList()
    {
        var numberRange = Enumerable.Range(1,1000);
        var randomList = new TurboLinkedList<int>();
        foreach (var item in numberRange) randomList.Add(item);
        for (int i = 0; i < randomList.Count - 1; i++)
        {
            var r = Random.Shared.Next(i + 1, randomList.Count);
            (randomList[i], randomList[r]) = (randomList[r], randomList [i]);
        }
        
        var sw = new Stopwatch();
        sw.Start();
    
        TurboSort.BubbleSort(randomList);
        sw.Stop();
        TimeSpan timeTaken = sw.Elapsed;
        Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        
        Assert.That(randomList, Is.EquivalentTo(numberRange));
        Assert.That(randomList, Is.Ordered);
    }
}