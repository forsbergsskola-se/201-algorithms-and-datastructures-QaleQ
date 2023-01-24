namespace TurboCollections;

public static class TurboSort
{
    public static void SelectionSort(TurboLinkedListMarc<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < list.Count; j++)
                if (list[j] < list[min]) min = j;
            if (min != i) (list[i], list[min]) = (list[min], list[i]);
        }
    }
}