namespace TurboCollections;

public static partial class TurboSort
{
    public static void QuickSort(TurboLinkedList<int> list)
    {
        Sort(list, 0, list.Count-1);
        
        static void Sort(TurboLinkedList<int> list, int low, int high)
        {
            if (low <= high)
            {
                int partitionIndex = Partition(list, low, high);
                Sort(list, low, partitionIndex - 1);
                Sort(list, partitionIndex + 1, high);
            }
        }

        static int Partition(TurboLinkedList<int> list, int low, int high)
        {
            int pivotValue = list[high];
            int partitionIndex = low;
            for (int i = partitionIndex; i < high; i++)
            {
                if (list[i] < pivotValue)
                {
                    (list[partitionIndex], list[i]) = (list[i], list[partitionIndex]);
                    partitionIndex++;
                }
            }
            (list[partitionIndex], list[high]) = (list[high], list[partitionIndex]);
            return partitionIndex;
        }

    }
}