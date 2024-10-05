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
            select = Instantiate(prefab, pos, Quaternion.identity);

            // 풀에 아이템 추가 
            pools[key].Add(select);
        }

        return select;
    }
}
