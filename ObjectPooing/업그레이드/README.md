# 기존의 오브젝트 풀링 

```C#
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

# 단점 
```C#
public GameObject GetObject(int index)
```
  아이템을 생성할 때 index로 생성하기 때문에 해당 index가 무슨 아이템을 생성하는지 외우고 있어야한다는 단점이 있다.
  
  그래서 이러한 방식을 개선하고자 했다.

# 개선한 오브젝트 풀링 
```C#
public class Pooling : MonoBehaviourPun {
    public static Pooling instance;                     // 싱글톤 생성

    public GameObject[] prefabs;                        // 생성될 오브젝트 
    private Dictionary<string, List<GameObject>> pools; // 오브젝트를 찾을 딕셔너리 생성

    void Awake()
    {
        // 싱글톤 생성 
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        // pools 초기화 
        pools = new Dictionary<string, List<GameObject>>();
        foreach (GameObject prefab in prefabs) {
            pools[prefab.name] = new List<GameObject>();
        }
    }

    public GameObject GetObject(string key, Vector3 pos)
    {
        // 딕셔너리에 key가 있는지 확인 없으면 return;
        if (!pools.ContainsKey(key)) {
            return null;
        }

        GameObject select = null;

        // 아이템 생성 
        foreach (GameObject obj in pools[key]) {
            if (obj != null && !obj.activeSelf) {
                // 생성된 오브젝트 반환
                select = obj;
                // 오브젝트 생성 
                select.gameObject.SetActive(true);
                    
                break;
            }
        }

        // 새로운 오브젝트 생성
        if (select == null) {
            GameObject prefab = null;
            foreach (GameObject p in prefabs) {
                if (p.name == key) {
                    prefab = p;
                    break;
                }
            }

            if (prefab == null) return null;

            // 새로운 아이템 프리팹 생성 
            select = Instantiate(prefab, Vector3.zero, Quaternion.identity);

            // 풀에 아이템 추가 
            pools[key].Add(select);
        }

        return select;
    }
}
```

# 개선된 점 
    
    
## 오브젝트 저장 변경  
    
```C#
private Dictionary<string, List<GameObject>> pools; // 오브젝트를 찾을 딕셔너리 생성
```
기존에는 단순 배열에만 저장하였지만 바꾸면서 오브젝트 이름을 키값으로 생성될 오브젝트와 맵핑

이렇게 하므로 index의 값을 외우고 있지 않아도 오브젝트의 이름으로 아이템을 생성할 수 있었다. 


## 검색 방식의 변경 
    
```C#
public GameObject GetObject(string key, Vector3 pos)
```
기존에는 indx로 찾았던 것을 Key값으로 찾는 방식으로 변경

또한 초기의 오브젝트 생성 위치를 주어 원하는 위치에 바로 생성이 가능하게 하였다. 


