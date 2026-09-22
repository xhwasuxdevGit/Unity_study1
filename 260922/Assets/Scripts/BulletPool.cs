using UnityEngine;  
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour  
{  
    [SerializeField] private GameObject _bulletPrefab;  
    [SerializeField] private int _poolSize = 8;

    private ObjectPool<GameObject> _bullets;

    public static BulletPool Instance { get; private set; }

    private void Awake()  
    {  
        SetSingleton();  
    }

    private void Start()  
    {  
        CreatePool();  
    }

    public GameObject Take()  
    {  
        return _bullets.Get();  
    }

    public void Return(GameObject bullet)  
    {  
        _bullets.Release(bullet);  
    }

    private void SetSingleton()  
    {  
        if (Instance != null && Instance != this)  
        {  
            Destroy(gameObject);  
            return;  
        }

        Instance = this;  
    }

    private void CreatePool()  
    {  
        _bullets = new ObjectPool<GameObject>(  
            CreateBullet,  
            bullet => bullet.SetActive(true),  
            bullet => bullet.SetActive(false),  
            bullet => Destroy(bullet),  
            true,  
            _poolSize,  
            _poolSize);  
    }

    private GameObject CreateBullet()  
    {  
        return Instantiate(_bulletPrefab);  
    }  
}