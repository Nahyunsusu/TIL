
```
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

struct info
{
    public string   Name;
    public int       Age;
    public float  Height;
    public string Reason;
};

namespace _1209_Temp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<info> Students = new List<info>();

            info temp;

            temp.Name = "김경주";
            temp.Age = 23;
            temp.Height = 173;
            temp.Reason = "취업";

            Students.Add(temp);

            temp.Name = "김건표";
            temp.Age = 29;
            temp.Height = 170;
            temp.Reason = "1인 개발자가 되고싶어서";

            Students.Add(temp);

            temp.Name = "최원탁";
            temp.Age = 33;
            temp.Height = 174;
            temp.Reason = "업종 변경을 위해서";

            Students.Add(temp);

            temp.Name = "송근형";
            temp.Age = 37;
            temp.Height = 172.4f;
            temp.Reason = "취업";

            Students.Add(temp);

            temp.Name = "서정아";
            temp.Age = 31;
            temp.Height = 158;
            temp.Reason = "게임을 좋아해서";

            Students.Add(temp);

            for(int i=0;i<5;i++)
            {
                Console.WriteLine(Students[i].  Name);
                Console.WriteLine(Students[i].   Age);
                Console.WriteLine(Students[i].Height);
                Console.WriteLine(Students[i].Reason);
                Console.WriteLine();
            }
        }
    }
}
```

```
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

struct info
{
    public string   Name;
    public int       Age;
    public float  Height;
    public string Reason;
};

namespace _1209_Temp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("값을 입력하세요");
            string str = Console.ReadLine();

            int temp = int.Parse(str);

            int a = temp / 10;
            int b = temp % 10;

            Console.WriteLine($"두 결과를 더한 값                     {a+b}");
            Console.WriteLine($"첫번째 값에서 두번째 값을 뺀 값       {a-b}");
            Console.WriteLine($"두 결과를 곱한 값                    {a*b}");
            if(b!=0)
            {
            Console.WriteLine($"첫번째 값에서 두번째 값을 나눈 값     {a / b}");
            Console.WriteLine($"첫번째 값에서 두번째 값을 나눈 나머지 {a % b}");
            }
            
        }
    }
}