namespace TurboCollections.Test;

public class TurboBSTTests
{
    [Test]
    public void InsertAndSearchWorks()
    {
        int[] valuesToInsert = { 1, 5, 7, 12, 6 };
        var bst = new TurboBinarySearchTree<int>();
        foreach (var number in valuesToInsert) bst.Insert(number);
        foreach (var number in valuesToInsert) Assert.That(bst.Search(number).Value, Is.EqualTo(number));
        Assert.That(bst.Search(4).Value, Is.Not.EqualTo(4));
        Assert.That(bst.Search(8).Value, Is.Not.EqualTo(8));
    }
    
    [Test]
    public void DeleteWorks()
    {
        int[] valuesToInsert = { 1, 5, 7, 12, 6 };
        int[] valuesAfterRemove = { 1, 7, 12, 6 };
        var bst = new TurboBinarySearchTree<int>();
        foreach (var number in valuesToInsert) bst.Insert(number);
    
        bst.Delete(5);
        
        foreach (var value in valuesAfterRemove) Assert.True(!bst.Search(value).Equals(null));
        Assert.That(bst.Search(5).Value.Equals(null));
    } 

    // [Test]
    // public void PreOrderTraversalTest()
    // {
    //     int[] valuesToInsert = { 7, 11, 15, 8, 2, 3, 0, 4 };
    //     int[] expectedResult = { 7, 2, 0, 3, 4, 11, 8, 15 };
    //     var bst = new TurboBinarySearchTree<int>();
    //     foreach (var number in valuesToInsert) bst.Insert(number);
    // }
    
    [Test]
    public void InOrderTraversalTest()
    {
        int[] valuesToInsert = { 7, 11, 15, 8, 2, 3, 0, 4 };
        int[] expectedResult = { 0, 2, 3, 4, 7, 8, 11, 15 };
        var bst = new TurboBinarySearchTree<int>();
        foreach (var number in valuesToInsert) bst.Insert(number);
        int count = 0;
        foreach (var i in bst.GetInOrder(bst.Root))
        {
            Assert.That(expectedResult[count], Is.EqualTo(i));
            count++;
        }
    }
    
    // [Test]
    // public void PostOrderTraversalTest()
    // {
    //     int[] valuesToInsert = { 7, 11, 15, 8, 2, 3, 0, 4 };
    //     int[] expectedResult = { 7, 2, 11, 0, 3, 8, 15, 4 };
    //     var bst = new TurboBinarySearchTree<int>();
    //     foreach (var number in valuesToInsert) bst.Insert(number);
    // }
    
    [Test]
    public void ReverseOrderTraversalTest()
    {
        int[] valuesToInsert = { 7, 11, 15, 8, 2, 3, 0, 4 };
        int[] expectedResult = { 15, 11, 8, 7, 4, 3, 2, 0 };
        var bst = new TurboBinarySearchTree<int>();
        foreach (var number in valuesToInsert) bst.Insert(number);
        int count = 0;
        foreach (var i in bst.GetInReverseOrder(bst.Root))
        {
            Assert.That(expectedResult[count], Is.EqualTo(i));
            count++;
        }
    }
}