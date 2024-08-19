# 2D 슈팅 게임 

  - 강의를 보고 만들어본 2D 슈팅게임 입니다.
  - 슈팅게임에 필요한 기능을 구현하였습니다.
  - 유니티의 기초를 다지기 위해 만든 프로젝트입니다. 

## 알게된 점 

  ### 공격의 딜레이 
  - 버튼을 눌러서 공격을 할 경우에 필수적으로 필요한것이 공격 딜레이다.
  - 이를 설정해주지 않으면 무한으로 딜레이 없이 공격을 하는 상황이 발생하기 때문에 막아줘야 한다.
  - 이번 프로젝트에서는 Time.deltaTime 을 지속적으로 더해주고 공격을 할 시 0으로 초기화 하는 방법을 사용하였다.
    - 이외에도 Time.time 을 사용하여 공격을 하면 Time.time에 특정 딜레이 시간을 더해주면서 딜레이를 구현하는 방법이 있다. 

  ### 오브젝트 풀링 
  - 2D 에서 가장 중요한 최적화 방법으로 알고있다. 
  - 수많은 오브젝트를 생성, 삭제를 반복을 하면 메모리에 많은 부하가 생기게 되고 이것이 게임을 느리게 만든다. 
  - 위 문제를 해결하기 위해 오브젝트 풀링이라는 기술을 사용하여 최적화를 하게 된다.
  - 오브젝트 풀링이란?
    - 오브젝트를 미리 메모리에 할당을 해두고 오브젝트를 껐다, 켰다만 반복하여 메모리를 최적화 한다.
  - 오브젝트 풀링을 사용하게 되면 가비지컬렉터가 처리해야하는 양도 줄어들기 때문에 메모리 관리에 매우 효율적이다.  

  ### 보스 구현 
  - 보스의 패턴 동작 구현방식이 대하여 알게되었다.
  - 보스는 Invoke() 함수를 사용하여 무한 루프로 동작하는 방식이다.
  - Think() 라는 함수에 패턴을 실행하고 해당 패턴은 실행후 다시 Think() 함수를 호출하여 패턴을 생각한다.
  - 위 방식으로 여러 패턴을 랜덤으로 사용하며 지속적으로 패턴을 실행하는 보스를 구현할 수 있다. 

## 구현 기능 

  ### 게임 시작
    
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/2D_%20Shooting_game/Image/play.PNG" alt="Image Error" width="30%" height="30%" />
  
  - 플레이 씬
    - 플레이어 이동을 InputManager를 사용하여 구현
    - 몬스터의 드랍테이블 구현
    - 보스 몬스터의 패턴 구현
    - 적의 등장은 텍스트 파일을 이용하여 특정 스폰 포인트에서 등장
      ```C#
      void ReadSpawnFile()
      {
          // 변수 초기화 
          spawnList.Clear();
          spawnIndex = 0;
          spawnEnd = false;
  
          // 파일 열기  
          TextAsset textFile = Resources.Load("Stage 0") as TextAsset;
          StringReader stringReader = new StringReader(textFile.text);
  
          while (stringReader != null) {
              string line = stringReader.ReadLine();
  
              Debug.Log(line);
  
              if (line == null)
                  break;
  
              // 파일 읽어 오기 
              Spawn spawnData = new Spawn();   // 스폰의 구조체 가져오기  
              spawnData.delay = float.Parse(line.Split(',')[0]);   //Parse 형변환    Split() 괄호안에 내가 메모장에서 구분 주었던 문자를 넣어주면 됨 
              spawnData.type = line.Split(',')[1];
              spawnData.point = int.Parse(line.Split(',')[2]);
  
              spawnList.Add(spawnData);
          }
  
          // 파일 닫기 
          stringReader.Close();
  
          //nextSpawnDelay = spawnList[0].delay;
      }
      ```

  ### 아이템 사용 
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/2D_%20Shooting_game/Image/boom.PNG" alt="Image Error" width="30%" height="30%" />

  - InputManager를 사용하여 아이템 동작 구현 
  - Enemy의 관련된 태그의 오브젝트를 모두 비활성화하여 무적을 구현
  - 아이템 및 적은 모두 오브젝트 풀링에서 생성하여 메모리를 관리하였다 
   
  ### 게임 오버
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/2D_%20Shooting_game/Image/dead.PNG" alt="Image Error" width="30%" height="30%" />

  - 게임 오버 시 TimeScale을 0으로 하여 시간을 정지
  - reStart 버튼을 이용하여 현재의 씬을 다시 불러와 게임 재개 
