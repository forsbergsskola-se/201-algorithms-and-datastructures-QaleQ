namespace TurboCollections;

public static partial class TurboSearch
{
    public static int BinarySearch(TurboLinkedList<int> list, int value)
    {
        int lowerBound = 0;
        int upperBound = list.Count - 1;
        while (true)
        {
            if (upperBound < lowerBound) return -1;
            int midpoint = (lowerBound + upperBound) / 2;
            if (list[midpoint] < value) lowerBound = midpoint + 1;
            else if (list[midpoint] > value) upperBound = midpoint - 1;
            else if (list[midpoint] == value) return midpoint;
        }
    }
}