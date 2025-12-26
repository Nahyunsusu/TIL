# namespace

개발은 혼자서도 할 수 있지만 주로 팀원들과 함께 진행하게 된다. 그러면 어떤 부분을 맞아서 개발을 하다보면 똑같은 이름의 함수이지만 다른 역활을 할 때가 있을 수도 있다. 그럴 때를 위하여 namespace로 구역을 제한하여 별명을 붙여주면 이름이 같은 두 함수 모두 이용할 수 있다. 다음은 그 예시이다.

**Player.cs**
```csharp
using System;

namespace Player
{
    public class Controller
    {
        public void Move()
        {
            Console.WriteLine("Player Move");
        }

        public void Attack()
        {
            Console.WriteLine("Player Attack");
        }
    }

}
```
**Monster.cs**
```csharp
using System;

namespace Monster
{
    public class Controller
    {
        public void Move()
        {
            Console.WriteLine("Monster Move");
        }

        public void Attack()
        {
            Console.WriteLine("Monster Attack");
        }
    }

}
```
위 두 예시는 이름이 같은 함수를 보여준다. 이 함수를 사용하려고 하면 어느 클래스의 함수인지 모호할 수가 있기 때문에 namespace를 지정하여 별명을 붙인다. 그리고 그 별명을 사용한다는 의미로 **using '별명'**을 추가해준다.
```csharp
using System;
using Player;
using Monster;

public class Solution
{
    public static void Main(string[] args)
    {
         Player.Controller  PlayerController = new  Player.Controller();
        Monster.Controller MonsterController = new Monster.Controller();

         PlayerController.Move();
        MonsterController.Move();
    }
}
```
함수를 사용하려할 떄 변수를 확실히 입력해줌으로써 모호함이 사라지고 어떤 함수를 써야할지 확실하게 알 수 있다.