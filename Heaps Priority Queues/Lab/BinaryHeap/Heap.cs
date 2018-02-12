using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        for (int i = arr.Length/2 ; i >= 0; i--)
        {
            HeapfiDown(arr,i,arr.Length);
        }

        for (int i = arr.Length - 1; i >= 1; i--)
        {
            Swap(arr,0,i);
            HeapfiDown(arr,0,i);
        }
    }

    private static void HeapfiDown(T[] arr, int index,int length)
    {
        while (index < length/2)
        {
            int child = 2 * index + 1;

            if (child + 1 < length && IsGreater(arr,child + 1, child))
            {
                child++;
            }
            if (IsGreater(arr,index, child))
            {
                break;
            }
            Swap(arr,child, index);
            index = child;
        }
    }

    private static void Swap(T[] heap, int a, int b)
    {
        T current = heap[a];
        heap[a] = heap[b];
        heap[b] = current;
    }

    private static bool IsGreater(T[] arr, int a,int b)
    {
        return arr[a].CompareTo(arr[b]) > 0;
    }
}
