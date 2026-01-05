```csharp
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

class Program
{
    static void Main(string[] args)
    {
        int[] arr =  {4,2,6,7,3,1,9,8,5 };

        BubbleSort(arr);

        for(int i=0;i<arr.Length;i++)
        {
            Console.Write($"{arr[i]}\t");
        }
    }

    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}
```