# Object Pooling

  <p align="left" >
    <img src = "https://github.com/parkjun-0521/unity_-practice/assets/103255864/56d9c327-01ae-449b-8109-c4a6be897686">
  </p>
  
## Object Pooling 이란 

  - 게임 오브젝트를 필요한 만큼 미리 생성해 두고 풀에 쌓아두는 기법이다. 

  - 오브젝트의 생성 파괴를 반복하는 것이 아닌 생성 반환 방식으로 기존에 생성된 오브젝트를 재사용하는 기법이다. 

## Object Pooling 왜 사용하는가
  
  - Object Pooling 기법을 사용하면 매번 오브젝트를 생성하고 파괴하지 않기 때문에 메모리 사용량과 성능 저하를 줄일 수 있다. 

  - 또한 유니티에서는 메모리 해제를 하면 가비지 컬렉터가 발생하는데, 많은 오브젝트를 파괴할수록 많은 가비지 컬렉터가 발생하게 되면서 
  
    CPU의 큰 부담이 발생하게 되는데 Object Pooling 를 사용하게 되면 생성 파괴의 빈도가 현저히 줄어들기때문에 CPU의 부담이 줄어든다.

## 구현 
  ```ruby
    public class Pooling : MonoBehaviour
  {
      public GameObject[] prefabs;
      List<GameObject>[] pools;
  
      void Awake()
      {
          pools = new List<GameObject>[prefabs.Length];
          for(int index = 0; index < prefabs.Length; index++) {
              pools[index] = new List<GameObject>();
          }
      }
  
      public GameObject GetObject(int index)
      {
          GameObject select = null;
          foreach(GameObject objects in pools[index]){
              if (!objects.activeSelf) {
                  select = objects;
                  objects.SetActive(true);
                  break;
              }
          }
          if (!select) {
              select = Instantiate(prefabs[index], transform);
              pools[index].Add(select);
          }
          return select;
      }
  }
```
## 코드 분석
  - List를 사용하여 구현하였습니다. 
  ```ruby
  void Awake()
  {
    pools = new List<GameObject>[prefabs.Length];
    for(int index = 0; index < prefabs.Length; index++) {
      pools[index] = new List<GameObject>();
    }
  }
  ```
  - Awake() 에서 생성되었을 때 Pool을 초기화 해줍니다.

  ```ruby
  foreach(GameObject objects in pools[index]){
    if (!objects.activeSelf) {
      select = objects;
      objects.SetActive(true);
      break;
    }
  }
  ```
  - index 값에 맞는 Pool 안의 오브젝트를 찾아 objects 변수에 저장 후 
  - Pool 안의 비활성화 된 오브젝트를 찾아
  - 비활성화 된 오브젝트에 Pool이 찾은 오브젝트를 대입하고 활성화 해줍니다.
  - 이후 return sleelct로 값을 반환하여 오브젝트를 생성합니다. 

  ```ruby
  if (!select) {
    select = Instantiate(prefabs[index], transform);
    pools[index].Add(select);
  }
  ```
  - 만약 위에서 오브젝트를 찾지 못했을 경우 ( Pool 안의 모든 오브젝트가 사용중 일때 )
  - 새로운 오브젝트를 생성하여 Pool에 추가합니다. ( Pool의 크기 증가 )
  - 이후 return sleelct로 값을 반환하여 오브젝트를 생성합니다. 
