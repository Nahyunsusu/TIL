# Insertion Sort

- 삽입정렬은 정렬 알고리즘의 대표적인 방법으로 앞에서부터 뒤로 두수를 비교해가면서 작은수를 앞으로 큰수를 뒤로 놓는 간단한 방법이다. 2개씩 비교하면서 뒤에서 작은수가 발견되면 앞으로 보내어 자리가 맞을 떄까지 앞으로 보낸다.
- 적절한 위치를 찾아 끼워넣는(Insert) 동작 그 자체이기 때문에 붙여진 이름이다.
- 시간복잡도 : BigO: O(n^2)

리스트를 정렬된 부분과 정렬되지 않은 부분으로 나눈 후, 정렬되지 않은 부분의 원소를 정렬된 부분의 적절한 위치에 삽입하는 과정을 반복하여 정렬을 수행한다.

```csharp
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 4, 2, 6, 7, 3, 1, 9, 8, 5 };

        InsertionSort(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]}\t");
        }
    }

    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int compareIndex = i - 1;

            while (compareIndex >= 0 && arr[compareIndex] > key)
            {
                arr[compareIndex + 1] = arr[compareIndex];
                compareIndex--;
            }

            arr[compareIndex + 1] = key;
        }
    }
}
```