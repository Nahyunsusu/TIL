# 과제 1. 트레이너와 몬스터 클래스 제작
## main.cs
```csharp
using PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class main
    {
        static void Main()
        {
            Console.WriteLine("플레이어의 이름은 무엇인가요?");
            Console.ReadLine();
            Player Player = new Player(Console.ReadLine());

            while(true)
            {
                {
                    Console.Write("1. Add\t");
                    Console.Write("2. Remove\t");
                    Console.Write("3. PrintAll\t");
                    Console.Write("4. Attack\t");
                    Console.WriteLine("5. Skill");
                }
                Console.WriteLine("행동을 선택하세요");
                if(int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 1)
                    {
                        Console.WriteLine("어떤 포켓몬을 데려갈까요?");
                        for(int i=0;i<(int)EeveeType.Umbreon;i++)
                        {
                            Console.WriteLine($"{i} : {(EeveeType)i}");
                        }

                        if (int.TryParse(Console.ReadLine(), out int typeInput))
                        {
                            EeveeType selectedType = (EeveeType)typeInput;
                            
                            Player.Add(selectedType);
                        }
                        else
                        {
                            Console.WriteLine("숫자 번호를 입력해주세요.");
                        }
                    }

                    if (input == 2)
                    {
                        Console.WriteLine("어떤 포켓몬을 삭제할까요?");
                        Player.Remove(Console.ReadLine());
                    }

                    if (input == 3)
                    {
                        Player.PrintAll();
                    }
                    if (input == 4)
                    {
                        Console.WriteLine("어떤 포켓몬이 공격할까요?");
                        Player.Attack();
                    }
                    if(input == 5)
                    {
                        Console.WriteLine("어떤 포켓몬이 특수공격할까요?");
                        Player.Skill();
                    }

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                Console.WriteLine("");
            }
        }
    }
}

```
## player.cs
```csharp
using System;
using System.ComponentModel;

using PM;

public class Player
{
    public Player(string name) 
    {
        this.name = name;
    }

    public void Add(EeveeType type)
    {
        if (curIndex >= 6)
        {
            Console.WriteLine("포켓몬이 꽉 찼습니다.");
            return;
        }

        Eevee newEevee = null;

        switch (type)
        {
            case EeveeType.Eevee:
                newEevee = new Eevee();
                break;

            case EeveeType.Sylveon:
                newEevee = new Sylveon();
                break;
            case EeveeType.Vaporeon:
                newEevee = new Vaporeon();
                break;
            case EeveeType.Jolteon:
                newEevee = new Jolteon();
                break;

        }

        if (newEevee != null)
        {
            Eevees[curIndex++] = newEevee;
            Console.WriteLine($"{type}이(가) 추가되었습니다.");
        }
    }
    public void Remove(string speices)
    {
        for(int i=0;i< curIndex;i++)
        {
            if (Eevees[i].Species == speices && Eevees[i] != null)
            {
                Console.WriteLine($"{Eevees[i].Species}를 파티에서 제외했습니다.");

                for (int j = i; j < curIndex - 1; j++)
                {
                    Eevees[j] = Eevees[j + 1];
                }

                Eevees[curIndex - 1] = null;
                curIndex--;

                i--;
            }
        }
    }

    public void PrintAll()
    {
        if (Eevees[0] == null)
        {
            Console.WriteLine("현재 데리고 있는 포켓몬이 없습니다.");
            return;
        }

        Console.WriteLine("현재 가지고 있는 포켓몬 입니다.");

        for(int i=0;i<curIndex;i++)
        {
            if (Eevees[i] != null)
            {
                Eevees[i].PrintName();
            }
        }
    }

    public void Attack()
    {
        for(int i=0;i<curIndex;i++)
        {
            Console.WriteLine($"{i} : {Eevees[i].Species} ");
        }

        int num = int.Parse(Console.ReadLine());

        if (num >= curIndex)
        {
            Console.WriteLine("올바른 입력이 아닙니다.");
            return;
        }

        CurEevee = Eevees[num];
        CurEevee.Attack();
    }

    public void Skill()
    {
        for (int i = 0; i < curIndex; i++)
        {
            Console.WriteLine($"{i} : {Eevees[i].Species} ");
        }

        int num = int.Parse(Console.ReadLine());

        if (num >= curIndex)
        {
            Console.WriteLine("올바른 입력이 아닙니다.");
            return;
        }

        CurEevee = Eevees[num];
        CurEevee.Skill();
    }

    public 

    // 이브이 관리
    int curIndex = 0;

    Eevee[] Eevees = new Eevee[6];
    Eevee CurEevee;

    // 플레이어 스탯
    string name = "";
}
```
## eevee.cs
```csharp
using System;
using System.Security.Cryptography.X509Certificates;

namespace PM;

public enum EeveeType
{
    Eevee,
    Sylveon,
    Vaporeon,
    Jolteon,
    Umbreon
}

public class Eevee
{
    public Eevee()
    {
        Name = Species;
    }

     public virtual string Species { get; } = "Eevee";
     public virtual string Name { get; set; }

    public virtual void PrintName() { Console.WriteLine(Species); }
    public virtual void Attack() { Console.WriteLine($"{Name} : {Level * Power} 데미지로 공격"); }

    public virtual void Skill() { Console.WriteLine($"몸통 박치기"); }

    public int Level { get; set; } = 1;
    public int Power { get; set; } = 10;
};

public class Sylveon : Eevee
{
    public Sylveon()
    {
    }

    public override void Skill(){ Console.WriteLine($"문포스"); }
    public override string Species => "Sylveon";
}

public class Vaporeon : Eevee
{
    public Vaporeon()
    {
    }

    public override void Skill() { Console.WriteLine($"하이드로 펌프"); }
    public override string Species => "Vaporeon";
}

public class Jolteon : Eevee
{
    public Jolteon()
    {
    }

    public override void Skill() { Console.WriteLine($"전자포"); }
    public override string Species => "Jolteon";
}

public class Umbreon : Eevee
{
    public Umbreon()
    {
    }

    public override void Skill() { Console.WriteLine($"사이코 키네시스"); }
    public override string Species => "Umbreon";
}
```
## 과제 2. 출력결과 판단하기 1

