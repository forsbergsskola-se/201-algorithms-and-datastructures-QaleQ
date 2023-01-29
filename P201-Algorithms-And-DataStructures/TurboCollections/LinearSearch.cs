namespace TurboCollections;

public static partial class TurboSearch
{
    public static int LinearSearch(TurboLinkedList<int> list, int value)
    {
        for (var i = 0; i < list.Count; i++) if (list[i] == value) return i;
        return -1;
    }
}