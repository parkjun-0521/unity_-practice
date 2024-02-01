# 수박 게임
  
  - 수박 게임을 모작으로 만들어 봤습니다.
  - 서로 같은 동글이끼리 합치면서 큰 동글이를 계속 만들어 점수를 높혀가는 게임입니다.

## 시연 영상
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/PhysicsBasedGame/image/PhysicsBasedGame-SampleScene-Windows_-Mac_-Linux-Unity-2021.3.gif" alt="Image Error" width="50%" height="50%" />

## 기능 구현 

  ### 게임 시작 
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/PhysicsBasedGame/image/start.PNG" alt="Image Error" width="20%" height="10%" />

  - 게임 시작 버튼을 눌러 게임을 시작할 수 있습니다.
  - 게임 시작을 하면 BGM 음악이 나옵니다. 

  ### 플레이 
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/PhysicsBasedGame/image/play.PNG" alt="Image Error" width="20%" height="10%" />

  - 동글이가 생성되는 위치입니다.
  - 동글이는 2초 간격으로 생성됩니다.
  - 동글이의 생성은 오브젝트 풀링으로 구현하였습니다. 

  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/PhysicsBasedGame/image/play2.PNG" alt="Image Error" width="20%" height="10%" />
  
  - 동글이가 합쳐지는 과정입니다. 
  - 합쳐질 때 파티클 이벤트가 발생하고 효과음이 나옵니다.
  - 효과음은 채널링으로 구현하여 여러개가 합쳐져도 소리가 각각 나오게됩니다. 

  ### 게임 오버 
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/PhysicsBasedGame/image/dead.PNG" alt="Image Error" width="20%" height="10%" />

  - 동글이가 라인에 2초 이상 닿았을 경우 빨간색으로 색을 변경하여 위험 경고를 보여줍니다. 

  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/PhysicsBasedGame/image/gameover.PNG" alt="Image Error" width="20%" height="10%" />

  - 동글이가 라인에 4초이상 닿았을 경우 게임이 종료 됩니다.
  - 모든 오브젝트를 비활성화 하고 종료 UI를 활성화 시킵니다. 
  - 재시작 버튼에 현재 점수를 알려줍니다.
  - 현재 점수가 최고 점수보다 높을 시 최고점수를 바꿔줍니다.
  - PlayerPrefs 를 사용하여 최고 점수를 저장합니다. 
  
