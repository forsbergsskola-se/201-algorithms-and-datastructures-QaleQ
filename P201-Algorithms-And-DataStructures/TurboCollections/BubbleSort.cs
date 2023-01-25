namespace TurboCollections;

public static partial class TurboSort
{
    public static void BubbleSort(TurboLinkedListMarc<int> list)
    {
        int unsorted = list.Count;
        for (int i = 0; i < list.Count; i++)
        {
            bool swapped = false;
            for (int j = 0; j < unsorted - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    swapped = true;
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
            if (!swapped) break;
            unsorted--;
        }
    }
}