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
