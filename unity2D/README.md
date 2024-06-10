## 2D Platformer Game

  - 유니티를 입문하면서 만들어본 플랫포머 게임
  - 점프와 이동으로만 구현된 게임

## 알게된 점 

  ### InmputManager 
  - 유니티의 가장 기초
  - 프로젝트의 대한 입력 관련 행동을 정의하는 것
  - Edit -> ProjectSettings 에서 InputManager를 선택하여 여러 입력 옵션을 확인할 수 있다. 
    
  ### Collider
  - 유니티 물리 충돌
  - 물리 충돌을 하기 위해서는 반드시 Rigidbody 와 Collider 컴포넌트를 가지고 있어야 물리 충돌이 동작한다.
  - Collider에는 Box 뿐만이 아닌 Circle, Polygon, Capsule 등 다양한 Collider가 존재한다. 
    - UnityDocumentation 참고 : https://docs.unity3d.com/kr/2021.3/Manual/class-CapsuleCollider2D.html
  
  - 물리충돌은 Collision 충돌 이외에도 isTrigger를 활성화 하여 Trigger 충돌도 할 수 있다.
    - Collision 과 isTrigger의 차이점   
      OnTriggerEnter2D:
      - 이 메소드는 두 객체 중 하나라도 'Trigger' 속성을 가진 Collider2D가 다른 Collider2D와 겹쳤을 때 호출된다. 
      - OnTriggerEnter2D는 실제 물리적 충돌을 계산하지 않기 때문에 객체들이 서로를 통과할 수 있다는 단점이 있다. 단, 그렇기에 내부적으로 연산량이 줄어든다.
      - 그렇기 때문에 주로 비물리적 상호작용이나 특정 영역 감지를 위해 사용된다.

      OnCollisionEnter2D:      
      - 이 메소드는 두 객체의 Collider2D가 서로 접촉하고, 둘 다 'Trigger' 속성이 비활성화된 상태일 때 호출된다.
      - OnCollisionEnter2D는 물리적 충돌을 처리하고 충돌에 따른 반응을 계산한다. Trigger 보다 연산이 복잡하다.
      - 그렇기 때문에 물리적 충돌과 그에 따른 반응을 처리하기 위해 사용된다.\
     
  ### Physics Material (2D)
  - 유니티에서 Collder의 재질을 지정해 줄 수 있는 Material 이다.
  - 2D 에서는 마찰력과 반발력을 설정해줄 수 있다.

  - Friction ( 마찰력 )
    - 해당 값을 0으로 만들면 마찰력이 아에 없는 오브젝트로 만들 수 있다. 값이 높을 수록 해당 오브젝트의 마찰력이 높아진다.
   
  - Bounciness ( 반발력 )
    - 객체가 부딪쳤을 떄 튕겨나가는 정도를 말한다. 값이 높을 수록 많이 튕겨져 나가게 된다. 
     
  ### 2D 이미지 편집 
  - 2D에서 이미지를 사용하려면 이미지 형식이 Sprite(2D) 형식으로 되어있어야 사용할 수 있다.
  - 이미지 슬라이스를 사용하여 이미지를 잘라서 원하는 크기로 사용할 수 있다.
  - 이미지 슬라이스를 사용하여 Collider의 크기도 원하는 크기로 자를 수 있다. 

## 게임 내부 기능 

<img src="https://github.com/parkjun-0521/unity_-practice/blob/main/unity2D/PlatFormer.PNG" alt="Image Error" width="50%" height="50%" />
  
  - 캐릭터 이동 및 점프
    - 캐릭터의 이동 및 점프를 InputManager를 사용하여 간단하게 구현
    - 애니메이션 Parameter bool값으로 하여 애니메이션 전환 구현 
  
  - 몬스터 AI
    - 몬스터는 일정 시간 좌, 우로 이동을 결정한다. 따라서 랜덤으로 좌, 우로 이동을 함
    - 정면 앞쪽으로 Ray를 아래방향으로 쏴서 땅에 닿았는지 아닌지를 판단하여 낭떨어지를 판단하고 방향 전환 
  
  - 몬스터 피격 처리
    - 캐릭터의 Y 좌표가 몬스터의 Y 좌표보다 높을 시 밟았다고 판단하여 몬스터가 죽게된다. 
    - 이때 Collider를 끄고 위쪽으로 힘을 주며 Color의 alpha 값을 낮춰 죽은거 같은 애니메이션을 만들어주었다.
    - 캐릭터가 몬스터와 피격시 같은 원리로 넉백을 구현하였다. 
  
  - 씬 전환 
