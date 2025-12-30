# CallByValue CallByRef



## Call By Value

```csharp
using System;

public class Program
{
    public static void Main(string[] arg)
    {
        MyStruct  FirstStruct = new MyStruct() { value = 5 };
        MyStruct SecondStruct = FirstStruct;

        SecondStruct.value = 15;

        Console.WriteLine(FirstStruct.value);
        Console.WriteLine(SecondStruct.value);
    }
}

public struct MyStruct
{
    public int value;
}
```

FirstStruct를 만들어 value를 5로 하고 SecondStruct를 만들고 FirstStruct를 복사했다. 그리고 value를 15로 설정하고 출력해보면 FirstStruct의 value는 5 SecondStruct의 value는 15이다. SecondStruct는 FirstStruct를 깊은복사를 통하여 복사했고 각자의 value를 가지고 있다. 그러니 어느 한 값을 바꾸더라도 서로에게 영향을 미치지 않는다.

## Call By Ref
```csharp
using System;

public class Program
{
    public static void Main(string[] arg)
    {
        MyClass FirstClass = new MyClass() { value = 5 };
        MyClass SecondClass = FirstClass;

        SecondClass.value = 15;

        Console.WriteLine(FirstClass.value);
        Console.WriteLine(SecondClass.value);
    }
}

public class MyClass
{
    public int value;
}
```

이번에는 class를 만들어보자 첫번째 경우와 마찬가지로 FirstClass를 만들고 value에 5를 대입하였고 두번째 클래스는 첫번째 클래스를 복사하여 생성하였다. 그리고 값을 변경하였을 때 두 클래스 모두의 값이 변경 되었다 왜 이런 차이가 생기는 것일까? 

이 이유는 클래스는 값을 가리키고 있는 주소값을 복사했기 때문이다. 그래서 값을 변경했을 때 그 값을 가리키고 있던 다른 클래스도 값이 변경 되는 것처럼 보였던 것이다.
