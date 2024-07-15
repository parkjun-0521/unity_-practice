using UnityEngine;

public abstract class MonoSingleton3<T> : MonoBehaviour where T : MonoSingleton3<T> {
    private static T _Instance = null;
    public static T Instance {
        get {
            if (_Instance == null) {
                _Instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (_Instance == null) {
                    _Instance = new GameObject("Singleton_" + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                    
                    Debug.Log(2);
                    DontDestroyOnLoad(_Instance);
                }
            }
            return _Instance;
        }
    }

    public static T IsExist() {
        if (_Instance)
            return _Instance;

        return null;
    }
    protected virtual void Awake() {
        if (_Instance == null) {
            _Instance = this as T;
            Debug.Log(1);
            _Instance.Init();
        }
    }

    protected virtual void OnDestroy() {
        if (_Instance != null) {
            _Instance.Clear();
            _Instance = null;
        }
    }

    private void OnApplicationQuit() {
        _Instance = null;
    }

    public virtual void Init() { }
    public virtual void Clear() { }
    public virtual void Test() { }
}
