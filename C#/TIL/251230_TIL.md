# 자료구조 Dictionary, Graph

## Dictionary<key, value> 
해쉬 테이블 알고리즘을 이용하여 매우 빠른 탐색 속도를 가지고 있다. 


키 및 값의 컬렉션을 나타낸다. 키를 가지고 있으면 값을 알 수 있다.

namespace : System.Collections.Generic

**Dictionary<TKey, TValue>**
- TKey : Dictionary에 있는 키 형식
- TValue : Dictionary에 있는 값 형식

## 핵심 메서드
```csharp
Dictionary<string, int> dict = new Dictionary<string, int>();

dict.Add();        // Dictoinary에 새로운 key와 value를 추가한다.
dict.ContainKey(); // Dictoinary에 Key의 값이 있는지 확인한다.
dict.Remove();     // Dictoinary에 있는 Key에 따라 key, value를 제거한다.

```
아래는 Dictionary를 이용한 c#코드 사용예시이다.
```csharp
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();

        dict.Add("부안", 40000);
        dict.Add("김제", 30000);
        Console.WriteLine(++dict["부안"]);

        dict["전주"] = 19000;

        if(!dict.ContainsKey("광주"))
        {
            dict.Add("광주", 30000);
        }

        dict.Remove("광주");

        foreach (KeyValuePair<string, int> place in dict)
        {
            Console.WriteLine($"Key = {place.Key}, Value = {place.Value}");
        }

        Console.WriteLine(dict.Count);

    }
}
```

## 그래프(Graph) : 비선형 자료구조

Graph는 List나 배열과 달리 자료가 연속적으로 있지 않고 각자 존재하면서 연결되어있는 구조이다.

인접 리스트 방식과 인접 행렬 방식으로 나뉘어져있다.
```csharp
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Program
{
    static void Main(string[] args)
    {
        MatrixGraph<string> matrix = new MatrixGraph<string>(4);

        matrix.AddEdgeCycle(0, 1, 1);
        matrix.AddEdgeCycle(0, 2, 1);
        matrix.AddEdgeCycle(1, 2, 1);
        matrix.AddEdgeCycle(1, 3, 1);
        matrix.AddEdgeCycle(2, 3, 1);
    }
}
// 인접 리스트 방식
public class ListGraph
{
    private List<int>[] _arr;

    public void AddEdget(int from, int to )
    {
        AddUnique(_arr[from], to);
    }

    public void AddUnique(List<int> list, int value)
    {
        if(!list.Contains(1))
        {
            list.Add(value);
        }
    }
}

// 인접 행렬 방식
public class MatrixGraph<T>
{
    private int[,] _matrix;

    public MatrixGraph(int size)
    {
        _matrix = new int[size, size];
    }

    public void AddEdge(int from, int to, int value)
    {
        if(value <=0)
        {
            return;
        }

        _matrix[from, to] = value;
    }

    public void AddEdgeCycle(int a, int b, int value)
    {
        if (value <= 0) return;

        _matrix[a, b] = value;

    }
}
```