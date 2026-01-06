# Quick Sort

- 다른 정렬(버블, 선택, 삽입)에 비해서 월등하게 빠르다는 의미로 이름을 퀵소트로 지었다고 한다.
- 시간복잡도 : O(nlogN)

```csharp
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();

        list.Add(7);
        list.Add(3);
        list.Add(9);
        list.Add(1);
        list.Add(5);
        list.Add(8);
        list.Add(2);

        QuickSort(list, 0, list.Count - 1);

        for (int i = 0; i < list.Count; i++)
        {
            Console.Write($"{list[i]} \t");
        }
    }

    static void QuickSort(List<int> list, int left, int right)
    {
        if (left >= right)
            return;

        int pivot = Partition(list, left, right);

        QuickSort(list, left, pivot - 1);
        QuickSort(list, pivot + 1, right);
    }


    static int Partition(List<int> list, int left, int right)
    {
        int pivot = list[right];
        int i = left - 1;

        // 리스트 내부에서 pivot보다 작은 값들을 왼쪽으로
        for (int j = left; j < right; j++)
        {
            if (list[j] < pivot)
            {
                i++;
                Swap(list, i, j);
            }
        }

        // pivot을 작은 값 바로 다음 영역으로 이동시키고 고정
        int pivotIndex = i + 1;
        Swap(list, pivotIndex, right);

        return pivotIndex;
    }

    static void Swap(List<int> list, int a, int b)
    {
        int temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }

}
```