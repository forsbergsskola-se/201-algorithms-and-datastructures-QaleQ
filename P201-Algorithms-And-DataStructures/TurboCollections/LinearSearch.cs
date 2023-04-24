namespace TurboCollections;

public static partial class TurboSearch
{
    public static int LinearSearch(TurboLinkedList<int> list, int value)
    {
        int count = 0;
        foreach (var i in list)
        {
            if (i == value) return count;
            count++;
        }
        return -1;
    }
}