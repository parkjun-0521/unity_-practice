# 2D 슈팅 게임 

  - 강의를 보고 간단하게 만들어본 2D 슈팅게임 입니다.
  - 슈팅게임에 필요한 기능만 구현하였습니다. 

## 구현 기능 

  ### 게임 시작
    
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/2D_%20Shooting_game/Image/play.PNG" alt="Image Error" width="30%" height="30%" />
  
  - 플레이 하면 가장 먼저 등장하는 씬입니다.
  - 플레이어의 이동은 키보드로 이동할 수 있도록 설계했습니다.
  - 플레이어 공격은 마우스 좌클릭으로 구현하였습니다. 
  - 적의 등장은 텍스트 파일을 이용하여 등장하도록 설계하였습니다.
  - 보스 몬스터는 랜덤 4개의 패턴을 사용할 수 있습니다.
  - 몬스터는 사망할 경우 확률에 따라 아이템을 드랍하도록 하였습니다. 

  ### 아이템 사용 
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/2D_%20Shooting_game/Image/boom.PNG" alt="Image Error" width="30%" height="30%" />

  - 마우스 우클릭을 사용하여 아이템을 사용하는 경우입니다
  - 필드 전체에 큰 데미지를 줍니다.
  - 사용시 플레이어가 무적이 되도록 설계하였습니다. 

  ### 게임 오버
  <img src="https://github.com/parkjun-0521/unity_-practice/blob/main/2D_%20Shooting_game/Image/dead.PNG" alt="Image Error" width="30%" height="30%" />

  - 게임 오버시 모든 시간을 정지 시킵니다.
  - reStart 버튼을 이용하여 게임을 다시 시작할 수 있습니다. 
