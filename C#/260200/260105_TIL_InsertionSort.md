# Selection Sort

- Selection Sort는 간단한 정렬 알고리즘의 한 종류로 버블정렬은 제일 큰수를 뒤로보내 뒤에서 부터 확정짓는 알고리즘이었다면 선택정렬은 제일 작은 수를 앞에 놔서 앞에서부터 확정짓는 알고리즘이다.
- 가장 작은 수를 선택하여 앞에 갔다놓기 때문에 선택정렬이라는 이름이 붙었다.
- 시간복잡도 : BigO: O(n^2)

제일 작은 수가 인덱스가 0이라고 생각하고 시작한다. 그리고 더 작은수가 나타나면 인덱스를 바꾸고 가장 작은 수를 앞으로 가져다두면서 정렬을 완성한다.

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