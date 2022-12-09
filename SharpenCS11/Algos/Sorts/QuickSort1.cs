using System.Text;

namespace SharpenCS11.Algos.Sorts;

public static class QuickSortDemoType
{
    private static readonly int[] Ints;
    private static int _partitionsCount;
    static QuickSortDemoType()
    {
        var rand = new Random();
        Ints = new int[rand.Next(10, 20)];

        for (var i = 0; i < Ints.Length; i++)
        {
            Ints[i] = rand.Next(-20, 21);
        }

        _partitionsCount = 0;
    }

    public static void Demo()
    {
        QuickSortRandomArray();
    }

    private static void QuickSortRandomArray()
    {
        PrintArray(printLength: true);
        QuickSort(Ints, 0, Ints.Length - 1);
        PrintArray();
        WriteLine($"  Partitions completed: {_partitionsCount}");
    }

    private static void QuickSort(int[] array, int lo, int hi)
    {
        if (lo >= hi) return;
        var p = PartitionHoare(array, lo, hi);
        QuickSort(array, lo, p - 1);
        // ReSharper disable once TailRecursiveCall
        QuickSort(array, p + 1, hi);
    }

    private static int PartitionHoare(int[] array, int lo, int hi)
    {
        var i = lo + 1;
        var j = hi;
        var pivot = array[lo];

        while (true)
        {
            while (i < hi && array[i] < pivot)
            {
                ++i;
            }

            while (array[j] > pivot)
            {
                --j;
            }

            if (i >= j)
            {
                break;
            }

            (array[i], array[j]) = (array[j], array[i]);
            i++; j--;
            _partitionsCount++;

        }
        (array[lo], array[j]) = (array[j], array[lo]);
        return j;
    }

    private static void PrintArray(bool printLength = false)
    {
        var sb = new StringBuilder();
        sb.Append("[ ");
        foreach (var t in Ints)
        {
            sb.Append(t).Append(' ');
        }

        sb.Append(']').Append(printLength == false ? '\n' : $"  Length: {Ints.Length}\n");

        WriteLine(sb);
    }
}